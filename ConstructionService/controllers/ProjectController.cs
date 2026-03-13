using Microsoft.AspNetCore.Mvc;
using ConstructionService.Models;

namespace ConstructionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        static List<Project> projects = new List<Project>();

        [HttpGet]
        public IActionResult GetProjects()
        {
            return Ok(projects);
        }

        [HttpPost]
        public IActionResult AddProject([FromBody] Project project)
        {
            if(project == null)
            {
                return BadRequest();
            }

            projects.Add(project);

            return Ok(project);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var project = projects.FirstOrDefault(p => p.Id == id);

            if (project == null)
                return NotFound();

            projects.Remove(project);

            return Ok();
        }
    }
}