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

        double umbral;
        while (true)
        {
            Console.Write("Introduce el valor umbral n: ");
            if (double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.CurrentCulture, out umbral))
            {
                break;
            }
            Console.WriteLine("Valor no válido. Introduce un número para n.");
        }

        int[] binarizado = BinarizarArray(numeros, umbral);
        Console.WriteLine("Array original: [" + string.Join(", ", numeros) + "]");
        Console.WriteLine($"Array binarizado (umbral n = {umbral}): [" + string.Join(", ", binarizado) + "]");
    }

    static int[] BinarizarArray(double[] array, double n)
    {
        int[] resultado = new int[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            resultado[i] = array[i] < n ? 0 : 1;
        }

        return resultado;
    }
}