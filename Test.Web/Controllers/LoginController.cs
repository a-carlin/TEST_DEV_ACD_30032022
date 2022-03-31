using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test.Web.Models;
using System;
using Microsoft.Extensions.Options;

namespace Test.Web.Controllers
{
    public class LoginController : BaseController
    {
        private IHttpContextAccessor _httpContextAccessor;
        public LoginController(IHttpContextAccessor httpContextAccessor,
            IOptions<AppSettings> appSettings) :base(appSettings)
        {
            _httpContextAccessor = httpContextAccessor;

        }
        public IActionResult Login()
        {
            Usuario usuario = new Usuario();    
            return View(usuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (usuario.Correo == null || usuario.Correo.Equals("") ||
                usuario.Contrasena == null || usuario.Contrasena.Equals(""))
                {
                    ModelState.AddModelError("", "");
                }
                else
                {
                    Usuario usuarioModel = new Usuario();

                    using (var httpClient = new HttpClient())
                    {
                        StringContent content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
                        using (var response = await httpClient.PostAsync(UrlBase + $"/api/Auth", content))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            usuarioModel = JsonConvert.DeserializeObject<Usuario>(apiResponse);
                        }
                    }
                    if (usuarioModel != null)
                    {
                        _httpContextAccessor.HttpContext.Response.Cookies.Append("test",
                           usuarioModel.Nombre + " " + usuarioModel.ApellidoPaterno, new CookieOptions()
                           {
                               Expires = DateTime.Now.AddDays(7),
                               IsEssential = true
                           });

                        return RedirectToAction("Index", "PersonasFisicas");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuario o contraseña no válidos");
                    }
                }
            }
            return View();
        }
        public ActionResult LogOff()
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("test");
            return RedirectToAction("Login", "Login");

        }
    }
}
