using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using PagedList;
using TestTask.Contracts;
using TestTask.Mappers;
using TestTask.Resources;
using TestTask.ViewModels;

namespace TestTask.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private const int ITEMS_ON_THE_PAGE = 15;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: User
        public ActionResult Index(int page = 1)
        {
            var users = _userService
                .GetAll()
                .Select(DomainToUI.Map)
                .OrderBy(u => u.Name)
                .ToList();
            PagedList<UserIndexViewModel> viewModel = new PagedList<UserIndexViewModel>(users, page, ITEMS_ON_THE_PAGE);
            return View(viewModel);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            var user = new UserCreateEditViewModel();
            return View(user);
        }

        // POST: User/Create
        [HttpPost]
        public JsonResult Create(UserCreateEditViewModel user, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return Json(new UserCreateEditResultViewModel
                {
                    Id = 0,
                    Message = Resource.NotValidUserModel,
                    HasSaved = false
                });
            }
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    user.FilePath = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    file.SaveAs(Path.Combine(Server.MapPath("~/UploadedImages/"), user.FilePath));
                }

                var userDomain = UIToDomain.Map(user);
                _userService.Create(userDomain);
                user.Id = userDomain.Id;
                return Json(new UserCreateEditResultViewModel
                {
                    Id = user.Id,
                    Message = Resource.UserSuccessfullySaved,
                    HasSaved = true
                });
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Json(new UserCreateEditResultViewModel
                {
                    Id = 0,
                    Message = ex.Message,
                    HasSaved = false
                });
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _userService.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var userViewModel = new UserCreateEditViewModel();
            DomainToUI.Map(userViewModel, user);
            return View(userViewModel);
        }

        // POST: User/Edit/5
        [HttpPost]
        public JsonResult Edit(UserCreateEditViewModel user, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return Json(new UserCreateEditResultViewModel
                {
                    Id = 0,
                    Message = Resource.NotValidUserModel,
                    HasSaved = false
                });
            }
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    user.FilePath = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    file.SaveAs(Path.Combine(Server.MapPath("~/UploadedImages/"), user.FilePath));
                }

                var userDomain = UIToDomain.Map(user);
                _userService.Edit(userDomain);
                user.Id = userDomain.Id;
                return Json(new UserCreateEditResultViewModel
                {
                    Id = user.Id,
                    Message = Resource.UserSuccessfullySaved,
                    HasSaved = true
                });
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Json(new UserCreateEditResultViewModel
                {
                    Id = 0,
                    Message = ex.Message,
                    HasSaved = false
                });
            }
        }


        // POST: User/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                _userService.Delete(id);
            }
            catch (ArgumentException ex)
            {
                return Json(new UserDeleteResultViewModel
                {
                    Id = id,
                    Message = ex.Message,
                    HasDeleted = false
                });
            }
            return Json(new UserDeleteResultViewModel
            {
                Id = id,
                Message = Resource.UserWasDeleted,
                HasDeleted = true
            });
        }
    }
}
