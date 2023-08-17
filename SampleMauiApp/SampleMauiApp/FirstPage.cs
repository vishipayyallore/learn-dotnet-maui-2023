namespace SampleMauiApp;

public class FirstPage : ContentPage
{
    int count = 0;
    readonly Label lblCounter;

    public FirstPage()
    {
        Title = "First Page - C#";

        var scrollView = new ScrollView();

        var stackLayout = new StackLayout();
        scrollView.Content = stackLayout;

        Color.TryParse("#3498DB", out Color _color);
        lblCounter = new Label
        {
            Text = "Count: 0",
            FontSize = 22,
            TextColor = _color,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center,
        };
        stackLayout.Children.Add(lblCounter);

        var btnCounter = new Button
        {
            Text = "Click To Count",
            HorizontalOptions = LayoutOptions.Center,
        };
        stackLayout.Children.Add(btnCounter);
        btnCounter.Clicked += OnButtonClickedEvent;

        this.Content = scrollView;
    }

    private void OnButtonClickedEvent(object sender, EventArgs e)
    {
        count++;
        lblCounter.Text = $"Click Count: {count}";

        SemanticScreenReader.Announce(lblCounter.Text);
    }

}