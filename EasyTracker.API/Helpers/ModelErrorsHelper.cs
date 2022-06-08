using EasyTracker.API.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EasyTracker.API.Helpers
{
    public static class ModelErrorsHelper
    {
        public static void PutModelStateErrorsToResponseModel<T>(
                ModelStateDictionary modelState,
                T model) where T : ResponseModelBase
        {
            foreach (
                    var modelError in modelState.Values.SelectMany(
                            modelStateEntry => modelStateEntry.Errors))
            {
                model.Errors.Add(modelError.ErrorMessage);
            }
        }
    }
}
