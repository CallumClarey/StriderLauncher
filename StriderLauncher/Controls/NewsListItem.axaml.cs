using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace StriderLauncher.TemplatedControls;

public class NewsListItem : TemplatedControl
{
    public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<NewsListItem,string>(
        nameof(Title), "Heading 1");

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    
    public static readonly StyledProperty<string> DateReleasedProperty = AvaloniaProperty.Register<NewsListItem,string>(
        nameof(DateReleased), "Decription");
    
    public string DateReleased
    {
        get => GetValue(DateReleasedProperty);
        set => SetValue(DateReleasedProperty, value);
    }
}