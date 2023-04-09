namespace MauiAppLabs.Converter;

public partial class ConverterView : ContentPage
{
    CurConverterVM converterVM;
    public ConverterView(CurConverterVM curConverter)
    {
        InitializeComponent();
        CurDatePicker.MinimumDate = new DateTime(1996, 1, 1);
        CurDatePicker.MaximumDate = DateTime.Now;

        this.converterVM = curConverter;
        BindingContext = converterVM;

    }

    private void BelCur_Completed(object sender, EventArgs e)
    {
        converterVM.InputBel();
    }

    private void ForeignCur_Completed(object sender, EventArgs e)
    {
        converterVM.InputForeign();
    }

    private async void CurDatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (CurDatePicker.MaximumDate != DateTime.Now)
        {
            CurDatePicker.MaximumDate = DateTime.Now;
        }

        try
        {
            await converterVM.GetNBRBRates(((DatePicker)sender).Date);
        }
        catch (Exception)
        {
            await DisplayAlert("Ошибка", "Проблемы с интернет соединением", "Понял");
        }
    }

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        try
        {
            await converterVM.GetNBRBRates(DateTime.Now);
            await converterVM.GetNBRBRates(DateTime.Now);
            CurDatePicker.Date = DateTime.Now;
        }
        catch (Exception)
        {
            await DisplayAlert("Ошибка", "Проблемы с интернет соединением", "Понял");
        }
    }
}