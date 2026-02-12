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
    /// Design time constructor 
    /// </summary>
    public MainViewModel()
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