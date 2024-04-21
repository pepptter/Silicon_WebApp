using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApp.ViewModels;

namespace WebApp.Controllers;
[Authorize]

public class AccountController(UserManager<UserEntity> userManager, ApplicationContext context) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly ApplicationContext _context = context;

    public async Task<IActionResult> Details(AccountDetailsViewModel viewModel)
    {
        var nameIdentifier = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var user = await _context.Users.Include(i => i.Address).FirstOrDefaultAsync(x => x.Id == nameIdentifier);

        viewModel = new AccountDetailsViewModel
        {
            BasicInfo = new AccountBasicInfo
            {
                FirstName = user!.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber,
                Bio = user.Bio
            },
            AddressInfo = new AccountAddressInfo
            {
                AddressLine_1 = user.Address?.AddressLine_1 ?? "",
                AddressLine_2 = user.Address?.AddressLine_2 ?? "",
                PostalCode = user.Address?.PostalCode ?? "",
                City = user.Address?.City ?? ""
            }
        };
        return View(viewModel);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateBasicInfo(AccountDetailsViewModel model)
    {
        if(TryValidateModel(model.BasicInfo!))
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                user.FirstName = model.BasicInfo!.FirstName;
                user.LastName = model.BasicInfo!.LastName;
                user.Email = model.BasicInfo!.Email;
                user.PhoneNumber = model.BasicInfo!.PhoneNumber;
                user.UserName = model.BasicInfo!.Email;
                user.Bio = model.BasicInfo!.Bio;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData["StatusMessage"] = "Basic information updated successfully.";
                }
                else
                {
                    TempData["StatusMessage"] = "Unable to save basic information. Please try again.";
                }
            }

        }
        else
        {
            TempData["StatusMessage"] = "Unable to save basic information. Please try again.";
        }
        return RedirectToAction("Details", "Account");

    }
    [HttpPost]
    public async Task<IActionResult> UpdateAddressInfo(AccountDetailsViewModel model)
    {
        if (TryValidateModel(model.AddressInfo!))
        {
            var nameIdentifier = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var user = await _context.Users.Include(i => i.Address).FirstOrDefaultAsync(x => x.Id == nameIdentifier);
            if (user != null)
            {
                try
                {
                    if (user.Address != null)
                    {
                        user.Address.AddressLine_1 = model.AddressInfo!.AddressLine_1;
                        user.Address.AddressLine_2 = model.AddressInfo!.AddressLine_2;
                        user.Address.PostalCode = model.AddressInfo!.PostalCode;
                        user.Address.City = model.AddressInfo!.City;
                    }
                    else
                    {
                        user.Address = new AddressEntity
                        {
                            AddressLine_1 = model.AddressInfo!.AddressLine_1,
                            AddressLine_2 = model.AddressInfo!.AddressLine_2!,
                            PostalCode = model.AddressInfo.PostalCode,
                            City = model.AddressInfo.City
                        };
                    }
                    _context.Update(user);
                    await _context.SaveChangesAsync();

                    TempData["StatusMessage"] = "Address information updated successfully.";
                }
                catch (Exception)
                {
                    TempData["StatusMessage"] = "Unable to save address information. Please try again.";
                }
            }

        }
        else
        {
            TempData["StatusMessage"] = "Unable to save basic information. Please try again.";
        }
        return RedirectToAction("Details", "Account");
    }
    [HttpPost]
    public async Task<IActionResult> UploadProfilePicture(IFormFile file)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user != null && file != null && file.Length != 0)
        {

            var fileName = $"p_{user.Id}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/uploads/profiles", fileName);

            using var fs = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fs);
                
            user.ProfilePicture = fileName;
            await _userManager.UpdateAsync(user);

            TempData["StatusMessage"] = "Profile picture updated successfully.";           
        }
        else
        {
            TempData["StatusMessage"] = "Unable to save profile picture. Please try again.";
        }
        return RedirectToAction("Details", "Account");
    }


}
