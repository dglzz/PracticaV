using System;

class Program
{
    static void Main()
    {
        int numero;
        while (true)
        {
            Console.Write("Introduce un número entero: ");
            if (int.TryParse(Console.ReadLine(), out numero))
            {
                break;
            }
            Console.WriteLine("Valor no válido. Introduce un número entero.");
        }

        if (EsPrimo(numero))
        {
            Console.WriteLine($"El número {numero} ES primo.");
        }
        else
        {
            Console.WriteLine($"El número {numero} NO es primo.");
        }
    }

    static bool EsPrimo(int n)
    {
        if (n <= 1)
        {
            return false;
        }

        if (n == 2)
        {
            return true;
        }

        if (n % 2 == 0)
        {
            return false;
        }

        int limite = (int)Math.Sqrt(n);
        for (int divisor = 3; divisor <= limite; divisor += 2)
        {
            if (n % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }
}