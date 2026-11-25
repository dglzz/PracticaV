using System;

class Program
{
    static void Main()
    {
        long totalSegundos;
        while (true)
        {
            Console.Write("Introduce el número de segundos: ");
            if (long.TryParse(Console.ReadLine(), out totalSegundos) && totalSegundos >= 0)
            {
                break;
            }
            Console.WriteLine("Valor no válido. Introduce un número entero mayor o igual que 0.");
        }

        ConvertirSegundos(totalSegundos, out long horas, out long minutos, out long segundos);
        Console.WriteLine($"{totalSegundos} segundos son {horas} hora, {minutos} min, y {segundos} segundos.");
    }

    static void ConvertirSegundos(long totalSegundos, out long horas, out long minutos, out long segundos)
    {
        horas = totalSegundos / 3600;
        long resto = totalSegundos % 3600;
        minutos = resto / 60;
        segundos = resto % 60;
    }
}