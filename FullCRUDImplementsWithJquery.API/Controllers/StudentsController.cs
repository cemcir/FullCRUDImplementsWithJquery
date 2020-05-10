using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FullCRUDImplementationWithJquery.API.Extensions;
using FullCRUDImplementationWithJquery.API.Models.Resource;
using FullCRUDImplementationWithJquery.API.Models.Response;
using FullCRUDImplementationWithJquery.Core.ErrorMessage;
using FullCRUDImplementationWithJquery.Core.Models;
using FullCRUDImplementationWithJquery.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullCRUDImplementationWithJquery.API.Controllers
{
    [Route("Students")]
    [ApiController]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;

        public StudentsController(IStudentService studentService,IMapper mapper)
        {
            this.studentService = studentService;
            this.mapper = mapper;
        }

        [HttpGet("GetStudentList")]
        public IActionResult GetStudentList()
        {
            var response = this.studentService.GetStudentList();
            if (response.Success) {
                return Ok(mapper.Map<List<StudentResponse>>(response.Extra));
            }
            return BadRequest(response.ErrorMessageCode);
        }

        [HttpGet("GetByStudentId")]
        public IActionResult GetByStudentId(int id)
        {
            var resp = this.studentService.GetByStudentId(id);
            if (resp.Success) {
                return Ok(mapper.Map<StudentResponse>(resp.Extra));
            }
            return BadRequest(resp.ErrorMessageCode);
        }

        [HttpGet("GetByStudentName")]
        public IActionResult GetByStudentName(string name)
        {
            var response = this.studentService.GetByStudentName(name);
            if (response.Success) {
                //return Ok(response.Extra);
                return Ok(mapper.Map<IEnumerable<StudentResponse>>(response.Extra));
            }
            return BadRequest(response.ErrorMessageCode);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(IdentityResource identityResource)
        {
            var response = this.studentService.GetById(identityResource.IdentityKey);
            if (response.Success) {
                return Ok(mapper.Map<StudentResource>(response.Extra));
            }
            return BadRequest(response.ErrorMessageCode);
        }

        [HttpPost("AddStudent")]
        public IActionResult AddStudent(StudentResource studentResource) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else {
                var response = this.studentService.SingleOrDefault(s => s.StudentNo == studentResource.StudentNo);
                if (response.Success) {
                    return BadRequest(new ErrorMessageCode().AlreadyExistEntity);
                }
                else {
                    Student student = mapper.Map<StudentResource, Student>(studentResource);
                    /*
                    var resp = this.studentService.AddStudent(student);
                    if (resp.Success) {
                        return NoContent();
                    }
                    
                    return BadRequest(resp.ErrorMessageCode);
                    */  
                    var resp = this.studentService.Add(student);
                    if (resp.Success) {
                        return NoContent();
                    }
                    return BadRequest(resp.ErrorMessageCode);                   
                }
            }
        }

        [HttpPut("UpdateStudent")]
        public IActionResult UpdateStudent(StudentResource studentResource)
        {
            Student student = mapper.Map<StudentResource,Student>(studentResource);
            if (!ModelState.IsValid) {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else {
                /*
                var response = this.studentService.Remove(student);
                if (response.Success) {
                    student.Id = 0;
                    var stu = this.studentService.Add(student);
                    if (stu.Success) {
                        return NoContent();
                    }
                    return BadRequest(stu.ErrorMessageCode);
                }
                return BadRequest(response.ErrorMessageCode);
                */
                
                var response = this.studentService.UpdateStudent(student);
                if (response.Success) {
                    return NoContent();
                }
                return BadRequest(response.ErrorMessageCode);
                
            }
        }

        [HttpDelete("DeleteStudent")]
        public IActionResult DeleteStudent(IdentityResource identityResource) {
            var response = this.studentService.GetById(identityResource.IdentityKey);
            if (response.Success) {
                var resp = this.studentService.Remove(response.Extra);
                if (resp.Success) {
                    return NoContent();
                }
                return BadRequest(resp.ErrorMessageCode);
            }
            return BadRequest(response.ErrorMessageCode);
        }
    }
}