using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class JobCategory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(128, ErrorMessage = "Max 128 characters")]
        public string Name { get; set; } = "";
        public List<JobRequirement> JobRequirements { get; set; }
    }
}

