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

            ViewBag.selectedVisaType = 1;
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
                    model.PassportPhotoPath = await SaveFile(PassportPhotoPath);
                }

                if (ResumePath != null && ResumePath.Length > 0)
                {
                    model.ResumePath = await SaveFile(ResumePath);
                }

                if (TestCardPath != null && TestCardPath.Length > 0)
                {
                    model.TestCardPath = await SaveFile(TestCardPath);
                }

                if (HighestEducationLevelMarkSheetPath != null && HighestEducationLevelMarkSheetPath.Length > 0)
                {
                    model.HighestEducationLevelMarkSheetPath = await SaveFile(HighestEducationLevelMarkSheetPath);
                }

                if (Passportpath != null && Passportpath.Length > 0)
                {
                    model.Passportpath = await SaveFile(Passportpath);
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5166/api/ApplyVisaAPI/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var jsonModel = JsonConvert.SerializeObject(model);
                    var content = new StringContent(jsonModel, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("Student", content);

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

        private async Task<string> SaveFile(IFormFile file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(_environment.WebRootPath, "Student", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return filePath;
        }

        [HttpPost]
        public async Task<IActionResult> Tourist(TouristVisaForm model, int visaTypeId, [FromForm] IFormFile PassportPhotoPath, [FromForm] IFormFile TravelItineraryPath, [FromForm] IFormFile HotelReservationPath, [FromForm] IFormFile Passportpath)
        {

            var applicantId = model.ApplicantId;
            var applicantname = model.FullName;
            var applicantEmail = model.Email;

            var visaStatus = new VisaStatusModel
            {
                ApplicantId = applicantId,
                VisaType = "Tourist",
                Status = "Pending",
                Email = applicantEmail,
                FullName = applicantname

            };

            _dbContext.tblVisaStatus.Add(visaStatus);
            await _dbContext.SaveChangesAsync();


            if (PassportPhotoPath != null && PassportPhotoPath.Length > 0)
            {

                var fileName = Path.GetFileName(PassportPhotoPath.FileName);
                var filePath = Path.Combine(_environment.WebRootPath, "Tourist", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    PassportPhotoPath.CopyTo(fileStream);
                }

                model.PassportPhotoPath = filePath;
            }
            if (TravelItineraryPath != null && TravelItineraryPath.Length > 0)
            {

                var fileName = Path.GetFileName(TravelItineraryPath.FileName);
                var filePath = Path.Combine(_environment.WebRootPath, "Tourist", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    TravelItineraryPath.CopyTo(fileStream);
                }

                model.TravelItineraryPath = filePath;
            }
            if (HotelReservationPath != null && HotelReservationPath.Length > 0)
            {

                var fileName = Path.GetFileName(HotelReservationPath.FileName);
                var filePath = Path.Combine(_environment.WebRootPath, "Tourist", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    HotelReservationPath.CopyTo(fileStream);
                }

                model.HotelReservationPath = filePath;
            }

            if (Passportpath != null && Passportpath.Length > 0)
            {

                var fileName = Path.GetFileName(Passportpath.FileName);
                var filePath = Path.Combine(_environment.WebRootPath, "Tourist", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Passportpath.CopyTo(fileStream);
                }

                model.Passportpath = filePath;
            }


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5166/api/ApplyVisaAPI/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonModel = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonModel, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("Tourist", content);
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

            var applicantId = model.ApplicantId;
            var applicantname = model.FullName;
            var applicantEmail = model.Email;

            var visaStatus = new VisaStatusModel
            {
                ApplicantId = applicantId,
                VisaType = "Employment",
                Status = "Pending",
                Email = applicantEmail,
                FullName = applicantname

            };

            _dbContext.tblVisaStatus.Add(visaStatus);
            await _dbContext.SaveChangesAsync();


            if (PassportPhotoPath != null && PassportPhotoPath.Length > 0)
            {

                var fileName = Path.GetFileName(PassportPhotoPath.FileName);
                var filePath = Path.Combine(_environment.WebRootPath, "Employment", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    PassportPhotoPath.CopyTo(fileStream);
                }

                model.PassportPhotoPath = filePath;
            }
            if (EmploymentContractPath != null && EmploymentContractPath.Length > 0)
            {

                var fileName = Path.GetFileName(EmploymentContractPath.FileName);
                var filePath = Path.Combine(_environment.WebRootPath, "Employment", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    EmploymentContractPath.CopyTo(fileStream);
                }

                model.EmploymentContractPath = filePath;
            }
            if (ResumePath != null && ResumePath.Length > 0)
            {

                var fileName = Path.GetFileName(ResumePath.FileName);
                var filePath = Path.Combine(_environment.WebRootPath, "Employment", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    ResumePath.CopyTo(fileStream);
                }

                model.ResumePath = filePath;
            }

            if (Passportpath != null && Passportpath.Length > 0)
            {

                var fileName = Path.GetFileName(Passportpath.FileName);
                var filePath = Path.Combine(_environment.WebRootPath, "Employment", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Passportpath.CopyTo(fileStream);
                }

                model.Passportpath = filePath;
            }



            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5166/api/ApplyVisaAPI/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonModel = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonModel, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("Employment", content);
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
            var applicantId = model.ApplicantId;
            var applicantname = model.FullName;
            var applicantEmail = model.Email;

            var visaStatus = new VisaStatusModel
            {
                ApplicantId = applicantId,
                VisaType = "Business",
                Status = "Pending",
                Email = applicantEmail,
                FullName = applicantname

            };

            _dbContext.tblVisaStatus.Add(visaStatus);
            await _dbContext.SaveChangesAsync();


            if (PassportPhotoPath != null && PassportPhotoPath.Length > 0)
            {

                var fileName = Path.GetFileName(PassportPhotoPath.FileName);
                var filePath = Path.Combine(_environment.WebRootPath, "Business", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    PassportPhotoPath.CopyTo(fileStream);
                }

                model.PassportPhotoPath = filePath;
            }
           
          

            if (Passportpath != null && Passportpath.Length > 0)
            {

                var fileName = Path.GetFileName(Passportpath.FileName);
                var filePath = Path.Combine(_environment.WebRootPath, "Business", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Passportpath.CopyTo(fileStream);
                }

                model.Passportpath = filePath;
            }


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5166/api/ApplyVisaAPI/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonModel = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonModel, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("Employment", content);
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
