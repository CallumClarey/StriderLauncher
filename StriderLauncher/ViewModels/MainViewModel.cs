using Avalonia;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StriderLauncher.Data;
using StriderLauncher.Factory;
using StriderLauncher.Helpers;
using StriderLauncher.ViewModels.Bases;

namespace StriderLauncher.ViewModels;

public partial class MainViewModel: ViewModelBase
{
    [ObservableProperty]
    private PageViewModel? currentPage;
    //the factory for the dependency injection
    private readonly PageFactory pageFactory;

    /// <summary>
    /// Uses a special method to combine the url to latest release version
    /// </summary>
    public string DocumentationUrl
    {
        get
        {
            Application.Current!.TryGetResource("DocumentationUrl", ThemeVariant.Default, out var url);
            Application.Current.TryGetResource("Version", ThemeVariant.Default, out var version);
            return string.Format((string)url!, (string)version!) ?? string.Empty;
        }
    }


    /// <summary>
    /// Design time constructor 
    /// </summary>
#pragma warning disable CS8618, CS9264
    public MainViewModel()
#pragma warning restore CS8618, CS9264
    {
        currentPage = new DashboardViewModel();
    }
    
    
    public MainViewModel(PageFactory pageFactory)
    {
        this.pageFactory = pageFactory;
        GoToDashboard();
    }
    
    [RelayCommand]
    private void GoToDashboard() => CurrentPage = pageFactory.GetPageViewModel(LauncherPageNames.DashboardPage);
    
    [RelayCommand]
    private void GoToProject() => CurrentPage = pageFactory.GetPageViewModel(LauncherPageNames.ProjectPage);

    [RelayCommand]
    private void OpenLink(string urlTarget) => UrlOpener.OpenUrl(urlTarget);
    
}