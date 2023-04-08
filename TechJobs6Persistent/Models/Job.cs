using System;
using Microsoft.Extensions.Logging;

namespace TechJobs6Persistent.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Employer Employer { get; set; }
        public int EmployerId { get; set; }

        public ICollection<Skill>? Skills { get; set; }

        public Job(string name)
        {
            Name = name;
            Skills = new List<Skill>();
        }

        public Job()
        {
        }
    }
}

