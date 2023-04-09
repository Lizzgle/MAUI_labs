
namespace MauiAppLabs.Tourism;

public partial class TourismView : ContentPage
{
    VMTouristRoutes _VMTouristRoutes;
    public TourismView(IDbService model)
    {
		InitializeComponent();
        _VMTouristRoutes = new VMTouristRoutes((SQLiteService)model);
        BindingContext = _VMTouristRoutes;
    }

    private void TouristRoutesPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (TouristRoutesPicker.SelectedIndex == -1)
            return;
        _VMTouristRoutes.ChangedCocktail(TouristRoutesPicker.SelectedIndex + 1);
    }
}