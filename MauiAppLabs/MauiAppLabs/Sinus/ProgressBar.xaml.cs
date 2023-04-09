using System;

namespace MauiAppLabs.Sinus;

public partial class ProgressBar : ContentPage
{
    static CancellationTokenSource cts = new CancellationTokenSource();
    CancellationToken ct = cts.Token;

    private Progress progress;

    bool isActive = false;

    public ProgressBar()
	{
		InitializeComponent();
        
        progress = new();
        progress.progress += (int progress) =>
        {
            labelProcent.Text = $"{progress}%";
            progressBar.Progress = (double)progress / 100;
        };
    }

    
    async void OnStart(object sender, EventArgs e)
    {
        if (isActive) 
            return;

        labelText.Text = "Calculating...";
        isActive = true;
        double result = await CalculateAsync(progress);

        if (result != -1)
            labelText.Text = $"Result = {result}";
        isActive = false;
    }

    private async Task<double> CalculateAsync(Progress progress)
    {
        return await Task.Run(() => CalculateIntegral(progress));
    }

    private double CalculateIntegral(Progress progress)
    {
        //Progress progress = new Progress();

        double h = 0.00000001;
        double a = 0;
        double b = 1;

        int n = (int)((int)(b - a) / h);
        int path = n / 100;
        int percentage = 0;

        double result = 0;
        int k = 0;

        for (double x = a; x <= b; x += h)
        {
            if (ct.IsCancellationRequested)
                return -1;

            result += Math.Sin(x) * h;

            for (int i = 0; i < 10; i++)
            {
                int wait = 10 * 2;
            }

            k++;
            if(k > percentage * path)
            {
                percentage++;
                MainThread.BeginInvokeOnMainThread(() => progress.Report(percentage));
            }
        }
        return result;
    }

    void OnCancel(object sender, EventArgs e)
    {
        labelText.Text = "Calculation was canceled!";
        cts.Cancel();
        cts.Dispose();

        isActive = false;
        cts = new();
        ct = cts.Token;
    }
}