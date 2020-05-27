using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.May2020.Core.Models
{
    public class Applicant:BaseEntity
    {
        public Applicant() { }
        public Applicant(string applicantName) { Name = applicantName; }
        public string Name { get; set; }
    }
}
