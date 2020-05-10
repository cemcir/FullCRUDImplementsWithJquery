using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FullCRUDImplementationWithJquery.API.Models;
using FullCRUDImplementationWithJquery.API.Models.Resource;
using FullCRUDImplementationWithJquery.API.Models.Response;
using FullCRUDImplementationWithJquery.Core.Models;
using FullCRUDImplementationWithJquery.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullCRUDImplementationWithJquery.API.Controllers
{
    [Route("Departments")]
    [ApiController]
    [Authorize]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService departmentService;
        private readonly IMapper mapper;

        public DepartmentsController(IMapper mapper,IDepartmentService departmentService) {
            this.mapper = mapper;
            this.departmentService = departmentService;
        }

        [HttpPost("AddDepartment")]
        public IActionResult AddDepartment(DepartmentResource departmentResource) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            else {
                var resp = this.departmentService.FindByDepartmentName(departmentResource.DepartmentName);
                if (resp.Success) {
                    Department department = mapper.Map<DepartmentResource, Department>(departmentResource);
                    var response = this.departmentService.Add(department);
                    if (response.Success) {
                        //DepartmentModel model = mapper.Map<Department, DepartmentModel>(response.Extra);
                        return NoContent();
                    }
                    return BadRequest(response.ErrorMessageCode);
                }
                return BadRequest(resp.ErrorMessageCode);
            }
        }
        
        [HttpGet("GetDepartmentList")]
        public IActionResult GetDepartmentList() {
            var response = this.departmentService.GetAll();
            if (response.Success) {
                //IEnumerable<DepartmentModel> departmentModels = mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentModel>>(response.Extra);

                return Ok(mapper.Map<IEnumerable<DepartmentResource>>(response.Extra));
            }
            return BadRequest(response.ErrorMessageCode);
        }

        [HttpGet("GetDepartmentByName")]
        public IActionResult GetDepartmentByName(string name)
        {
            var response = this.departmentService.GetByDepartmentName(name);
            if (response.Success) {
                return Ok(mapper.Map<List<DepartmentResource>>(response.Extra));
            }
            return BadRequest(response.ErrorMessageCode); 
        }

        [HttpPost("GetById")]
        public IActionResult GetById(IdentityResource identityResource)
        {
            var response = this.departmentService.GetById(identityResource.IdentityKey);
            if (response.Success) {
                return Ok(mapper.Map<DepartmentResource>(response.Extra));
            }
            return BadRequest(response.ErrorMessageCode);
        }

        [HttpPost("GetByDepartmentId")]
        public IActionResult GetByDepartmentId(IdentityResource identityResource)
        {
            var response = this.departmentService.GetByDepartmentId(identityResource.IdentityKey);
            if (response.Success) {
                return Ok(mapper.Map<DepartmentResponse>(response.Extra));
            }
            return BadRequest(response.ErrorMessageCode);
        }

        [HttpPut("UpdateDepartment")]
        public IActionResult UpdateDepartment(DepartmentResource departmentResource) { 
            Department department = mapper.Map<Department>(departmentResource);
            var response = this.departmentService.UpdateDepartment(department);
            if (response.Success) {
                return NoContent();
            }
            return BadRequest(response.ErrorMessageCode);
        }

        [HttpDelete("DeleteDepartment")]
        public IActionResult DeleteDepartment(IdentityResource identityResource)
        {
            var resp = this.departmentService.GetById(identityResource.IdentityKey);
            if (resp.Success) {
                var response = this.departmentService.Remove(resp.Extra);
                return NoContent();
            }
            return BadRequest(resp.ErrorMessageCode);
        }
    }
}