using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sample.SiteA.Model.ViewModels
{
    public class ViewRenderingPostViewModel : IRenderingModel
    {

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Address is required")]
        [RegularExpression("^[\\w!#$%&\'*+\\-/=?\\^_`{|}~]+(\\.[\\w!#$%&\'*+\\-/=?\\^_`{|}~]+)*@((([\\-\\w]+\\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\\.){3}[0-9]{1,3}))$", ErrorMessage = "Email Address is not valid")]
        public string Email { get; set; }

        public Rendering Rendering { get; set; }
        public Item Item { get; set; }
        public Item PageItem { get; set; }


        public void Initialize(Rendering rendering)
        {
            Rendering = rendering;
            Item = rendering.Item;
            PageItem = PageContext.Current.Item;

            //Potentially pre-load contact information from Tracker.Current.Contact
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
           
            //Logic to load pick list.            
        }
    }
}
