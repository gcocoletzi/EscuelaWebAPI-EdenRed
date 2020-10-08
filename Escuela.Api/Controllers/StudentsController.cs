using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Context;
using Escuela.Api.Managers;
using Escuela.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Escuela.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentManager _studentManager;

        public StudentsController(SchoolDbContext context)
        {
            _studentManager = new StudentManager(context);
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<Student>), StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateStudentAsync(Student student, CancellationToken token)
        {
            try
            {
                await _studentManager.InsertStudent(student, token);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Student>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Student>>>GetStudentsAsync(CancellationToken token)
        {
            try
            {
                var students = await _studentManager.GetAllStudents(token);

                if (students.Count == 0)
                {
                    return NotFound();
                }
                return students;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
