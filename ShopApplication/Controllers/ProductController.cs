using Microsoft.AspNetCore.Mvc;
using ShopApplication.Services.Interfaces;
using ShopApplication.ViewModel;

namespace ShopApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IFileService _fileService;

        public ProductController(IProductService productService, IFileService fileService)
        {
            _productService = productService;
            _fileService = fileService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                _productService.Create(model);
                await _productService.SaveTableAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}
