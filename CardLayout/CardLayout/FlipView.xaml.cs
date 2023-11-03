namespace CardLayout;

public partial class FlipView : ContentView
{
    public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(FlipView));
    public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(Image), typeof(string), typeof(FlipView));
    public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(nameof(Description), typeof(string), typeof(FlipView));
    public static readonly BindableProperty PriceProperty = BindableProperty.Create(nameof(Price), typeof(string), typeof(FlipView));

    int side = 0;

    public string Name
    {
        get => GetValue(NameProperty) as string;
        set => SetValue(NameProperty, value);
    }

    public string Description
    {
        get => GetValue(DescriptionProperty) as string;
        set => SetValue(DescriptionProperty, value);
    }

    public string Image
    {
        get => GetValue(ImageProperty) as string;
        set => SetValue(ImageProperty, value);
    }

    public string Price
    {
        get => GetValue(PriceProperty) as string;
        set => SetValue(PriceProperty, value);
    }

    public FlipView()
    {
        InitializeComponent();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        this.RotationY = 0;
        var animation = new Animation();
        animation.Add(0, 0.5, new Animation(v => this.RotateYTo(v, 1000), 0, 360));
        animation.Commit(this, "ChildAnimation", 16, 2000, finished: delegate
        {
            if (side == 1)
            {
                side = 0;
                image.IsVisible = true;
                labelDescription.IsVisible = false;
                labelPrice.IsVisible = false;
            }
            else
            {
                side = 1;
                image.IsVisible = false;
                labelDescription.IsVisible = true;
                labelPrice.IsVisible = true;
            }
            animation.Dispose();
        });
    }
}