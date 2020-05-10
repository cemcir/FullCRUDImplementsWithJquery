using FullCRUDImplementationWithJquery.API.Models.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullCRUDImplementationWithJquery.API.Models.Response
{
    public class StudentResponse:StudentResource
    {
        public DepartmentResource Department { get; set; }
    }
}
