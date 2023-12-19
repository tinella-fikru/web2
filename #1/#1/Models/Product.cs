namespace _1.Models
{
	public class Product
	{
		public int productId { get; set; }
		public string productName { get; set; }
		public string productDescription { get; set; }
		public int quantity { get; set; }
		public decimal unitPrice { get; set; }
		public string imagePath { get; set; }
		public List<ProductGallary> imageGallary { get; set; }
	}
}
