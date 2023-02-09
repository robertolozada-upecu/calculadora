namespace Calculadora;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
        OnClear(this, null);

    }

    string currentEntry = "";
    string mathOperator;
    double firstNumber, secondNumber;
    public enum State {NoNumbers, FirstNumberOk, OperatorOk, SecondNumberOk};
    public State currentState = State.NoNumbers;



    void OnSelectNumber(object sender, EventArgs e)
    {

        Button button = (Button)sender;
        string pressed = button.Text;

        currentEntry += pressed;

        if ((this.resultText.Text == "0" && pressed == "0")
            || (currentEntry.Length <= 1 && pressed != "0")
            || currentState==State.OperatorOk)
        {
            this.resultText.Text = "";
            if (currentState == State.OperatorOk)
                currentState = State.FirstNumberOk;
        }

        this.resultText.Text += pressed;
    }

    void OnSelectOperator(object sender, EventArgs e)
    {
        if (currentState!=State.OperatorOk)
            LockNumberValue(resultText.Text);
        currentState = State.OperatorOk;
        Button button = (Button)sender;
        string pressed = button.Text;
        mathOperator = pressed;

    }

    private void LockNumberValue(string text)
    {
        double number = Convert.ToDouble(text);
        if (currentState==State.NoNumbers)
        {
            firstNumber = number;
        }
        else
        {
            secondNumber = number;
        }
        currentEntry = string.Empty;
    }

    void OnClear(object sender, EventArgs e)
    {
        firstNumber = 0;
        secondNumber = 0;
        currentState = State.NoNumbers;
        this.resultText.Text = "0";
        currentEntry = string.Empty;
        CurrentCalculation.Text = string.Empty;
    }

    void OnCalculate(object sender, EventArgs e)
    {
        if (currentState==State.FirstNumberOk)
        {
            if (secondNumber == 0)
                LockNumberValue(resultText.Text);

            double result = Calculadora.Calculate(firstNumber, secondNumber, mathOperator);

            this.CurrentCalculation.Text = $"{firstNumber} {mathOperator} {secondNumber}";

            this.resultText.Text = result.ToString();
            firstNumber = result;
            secondNumber = 0;
            currentState = State.OperatorOk;
            currentEntry = string.Empty;
        }
    }

    void OnNegative(object sender, EventArgs e)
    {
        if (resultText.Text != "0")
        {
            LockNumberValue(resultText.Text);
            if (currentState==State.NoNumbers)
            {
                firstNumber *= -1;
                resultText.Text = firstNumber.ToString();
            }
            else
            {
                secondNumber *= -1;
                resultText.Text = secondNumber.ToString();
            }
        }
    }
}

