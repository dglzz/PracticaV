using System.Globalization;
using System.Text;

namespace StringOperations;

/// <summary>
/// Funcionalidades del proyecto String.
/// </summary>
public static class StringUtils
{
    /// <summary>
    /// 1. Indica si el texto es un palíndromo (ignora mayúsculas, espacios,
    /// signos de puntuación y tildes).
    /// </summary>
    public static bool EsPalindromo(string texto)
    {
        var sb = new StringBuilder();
        foreach (char c in texto.Normalize(NormalizationForm.FormD))
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) == UnicodeCategory.NonSpacingMark)
                continue; // descarta las tildes
            if (char.IsLetterOrDigit(c))
                sb.Append(char.ToLowerInvariant(c));
        }

        string limpio = sb.ToString();
        for (int i = 0, j = limpio.Length - 1; i < j; i++, j--)
        {
            if (limpio[i] != limpio[j])
                return false;
        }
        return true;
    }

    /// <summary>2. Devuelve el texto en mayúsculas.</summary>
    public static string AMayusculas(string texto) => texto.ToUpper();

    /// <summary>2. Devuelve el texto en minúsculas.</summary>
    public static string AMinusculas(string texto) => texto.ToLower();

    /// <summary>
    /// 3. Número de ocurrencias de una letra (sin distinguir mayúsculas de minúsculas).
    /// </summary>
    public static int ContarOcurrencias(string texto, char letra)
    {
        char objetivo = char.ToLowerInvariant(letra);
        int contador = 0;
        foreach (char c in texto)
        {
            if (char.ToLowerInvariant(c) == objetivo)
                contador++;
        }
        return contador;
    }

    /// <summary>
    /// 4. Repite el par de cadenas el número de veces indicado.
    /// Ejemplo: (Alejandro, crack, 2) -> "Alejandro crack Alejandro crack".
    /// </summary>
    public static string RepetirCadenas(string primera, string segunda, int veces)
    {
        if (veces <= 0)
            return string.Empty;

        string par = $"{primera} {segunda}";
        return string.Join(" ", Enumerable.Repeat(par, veces));
    }

    /// <summary>
    /// 5. Duplica cada carácter. Ejemplo: "Madrid" -> "MMaaddrriidd".
    /// </summary>
    public static string DuplicarLetras(string texto)
    {
        var sb = new StringBuilder(texto.Length * 2);
        foreach (char c in texto)
        {
            sb.Append(c).Append(c);
        }
        return sb.ToString();
    }

    /// <summary>
    /// 6. Borra del primer texto todas las apariciones del segundo
    /// (sin distinguir mayúsculas de minúsculas).
    /// Ejemplo: ("Real Zaragoza es de la realeza", "Real") -> "Zaragoza es de la eza".
    /// </summary>
    public static string BorrarApariciones(string texto, string aBorrar)
    {
        if (string.IsNullOrEmpty(aBorrar))
            return texto;

        return texto.Replace(aBorrar, string.Empty, StringComparison.OrdinalIgnoreCase).Trim();
    }
}
