using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullCRUDImplementationWithJquery.API.Models.Resource
{
    public class StudentResource
    {
        public int Id { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public string StudentNo { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}
