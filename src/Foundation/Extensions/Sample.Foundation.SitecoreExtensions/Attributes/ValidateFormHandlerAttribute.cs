using System.Reflection;
using System.Web.Mvc;

namespace Sample.Foundation.SitecoreExtensions.Attributes
{
    public class ValidateFormHandlerAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            string str1 = controllerContext.HttpContext.Request.Form["fhController"] ?? controllerContext.HttpContext.Request.Form["scController"];
            string str2 = controllerContext.HttpContext.Request.Form["fhAction"] ?? controllerContext.HttpContext.Request.Form["scAction"];
            return !string.IsNullOrWhiteSpace(str1) && !string.IsNullOrWhiteSpace(str2) && str1.ToLowerInvariant().Replace("controller", "") == controllerContext.Controller.GetType().Name.ToLowerInvariant().Replace("controller", "") && methodInfo.Name.ToLowerInvariant() == str2.ToLowerInvariant();
        }
    }
}