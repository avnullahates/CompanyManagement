using CompanyManagement.BUSINESS.Abstract;
using CompanyManagement.ENTITIES.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.API.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : Controller
	{
		private readonly IGenericService<Order> _orderService;
		private readonly IGenericService<Firm> _firmService;

		public OrderController(IGenericService<Order> orderService, IGenericService<Firm> firmService)
		{
			_orderService = orderService;
			_firmService = firmService;
		}

		[HttpGet]
		public ActionResult<Firm> GetAllOrder()
		{
			var orders = _orderService.GetAll();

			return Ok(orders);
		}

		[HttpGet]
		[Route("[action]/{id}")]
		public ActionResult GetOrderById(int id)
		{
			var orderId = _orderService.GetByID(id);
			if (orderId != null)
			{
				return Ok(orderId);
			}
			else
			{
				return NotFound();
			}
		}

		[HttpPost]
		[Route("[action]")]
		public IActionResult AddOrder([FromBody] Order order)
		{
			var addOrderToFirm = _firmService.GetByID(order.FirmID);

			var orderHour = DateTime.Now.TimeOfDay;


			var firmStartHour = addOrderToFirm.OrderStartDate.TimeOfDay;
			var firmEndHour = addOrderToFirm.OrderEndDate.TimeOfDay;


			if (addOrderToFirm.ApprovalStatus == true)
			{
				if (orderHour >= firmStartHour && orderHour <= firmEndHour)
				{
					var addOrders = _orderService.Add(order);
					return Ok(addOrders);
				}
				else
				{
					return BadRequest($"Suan siparis alinmiyor. Suanki saat: {DateTime.Now.TimeOfDay}. Firmanin siparis alma saat araliklari {firmStartHour} - {firmEndHour} ");
				}
			}
			else
			{
				return BadRequest("Firma Onaylı Değil, Firma şuan sipariş almıyor");
			}








		}

		[HttpPut]
		[Route("[action]/{id}")]
		public IActionResult UpdateOrder([FromBody] Order order)
		{
			try
			{
				_orderService.Update(order);
				return Ok(order);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpDelete]
		[Route("[action]")]
		public IActionResult DeleteOrder(int id)
		{
			try
			{
				_orderService.Remove(id);
				return Ok("Order Deleted");
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}
	}
}
