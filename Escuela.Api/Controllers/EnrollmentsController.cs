using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Context;
using Escuela.Api.Managers;
using Escuela.Api.Models;
using Escuela.Api.Models.InputParameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Escuela.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private IEnrollmentManager _enrollmentManager;

        public EnrollmentsController(SchoolDbContext context)
        {
            _enrollmentManager = new EnrollmentManager(context);
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Enrollment>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Enrollment>>> GetEnrollmentsAsync(
            [FromQuery]EnrollmentInputParameters inputParameters, CancellationToken token)
        {
            try
            {
                var enrollments = await _enrollmentManager.GetEnrollments(inputParameters, token);

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

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Enrollment>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Enrollment>> GetEnrollmentAsync(long id, CancellationToken token)
        {
            try
            {
                var enrollment = await _enrollmentManager.GetSingleEnrollment(id, token);

                if (enrollment == null)
                {
                    return NotFound();
                }
                return enrollment;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Enrollment>> UpdateEnrollmentAsync(
           long id,
           [FromQuery]EnrollmentInputParameters inputParameters,
           [FromBody] Enrollment enrollment,
           CancellationToken cancellationToken)
        {
            try
            {
                return await _enrollmentManager.UpdateEnrollment(enrollment, inputParameters, id, cancellationToken);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

            [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<Enrollment>), StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateProfessorAsync([FromBody]Enrollment enrollment, CancellationToken token)
        {
            try
            {
                await _enrollmentManager.EnrollToCourse(enrollment, token);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


    }
}
