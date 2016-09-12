using Sitecore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Foundation.SitecoreExtensions.Attributes;
using System.Web.Mvc;
using Sample.SiteA.Model.ViewModels;
using Sitecore.Links;
using Sitecore.Mvc.Configuration;

namespace Sample.SiteA.Controllers
{
    public class SamplePostController:SitecoreController
    {
        /// <summary>
        /// Following method demonstrates a simplefied View Rendering Post
        /// For further reading see: https://mhwelander.net/2014/05/28/posting-forms-in-sitecore-mvc-part-1-view-renderings/
        /// 
        /// The ValidateFromHandler attribute performs a checks to confirm the the web submitted form's controller and action properly correspond
        /// to this action and therefore should be processed.
        /// 
        /// </summary>
        /// <param name="queryParameter"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateFormHandler]        
        public ActionResult PostFromViewRendering(ViewRenderingPostViewModel pageModelInformation)
        {
            //Check Server Side Model Validation
            if (!ModelState.IsValid)
            {                
                return base.Index();
            }

            try
            {
                //Perform logic
            }
            catch(Exception ex)
            {
                //I have found it helpful to add error messages with a unique key, so message show approriately depending on the form submitted.
                ModelState.AddModelError("Error Key Unique to this Call", "Message for the user that something happened");
            }

            //Return to same page
            return base.Index();

            //OR redirect to a new page, this build the URL from Link Manager you can just enter a non-domain URL.
            var options = new UrlOptions
            {
                AddAspxExtension = false,
                LanguageEmbedding = LanguageEmbedding.Never
            };

            var pathInfo = LinkManager.GetItemUrl(Sitecore.Context.Item.Children.FirstOrDefault(), options);

            return RedirectToRoute(MvcSettings.SitecoreRouteName, new { pathInfo = pathInfo.TrimStart(new char[] { '/' }) });
        }

        /// <summary>
        /// https://mhwelander.net/2014/05/30/posting-forms-in-sitecore-mvc-part-2-controller-renderings/
        /// https://mhwelander.net/2014/04/09/sitecore-controller-rendering-action-results-what-can-i-return/
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateFormHandler]
        public ActionResult PostFromControllerRendering(ControllerRenderingPostViewModel pageModelInformation)
        {
            //Perform actions saving the information
            int errorCode = 0;
            //Due to when a control rendering is processed it is not recommended to post directly back to the same page
            //The post should redirect to a new page or use the redirect to reload the entire page
            //In cases a redirect to the current page is triggered with information, use query parameters to display/take actions during the get


            if (errorCode > 0)
            {
                return Redirect("/samples/postviacontrolspage?error="+errorCode);
            }
            else
            {
                return Redirect("/samples/controlsucess");
            }

        }
    }
}
