using System;

namespace _01SinSincronizar
{
    public class Color
    {

        private ConsoleColor color;

        public Color(ConsoleColor color)
        {
            this.color = color;
        }

        public void Show()
        {
            // ¿Por qué en el ejemplo esto debería considerarse una sección crítica?
            // Porque un hilo puede estar modificando el colorAnterior a la vez que otro usando la consola
            // Todo el método es una sección crítica
            ConsoleColor colorAnterior = Console.ForegroundColor;
            Console.ForegroundColor = this.color;
            Console.Write("{0}\t", this.color);
            Console.ForegroundColor = colorAnterior;
        }

    }
}
