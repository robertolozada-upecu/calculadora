namespace Calculadora;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();

    }

    double numeroUno, numeroDos;
    string operador;

    void SeleccionarNumero(object sender, EventArgs e)
    {
        Button boton = (Button) sender;
        if (numerosResultado.Text == "0" && numerosResultado.Text.Length == 1 & boton.Text != ".")
        {
            numerosResultado.Text = boton.Text;
        }
        else
        {
            numerosResultado.Text += boton.Text;
        }

    }

    void LimpiarIngreso(object sender, EventArgs e)
    {
        numerosResultado.Text = "0";
        operacionResultado.Text = "";

    }

    void NumeroNegativo(object sender, EventArgs e)
    {
        if(numerosResultado.Text != "0")
        {
            if (numerosResultado.Text.StartsWith("-"))
                numerosResultado.Text = numerosResultado.Text.Remove(0, 1);
            else
                numerosResultado.Text = "-" + numerosResultado.Text;
        }    

    }

    void SeleccionarOperacion(object sender, EventArgs e)
    {
        Button boton = (Button)sender;
        numeroUno = Convert.ToDouble(numerosResultado.Text);
        operador = boton.Text;
        operacionResultado.Text = $"{numeroUno} {operador}";
        numerosResultado.Text = "";
    }

    void Calcular(object sender, EventArgs e)
    {
        numeroDos = Convert.ToDouble(numerosResultado.Text);
        double resultado = Calculadora.Calculate(numeroUno, numeroDos, operador);
        operacionResultado.Text = $"{numeroUno} {operador} {numeroDos} =";
        numerosResultado.Text = resultado.ToString();
        numeroUno = resultado;
    }
}




    