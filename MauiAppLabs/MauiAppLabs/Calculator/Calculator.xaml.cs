//using static Android.Renderscripts.ScriptGroup;

namespace MauiAppLabs.Calculator;

public partial class Calculator1 : ContentPage
{
    public Calculator1()
    {
        InitializeComponent();
    }

    double firstNum, secondNum;
    int status = 0; //0 - ничего, -1 - унарная операция, -2 - бинарная операция, 1-9 - число

    bool wasOperation = false;
    bool NumberIsDouble = false;

    private void NumberButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string btnClicked = button.Text;

        FirstOrSecondNum(btnClicked, button);
    }

    private void FirstOrSecondNum(string Num, Button b)
    {
        if (status == 0)
            firstNum = Number(Num, b, firstNum);
        else
            secondNum = Number(Num, b, secondNum);
    }

    private double Number(string Num, Button b, double first_or_second)
    {
        if (status == 9)
            return first_or_second;

        if (status == 0)
        {
            Input.Text = "";
            Result.Text = "";
        }

        Input.Text = Input.Text + b.Text;
        Result.Text = Result.Text + b.Text;
        first_or_second = Convert.ToDouble(Result.Text);
        status++;

        return first_or_second;
    }

    private void ModulButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        if (status < 1)
            return;

        firstNum = -firstNum;
        Input.Text = Convert.ToString(firstNum);
        Result.Text = Convert.ToString(firstNum);
    }

    private void DoubleButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        if (status < 1 | NumberIsDouble)
            return;

        NumberIsDouble = true;
        Input.Text = Input.Text + ",";
        Result.Text = Result.Text + ",";
    }

    private void PlusButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        if (status == 0)
            return;

        CheckOperation();
        Calculate.DataOfOperation(out wasOperation, out status, button.Text);
        OutputOperation(button);
    }

    private void MinusButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        if (status == 0)
            return;

        CheckOperation();
        Calculate.DataOfOperation(out wasOperation, out status, button.Text);
        OutputOperation(button);
    }

    private void MulButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        if (status == 0)
            return;

        CheckOperation();
        Calculate.DataOfOperation(out wasOperation, out status, button.Text);
        OutputOperation(button);
    }

    private void DelButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        if (status == 0)
            return;

        CheckOperation();
        Calculate.DataOfOperation(out wasOperation, out status, button.Text);
        OutputOperation(button);
    }

    private void ModButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        if (status == 0)
            return;

        CheckOperation();
        Calculate.DataOfOperation(out wasOperation, out status, button.Text);
        OutputOperation(button);
    }

    private void CheckOperation()
    {
        if (status == -2 | status == -1)
            Input.Text = Calculate.ChangeOperation(Input.Text);

        if (wasOperation && status == -2)
            firstNum = Calculate.Equal(firstNum, secondNum);
    }

    private void OutputOperation(Button b)
    {
        Input.Text = Input.Text + b.Text;
        Result.Text = "";
    }

    private void EqualButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        Input.Text = firstNum + Calculate.operation + secondNum;

        firstNum = Calculate.Equal(firstNum, secondNum);

        Result.Text = Convert.ToString(firstNum);
    }

    private void ReverseButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        if (status > 0)
        {
            Calculate.operation = "reverse";
            Input.Text = "1/" + firstNum;
            firstNum = Calculate.Reverse(firstNum, out status);
            Result.Text = Convert.ToString(firstNum);
        }
    }

    private void PowButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        if (status > 0)
        {
            Input.Text = firstNum + "2";
            firstNum = Calculate.Pow(firstNum, out status);
            Result.Text = Convert.ToString(firstNum);
        }
    }

    private void SqrtButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        if (status > 0)
        {
            Calculate.operation = "sqrt";
            Input.Text = "√" + firstNum;
            firstNum = Calculate.Sqrt(firstNum, out status);
            Result.Text = Convert.ToString(firstNum);
        }
    }

    private void PercentButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        if (status > 0)
        {
            Input.Text = firstNum + "%";
            firstNum = Calculate.Percent(firstNum, out status);
            Result.Text = Convert.ToString(firstNum);
        }
    }

    private void CButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        DeleteAll();
    }

    private void DeButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        if (Input.Text.Length == 0)
        {
            Result.Text = "0";
            Input.Text = "";
            return;
        }

        Input.Text = Input.Text.Substring(0, Input.Text.Length - 1);
        Result.Text = Result.Text.Substring(0, Result.Text.Length - 1);
        Button btn = new Button();
        btn.Text = "";
        FirstOrSecondNum(Result.Text, btn);
    }


    private void DeleteAll()
    {
        firstNum = 0;
        secondNum = 0;
        status = 0;
        //doubl = false;
        Calculate.error = false;
        wasOperation = false;
        Input.Text = "";
        Result.Text = "";
    }
}