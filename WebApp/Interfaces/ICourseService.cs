using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels;

public interface ICourseService
{
    Task<List<CoursesViewModel>> GetAllCoursesAsync();
}
