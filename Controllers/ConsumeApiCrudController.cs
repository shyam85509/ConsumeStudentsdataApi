using ConsumeWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeWebApi.Controllers
{
    public class ConsumeApiCrudController : Controller
    {
        public async Task<IEnumerable<StudentsData>>  GetAllData()
        {
            IEnumerable<StudentsData> obj = null;
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7011/api/");
                var responce = client.GetAsync("Crudstd/GetAllData");
                responce.Wait();

                var data = responce.Result;
                if (data.IsSuccessStatusCode)
                {
                    var read = data.Content.ReadAsAsync<List<StudentsData>>();
                    read.Wait();
                    obj = read.Result;
                }
            }
            return obj;
        }

        public async Task<IActionResult> ShowData()
        {
            IEnumerable<StudentsData> obj = await GetAllData();
            return View(obj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentsData obj)
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7011/api/");
                var postData = client.PostAsJsonAsync<StudentsData>("Crudstd/InsetStd", obj);
                var res = postData.Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowData", "ConsumeApiCrud");
                }
                else
                {
                    ModelState.AddModelError("","Something wrong");
                }
            }
            return View();
        }

        public IActionResult Detials()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            StudentsData obj = null;
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7011/api/");
                var responce = client.GetAsync("Crudstd/GetDataById?Id="+Id);
                var res = responce.Result;
                if (res.IsSuccessStatusCode)
                {
                    var data = res.Content.ReadAsAsync<StudentsData>();
                    obj = data.Result;
                }
            }
            return View(obj);
        }

        

        [HttpPost]
        public IActionResult Delete(int Id, StudentsData obj)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7011/api/");

            }
                return View();
        }
    }
}



























