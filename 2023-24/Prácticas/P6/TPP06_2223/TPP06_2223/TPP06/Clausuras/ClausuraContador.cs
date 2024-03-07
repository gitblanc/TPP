using System;

namespace Clausuras
{
    public static class ClausuraContador
    {
        /// <summary>
        /// Esta función devuelve una clausura
        /// Almacena el estado de la variable contador.
        /// </summary>
        /// <returns>Clausura contador</returns>
        public static Func<int> CrearContador()//aquí se pueden pasar parámetros que se usen en el constructor/función devuelta
        {
            //Se define el estado
            int contador = 0; // Esto es el constructor de la clausura, porque almacena el estado

            //si definimos otra variable que no usemos en la función, ésta se pierde

            //Se devuelve la clausura

            return () => ++contador;//este func almacena una referencia a contador (definida en ClausuraContador)

        }
    }
}
