using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullCRUDImplementationWithJquery.API.Models.Response
{
    public class UserResponse {

        public int Id { get; set; }

        [Required]
        [StringLength(11)]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
    }
}
