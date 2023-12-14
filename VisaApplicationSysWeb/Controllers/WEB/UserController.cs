using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VisaApplicationSysWeb.Data;
using VisaApplicationSysWeb.Models;
using Newtonsoft.Json;

namespace VisaApplicationSysWeb.Controllers.WEB
{
    public class UserController : Controller
    {
        private readonly VisaDBContext dBContext;

        public UserController(VisaDBContext dbContext)
        {
            dBContext = dbContext;
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
                        TempData["SuccessMessage"] = "Registration successful Please Login!";
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
                            TempData["SuccessMessage"] = "Registration successful Please Login!";
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
        public async Task<IActionResult> Profile()
        {
            try
            {
                var visaTypes = await GetVisaTypesAsync();

                ViewBag.VisaTypes = new SelectList(visaTypes, "Value", "Text");

                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return View();
            }
        }

        public async Task<List<VisaType>> GetVisaTypesAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5166/api/UserAPI/");

                var response = await client.GetAsync("GetVisaTypes"); // Adjust the API endpoint accordingly

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<VisaType>>(responseData);
                }
                else
                {
                    // Log the error instead of writing to the console
                    Console.WriteLine($"Failed to retrieve Visa Types. Status Code: {response.StatusCode}");
                    return new List<VisaType>();
                }
            }
        }
    }
}

