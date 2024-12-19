using Microsoft.AspNetCore.Mvc;
using MyDapperProject.Dtos.ProductDtos;
using MyDapperProject.Repositories;

namespace MyDapperProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> ProductList()
        {
            var values = await _repository.GetAllProductAsync();
            return View(values);
        }

        public async Task<IActionResult> ProductListWithCategory()
        {
            return View(await _repository.GetAllProductWithCategory());
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _repository.CreateProductAsync(createProductDto);
            return RedirectToAction("ProductList");
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _repository.DeleteProductAsync(id);
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            return View(await _repository.GetByIdProductAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _repository.UpdateProductAsync(updateProductDto);
            return RedirectToAction("ProductList");
        }
    }
}
