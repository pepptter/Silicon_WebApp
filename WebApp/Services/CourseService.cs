public class CourseService : ICourseService
{
    private readonly HttpClient _httpClient;

    public CourseService(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient("CourseClient");
    }

    public async Task<List<CoursesViewModel>> GetAllCoursesAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("courses");
            response.EnsureSuccessStatusCode();
            var courses = await response.Content.ReadFromJsonAsync<List<CoursesViewModel>>();
            return courses ?? new List<CoursesViewModel>();
        }
        catch
        {
            return new List<CoursesViewModel>();
        }
    }
}
