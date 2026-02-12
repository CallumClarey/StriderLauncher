using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using StriderLauncher.ViewModels;
using StriderLauncher.ViewModels.Bases;
using StriderLauncher.Views;

namespace StriderLauncher;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? data)
    {
        if(data is null) return null;
        //get the name
        var viewName = data.GetType().FullName!.Replace("ViewModel", "View", StringComparison.InvariantCulture);
        
        //reflects type
        var type = Type.GetType(viewName);
        if(type is null) return null;
        
        //creates instance of control
        var control = (Control)Activator.CreateInstance(type)!;
        control.DataContext = data;
        return control;
    }

    public bool Match(object? data) => data is ViewModelBase;
}