using System;
using System.ComponentModel.DataAnnotations;

namespace TechJobs6Persistent.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string SkillName { get; set; }

        public ICollection<Job>? Jobs { get; set; }

        public Skill(string name)
        {
            SkillName = name;
            Jobs = new List<Job>();
        }

        public Skill()
        {
        }
    }
}

