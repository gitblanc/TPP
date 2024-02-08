
namespace MetodosExtensores
{
    public enum Estaciones { Invierno = 0, Primavera = 1, Verano = 2, Otoño = 3 };

    /// <summary>
    /// Los métodos extensores están contenidos en clases estáticas.
    /// </summary>
    public static class Extensores
    {
        /// <summary>
        /// Los métodos extensores son métodos estáticos.
        /// Afectan a la clase que se establece después del this
        /// En este caso, extendemos string con el método ContarVocalesSinTilde
        /// </summary>
        /// <param name="texto"></param>
        /// <returns>Número de vocales sin tilde</returns>
        public static int ContarVocalesSinTilde(this string texto)//el método se añade a la clase string
        {
            int resultado = 0;
            foreach (char letra in texto)
                if ("aeiouAEIOU".Contains(letra))
                    resultado++;
            return resultado;

        }
    }
}
