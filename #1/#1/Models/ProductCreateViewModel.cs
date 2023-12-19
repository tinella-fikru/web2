using System.ComponentModel.DataAnnotations;

namespace _1.Models
{
	public class ProductCreateViewModel
	{
		[Required(ErrorMessage = "Id is Mandatory")]
		[Display(Name = "Product Id")]
		public int productId { get; set; }
		[Required(ErrorMessage = "Product Name is Mandatory")]
		[Display(Name = "Name")]
		public string productName { get; set; }
		[Required]
		[Display(Name = "Description")]
		public string productDescription { get; set; }
		[Required]
		[Display(Name = "Quantity")]
		public int quantity { get; set; }
		[Required]
		[Display(Name = "Unit Price")]
		public decimal unitPrice { get; set; }
		[Display(Name = "Upload Cover")]
		public IFormFile productImage { get; set; }
		[Display(Name = "Upload Images")]
		public List<IFormFile> productImages { get; set; }
	}
}
