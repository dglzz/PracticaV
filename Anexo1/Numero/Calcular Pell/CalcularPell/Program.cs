using System;

class Program
{
    static void Main()
    {
        int cantidad = 15;
        long[] seriePell = CalcularSeriePell(cantidad);

        Console.WriteLine($"Los primeros {cantidad} números de la serie de Pell son:");
        Console.WriteLine(string.Join(", ", seriePell));
    }

    static long[] CalcularSeriePell(int cantidad)
    {
        if (cantidad <= 0)
        {
            return Array.Empty<long>();
        }

        long[] serie = new long[cantidad];

        if (cantidad >= 1)
        {
            serie[0] = 0;
        }

        if (cantidad >= 2)
        {
            serie[1] = 1;
        }

        for (int i = 2; i < cantidad; i++)
        {
            serie[i] = 2 * serie[i - 1] + serie[i - 2];
        }

        return serie;
    }
}