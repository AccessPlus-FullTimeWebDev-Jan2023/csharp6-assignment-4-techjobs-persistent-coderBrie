using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobs6Persistent.Controllers
{
    public class SkillController : Controller
    {
        private JobDbContext context;

        public SkillController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Skill> skills = context.Skills.ToList();
            return View(skills);
        }

        [HttpGet]
        public IActionResult Add()
        {
            Skill skill = new Skill();
            return View(skill);
        }

        [HttpPost]
        public IActionResult Add(Skill skill)
        {
            if (ModelState.IsValid)
            {
                context.Skills.Add(skill);
                context.SaveChanges();

                return Redirect("/Skill/");
            }

            return View("Add", skill);
        }

        [HttpGet]
        public IActionResult AddJob(int id)
        {
            Job theJob = context.Jobs.Find(id);
            List<Skill> possibleSkills = context.Skills.ToList();

            AddSkillViewModel addSkillViewModel = new AddSkillViewModel(theJob, possibleSkills);

            return View(addSkillViewModel);
        }

        [HttpPost]
        public IActionResult AddJob(AddSkillViewModel addSkillViewModel)
        {
            if (ModelState.IsValid)
            {
                int jobId = addSkillViewModel.JobId;
                int skillId = addSkillViewModel.SkillId;

                Job theJob = context.Jobs.Include(s => s.Skills).Where(j => j.Id == jobId).First();
                Skill theSkill = context.Skills.Where(s => s.Id == skillId).First();

                theJob.Skills.Add(theSkill);

                context.SaveChanges();

                return Redirect("/Job/Detail/" + jobId);
            }

            return View(addSkillViewModel);
        }

        public IActionResult Detail(int id)
        {
            Skill theSkill = context.Skills.Include(j => j.Jobs).Where(s => s.Id == id).First();

            return View(theSkill);
        }
    }
}

