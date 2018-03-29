using Capstone.Web.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Models
{
    public class SurveyModel
    {
        public string ParkName { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string StateOfResidence { get; set; }
        public string ActivityLevel { get; set; }

        public List<SelectListItem> PossibleStateOfResidence = new List<SelectListItem>()
        {
            new SelectListItem { Value = "AL", Text = "Alabama" },
                    new SelectListItem { Value = "AK", Text = "Alaska" },
                    new SelectListItem { Value = "AZ", Text = "Arizona" },
                    new SelectListItem { Value = "AR", Text = "Arkansas" },
                    new SelectListItem { Value = "CA", Text = "California" },
                    new SelectListItem { Value = "CO", Text = "Colorado" },
                    new SelectListItem { Value = "CT", Text = "Connecticut" },
                    new SelectListItem { Value = "DE", Text = "Delaware" },
                    new SelectListItem { Value = "FL", Text = "Florida" },
                    new SelectListItem { Value = "GA", Text = "Georgia" },
                    new SelectListItem { Value = "HI", Text = "Hawaii" },
                    new SelectListItem { Value = "ID", Text = "Idaho" },
                    new SelectListItem { Value = "IL", Text = "Illinois" },
                    new SelectListItem { Value = "IN", Text = "Indiana" },
                    new SelectListItem { Value = "IA", Text = "Iowa" },
                    new SelectListItem { Value = "KS", Text = "Kansas" },
                    new SelectListItem { Value = "KY", Text = "Kentucky" },
                    new SelectListItem { Value = "LA", Text = "Louisiana" },
                    new SelectListItem { Value = "ME", Text = "Maine" },
                    new SelectListItem { Value = "MD", Text = "Maryland" },
                    new SelectListItem { Value = "MA", Text = "Massachusetts" },
                    new SelectListItem { Value = "MI", Text = "Michigan" },
                    new SelectListItem { Value = "MN", Text = "Minnesota" },
                    new SelectListItem { Value = "MS", Text = "Mississippi" },
                    new SelectListItem { Value = "MO", Text = "Missouri" },
                    new SelectListItem { Value = "MT", Text = "Montana" },
                    new SelectListItem { Value = "NC", Text = "North Carolina" },
                    new SelectListItem { Value = "ND", Text = "North Dakota" },
                    new SelectListItem { Value = "NE", Text = "Nebraska" },
                    new SelectListItem { Value = "NV", Text = "Nevada" },
                    new SelectListItem { Value = "NH", Text = "New Hampshire" },
                    new SelectListItem { Value = "NJ", Text = "New Jersey" },
                    new SelectListItem { Value = "NM", Text = "New Mexico" },
                    new SelectListItem { Value = "NY", Text = "New York" },
                    new SelectListItem { Value = "OH", Text = "Ohio" },
                    new SelectListItem { Value = "OK", Text = "Oklahoma" },
                    new SelectListItem { Value = "OR", Text = "Oregon" },
                    new SelectListItem { Value = "PA", Text = "Pennsylvania" },
                    new SelectListItem { Value = "RI", Text = "Rhode Island" },
                    new SelectListItem { Value = "SC", Text = "South Carolina" },
                    new SelectListItem { Value = "SD", Text = "South Dakota" },
                    new SelectListItem { Value = "TN", Text = "Tennessee" },
                    new SelectListItem { Value = "TX", Text = "Texas" },
                    new SelectListItem { Value = "UT", Text = "Utah" },
                    new SelectListItem { Value = "VT", Text = "Vermont" },
                    new SelectListItem { Value = "VA", Text = "Virginia" },
                    new SelectListItem { Value = "WA", Text = "Washington" },
                    new SelectListItem { Value = "WV", Text = "West Virginia" },
                    new SelectListItem { Value = "WI", Text = "Wisconsin" },
                    new SelectListItem { Value = "WY", Text = "Wyoming" }
        };

        public List<SelectListItem> PossibleActivityLevel = new List<SelectListItem>()
        {
           (new SelectListItem() { Text = "Inactive", Value = "Inactive"}),
           (new SelectListItem() { Text = "Sedentary", Value = "Sedentary"}),
           (new SelectListItem() { Text = "Active", Value = "Active"}),
           (new SelectListItem() { Text = "Extremely-Active", Value = "Extremely-Active"})
        };

        public List<SelectListItem> PossibleParks = new List<SelectListItem>()
        {
           (new SelectListItem() { Text = "Cuyahoga Valley National Park", Value = "Cuyahoga Valley National Park"}),
           (new SelectListItem() { Text = "Everglades National Park", Value = "Everglades National Park"}),
           (new SelectListItem() { Text = "Grand Canyon National Park", Value = "Grand Canyon National Park"}),
           (new SelectListItem() { Text = "Glacier National Park", Value = "Glacier National Park"}),
           (new SelectListItem() { Text = "Great Smoky Mountains National Park", Value = "Great Smoky Mountains National Park"}),
           (new SelectListItem() { Text = "Grand Teton National Park", Value = "Grand Teton National Park"}),
           (new SelectListItem() { Text = "Mount Rainier National Park", Value = "Mount Rainier National Park"}),
           (new SelectListItem() { Text = "Rocky Mountain National Park", Value = "Rocky Mountain National Park"}),
           (new SelectListItem() { Text = "Yellowstone National Park", Value = "Yellowstone National Park"}),
           (new SelectListItem() { Text = "Yosemite National Park", Value = "Yosemite National Park"}),
        };
    }
}