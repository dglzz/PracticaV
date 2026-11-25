using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("              MENÚ DE EJERCICIOS          ");
            Console.WriteLine("==========================================");
            Console.WriteLine("1. Comprobar si un número es primo");
            Console.WriteLine("2. Calcular el factorial de un número");
            Console.WriteLine("3. Convertir segundos a horas, min y seg");
            Console.WriteLine("4. Primeros 15 números de la serie de Pell");
            Console.WriteLine("5. Comprobar si es número de Armstrong");
            Console.WriteLine("6. Comprobar si todos los dígitos son diferentes");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opción: ");

            string opcion = Console.ReadLine()?.Trim() ?? "";
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    OpcionEsPrimo();
                    break;
                case "2":
                    OpcionFactorial();
                    break;
                case "3":
                    OpcionConvertirSegundos();
                    break;
                case "4":
                    OpcionSeriePell();
                    break;
                case "5":
                    OpcionNumeroArmstrong();
                    break;
                case "6":
                    OpcionDigitosDiferentes();
                    break;
                case "0":
                    salir = true;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Elige un número del 0 al 6.");
                    break;
            }
        }
    }

    static void OpcionEsPrimo()
    {
        int numero = LeerEntero("Introduce un número entero: ");
        if (EsPrimo(numero))
        {
            Console.WriteLine($"El número {numero} SÍ es primo.");
        }
        else
        {
            Console.WriteLine($"El número {numero} NO es primo.");
        }
    }

    static void OpcionFactorial()
    {
        int numero = LeerEnteroNoNegativo("Introduce un número entero mayor o igual que 0: ");
        BigInteger factorial = CalcularFactorial(numero);
        Console.WriteLine($"El factorial de {numero} ({numero}!) es: {factorial}");
    }

    static void OpcionConvertirSegundos()
    {
        long totalSegundos = LeerLongNoNegativo("Introduce el número de segundos: ");
        ConvertirSegundos(totalSegundos, out long horas, out long minutos, out long segundos);
        Console.WriteLine($"{totalSegundos} segundos son {horas} hora, {minutos} min, y {segundos} segundos.");
    }

    static void OpcionSeriePell()
    {
        int cantidad = 15;
        long[] seriePell = CalcularSeriePell(cantidad);
        Console.WriteLine($"Los primeros {cantidad} números de la serie de Pell son:");
        Console.WriteLine(string.Join(", ", seriePell));
    }

    static void OpcionNumeroArmstrong()
    {
        long numero = LeerLongNoNegativo("Introduce un número entero mayor o igual que 0: ");
        if (EsNumeroArmstrong(numero))
        {
            Console.WriteLine($"El número {numero} SÍ es un número de Armstrong.");
        }
        else
        {
            Console.WriteLine($"El número {numero} NO es un número de Armstrong.");
        }
    }

    static void OpcionDigitosDiferentes()
    {
        long numero = LeerLong("Introduce un número entero: ");
        if (TieneDigitosDiferentes(numero))
        {
            Console.WriteLine($"El número {numero} SÍ tiene todos sus dígitos diferentes.");
        }
        else
        {
            Console.WriteLine($"El número {numero} NO tiene todos sus dígitos diferentes.");
        }
    }

    // --- Lectura validada por teclado ---

    static int LeerEntero(string mensaje)
    {
        int valor;
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out valor))
            {
                return valor;
            }
            Console.WriteLine("Valor no válido. Introduce un número entero.");
        }
    }

    static int LeerEnteroNoNegativo(string mensaje)
    {
        while (true)
        {
            int valor = LeerEntero(mensaje);
            if (valor >= 0)
            {
                return valor;
            }
            Console.WriteLine("El número debe ser mayor o igual que 0.");
        }
    }

    static long LeerLong(string mensaje)
    {
        long valor;
        while (true)
        {
            Console.Write(mensaje);
            if (long.TryParse(Console.ReadLine(), out valor))
            {
                return valor;
            }
            Console.WriteLine("Valor no válido. Introduce un número entero.");
        }
    }

    static long LeerLongNoNegativo(string mensaje)
    {
        while (true)
        {
            long valor = LeerLong(mensaje);
            if (valor >= 0)
            {
                return valor;
            }
            Console.WriteLine("El número debe ser mayor o igual que 0.");
        }
    }

    // --- Funciones de cálculo ---

    static bool EsPrimo(int n)
    {
        if (n <= 1) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;

        int limite = (int)Math.Sqrt(n);
        for (int divisor = 3; divisor <= limite; divisor += 2)
        {
            if (n % divisor == 0) return false;
        }
        return true;
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

    static void ConvertirSegundos(long totalSegundos, out long horas, out long minutos, out long segundos)
    {
        horas = totalSegundos / 3600;
        long resto = totalSegundos % 3600;
        minutos = resto / 60;
        segundos = resto % 60;
    }

    static long[] CalcularSeriePell(int cantidad)
    {
        if (cantidad <= 0) return Array.Empty<long>();

        long[] serie = new long[cantidad];
        if (cantidad >= 1) serie[0] = 0;
        if (cantidad >= 2) serie[1] = 1;

        for (int i = 2; i < cantidad; i++)
        {
            serie[i] = 2 * serie[i - 1] + serie[i - 2];
        }
        return serie;
    }

    static bool EsNumeroArmstrong(long numero)
    {
        if (numero < 0) return false;

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

    static bool TieneDigitosDiferentes(long numero)
    {
        long valor = Math.Abs(numero);
        bool[] vistos = new bool[10];

        while (valor > 0)
        {
            int digito = (int)(valor % 10);
            if (vistos[digito]) return false;
            vistos[digito] = true;
            valor /= 10;
        }

        return true;
    }
}