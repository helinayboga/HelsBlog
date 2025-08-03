using Microsoft.AspNetCore.Mvc;
using MyBlog.Models.ViewModels;
using MyBlog.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.Models.Domain;
using Microsoft.AspNetCore.Authorization;

namespace MyBlog.Controllers
{
    public class AdminCategoriesController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public AdminCategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(AddCategoryRequest addCategoryRequest)
        {
            var category = new Category
            {
                Name = addCategoryRequest.Name,
                Description = addCategoryRequest.Description,
                UrlHandle = addCategoryRequest.UrlHandle,
                Visible = addCategoryRequest.Visible,
                CreatedDate = DateTime.UtcNow
            };

            await categoryRepository.AddAsync(category);

            return RedirectToAction("Add");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> List()
        {
            var categories = await categoryRepository.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var category = await categoryRepository.GetAsync(id);

            if (category != null)
            {
                var editCategoryRequest = new EditCategoryRequest
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    UrlHandle = category.UrlHandle,
                    Visible = category.Visible
                };

                return View(editCategoryRequest);
            }

            return View(null);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(EditCategoryRequest editCategoryRequest)
        {
            var category = new Category
            {
                Id = editCategoryRequest.Id,
                Name = editCategoryRequest.Name,
                Description = editCategoryRequest.Description,
                UrlHandle = editCategoryRequest.UrlHandle,
                Visible = editCategoryRequest.Visible
            };

            var updatedCategory = await categoryRepository.UpdateAsync(category);

            if (updatedCategory != null)
            {
                return RedirectToAction("Edit", new { @id = editCategoryRequest.Id });
            }

            return RedirectToAction("Edit", new { @id = editCategoryRequest.Id });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(EditCategoryRequest editCategoryRequest)
        {
            var deletedCategory = await categoryRepository.DeleteAsync(editCategoryRequest.Id);

            if (deletedCategory != null)
            {
                return RedirectToAction("List");
            }

            return RedirectToAction("Edit", new { @id = editCategoryRequest.Id });
        }
    }
} 