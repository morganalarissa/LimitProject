using LimitProject.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LimitProject.Web.Controllers
{
    public class ClientController : Controller
    {
        #region Properties

        private readonly string ENDPOINT = "";
        private readonly HttpClient httpClient = null;

        private readonly IConfiguration _configuration;

        #endregion

        #region Constructors
        public ClientController(IConfiguration configuration)
        {
            _configuration = configuration;
            ENDPOINT = _configuration["AppConfig:Endpoints:Url_Api"];

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ENDPOINT);
        }
        #endregion
        public async Task<IActionResult> Index()
        {
            try
            {
                List<ClientViewModel> clients = null;

                HttpResponseMessage response = await httpClient.GetAsync(ENDPOINT);
                if (response.IsSuccessStatusCode) 
                {
                    string content = await response.Content.ReadAsStringAsync();
                    clients = JsonConvert.DeserializeObject<List<ClientViewModel>>(content);
                }
                else
                {
                    ModelState.AddModelError(null, "Error processing request");
                }

                return View(clients);
            }
            catch (Exception ex) 
            {
                string message = ex.Message;
                throw ex;
            }
        }

        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                ClientViewModel result = await Search(Id);

                return View(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Document, Name, AgencyNumber, AccountNumber, MaximumLimit")]ClientViewModel client)
        {
            try
            {
                string json = JsonConvert.SerializeObject(client);
                byte[] buffer = Encoding.UTF8.GetBytes(json);
                ByteArrayContent byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = 
                    new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                string url = ENDPOINT;
                HttpResponseMessage response = await httpClient.PostAsync(url, byteContent);

                if (!response.IsSuccessStatusCode)
                    ModelState.AddModelError(null, "Error processing request");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IActionResult> Edit(int Id)
        {
               ClientViewModel client = await Search(Id);

               return View(client);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("ClientId, Document, Name, AgencyNumber, AccountNumber, MaximumLimit")] ClientViewModel client)
        {
            try
            {
                string json = JsonConvert.SerializeObject(client);
                byte[] buffer = Encoding.UTF8.GetBytes(json);
                ByteArrayContent byteContent = new ByteArrayContent(buffer);

                byteContent.Headers.ContentType =
                    new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                string url = ENDPOINT;
                HttpResponseMessage response = await httpClient.PutAsync(url, byteContent);

                if (!response.IsSuccessStatusCode)
                    ModelState.AddModelError(null, "Error processing request");

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<IActionResult> Delete(int Id)
        {
            ClientViewModel client = await Search(Id);
            if (client == null)
                return NotFound();

            return View(client);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string ClientId)
        {
            int Id = Int32.Parse(ClientId);
            string url = $"{ENDPOINT}{Id}";
            HttpResponseMessage response = await httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                ModelState.AddModelError(null, "Error processing request");

            return RedirectToAction("Index");
        }
        private async Task<ClientViewModel> Search (int Id)
        {
            try
            {
                ClientViewModel result = null;

                string url = $"{ENDPOINT}{Id}";
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode) 
                {
                    string content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ClientViewModel>(content);
                }
                return result;
            }
            catch (Exception ex) 
            {
                throw ex;
            }

        }


    }
}
