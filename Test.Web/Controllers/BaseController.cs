using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test.Models;
using Test.Web.Models;

namespace Test.Web.Controllers
{
    public class BaseController : Controller
    {
        //protected string UsernameAPi = "ucand0021";
        //protected string PasswordApi= "yNDVARG80sr@dDPc2yCT!";
        //protected string UrlApiAuth = "https://api.toka.com.mx/candidato/api/login/authenticate";
        //protected string UrlApiCustomer = "https://api.toka.com.mx/candidato/api/customers";
        //protected string UrlBase = "http://localhost:20120";

        public string UsernameAPi;
        public string PasswordApi;
        public string UrlApiAuth;
        public string UrlApiCustomer;
        public string UrlBase;

        public BaseController(IOptions<AppSettings> appSettings)
        {
            this.UrlBase = appSettings.Value.BaseUrl;
            this.UsernameAPi = appSettings.Value.UserAPI;
            this.PasswordApi = appSettings.Value.PasswordAPI;
            this.UrlApiAuth = appSettings.Value.UrlApiAuth;
            this.UrlApiCustomer = appSettings.Value.UrlApiCustomer;

        }
        protected async Task<string> GetTokenValue()
        {
            DataToken token = new DataToken();
            AccesoDatosApi accesApi = new AccesoDatosApi();
            accesApi.Username = UsernameAPi;
            accesApi.Password = PasswordApi;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(accesApi), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(UrlApiAuth, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    token = JsonConvert.DeserializeObject<DataToken>(apiResponse);
                }
            }

            return token.Data.ToString();
        }
       
    }
}
