using Microsoft.AspNetCore.Mvc;
using shahzaib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.IO;
using Microsoft.AspNetCore.Hosting;
namespace shahzaib.Controllers
{
    public class ResumeController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        //for profile Uploading 
        private readonly IWebHostEnvironment webHost;

        public ResumeController(ApplicationDbContext applicationDbContext , IWebHostEnvironment webHost)
        {
            this.applicationDbContext = applicationDbContext;
            this.webHost = webHost;
        }
        public IActionResult Index()
        {
            List<Applicant> applicants = applicationDbContext.Applicants.ToList();
            return View(applicants);
        }
        public IActionResult Create()
        {
            Applicant applicant = new Applicant();
            applicant.Experiences.Add(new Experience() { ExperienceId = 1 });
            //applicant.Experiences.Add(new Experience() { ExperienceId = 2 });
            //applicant.Experiences.Add(new Experience() { ExperienceId = 3 });



            return View(applicant);
        }

        [HttpPost]
        public IActionResult Create(Applicant applicant)
        {
            string uniqueFileName = GetUploadedFileName(applicant);
            applicant.PhotoUrl = uniqueFileName;

            applicationDbContext.Add(applicant);
            applicationDbContext.SaveChanges();
            return RedirectToAction("index");
        }
        //method to upload an image
        private string GetUploadedFileName(Applicant applicant)
        {
            string uniqueFileName = null;
            if (applicant.ProfilePhoto != null)
            {
                string uploadsFolder = Path.Combine(webHost.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + applicant.ProfilePhoto.FileName;
                string filepath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filepath , FileMode.Create))
                {
                    applicant.ProfilePhoto.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
