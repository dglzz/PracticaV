using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        int numero;
        while (true)
        {
            Console.Write("Introduce un número entero mayor o igual que 0: ");
            if (int.TryParse(Console.ReadLine(), out numero) && numero >= 0)
            {
                break;
            }
            Console.WriteLine("Valor no válido. Introduce un entero no negativo.");
        }

        BigInteger factorial = CalcularFactorial(numero);
        Console.WriteLine($"El factorial de {numero} ({numero}!) es: {factorial}");
    }

    static BigInteger CalcularFactorial(int n)
    {
        BigInteger resultado = 1;
        for (int i = 2; i <= n; i++)
        {
            resultado *= i;
        }
        return resultado;
    }
}