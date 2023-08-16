namespace SampleMauiApp;

public partial class FirstPageV1 : ContentPage
{
    private int count;

    public FirstPageV1()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        count++;
        lblCounter.Text = $"Click Count: {count}";

        SemanticScreenReader.Announce(lblCounter.Text);
    }
}