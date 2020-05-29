namespace Hahn.ApplicationProcess.May2020.Core.Models
{
    public class Applicant : BaseEntity
    {

        /// <summary>
        /// The Name of Applicant
        /// </summary>
        /// <example>hello</example>
        public string Name { get; set; }
        /// <summary>
        /// The FamilyName of Applicant
        /// </summary>
        /// <example>ABC</example>

        public string FamilyName { get; set; }
        /// <summary>
        /// The Address of Applicant
        /// </summary>
        /// <example>ABC</example>
        public string Address { get; set; }
        /// <summary>
        /// The CountryOfOrigin of Applicant
        /// </summary>
        /// <example>US</example>
        public string CountryOfOrigin { get; set; }
        /// <summary>
        /// The EmailAddress of Applicant
        /// </summary>
        /// <example>uzair.qq@outlook.com</example>
        public string EmailAddress { get; set; }
        /// <summary>
        /// The Age of Applicant
        /// </summary>
        /// <example>30</example>
        public int Age { get; set; }
        /// <summary>
        /// Hiring
        /// </summary>
        /// <example>false</example>
        public bool Hired { get; set; } = false;
    }
}
