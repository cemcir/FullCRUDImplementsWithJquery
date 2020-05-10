using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullCRUDImplementationWithJquery.API.Models.Resource
{
    public class LoginResource
    {
        [Required]
        [StringLength(11)]
        public string UserName { get; set; }

        [Required]
        [StringLength(8)]
        public string Password { get; set; }
    }
}
