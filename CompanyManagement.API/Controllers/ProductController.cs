using CompanyManagement.BUSINESS.Abstract;
using CompanyManagement.ENTITIES.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : Controller
	{
		private readonly IGenericService<Product> _productService;

		public ProductController(IGenericService<Product> productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public ActionResult GetAllProduct()
		{
			var products = _productService.GetAll();
			return Ok(products);
		}

		[HttpGet]
		[Route("[action]/{id}")]
		public ActionResult GetProductById(int id)
		{
			var productId = _productService.GetByID(id);
			if (productId != null)
			{
				return Ok(productId);
			}
			else
			{
				return NotFound();
			}
		}


		[HttpPost]
		[Route("[action]")]
		public IActionResult AddProduct([FromBody] Product product)
		{
			var addProduct = _productService.Add(product);
			return Ok(addProduct);
		}

		[HttpPut]
		[Route("[action]/{id}")]
		public IActionResult UpdateProduct([FromBody] Product product)
		{
			try
			{
				_productService.Update(product);
				return Ok(product);
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
				_productService.Remove(id);
				return Ok("Product Deleted");
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}



	}
}
