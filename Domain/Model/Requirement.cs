using AusTest.Domain.Model.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AusTest.Domain.Model
{
    public class Requirement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public AusTestUser User { get; set; }
    }
}
