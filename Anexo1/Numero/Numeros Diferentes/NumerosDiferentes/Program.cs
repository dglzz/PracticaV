using System;

class Program
{
    static void Main()
    {
        long numero;
        while (true)
        {
            Console.Write("Introduce un número entero: ");
            if (long.TryParse(Console.ReadLine(), out numero))
            {
                break;
            }
            Console.WriteLine("Valor no válido. Introduce un número entero.");
        }

        if (TieneDigitosDiferentes(numero))
        {
            Console.WriteLine($"El número {numero} SÍ tiene todos sus dígitos diferentes.");
        }
        else
        {
            Console.WriteLine($"El número {numero} NO tiene todos sus dígitos diferentes (hay dígitos repetidos).");
        }
    }

    static bool TieneDigitosDiferentes(long numero)
    {
        long valor = Math.Abs(numero);
        bool[] vistos = new bool[10];

        while (valor > 0)
        {
            int digito = (int)(valor % 10);
            if (vistos[digito])
            {
                return false;
            }
            vistos[digito] = true;
            valor /= 10;
        }

        return true;
    }
}