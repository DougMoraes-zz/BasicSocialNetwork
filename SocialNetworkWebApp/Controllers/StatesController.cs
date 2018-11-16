using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
//using System.Web;
using System.Web.Mvc;

namespace SocialNetworkWebApp.Controllers
{
    public class StatesController : Controller
    {
        private HttpClient _client;

        public StatesController()
        {
            _client = new HttpClient();
            //_client.BaseAddress = new Uri("https://socialnetworkwebapi.azurewebsites.net/");
            _client.BaseAddress = new Uri("http://localhost:58445/");
            _client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void RegisterClientToken()
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session["apiToken"].ToString());
        }

        // GET: States
        //[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            RegisterClientToken();
            return View(_client.GetAsync("api/states")
                .Result.Content
                .ReadAsAsync<IEnumerable<State>>().Result);
        }

        // GET: States/Details/5
        public ActionResult Details(Guid? id)
        {
            RegisterClientToken();
            State state;
                //Obtem State pelo Id
                state = _client.GetAsync("api/states/" + id)
                    .Result.Content.ReadAsAsync<State>().Result;

            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);

        }

        // GET: States/Create
        public ActionResult Create()
        {
            RegisterClientToken();
            return View();
        }

        // POST: States/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Email")] State state, HttpPostedFileBase PhotoFile)
        {
            RegisterClientToken();
            if (ModelState.IsValid)
            {
                state.Id = Guid.NewGuid();
                //##### Upload da Foto para o Blob #####
                HttpPostedFileBase file = PhotoFile;
                var blobService = new AzureStorageService.BlobService();
                string fileUrl = await blobService.UploadImage("socialnetwork", Guid.NewGuid().ToString() + file.FileName, file.InputStream, file.ContentType);
                state.Flag = fileUrl;
                //#######################################
                //db.States.Add(state);
                //db.SaveChanges();
                await _client.PostAsJsonAsync<State>("api/states", state);
                return RedirectToAction("Details", state.Id);
            }

            return View(state);
        }

        // GET: States/Edit/5
        public ActionResult Edit(Guid? id)
        {
            RegisterClientToken();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = _client.GetAsync("api/states/" + id)
                .Result.Content.ReadAsAsync<State>().Result;
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        // POST: States/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Flag")] State state)
        {
            RegisterClientToken();
            if (ModelState.IsValid)
            {
                await _client.PutAsJsonAsync<State>("api/states/" + state.Id, state);
            }
            return RedirectToAction("Details", state.Id);
        }

        // GET: States/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = _client.GetAsync("api/states/" + id)
                .Result.Content.ReadAsAsync<State>().Result;
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        // POST: States/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            RegisterClientToken();
            State state = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var deleteResult = _client.DeleteAsync("api/states/" + id).Result;
            if (deleteResult.IsSuccessStatusCode)
                state = deleteResult.Content.ReadAsAsync<State>().Result;

            if (state == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("SignOut", "Account");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}