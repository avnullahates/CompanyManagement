using CompanyManagement.ENTITIES.Entities;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using System.Text;

namespace CompanyManagement.UI.Controllers
{
	public class FirmController : Controller
	{
		public static string baseUrl = "https://localhost:7166/api/Firm/";

		public async Task<IActionResult> Index()
		{
			List<Firm> firms = new List<Firm>();

			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.GetAsync(baseUrl))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					firms = JsonConvert.DeserializeObject<List<Firm>>(apiResponse);
				}
			}

			return View(firms);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Create(Firm firm)
		{
			var url = baseUrl + "AddFirm";



			using (var httpClient = new HttpClient())
			{
				StringContent content = new StringContent(JsonConvert.SerializeObject(firm), Encoding.UTF8, "application/json");

				using (var response = await httpClient.PostAsync(url, content))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
				}
			}
			return RedirectToAction("Index");

		}

		[HttpGet]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
				return NotFound();

			var url = baseUrl + "GetFirmById/" + id;

			Firm getEditFirm = new Firm();
			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.GetAsync(url))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					getEditFirm = JsonConvert.DeserializeObject<Firm>(apiResponse);
				}
			}
			return View(getEditFirm);

		}

		[HttpPost]
		public async Task<IActionResult> Edit(Firm firm)
		{
			var url = baseUrl + "UpdateFirm/";
			Firm postEditFirm = new Firm();



			var httpClient = new HttpClient();

			var request = new HttpRequestMessage(HttpMethod.Put, $"{url}{firm.ID}")
			{
				Content = new StringContent(new JavaScriptSerializer().Serialize(firm), Encoding.UTF8, "application/json")
			};
			var response = await httpClient.SendAsync(request);

			string apiResponse = await response.Content.ReadAsStringAsync();

			postEditFirm = JsonConvert.DeserializeObject<Firm>(apiResponse);




			ViewBag.Result = "Success";
			return View(postEditFirm);




		}


	}
}
