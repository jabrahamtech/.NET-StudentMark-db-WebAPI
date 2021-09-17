using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using jabr888Q1.Data;
using jabr888Q1.Models;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System;
using System.Net;
using jabr888Q1.DTO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace jabr888Q1.Controllers
{
    [Route("quizapi")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IWebAPIRepo _repository;
        public HomeController(IWebAPIRepo repository)
        {
            _repository = repository;
        }

        //Get: /GetVersion Q0
        [HttpGet("GetVersion")]
        public ContentResult Version()
        {
            return Content("v1");
        }

        //Get: /GetCourseInfo/{course} Q1
        [HttpGet("GetCourseInfo/{course}")]
        public ActionResult<string> Get_Course(string course)
        {
            var path = Directory.GetCurrentDirectory();
            var folder = Path.Combine(path, "templates");
            var fileName = Path.Combine(folder, course + ".html");
            if (System.IO.File.Exists(fileName))
            {
                var fileContent = System.IO.File.ReadAllText(fileName);
                ContentResult j = new ContentResult
                {
                    Content = fileContent,
                    ContentType = "text/html",
                    StatusCode = (int)HttpStatusCode.OK
                };
                return j;
            }
            else
            {
                string fileContent = "There is no course " + course;
                ContentResult j = new ContentResult
                {
                    Content = fileContent,
                    ContentType = "text/html",
                    StatusCode = (int)HttpStatusCode.OK
                };
                return j;
            }
        }

        //Get: /GetMarks Q2
        [HttpGet("GetMarks")]
        public ActionResult<IEnumerable<MarkOutDto>> GetMarks()
        {
            IEnumerable<Marks> Marks = _repository.GetMarks();
            IEnumerable<MarkOutDto> p = Marks.Select(e => new MarkOutDto { Id = e.Id, A1 = e.A1, A2 = e.A2 });
            return Ok(p);
        }

        // Get: /GetMarkByID Q3
        [HttpGet("GetMarkByID/{id}")]
        public IActionResult GetMark(int id)
        {
            Marks Mark = _repository.GetMarkById(id);
            if (Mark == null)
            {
                return Ok("No record for the student with ID number " + id);
            }
            else
            {
                return Ok(Mark);
            }
        }

        //Post: /SetMark Q4
        [HttpPost("SetMark")]
        public ActionResult<MarkInputDto> SetMark(MarkInputDto Mark)
        {
            Marks M = _repository.GetMarkById(Mark.Id);
            IEnumerable<Marks> Marks = _repository.GetMarks();
            if (Marks.Contains(M))
            {
                return Ok(M);
            }
            Marks NewMark = new Marks { Id = Mark.Id, A1 = Mark.A1, A2 = Mark.A2 };
            Marks addedMark = _repository.AddMark(NewMark);
            return Ok(addedMark);
        }

        //Get: Marks Auth Q5
        [Authorize(AuthenticationSchemes = "MyAuthentication")]
        [Authorize(Policy = "UserOnly")]
        [HttpGet("GetMarksAuth")]
        public ActionResult<IEnumerable<MarkOutDto>> GetMarksAuth()
        {
            IEnumerable<Marks> Marks = _repository.GetMarks();
            IEnumerable<MarkOutDto> p = Marks.Select(e => new MarkOutDto { Id = e.Id, A1 = e.A1, A2 = e.A2 });
            return Ok(p);
        }

        //Get: Mark Auth Student&Staff Q6
        [Authorize(AuthenticationSchemes = "MyAuthentication2")]
        [Authorize(Policy = "UserOnly")]
        [HttpGet("GetMarkByIDAuth/{id}")]
        public IActionResult GetMarkAuth(int id)
        {
            Marks Mark = _repository.GetMarkById(id);
            if (Mark == null)
            {
                return Ok("No record for the student with ID number " + id);
            }
            else
            {
                return Ok(Mark);
            }
        }

        //Post: Add Mark Auth Staff Q7
        [Authorize(AuthenticationSchemes = "MyAuthentication")]
        [Authorize(Policy = "UserOnly")]
        [HttpPost("SetMarkAuth")]
        public ActionResult<MarkInputDto> Setmark(MarkInputDto Mark)
        {
            Marks NewMark = new Marks { Id = Mark.Id, A1 = Mark.A1, A2 = Mark.A2 };
            Marks addedMark = _repository.addmark(NewMark);
            return Ok(addedMark);
        }

    }
}
