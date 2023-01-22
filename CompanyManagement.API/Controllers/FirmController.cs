using CompanyManagement.BUSINESS.Abstract;
using CompanyManagement.ENTITIES.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FirmController : Controller
	{
		private readonly IGenericService<Firm> _firmService;

		public FirmController(IGenericService<Firm> firmService)
		{
			_firmService = firmService;
		}

		[HttpGet]
		public ActionResult<Firm> GetAllFirm()
		{
			var firms = _firmService.GetAll();

			return Ok(firms);
		}

		[HttpGet]
		[Route("[action]/{id}")]
		public ActionResult GetFirmById(int id)
		{
			var firmsId = _firmService.GetByID(id);
			if (firmsId != null)
			{
				return Ok(firmsId);
			}
			else
			{
				return NotFound();
			}
		}

		[HttpPost]
		[Route("[action]")]
		public IActionResult AddFirm([FromBody] Firm firm)
		{
			var addFirm = _firmService.Add(firm);
			return Ok(addFirm);
		}

		[HttpPut]
		[Route("[action]/{id}")]
		public IActionResult UpdateFirm([FromBody] Firm firm)
		{
			try
			{
				_firmService.Update(firm);
				return Ok(firm);
			}
			catch (Exception)
			{

				return BadRequest();
			}
		}

		[HttpDelete]
		[Route("[action]")]
		public IActionResult DeleteFirm(int id)
		{
			try
			{
				_firmService.Remove(id);
				return Ok("Firm Deleted");
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}






	}
}
