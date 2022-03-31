using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test.Models;
using Test.Web.Attributes;
using Test.Web.Models;

namespace Test.Web.Controllers
{
    [AuthAttribute]
    public class PersonasFisicasController : BaseController
    {
        public PersonasFisicasController(IOptions<AppSettings> appSettings) : base(appSettings)
        {

        }
        public async Task<IActionResult> Index()
        {
            List<PersonaFisicaViewModel> personasFisicas = new List<PersonaFisicaViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(UrlBase + $"/api/PersonasFisicas"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    personasFisicas = JsonConvert.DeserializeObject<List<PersonaFisicaViewModel>>(apiResponse);
                }
            }
            return View(personasFisicas);
        }
        [HttpGet]
        public async Task<IActionResult> Actualizar(int id)
        {
            PersonaFisicaViewModel personasFisica = new PersonaFisicaViewModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(UrlBase + $"/api/PersonaFisica/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    personasFisica = JsonConvert.DeserializeObject<PersonaFisicaViewModel>(apiResponse);
                }
            }

            if (personasFisica == null)
            {
                Response.StatusCode = 404;
                return View("NotFound", id);
            }

            return View(personasFisica);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Actualizar(PersonaFisicaViewModel personaFisica)
        {
            PersonaFisicaViewModel resPersonasFisica = new PersonaFisicaViewModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(personaFisica), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync(UrlBase + $"/api/PersonaFisica", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    resPersonasFisica = JsonConvert.DeserializeObject<PersonaFisicaViewModel>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Eliminar(int Id)
        {
            PersonaFisicaViewModel resPersonasFisica = new PersonaFisicaViewModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(UrlBase + $"/api/PersonaFisica/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    resPersonasFisica = JsonConvert.DeserializeObject<PersonaFisicaViewModel>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Crear()
        {
            PersonaFisicaViewModel personaFisica = new PersonaFisicaViewModel();
            return View(personaFisica);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(PersonaFisicaViewModel personaFisica)
        {
            PersonaFisicaViewModel resPersonasFisica = new PersonaFisicaViewModel();
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(personaFisica), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync(UrlBase + $"/api/PersonaFisica", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        resPersonasFisica = JsonConvert.DeserializeObject<PersonaFisicaViewModel>(apiResponse);
                    }
                }
            }
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Reporte()
        {
            DataClient clientes = new DataClient();
            using (var httpClient = new HttpClient())
            {
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, UrlApiCustomer)){
                    requestMessage.Headers.Add("Authorization", await GetTokenValue());
                    var response = await httpClient.SendAsync(requestMessage);
                    var contenido = await response.Content.ReadAsStringAsync();
                    clientes = JsonConvert.DeserializeObject<DataClient>(contenido);
                }

            }
            return View(clientes);
        }
        
    }
}
