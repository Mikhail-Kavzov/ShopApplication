using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopApplication.Extensions;
using ShopApplication.Models;
using ShopApplication.Services.Interfaces;
using ShopApplication.ViewModel;
using System.Net;

namespace ShopApplication.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IFileService _fileService;
        private readonly UserManager<User> _userManager;
        private readonly IPaginationService _paginationService;
        private const int PAGES_COUNT = 4;

        public ProductController(IProductService productService,
            IFileService fileService, UserManager<User> userManager,
            IPaginationService paginationService)
        {
            _productService = productService;
            _fileService = fileService;
            _userManager = userManager;
            _paginationService = paginationService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ProductItems(int page = 1, string sortOrder = "",
            string filter = "")
        {
            var products = await _productService.GetItemsAsync
                ((page - 1) * PAGES_COUNT, PAGES_COUNT, sortOrder, filter);
            var count = await _productService.ItemsTotal();
            var indexModel = _paginationService.CreateIndexViewModel(page, count,
                PAGES_COUNT, products);
            return PartialView(indexModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ProductPage(int page = 1)
        {
            var products = await _productService.GetItemsAsync
                ((page - 1) * PAGES_COUNT, PAGES_COUNT);
            var count = await _productService.ItemsTotal();
            var indexModel = _paginationService.CreateIndexViewModel(page, count,
                PAGES_COUNT, products);
            return View(indexModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ProductInfo(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            var productViewModel = _productService.CreateProductViewModel(product);
            return View(productViewModel);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model, IFormFile photoFile)
        {
            if (ModelState.IsValid)
            {
                model.PhotoLink = await _fileService.CreateFileAsync(photoFile);
                var currentUser = await _userManager.GetUserAsync(User);
                _productService.Create(model, currentUser.Id);
                await _productService.SaveTableAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetProductById(id);
            var result = CheckProductAccessability(product);
            if (result != null)
            {
                return result;
            }
            var productViewModel = _productService.CreateProductViewModel(product);
            return View(productViewModel);
        }

        private IActionResult? CheckProductAccessability(Product? product)
        {
            // if no product with such an id
            if (product == null)
            {
                return NotFound();
            }
            // if user is trying to update someone else product
            if (!this.HasAccess(User.Identity.Name))
            {
                return StatusCode((int)HttpStatusCode.Forbidden);
            }
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductViewModel model,
            IFormFile? photoFile = null)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.GetProductById(model.ProductId);
                var result = CheckProductAccessability(product);
                if (result != null)
                {
                    return result;
                }
                if (photoFile != null)
                {
                    model.PhotoLink = await _fileService.UpdateFileAsync
                        (product.PhotoLink, photoFile);
                }
                _productService.Update(product, model);
                await _productService.SaveTableAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductById(id);
            var result = CheckProductAccessability(product);
            if (result != null)
            {
                return result;
            }
            await _productService.DeleteAsync(product);
            return Ok();
        }
    }
}
