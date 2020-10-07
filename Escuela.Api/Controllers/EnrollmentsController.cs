using System;
using System.Collections.Generic;
using System.Linq;
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
    public class EnrollmentsController : ControllerBase
    {
        private EnrollmentManager _enrollmentManager;

        public EnrollmentsController(SchoolDbContext context)
        {
            _enrollmentManager = new EnrollmentManager(context);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Professor>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Enrollment>>> GetProfessorsAsync(CancellationToken token)
        {
            try
            {
                var enrollments = await _enrollmentManager.GetAllEnrollments(token);

                if (enrollments.Count == 0)
                {
                    return NotFound();
                }
                return enrollments;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
