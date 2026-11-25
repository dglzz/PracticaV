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

        int[] numeros = new int[cantidad];
        for (int i = 0; i < cantidad; i++)
        {
            while (true)
            {
                Console.Write($"Introduce el número {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.CurrentCulture, out numeros[i]))
                {
                    break;
                }
                Console.WriteLine("Valor no válido. Introduce un número entero.");
            }
        }

        double mediana = CalcularMediana(numeros);
        Console.WriteLine($"La mediana es: {mediana}");
    }

    static double CalcularMediana(int[] array)
    {
        int[] ordenado = (int[])array.Clone();
        Array.Sort(ordenado);

        int n = ordenado.Length;
        int mitad = n / 2;

        if (n % 2 == 0)
        {
            return (ordenado[mitad - 1] + ordenado[mitad]) / 2.0;
        }
        else
        {
            return ordenado[mitad];
        }
    }
}