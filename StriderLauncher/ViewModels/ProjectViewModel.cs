using StriderLauncher.Data;

namespace StriderLauncher.ViewModels;

public partial class ProjectViewModel : Bases.PageViewModel
{
    public string ProjectText { get; set; } = "Dashboard";

    public ProjectViewModel()
    {
        PageName = LauncherPageNames.ProjectPage;
    }
}