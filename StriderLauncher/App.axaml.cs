using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Metadata;
using Microsoft.Extensions.DependencyInjection;
using StriderLauncher.ViewModels;
using FxResources.Microsoft.Extensions.DependencyInjection;
using StriderLauncher.Data;
using StriderLauncher.Factory;
using StriderLauncher.ViewModels.Bases;



[assembly: XmlnsDefinition("https://github.com/avaloniaui","StriderLauncher.Controls")]



namespace StriderLauncher;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var collection = new ServiceCollection();
        collection.AddSingleton<MainViewModel>();
        collection.AddTransient<DashboardViewModel>();
        collection.AddTransient<ProjectViewModel>();

        //Delegate used to create page names at time they are needed 
        collection.AddSingleton<Func<LauncherPageNames,PageViewModel>>
        (x => name => name switch
        {
            LauncherPageNames.DashboardPage => x.GetRequiredService<DashboardViewModel>(),
            LauncherPageNames.ProjectPage => x.GetRequiredService<ProjectViewModel>(),
            _=> throw new NotImplementedException()
        });
        
        //the factory dependency used to create pages
        collection.AddSingleton<PageFactory>();
        
        var services = collection.BuildServiceProvider();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainView
            {
                DataContext = services.GetRequiredService<MainViewModel>()
            };
        }
    
        base.OnFrameworkInitializationCompleted();
    }
}