using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.ViewModels
{
	public class AddJobViewModel
	{
        [Required(ErrorMessage = "Job name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Employer is required")]
        [Display(Name = "Employer")]
        public int EmployerId { get; set; }

        public List<SelectListItem> Employers { get; set; }



        public AddJobViewModel()
		{
            Employers = new List<SelectListItem>();

        }

        public AddJobViewModel(List<Employer> employers) : this()
        {
            foreach (var employer in employers)
            {
                Employers.Add(new SelectListItem
                {
                    Value = employer.Id.ToString(),
                    Text = employer.Name
                });
            }
        }
    }
}


