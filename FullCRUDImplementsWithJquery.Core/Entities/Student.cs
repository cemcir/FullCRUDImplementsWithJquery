using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FullCRUDImplementationWithJquery.Core.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public string StudentNo { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
