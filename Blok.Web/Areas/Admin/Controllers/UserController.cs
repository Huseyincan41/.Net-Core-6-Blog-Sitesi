using AutoMapper;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.DTOs.Users;
using Blog.Entity.Entities;
using Blog.Entity.Enums;
using Blog.Service.Extensions;
using Blog.Service.Helpers.Images;
using Blog.Service.Services.Abstractions;
using Blok.Web.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.Data;
using static Blok.Web.ResultMessages.Messages;

namespace Blok.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
      
        private readonly IUserService userService;
        
        private readonly IValidator<AppUser> validator;
        private readonly IToastNotification toast;
        
        private readonly IMapper mapper;

        public UserController(IUserService userService,IValidator<AppUser> validator,IToastNotification toast,IMapper mapper)
        {
       
            this.userService = userService;
            
            
            this.validator = validator;
            this.toast = toast;
           
            this.mapper = mapper;
        }
        public async  Task<IActionResult> Index()
        {

            var result = await userService.GetAllUsersWithRoleAsync();

            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles=await userService.GetAllRolesAsync();
            return View(new UserAddDto {Roles=roles });
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var map = mapper.Map<AppUser>(userAddDto);
            var validaton=await validator.ValidateAsync(map);
            var roles = await userService.GetAllRolesAsync();
            if (ModelState.IsValid)
            {
                var result=await userService.CreateUserAsync(userAddDto);
                if (result.Succeeded)
                {
                    
                    toast.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email), new ToastrOptions { Title = "Başarılı!" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                        //foreach (var errors in result.Errors)
                        //ModelState.AddModelError("",errors.Description);

                    result.AddToIdentityModelState(this.ModelState);
                    validaton.AddToModelState(this.ModelState);
                    
                    return View(new UserAddDto { Roles = roles });
                }
            }
            return View(new UserAddDto { Roles=roles});
        }
        [HttpGet]

        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await userService.GetAppUserByIdAsync(userId);

            var rules = await userService.GetAllRolesAsync();

            var map=mapper.Map<UserUpdateDto>(user);
            map.Roles = rules;

            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var user = await userService.GetAppUserByIdAsync(userUpdateDto.Id);
            if (user != null)
            {
                
                var roles = await userService.GetAllRolesAsync();
                if (ModelState.IsValid)
                {
                    var map=mapper.Map(userUpdateDto,user);
                    var validaton = await validator.ValidateAsync(map);
                    if (validaton.IsValid)
                    {
                        user.UserName = userUpdateDto.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();
                        var result = await userService.UpdateUserAsync(userUpdateDto);
                        if (result.Succeeded)
                        {
                            
                            toast.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "Başarılı!" });
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            result.AddToIdentityModelState(this.ModelState);
                            
                            return View(new UserUpdateDto { Roles = roles });
                        }
                    }
                    else
                    {
                        validaton.AddToModelState(this.ModelState);
                        return View(new UserUpdateDto { Roles = roles });
                    }
                   
                }
            }
            return NotFound();   
        }
        public async Task<IActionResult> Delete(Guid userId)
        {
           
            
                var result = await userService.DeleteUserAsync(userId);
               
                if (result.identityResult.Succeeded)
                {
                toast.AddSuccessToastMessage(Messages.User.Delete(result.email), new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
            else
            {
                result.identityResult.AddToIdentityModelState(this.ModelState);
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var profile = await userService.GetUserProfileAsync();
            return View(profile);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
        {
           
            if (ModelState.IsValid)
            {
              var result=await  userService.UserProfileUpdateAsync(userProfileDto);
                if (result)
                {
                    toast.AddSuccessToastMessage("profil güncelleme işlemi tamamlandı", new ToastrOptions { Title = "Başarılı!" });
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
                else
                {
                    var profile = await userService.GetUserProfileAsync();
                    toast.AddErrorToastMessage("profil güncelleme işlemi tamamlanamadı", new ToastrOptions { Title = "Başarılı!" });
                    return View(profile);
                }

            }
            else
            {
                return NotFound();
            }
            
           
        }
    }
}
