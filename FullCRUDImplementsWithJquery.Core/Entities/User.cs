using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FullCRUDImplementationWithJquery.Core.Entities
{
    public class User {

        public int Id { get; set; }

        [Required]
        [StringLength(11)]
        public string UserName { get; set; }

        [Required]
        [StringLength(8)]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
    }
}
