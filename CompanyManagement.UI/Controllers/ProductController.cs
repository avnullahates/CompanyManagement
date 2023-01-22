using CompanyManagement.BUSINESS.Abstract;
using CompanyManagement.ENTITIES.Entities;
using CompanyManagement.UI.Models.VM;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using System.Text;

namespace CompanyManagement.UI.Controllers
{
	public class ProductController : Controller
	{
		

		public static string baseUrl = "https://localhost:7166/api/Product/";

		public async Task<IActionResult> Index()
		{
			List<Product> products = new List<Product>();


			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.GetAsync(baseUrl))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					products = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
				}
			}

			return View(products);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			ProductAddEditVM vm = new ProductAddEditVM();
			vm.Product = new Product();

			List<Firm> firms = new List<Firm>();
			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.GetAsync("https://localhost:7166/api/Firm/"))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					firms = JsonConvert.DeserializeObject<List<Firm>>(apiResponse);
				}
			}

			vm.Firms = firms;
			return View(vm);
		}


		[HttpPost]
		public async Task<IActionResult> Create(Product product)
		{
			var url = baseUrl + "AddProduct";			

			using (var httpClient = new HttpClient())
			{
				StringContent content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");

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

			var url = baseUrl + "GetProductById/" + id;

			Product getEditProduct = new Product();
			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.GetAsync(url))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					getEditProduct = JsonConvert.DeserializeObject<Product>(apiResponse);
				}
			}
			return View(getEditProduct);

		}

		[HttpPost]
		public async Task<IActionResult> Edit(Product product)
		{
			var url = baseUrl + "UpdateProduct/";
			Product postEditProduct = new Product();

			var httpClient = new HttpClient();
			var request = new HttpRequestMessage(HttpMethod.Put, $"{url}{product.ID}")
			{
				Content = new StringContent(new JavaScriptSerializer().Serialize(product), Encoding.UTF8, "application/json")
			};
			var response = await httpClient.SendAsync(request);
			string apiResponse = await response.Content.ReadAsStringAsync();

			postEditProduct = JsonConvert.DeserializeObject<Product>(apiResponse);
			ViewBag.Result = "Success";
			return View(postEditProduct);

		}



	}
}
