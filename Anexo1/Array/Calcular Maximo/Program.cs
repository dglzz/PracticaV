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

        int maximo = CalcularMaximo(numeros);
        Console.WriteLine($"El número máximo es: {maximo}");
    }

    static int CalcularMaximo(int[] array)
    {
        int maximo = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > maximo)
            {
                maximo = array[i];
            }
        }
        return maximo;
    }
}