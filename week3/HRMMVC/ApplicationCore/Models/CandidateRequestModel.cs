using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMMVC.Models
{
    public class CandidateRequestModel
    {
        // [somgeting] is called data annotation
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }


        // Required attribute is used to specify that the property is required
        [Required]
        // Here set the column type to varchar(100) of Email property
        [Column(TypeName = "varchar(100)")]
        public string? Email { get; set; }

        // Here set the column type to varchar(1000) of ResumeURL property
        [Column(TypeName = "varchar(1000)")]
        public string? ResumeURL { get; set; }
    }
}

