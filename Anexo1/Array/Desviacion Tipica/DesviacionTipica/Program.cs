using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        int cantidad;
        while (true)
        {
            Console.Write("¿Cuántos números vas a introducir?: ");
            if (int.TryParse(Console.ReadLine(), out cantidad) && cantidad > 0)
            {
                break;
            }
            Console.WriteLine("Introduce un número entero mayor que 0.");
        }

        double[] numeros = new double[cantidad];
        for (int i = 0; i < cantidad; i++)
        {
            while (true)
            {
                Console.Write($"Introduce el número {i + 1}: ");
                if (double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.CurrentCulture, out numeros[i]))
                {
                    break;
                }
                Console.WriteLine("Valor no válido. Introduce un número.");
            }
        }

        double desviacion = CalcularDesviacionTipica(numeros);
        Console.WriteLine($"Desviación típica: {desviacion:F4}");
    }

    static double CalcularDesviacionTipica(double[] datos)
    {
        if (datos.Length < 2)
        {
            return 0.0;
        }

        double media = 0.0;
        for (int i = 0; i < datos.Length; i++)
        {
            media += datos[i];
        }
        media /= datos.Length;

        double sumaCuadrados = 0.0;
        for (int i = 0; i < datos.Length; i++)
        {
            double diferencia = datos[i] - media;
            sumaCuadrados += diferencia * diferencia;
        }

        double varianza = sumaCuadrados / (datos.Length - 1);
        return Math.Sqrt(varianza);
    }
}