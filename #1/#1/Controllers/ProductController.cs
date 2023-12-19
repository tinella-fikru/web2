using _1.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1.Controllers
{
	public class ProductController : Controller
	{
		private IWebHostEnvironment webHostEnvironment;
        private EcomContext ecomContext;

        public ProductController(IWebHostEnvironment webHostEnvironment,EcomContext ecomContext)
        {
				this.webHostEnvironment = webHostEnvironment;
                this.ecomContext = ecomContext;

        }
        [HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(ProductCreateViewModel pvm)
		{
			string uniqueCFileName = "";
			string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
            string fileName = "";

            if (pvm.productImage!=null)
               {
                    fileName = Guid.NewGuid().ToString() + "_"+ pvm.productImage.FileName;//global unique id
                    uniqueCFileName = Path.Combine(uploadFolder, fileName);//url
                    //Upload single File
                    pvm.productImage.CopyTo(new FileStream(uniqueCFileName, FileMode.Create));
                }


            var prod = new Product()
            {
                productName = pvm.productName,
                productDescription = pvm.productDescription,
                quantity = pvm.quantity,
                unitPrice = pvm.unitPrice,
                imagePath = "/Images/" + fileName
            };
            
            
            prod.imageGallary = new List<ProductGallary>();


            foreach (IFormFile pI in pvm.productImages)
                if (pvm.productImages.Count > 0)
                {
                     fileName = Guid.NewGuid().ToString() + "_" + pI.FileName;//global unique id
                    uniqueCFileName = Path.Combine(uploadFolder, fileName);//url
                    //Upload single File
                    pI.CopyTo(new FileStream(uniqueCFileName, FileMode.Create));
                    ProductGallary pg = new ProductGallary()
                    {
                        url = "/Images/" + fileName
                    };
                    prod.imageGallary.Add(pg);
                }


            ProductRepository pr = new ProductRepository(ecomContext);
            pr.Add(prod);

            return RedirectToAction("GetAllProducts");
		}

        public IActionResult GetAllProducts()
        {
            ProductRepository pr = new ProductRepository(ecomContext);
            List<Product> products = pr.GetAllProducts();
            return View(products);
        }

        public IActionResult GetProductById(int id)
        {
            ProductRepository pr = new ProductRepository(ecomContext);
            Product product = pr.GetProductById(id);
            return View(product);
        }

    }
}
