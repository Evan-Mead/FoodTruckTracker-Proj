using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodTruckTracker.ActionFilters
{
    public class GlobalRouting : IActionFilter
    {
        private readonly ClaimsPrincipal _claimsPrincipal;
        public GlobalRouting(ClaimsPrincipal claimsPrincipal)
        {
            _claimsPrincipal = claimsPrincipal;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"];
            if (controller.Equals("Home"))
            {
                if (_claimsPrincipal.IsInRole("Food Truck"))
                {
                    context.Result = new RedirectToActionResult("Index", "Food Truck", null);
                }
                else if (_claimsPrincipal.IsInRole("Foodie"))
                {
                    context.Result = new RedirectToActionResult("Index", "Foodie", null);
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
