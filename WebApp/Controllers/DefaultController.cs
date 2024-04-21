using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApp.ViewModels;
using WebApp.ViewModels.Views;

namespace WebApp.Controllers;

public class DefaultController(HttpClient httpClient) : Controller
{
    private readonly HttpClient _httpClient = httpClient;

    public IActionResult Index()
    {
        var homeViewModel = new DefaultIndexViewModel
        {
            Features = new FeaturesSectionViewModel
            {
                Items =
                [
                    new FeatureViewModel
                    {
                        ImageSrc = "images/chat.svg",
                        ImageAltText = "image of chat bubbles",
                        Title = "Comments on Tasks",
                        Description = "Id mollis consectetur congue egestas egestas suspendisse blandit justo."
                    },
                    new FeatureViewModel
                    {
                        ImageSrc = "images/presentation.svg",
                        ImageAltText = "image of a screen with a chart",
                        Title = "Tasks Analytics",
                        Description = "Non imperdiet facilisis nulla tellus Morbi scelerisque eget adipiscing vulputate."
                    },
                    new FeatureViewModel
                    {
                        ImageSrc = "images/add-group.svg",
                        ImageAltText = "image of chat bubbles",
                        Title = "Multiple Assignees",
                        Description = "A elementum, imperdiet enim, pretium etiam facilisi in aenean quam mauris."
                    },
                    new FeatureViewModel
                    {
                        ImageSrc = "images/bell.svg",
                        ImageAltText = "image of a bell",
                        Title = "Notifications",
                        Description = "Diam, suspendisse velit cras ac. Lobortis diam volutpat, eget pellentesque viverra."
                    },
                    new FeatureViewModel
                    {
                        ImageSrc = "images/test.svg",
                        ImageAltText = "image of a checklist",
                        Title = "Sections & Subtasks",
                        Description = "Mi feugiat hac id in. Sit elit placerat lacus nibh lorem ridiculus lectus."
                    },
                    new FeatureViewModel
                    {
                        ImageSrc = "images/shield.svg",
                        ImageAltText = "image of a shield",
                        Title = "Data Security",
                        Description = "Aliquam malesuada neque eget elit nulla vestibulum nunc cras."
                    }
                ]
            },
            Integrate = new IntegrateSectionViewModel
            {
                Items =
                [
                    new IntegrateViewModel
                    {
                        ImageSrc = "images/Google.svg",
                        ImageAltText = "image of the Google logo",
                        Description = "Lorem magnis pretium sed curabitur nunc facilisi nunc cursus sagittis."
                    },
                    new IntegrateViewModel
                    {
                        ImageSrc = "images/Zoom.svg",
                        ImageAltText = "image of the Zoom logo",
                        Description = "In eget a mauris quis. Tortor dui tempus quis integer est sit natoque placerat dolor."
                    },
                    new IntegrateViewModel
                    {
                        ImageSrc = "images/Slack.svg",
                        ImageAltText = "image of the Slack logo",
                        Description = "Id mollis consectetur congue egestas egestas suspendisse blandit justo."
                    },
                    new IntegrateViewModel
                    {
                        ImageSrc = "images/Gmail.svg",
                        ImageAltText = "image of the Gmail logo",
                        Description = "Rutrum interdum tortor, sed at nulla. A cursus bibendum elit purus cras praesent."
                    },
                    new IntegrateViewModel
                    {
                        ImageSrc = "images/Trello.svg",
                        ImageAltText = "image of the Trello logo",
                        Description = "Congue pellentesque amet, viverra curabitur quam diam scelerisque fermentum urna."
                    },
                    new IntegrateViewModel
                    {
                        ImageSrc = "images/MailChimp.svg",
                        ImageAltText = "image of the MailChimp logo",
                        Description = "A elementum, imperdiet enim, pretium etiam facilisi in aenean quam mauris."
                    },
                    new IntegrateViewModel
                    {
                        ImageSrc = "images/Dropbox.svg",
                        ImageAltText = "image of the Dropbox logo",
                        Description = "Ut in turpis consequat odio diam lectus elementum. Est faucibus blandit platea."
                    },
                    new IntegrateViewModel
                    {
                        ImageSrc = "images/Evernote.svg",
                        ImageAltText = "image of the Evernote logo",
                        Description = "Faucibus cursus maecenas lorem cursus nibh. Sociis sit risus id. Sit facilisis dolor arcu."
                    },
                ]
            }
        };

        return View(homeViewModel);
    }
    public async Task<IActionResult> Subscribe(SubscribeViewModel model)
    {
        if (ModelState.IsValid)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7253/api/subscribe", content);
            if (response.IsSuccessStatusCode)
            {
                TempData["StatusMessage"] = "You have successfully subscribed!";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                 TempData["StatusMessage"] = "You are already subscribed!";
            }
        }
        else
        {
            TempData["StatusMessage"] = "Invalid email address!";
        }
        return RedirectToAction("Index", "Default", "newsletter");
    }
}
