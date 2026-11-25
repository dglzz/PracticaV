using System.Text;
using StringOperations;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

bool salir = false;
while (!salir)
{
    MostrarMenu();
    string opcion = LeerTexto("Selecciona una opción: ");
    Console.WriteLine();

    switch (opcion)
    {
        case "1":
            string t1 = LeerTexto("Introduce un texto: ");
            Console.WriteLine(StringUtils.EsPalindromo(t1)
                ? "-> Es un palíndromo."
                : "-> NO es un palíndromo.");
            break;

        case "2":
            string t2 = LeerTexto("Introduce un nombre: ");
            Console.WriteLine($"-> Mayúsculas: {StringUtils.AMayusculas(t2)}");
            Console.WriteLine($"-> Minúsculas: {StringUtils.AMinusculas(t2)}");
            break;

        case "3":
            string t3 = LeerTexto("Introduce un texto: ");
            char letra = LeerCaracter("Introduce la letra a contar: ");
            int total = StringUtils.ContarOcurrencias(t3, letra);
            Console.WriteLine($"-> La letra '{letra}' aparece {total} vez/veces.");
            break;

        case "4":
            string a = LeerTexto("Introduce el primer texto: ");
            string b = LeerTexto("Introduce el segundo texto: ");
            int veces = LeerEntero("¿Cuántas veces se repite?: ");
            Console.WriteLine($"-> {StringUtils.RepetirCadenas(a, b, veces)}");
            break;

        case "5":
            string t5 = LeerTexto("Introduce un texto: ");
            Console.WriteLine($"-> {StringUtils.DuplicarLetras(t5)}");
            break;

        case "6":
            string original = LeerTexto("Introduce el texto original: ");
            string borrar = LeerTexto("Introduce el texto a borrar: ");
            Console.WriteLine($"-> {StringUtils.BorrarApariciones(original, borrar)}");
            break;

        case "0":
            salir = true;
            Console.WriteLine("¡Hasta pronto!");
            break;

        default:
            Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
            break;
    }

    if (!salir)
    {
        Console.WriteLine();
        Console.Write("Pulsa ENTER para continuar...");
        Console.ReadLine();
        Console.Clear();
    }
}

static void MostrarMenu()
{
    Console.WriteLine("========== PROYECTO STRING ==========");
    Console.WriteLine("1. Comprobar si un texto es palíndromo");
    Console.WriteLine("2. Nombre en mayúsculas y minúsculas");
    Console.WriteLine("3. Contar ocurrencias de una letra");
    Console.WriteLine("4. Repetir dos textos N veces");
    Console.WriteLine("5. Duplicar cada letra de un texto");
    Console.WriteLine("6. Borrar apariciones de un texto en otro");
    Console.WriteLine("0. Salir");
    Console.WriteLine("=====================================");
}

static string LeerTexto(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        string? entrada = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(entrada))
            return entrada.Trim();
        Console.WriteLine("El texto no puede estar vacío.");
    }
}

static char LeerCaracter(string mensaje)
{
    while (true)
    {
        string entrada = LeerTexto(mensaje);
        if (entrada.Length == 1)
            return entrada[0];
        Console.WriteLine("Introduce un único carácter.");
    }
}

static int LeerEntero(string mensaje)
{
    while (true)
    {
        string entrada = LeerTexto(mensaje);
        if (int.TryParse(entrada, out int valor) && valor >= 0)
            return valor;
        Console.WriteLine("Introduce un número entero no negativo.");
    }
}
