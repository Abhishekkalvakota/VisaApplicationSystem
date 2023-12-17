﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using VisaApplicationSysWeb.Data;
using VisaApplicationSysWeb.Models;

namespace VisaApplicationSysWeb.Controllers.WEB
{
    public class UserController : Controller
    {
        private readonly VisaDBContext _dbContext;
        private readonly IWebHostEnvironment _environment;

       

        public UserController(VisaDBContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
          
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegisterRequestModel model)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5166/api/UserAPI/");

                    var response = await client.PostAsJsonAsync("Registration", model);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["SuccessMessage"] = "Registration Successful Please Login!";
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, $"API request failed with status code {response.StatusCode}. {response.ReasonPhrase}");
                    }
                }


                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {

            string successMessage = TempData["SuccessMessage"] as string;
            ViewBag.SuccessMessage = successMessage;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:5166/api/UserAPI/");

                        var response = await client.PostAsJsonAsync("Login", model);

                        if (response.IsSuccessStatusCode)
                        {
                            TempData["SuccessMessage"] = "Welcome back! You have successfully logged in.";


                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, $"API request failed with status code {response.StatusCode}. {response.ReasonPhrase}");
                        }
                    }
                }
                var error = ModelState.GetEnumerator();

                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return View(model);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Profile(int applicantId, int visaTypeId)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var apiUrl = $"http://localhost:5166/api/UserAPI/Getapplicantdata?parameter1={applicantId}&parameter2={visaTypeId}";

                    var response = await httpClient.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<ApplicantProfile>>(content);
                    return View(data);
                }
            }
            catch (HttpRequestException ex)
            {
                return View("Profile", $"Error during HTTP request: {ex.Message}");
            }
            catch (JsonException ex)
            {
                
                return View("Profile", $"Error during JSON deserialization: {ex.Message}");
            }
            catch (Exception ex)
            {
                return View("Profile", $"An unexpected error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetEmploymentFile(string documentPath)
        {
            
            string fileName = Path.GetFileName(documentPath);

            if (System.IO.File.Exists(documentPath))
            {
                return PhysicalFile(documentPath, "application/octet-stream", fileName);
            }
            else
            {
                
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditProfile(int applicantId, int visaTypeId, ApplicantProfile model,[FromForm] IFormFile NewPassportFile,[FromForm] IFormFile NewEmploymentContractFile,[FromForm] IFormFile NewResumeFile,[FromForm] IFormFile NewTestCardFile,[FromForm] IFormFile NewTravelItineraryFile,[FromForm] IFormFile NewHotelReservationFile)
        {
            try
            {
                
                model.PassportFilePath = HandleFileUpdate(NewPassportFile, model.PassportFilePath);
                model.EmploymentContractPath = HandleFileUpdate(NewEmploymentContractFile, model.EmploymentContractPath);
                model.ResumePath = HandleFileUpdate(NewResumeFile, model.ResumePath);
                model.TestCardPath = HandleFileUpdate(NewTestCardFile, model.TestCardPath);
                model.TravelItineraryPath = HandleFileUpdate(NewTravelItineraryFile, model.TravelItineraryPath);
                model.HotelReservationPath = HandleFileUpdate(NewHotelReservationFile, model.HotelReservationPath);

                using (var httpClient = new HttpClient())
                {
                    var apiUrl = $"http://localhost:5166/api/UserAPI/UpdateApplicantData?applicantId={applicantId}&visaTypeId={visaTypeId}";

                    var jsonContent = JsonConvert.SerializeObject(model);
                    var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                  
                    var response = await httpClient.PutAsync(apiUrl, httpContent);
                    response.EnsureSuccessStatusCode();

                  
                    return RedirectToAction("Index","Home");
                }
            }
            catch (HttpRequestException ex)
            {
                return View("EditProfile", $"Error during HTTP request: {ex.Message}");
            }
            catch (JsonException ex)
            {
                return View("EditProfile", $"Error during JSON serialization: {ex.Message}");
            }
            catch (Exception ex)
            {
                return View("EditProfile", $"An unexpected error occurred: {ex.Message}");
            }
        }

        private string HandleFileUpdate(IFormFile newFile, string currentFilePath)
        {
            string updatedFilePath = currentFilePath;

           
            if (newFile != null && newFile.Length > 0)
            {
                
                if (!string.IsNullOrEmpty(currentFilePath) && System.IO.File.Exists(currentFilePath))
                {
                    System.IO.File.Delete(currentFilePath);
                }
                var newFileName = Path.GetFileName(newFile.FileName);
                var newFilePath = Path.Combine(_environment.WebRootPath, "Employment", newFileName);

                using (var fileStream = new FileStream(newFilePath, FileMode.Create))
                {
                    newFile.CopyTo(fileStream);
                }
                updatedFilePath = newFilePath;
            }

            return updatedFilePath;
        }

        public IActionResult GetApplicantData()
        {
            var applicants = _dbContext.tblApplicant.ToList();

            int applicantId = 0;

            int visatypeid = 0;

            foreach (var applicant in applicants)
            {
                if (applicant.IsVisaApplied)
                {
                    applicantId = applicant.ApplicantID;
                    visatypeid = applicant.VisaTypeId;
                    break;
                }
            }

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var apiUrl = $"http://localhost:5166/api/UserAPI/GetApplicantData?applicantId={applicantId}&visaTypeId={visatypeid}";

                    var response = httpClient.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var content = response.Content.ReadAsStringAsync().Result;

                        var viewModelList = JsonConvert.DeserializeObject<List<ApplicantProfile>>(content);

                        // Assuming you want to display the first item in the list
                        var viewModel = viewModelList.FirstOrDefault();

                        ViewBag.VisaTypeId = visatypeid;
                        return View("Profile", viewModel);
                    }
                    else
                    {
                        return View("ErrorView", $"API request failed with status code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
             
                return View("ErrorView", $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetVisaStatus()
        {
            var applicants = _dbContext.tblApplicant.ToList();

            int applicantId = 0;

            foreach (var applicant in applicants)
            {
                if (applicant.IsVisaApplied)
                {
                    applicantId = applicant.ApplicantID;
                    break;
                }
            }
            using (var httpClient = new HttpClient())
            {
                var apiEndpoint = $"http://localhost:5166/api/UserAPI/GetVisaStatus/{applicantId}";

                try
                {
                    var response = await httpClient.GetAsync(apiEndpoint);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var visaStatusModel = JsonConvert.DeserializeObject<VisaStatusModel>(jsonString);

                        return View(visaStatusModel);
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                catch (HttpRequestException)
                {
                    // Handle HTTP request exception
                    return View("Error");
                }
            }
        }



    }
}

