using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using VisaApplicationSysWeb.Data;
using VisaApplicationSysWeb.Models;

namespace VisaApplicationSysWeb.Controllers.WEB
{
    public class ApplyVisaController : Controller
    {
        private readonly VisaDBContext _dbContext;
        private readonly IWebHostEnvironment _environment;


        public ApplyVisaController(VisaDBContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Student()
        {
           
            return View();
        }

        [HttpGet]
        public IActionResult Tourist()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Employement()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Business()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Student(StudentVisaForm model, int visaTypeId, [FromForm] IFormFile PassportPhotoPath, [FromForm] IFormFile ResumePath, [FromForm] IFormFile TestCardPath, [FromForm] IFormFile HighestEducationLevelMarkSheetPath, [FromForm] IFormFile Passportpath)
        {
            try
            {
                if (PassportPhotoPath != null && PassportPhotoPath.Length > 0)
                {
                    model.PassportPhotoPath = await SaveFile(PassportPhotoPath,"Student");
                }

                if (ResumePath != null && ResumePath.Length > 0)
                {
                    model.ResumePath = await SaveFile(ResumePath,"Student");
                }

                if (TestCardPath != null && TestCardPath.Length > 0)
                {
                    model.TestCardPath = await SaveFile(TestCardPath, "Student");
                }

                if (HighestEducationLevelMarkSheetPath != null && HighestEducationLevelMarkSheetPath.Length > 0)
                {
                    model.HighestEducationLevelMarkSheetPath = await SaveFile(HighestEducationLevelMarkSheetPath, "Student");
                }

                if (Passportpath != null && Passportpath.Length > 0)
                {
                    model.Passportpath = await SaveFile(Passportpath , "Student");
                }

                using (var client = new HttpClient())
                {
                  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var jsonModel = JsonConvert.SerializeObject(model);
                    var content = new StringContent(jsonModel, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("http://localhost:5166/api/ApplyVisaAPI/PostStudent", content);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["SuccessMessage"] = "Visa Applied Successfully";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, $"API request failed with status code {response.StatusCode}. {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
            }

            return View(model);
        }

        private async Task<string> SaveFile(IFormFile file, string Foldername)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(_environment.WebRootPath, Foldername, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return filePath;
        }

        [HttpPost]
        public async Task<IActionResult> Tourist(TouristVisaForm model, int visaTypeId, [FromForm] IFormFile PassportPhotoPath, [FromForm] IFormFile TravelItineraryPath, [FromForm] IFormFile HotelReservationPath, [FromForm] IFormFile Passportpath)
        {

            if (PassportPhotoPath != null && PassportPhotoPath.Length > 0)
            {
                model.PassportPhotoPath = await SaveFile(PassportPhotoPath, "Tourist");
            }

            if (TravelItineraryPath != null && TravelItineraryPath.Length > 0)
            {
                model.TravelItineraryPath = await SaveFile(TravelItineraryPath, "Tourist");
            }

            if (HotelReservationPath != null && HotelReservationPath.Length > 0)
            {
                model.HotelReservationPath = await SaveFile(HotelReservationPath, "Tourist");
            }

            if (Passportpath != null && Passportpath.Length > 0)
            {
                model.Passportpath = await SaveFile(Passportpath, "Tourist");
            }


            using (var client = new HttpClient())
            {
               
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonModel = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonModel, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://localhost:5166/api/ApplyVisaAPI/PostTourist", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Profile Created Successfully. Please Login!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"API request failed with status code {response.StatusCode}. {response.ReasonPhrase}");
                }
            }


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Employment(EmploymentVisaForm model, int visaTypeId, [FromForm] IFormFile PassportPhotoPath, [FromForm] IFormFile EmploymentContractPath, [FromForm] IFormFile ResumePath, [FromForm] IFormFile Passportpath)
        {

            if (PassportPhotoPath != null && PassportPhotoPath.Length > 0)
            {
                model.PassportPhotoPath = await SaveFile(PassportPhotoPath, "Employment");
            }

            if (EmploymentContractPath != null && EmploymentContractPath.Length > 0)
            {
                model.EmploymentContractPath = await SaveFile(EmploymentContractPath, "Employment");
            }

            if (ResumePath != null && ResumePath.Length > 0)
            {
                model.ResumePath = await SaveFile(ResumePath, "Employment");
            }

            if (Passportpath != null && Passportpath.Length > 0)
            {
                model.Passportpath = await SaveFile(Passportpath, "Employment");
            }

            using (var client = new HttpClient())
            {
               
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonModel = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonModel, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://localhost:5166/api/ApplyVisaAPI/PostEmployment", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Profile Created Successfully. Please Login!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"API request failed with status code {response.StatusCode}. {response.ReasonPhrase}");
                }
            }


            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Business(BusinessVisaForm model, int visaTypeId, [FromForm] IFormFile PassportPhotoPath, [FromForm] IFormFile Passportpath)
        {
            if (PassportPhotoPath != null && PassportPhotoPath.Length > 0)
            {
                model.PassportPhotoPath = await SaveFile(PassportPhotoPath, "Business");
            }

            if (Passportpath != null && Passportpath.Length > 0)
            {
                model.Passportpath = await SaveFile(Passportpath, "Business");
            }
            using (var client = new HttpClient())
            {
               
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonModel = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonModel, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://localhost:5166/api/ApplyVisaAPI/PostBusiness", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Profile Created Successfully. Please Login!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"API request failed with status code {response.StatusCode}. {response.ReasonPhrase}");
                }
            }
            return View(model);
        }

    }
}
