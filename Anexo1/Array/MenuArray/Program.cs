using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        double[] arrayActual = Array.Empty<double>();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine();
            Console.WriteLine("=======================================================");
            Console.WriteLine("               MENÚ DE FUNCIONES CON ARRAYS            ");
            Console.WriteLine("=======================================================");
            Console.WriteLine("1. Introducir / cambiar el array");
            Console.WriteLine("2. Mostrar el array actual");
            Console.WriteLine("3. Calcular máximo");
            Console.WriteLine("4. Calcular mínimo");
            Console.WriteLine("5. Calcular la mediana");
            Console.WriteLine("6. Calcular la media");
            Console.WriteLine("7. Ordenar un array de menor a mayor");
            Console.WriteLine("8. Calcular la desviación típica");
            Console.WriteLine("9. Binarizar un array en base a un número n");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opción: ");

            string opcion = Console.ReadLine()?.Trim() ?? "";
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    arrayActual = LeerArrayPorTeclado();
                    Console.WriteLine("Array guardado: [" + string.Join(", ", arrayActual) + "]");
                    break;
                case "2":
                    MostrarArray(arrayActual);
                    break;
                case "3":
                    AsegurarArray(ref arrayActual);
                    Console.WriteLine($"Máximo: {CalcularMaximo(arrayActual)}");
                    break;
                case "4":
                    AsegurarArray(ref arrayActual);
                    Console.WriteLine($"Mínimo: {CalcularMinimo(arrayActual)}");
                    break;
                case "5":
                    AsegurarArray(ref arrayActual);
                    Console.WriteLine($"Mediana: {CalcularMediana(arrayActual)}");
                    break;
                case "6":
                    AsegurarArray(ref arrayActual);
                    Console.WriteLine($"Media: {CalcularMedia(arrayActual)}");
                    break;
                case "7":
                    AsegurarArray(ref arrayActual);
                    double[] ordenado = OrdenarMenorAMayor(arrayActual);
                    Console.WriteLine("Array ordenado (menor a mayor): [" + string.Join(", ", ordenado) + "]");
                    break;
                case "8":
                    AsegurarArray(ref arrayActual);
                    Console.WriteLine($"Desviación típica: {CalcularDesviacionTipica(arrayActual)}");
                    break;
                case "9":
                    AsegurarArray(ref arrayActual);
                    double umbral = LeerDouble("Introduce el valor umbral n: ");
                    int[] binarizado = BinarizarArray(arrayActual, umbral);
                    Console.WriteLine($"Array binarizado (n = {umbral}): [" + string.Join(", ", binarizado) + "]");
                    break;
                case "0":
                    salir = true;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Elige un número del 0 al 9.");
                    break;
            }
        }
    }

    static void AsegurarArray(ref double[] arrayActual)
    {
        if (arrayActual.Length == 0)
        {
            Console.WriteLine("No hay ningún array cargado todavía. Vamos a introducirlo:");
            arrayActual = LeerArrayPorTeclado();
        }
    }

    static void MostrarArray(double[] array)
    {
        if (array.Length == 0)
        {
            Console.WriteLine("El array está vacío. Usa primero la opción 1.");
            return;
        }

        Console.WriteLine("Array actual: [" + string.Join(", ", array) + "]");
    }

    // --- Entrada de datos ---

    static double[] LeerArrayPorTeclado()
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
            numeros[i] = LeerDouble($"Introduce el número {i + 1}: ");
        }

        return numeros;
    }

    static double LeerDouble(string mensaje)
    {
        double valor;
        while (true)
        {
            Console.Write(mensaje);
            if (double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.CurrentCulture, out valor))
            {
                return valor;
            }
            Console.WriteLine("Valor no válido. Introduce un número.");
        }
    }

    // --- Funciones solicitadas ---

    static double CalcularMaximo(double[] array)
    {
        double max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }
        return max;
    }

    static double CalcularMinimo(double[] array)
    {
        double min = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }
        }
        return min;
    }

    static double CalcularMediana(double[] array)
    {
        double[] copiaOrdenada = OrdenarMenorAMayor(array);
        int n = copiaOrdenada.Length;
        int mitad = n / 2;

        if (n % 2 == 1)
        {
            return copiaOrdenada[mitad];
        }

        return (copiaOrdenada[mitad - 1] + copiaOrdenada[mitad]) / 2.0;
    }

    static double CalcularMedia(double[] array)
    {
        double suma = 0;
        for (int i = 0; i < array.Length; i++)
        {
            suma += array[i];
        }
        return suma / array.Length;
    }

    static double[] OrdenarMenorAMayor(double[] array)
    {
        double[] resultado = (double[])array.Clone();
        for (int i = 0; i < resultado.Length - 1; i++)
        {
            for (int j = 0; j < resultado.Length - 1 - i; j++)
            {
                if (resultado[j] > resultado[j + 1])
                {
                    double temp = resultado[j];
                    resultado[j] = resultado[j + 1];
                    resultado[j + 1] = temp;
                }
            }
        }
        return resultado;
    }

    static double CalcularDesviacionTipica(double[] array)
    {
        double media = CalcularMedia(array);
        double sumaCuadrados = 0;

        for (int i = 0; i < array.Length; i++)
        {
            double diferencia = array[i] - media;
            sumaCuadrados += diferencia * diferencia;
        }

        return Math.Sqrt(sumaCuadrados / array.Length);
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