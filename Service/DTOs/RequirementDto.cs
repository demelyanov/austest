using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AusTest.Service.DTOs
{
    public class RequirementDto
    {
        public int Id { get; set; }
        [Required]//(ErrorMessage ="Requirement Name is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
