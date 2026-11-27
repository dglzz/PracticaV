
namespace MenuDecimales
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
 
            do
            {
                Console.WriteLine();
                Console.WriteLine("===== DECIMALES =====");
                Console.WriteLine("1. Redondear el número al alza");
                Console.WriteLine("2. Eliminar los decimales del número");
                Console.WriteLine("3. Ecuación de segundo grado");
                Console.WriteLine("0. Salir");
                Console.Write("Elige una opción: ");
 
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = -1;
                }
 
                switch (opcion)
                {
                    case 1:
                        RedondearAlza();
                        break;
                    case 2:
                        EliminarDecimales();
                        break;
                    case 3:
                        EcuacionSegundoGrado();
                        break;
                    case 0:
                        Console.WriteLine("¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 0);
        }
 
        static double LeerDouble(string mensaje)
        {
            double valor;
            Console.Write(mensaje);
            while (!double.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write("Valor no válido. " + mensaje);
            }
            return valor;
        }
 
        static void RedondearAlza()
        {
            double n = LeerDouble("Introduce un número: ");
            Console.WriteLine("Redondeado al alza: " + Math.Ceiling(n));
        }
 
        static void EliminarDecimales()
        {
            double n = LeerDouble("Introduce un número: ");
            Console.WriteLine("Sin decimales: " + Math.Truncate(n));
        }
 
        static void EcuacionSegundoGrado()
        {
            Console.WriteLine("Ecuación: ax² + bx + c = 0");
            double a = LeerDouble("a = ");
            double b = LeerDouble("b = ");
            double c = LeerDouble("c = ");
 
            if (a == 0)
            {
                // Degenera en ecuación de primer grado: bx + c = 0
                if (b == 0)
                {
                    Console.WriteLine(c == 0
                        ? "Infinitas soluciones."
                        : "No tiene solución.");
                }
                else
                {
                    Console.WriteLine("No es de segundo grado. x = " + (-c / b));
                }
                return;
            }
 
            double discriminante = b * b - 4 * a * c;
 
            if (discriminante > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminante)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminante)) / (2 * a);
                Console.WriteLine("Dos soluciones reales:");
                Console.WriteLine("x1 = " + x1);
                Console.WriteLine("x2 = " + x2);
            }
            else if (discriminante == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine("Una solución doble: x = " + x);
            }
            else
            {
                Console.WriteLine("No tiene soluciones reales (discriminante negativo).");
            }
        }
    }
}
 