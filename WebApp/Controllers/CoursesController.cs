using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels.Views;

public class CoursesController : Controller
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet("/courses")]
    [Route("/courses")]
    [Authorize]

    public async Task<IActionResult> Index()
    {
        var courses = await _courseService.GetAllCoursesAsync();

        var viewModel = new CourseIndexViewModel
        {
            Courses = courses
        };
        return View(viewModel);
    }
}
