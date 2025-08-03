using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Models.Domain;
using MyBlog.Models.ViewModels;
using MyBlog.Repositories;

namespace MyBlog.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly ITagRepository tagRepository;

        public AdminTagsController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            //mapping AddTagRequest to Tag domian model
            var tag = new Tag
            {
                Name = addTagRequest.Name,
            };

         await tagRepository.AddAsync(tag);

            return RedirectToAction("List");

        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            var tags = await tagRepository.GetAllAsync();
            return View(tags);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid id)
        {
           var tag = await tagRepository.GetAsync(id);

            if (tag == null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name
                };
                return View(editTagRequest);

            }
            return View(null);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
            };
          var updatedTag = await tagRepository.UpdateAsync(tag);

            if (updatedTag != null)
            {//show success notification
            }
            else
            {
                //show error notification
            }
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {
          var deletedTag = await tagRepository.DeleteAsync(editTagRequest.Id);

            if (deletedTag != null)
            {
                // SHOW SUCCES NOTIFICATION
                return RedirectToAction("List");
            }

            return RedirectToAction("Edit", new {id = editTagRequest.Id});
        }
    }
}
