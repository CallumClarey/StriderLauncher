using System;
using StriderLauncher.Data;
using StriderLauncher.ViewModels.Bases;

namespace StriderLauncher.Factory;

public class PageFactory (Func<LauncherPageNames,PageViewModel> pageFactory)
{
    //the cached function pointer
    public PageViewModel GetPageViewModel(LauncherPageNames pageName) => pageFactory.Invoke(pageName);
}