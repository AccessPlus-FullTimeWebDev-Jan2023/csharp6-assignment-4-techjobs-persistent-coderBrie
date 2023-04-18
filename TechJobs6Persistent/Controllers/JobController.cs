using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobs6Persistent.Controllers
{
    public class JobController : Controller
    {
        private JobDbContext context;

        public JobController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }

        [HttpGet]
        public IActionResult Add()
        {
            // Retrieve list of employers from the dbContext
            List<Employer> employers = context.Employers.ToList();

            // Create a list of SelectListItem to represent the employers in the view
            List<SelectListItem> employerSelectList = employers.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Name
            }).ToList();

            // Create an instance of AddJobViewModel and pass the list of employers as SelectListItem
            AddJobViewModel viewModel = new AddJobViewModel
            {
                Employers = employerSelectList
            };

            // Pass the viewModel instance to the view
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(AddJobViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Create a new Job object and assign properties from the viewModel
                Job newJob = new Job
                {
                    Name = viewModel.Name,
                    Employer = context.Employers.Find(viewModel.EmployerId)
                };

                // Add the new Job to the context and save changes
                context.Jobs.Add(newJob);
                context.SaveChanges();

                // Redirect to the Job Index page
                return RedirectToAction("Index");
            }
            else
            {
                // If the ModelState is not valid, return the view with the viewModel to display errors
                viewModel.Employers = context.Employers.Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.Name
                }).ToList();

                return View(viewModel);
            }
        }





        [HttpPost]
        public IActionResult ProcessAddJobForm(AddJobViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the selected employer object from the database
                Employer employer = context.Employers.Find(viewModel.EmployerId);

                // Create a new job object with the form data and the employer object
                Job newJob = new Job
                {
                    Name = viewModel.Name,
                    Employer = employer
                };

                // Add the new job object to the database and save changes
                context.Jobs.Add(newJob);
                context.SaveChanges();

                // Redirect the user to the job detail page for the new job
                return Redirect($"/Job/Detail/{newJob.Id}");
            }

            // If the form data is not valid, return the Add Job form with validation errors
            viewModel.Employers = context.Employers
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.Name
                }).ToList();
            return View("Add", viewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.jobs = context.Jobs.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] jobIds)
        {
            foreach (int jobId in jobIds)
            {
                Job theJob = context.Jobs.Find(jobId);
                context.Jobs.Remove(theJob);
            }

            context.SaveChanges();

            return Redirect("/Job");
        }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs.Include(j => j.Employer).Include(j => j.Skills).Single(j => j.Id == id);

            JobDetailViewModel jobDetailViewModel = new JobDetailViewModel(theJob);

            return View(jobDetailViewModel);

        }
    }
}

