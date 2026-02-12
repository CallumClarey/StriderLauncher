using System;
using System.Runtime.CompilerServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Chrome;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.Input;

namespace StriderLauncher;

public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();
        
    }

    public string MaximisedIcon => WindowState == WindowState.Maximized ? "\uE8A2" : "\uE8A3";

    //Functions for custom window layout
    //--------------------------------------------
    private void Titlebar_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        //should handle the button presses
        if (e.Source is not Grid) return;

        //checks to see if the left button is being pressed if so it will let the window be draggable
        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
        {
            BeginMoveDrag(e);
        }

        if (e.ClickCount >= 2)
        {
            MaxWindow();
        }
    }

    private void OnClosed_OnClick(object? sender, RoutedEventArgs e) => Close();
    private void Minimize_OnClick(object? sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

    private void Maximumise_OnClick(object? sender, RoutedEventArgs e)
    {
        WindowState = WindowState == WindowState.Maximized
            ? WindowState.Normal
            : WindowState.Maximized;
        
        MaxBtn.Header = WindowState == WindowState.Maximized ? "❐" : "□";
    }
    
    private void MaxWindow() => WindowState = WindowState.Maximized;
}