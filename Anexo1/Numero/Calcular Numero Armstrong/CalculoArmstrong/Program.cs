using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        long numero;
        while (true)
        {
            Console.Write("Introduce un número entero mayor o igual que 0: ");
            if (long.TryParse(Console.ReadLine(), out numero) && numero >= 0)
            {
                break;
            }
            Console.WriteLine("Valor no válido. Introduce un número entero mayor o igual que 0.");
        }

        if (EsNumeroArmstrong(numero))
        {
            Console.WriteLine($"El número {numero} SÍ es un número de Armstrong.");
        }
        else
        {
            Console.WriteLine($"El número {numero} NO es un número de Armstrong.");
        }
    }

    static bool EsNumeroArmstrong(long numero)
    {
        if (numero < 0)
        {
            return false;
        }

        string texto = numero.ToString();
        int cantidadDigitos = texto.Length;
        BigInteger suma = 0;

        foreach (char c in texto)
        {
            int digito = c - '0';
            suma += BigInteger.Pow(digito, cantidadDigitos);
        }

        return suma == numero;
    }
}