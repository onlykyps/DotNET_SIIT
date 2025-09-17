using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using FilmTicketApp.Controllers;

namespace FilmTicketApp.Attributes
{
    public class AdminAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;
            
            // Check if user is authenticated
            if (!AccountController.IsAuthenticated(httpContext))
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }
            
            // Check if user is admin
            if (!AccountController.IsAdmin(httpContext))
            {
                context.Result = new RedirectToActionResult("Forbidden", "Account", null);
                return;
            }
            
            base.OnActionExecuting(context);
        }
    }
}