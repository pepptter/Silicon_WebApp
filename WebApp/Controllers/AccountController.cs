using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class AccountController(UserManager<UserEntity> userManager, ApplicationContext context) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly ApplicationContext _context = context;

    public IActionResult Details()
    {
        var viewModel = new AccountDetailsViewModel();
        return View(viewModel);
    }
    [HttpPost]
    public IActionResult UpdateBasicInfo(AccountDetailsViewModel model)
    {
        if(TryValidateModel(model.BasicInfo!))
        {


        }
        else
        {
            TempData["StatusMessage"] = "Unable to save basic information. Please try again.";
        }
        return RedirectToAction("Details", "Account");

    }
    [HttpPost]
    public IActionResult UpdateAddressInfo(AccountDetailsViewModel model)
    {
        if(TryValidateModel(model.AddressInfo!))
        {

        }
        TempData["StatusMessage"] = "Unable to save address information. Please try again.";
        return RedirectToAction("Details", "Account");
    }
}
