using System.ComponentModel.DataAnnotations;
using EasyTracker.DAL.Enums;

namespace EasyTracker.API.Models;

public class SalaryCreateRequestModel
{
    [Required(ErrorMessage = "Income amount is required")]
    [Range(
        0d,
        1000000000d,
        ErrorMessage = "Income amount should be in range from 0 to 1 billion"
    )]
    public decimal Amount { get; set; }

    [MaxLength(300, ErrorMessage = "Comment size should be less than 300 symbols")]
    public string Comment { get; set; }

    public CurrencyCode Currency { get; set; }
}
