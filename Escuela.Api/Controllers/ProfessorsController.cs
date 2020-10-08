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
    public class ProfessorsController : ControllerBase
    {
        private IProfessorManager _professorManager;

        public ProfessorsController(SchoolDbContext context)
        {
            _professorManager = new ProfessorManager(context);
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<Professor>), StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateProfessorAsync(Professor professor, CancellationToken token)
        {
            try
            {
                await _professorManager.InsertProfessor(professor, token);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Professor>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Professor>>> GetProfessorsAsync(CancellationToken token)
        {
            try
            {
                var professors = await _professorManager.GetAllProfessors(token);

                if (professors.Count == 0)
                {
                    return NotFound();
                }
                return professors;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
