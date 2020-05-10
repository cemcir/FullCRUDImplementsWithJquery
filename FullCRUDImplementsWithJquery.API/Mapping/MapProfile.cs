using AutoMapper;
using FullCRUDImplementationWithJquery.API.Models;
using FullCRUDImplementationWithJquery.API.Models.Resource;
using FullCRUDImplementationWithJquery.API.Models.Response;
using FullCRUDImplementationWithJquery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullCRUDImplementationWithJquery.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Student, StudentResource>();
            CreateMap<StudentResource,Student>();

            CreateMap<Department,DepartmentResource>();
            CreateMap<DepartmentResource, Department>();

            CreateMap<Student, StudentResponse>();
            CreateMap<StudentResponse, Student>();

            CreateMap<Department,DepartmentResponse>();
            CreateMap<DepartmentResponse,Department>();
        }
    }
}
