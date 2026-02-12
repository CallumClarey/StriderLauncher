using CommunityToolkit.Mvvm.ComponentModel;
using StriderLauncher.Data;

namespace StriderLauncher.ViewModels.Bases;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty]
    private LauncherPageNames pageName;
}