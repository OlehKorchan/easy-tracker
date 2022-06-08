using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EasyTracker.BLL.Config;
using EasyTracker.BLL.Interfaces;
using EasyTracker.DAL.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EasyTracker.BLL.Services
{
	public class JwtGenerator : IJwtGenerator
	{
		private readonly JwtSettings _settings;
		private readonly SymmetricSecurityKey _key;

		public JwtGenerator(IOptions<JwtSettings> config)
		{
			_settings = config.Value;
			_key = new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes(_settings.TokenKey));
		}

		public string GenerateToken(User user)
		{
			var claims = new List<Claim>
			{
				new(
					JwtRegisteredClaimNames.NameId, user.UserName)
			};

			var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddHours(_settings.ExpiresInHours),
				SigningCredentials = credentials
			};
			var tokenHandler = new JwtSecurityTokenHandler();

			var token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}
	}
}
