using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PumpItUp.Models
{
    public class IndexModel(ILogger<IndexModel> logger) : PageModel
    {
        public void OnGet()
        {
            try
            {
                logger.LogInformation("Test log");
            }catch (Exception ex)
            {
                logger.LogError(message: ex.Message, ex);
                throw;
            }
        }
    }
}