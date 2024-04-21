public class CoursesViewModel
{
    public int Id { get; set; }
    public bool IsBestseller { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Price { get; set; } = null!;
    public string? DiscountPrice { get; set; }
    public string Hours { get; set; } = null!;
    public string LikesInPercent { get; set; } = null!;
    public string LikesInNumbers { get; set; } = null!;
    public List<AuthorViewModel> Authors { get; set; } = new List<AuthorViewModel>();
}

public class AuthorViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
