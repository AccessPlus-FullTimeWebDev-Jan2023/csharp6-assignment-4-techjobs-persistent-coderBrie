using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.ViewModels
{
    public class AddSkillViewModel
    {
        public int JobId { get; set; }
        public Job? Job { get; set; }

        public List<SelectListItem>? Skills { get; set; }

        public int SkillId { get; set; }

        public AddSkillViewModel(Job theJob, List<Skill> possibleSkills)
        {
            Skills = new List<SelectListItem>();

            foreach (var skill in possibleSkills)
            {
                Skills.Add(new SelectListItem
                {
                    Value = skill.Id.ToString(),
                    Text = skill.SkillName
                });
            }

            Job = theJob;
        }

        public AddSkillViewModel() { }
    }
}

