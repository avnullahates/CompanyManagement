using CompanyManagement.ENTITIES.Entities;
using CompanyManagement.UI.Models.VM;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CompanyManagement.UI.Controllers
{
	public class OrderController : Controller
	{

		public static string baseUrl = "https://localhost:7166/api/Order/";

		public async Task<IActionResult> Index()
		{
			List<Order> orders = new List<Order>();

			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.GetAsync(baseUrl))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					orders = JsonConvert.DeserializeObject<List<Order>>(apiResponse);
				}
			}

			return View(orders);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			OrderAddEditVM vm= new OrderAddEditVM();
			vm.Order= new Order();			

			List<Product> products = new List<Product>();
			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.GetAsync(baseUrl))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					products = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
				}
			}

			List<Firm> firms = new List<Firm>();
			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.GetAsync(baseUrl))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					firms = JsonConvert.DeserializeObject<List<Firm>>(apiResponse);
				}
			}

			vm.Products = products;
			vm.Firms = firms;
			return View(vm);
		}


		[HttpPost]
		public async Task<IActionResult> Create(Order order)
		{
			var url = baseUrl + "AddOrder";

			
			
		
			using (var httpClient = new HttpClient())
			{
				StringContent content = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json");

				using (var response = await httpClient.PostAsync(url, content))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
				}
			}
			return RedirectToAction("Index");

		}
	}
}
