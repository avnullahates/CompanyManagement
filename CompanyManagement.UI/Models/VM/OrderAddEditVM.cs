using CompanyManagement.ENTITIES.Entities;

namespace CompanyManagement.UI.Models.VM
{
	public class OrderAddEditVM
	{
		public Order Order { get; set; }

		public List<Firm> Firms { get; set; }

		public List<Product> Products { get; set; }
	}
}
