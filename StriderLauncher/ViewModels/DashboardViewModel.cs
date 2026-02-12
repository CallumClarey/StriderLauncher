using StriderLauncher.Data;

namespace StriderLauncher.ViewModels;

public partial class DashboardViewModel : Bases.PageViewModel
{
    public string DashboardText { get; set; } = "Dashboard";

    public DashboardViewModel()
    {
        PageName = LauncherPageNames.DashboardPage;
    }
}