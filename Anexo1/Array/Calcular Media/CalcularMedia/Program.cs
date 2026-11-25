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

        double media = CalcularMedia(numeros);
        Console.WriteLine($"La media es: {media}");
    }

    static double CalcularMedia(int[] array)
    {
        long suma = 0;
        for (int i = 0; i < array.Length; i++)
        {
            suma += array[i];
        }
        return (double)suma / array.Length;
    }
}