using WebApp.ViewModels;
using WebApp.ViewModels.Views;

public class DefaultIndexViewModel
{
    public string Title { get; set; } = "Home";
    public FeaturesSectionViewModel Features { get; set; } = new FeaturesSectionViewModel();
    public IntegrateSectionViewModel Integrate { get; set; } = new IntegrateSectionViewModel();
    public SubscribeViewModel Subscribe { get; set; } = new SubscribeViewModel();


}