using System;


namespace _02ConSincronizacion
{

    // Ejercicio:
    // ¿ Cómo podemos refactorizar este código con respecto al de 01SinSincronizar ? 
    public class ColorSincro
    {
        private ConsoleColor color;

        //¿Por qué es readonly? ¿Por qué es estático? ¿Siempre será estático?
        // Es readonly porque si un lock tiene una referencia y se modifica, el lock peta
        // Es estático porque será el mismo objeto al que se acceda (para evitar personalización)
        // No siempre será estático
        private static readonly object _object = new object();
        public ColorSincro(ConsoleColor color)
        {
            this.color = color;
        }
        public void Show()
        {

            // Como regla básica, es necesario bloquear cualquier operación de escritura.
            // Incluyendo los casos más simples, como el de modificar/incrementar el valor de una variable.

            // ¡REPASAD EN LA TEORÍA QUÉ OPERACIONES SON!

            // No más de un hilo a la vez puede ejecutar este código (sección crítica).
            // ¿Qué hace lock?

            // Pilla la referencia a un objeto y le pone una señal
            // Cuando llega al lock para y el hilo se libera cuando termina el código de dentro del lock

            // No se está paralelizando nada, pues sólo 1 hilo puede acceder a la sección crítica
            lock (_object)
            {
                ConsoleColor colorAnterior = Console.ForegroundColor;
                Console.ForegroundColor = this.color;
                Console.Write("{0}\t", this.color);
                Console.ForegroundColor = colorAnterior;
            }
        }
    }
}
