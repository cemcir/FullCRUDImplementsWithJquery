using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullCRUDImplementationWithJquery.API.Models.Resource
{
    public class DepartmentResource
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartmentName { get; set; }
    }
}
