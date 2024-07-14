using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAndAPI.Razor.Services;

namespace WebAndAPI.Razor.Pages
{
    public class BasePageModel : PageModel
    {
        public bool IsFail => Errors.Any();

        public List<string> Errors { get; private set; } = new();

        public bool HasError<T>(ServiceResult<T> result)
        {
            if (!result.IsFailure) return false;


            foreach (var resultError in result.Errors!)
            {
                Errors.Add(resultError);
            }

            return true;
        }

        public bool HasError(ServiceResult result)
        {
            if (!result.IsFailure) return false;


            foreach (var resultError in result.Errors!)
            {
                Errors.Add(resultError);
            }

            return true;
        }
    }
}