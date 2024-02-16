﻿using System;


namespace Modelo
{
    /// <summary>
    /// Hereda de Animal.
    /// public class Nombre : ClaseBase
    /// </summary>
    public class Pato : Animal
    {
        private int _numeroPlumas;

        /// <summary>
        /// Constructor de Pato. Invoca al constructor de Animal mediante:
        /// base(nombre) <- Invocación al constructor de la clase base.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="numeroPlumas"></param>
        public Pato(string nombre, int numeroPlumas):base(nombre)//pasas el nombre al constructor de la superclase
        {
            this._numeroPlumas = numeroPlumas;
        }

        public override void Saludar()
        {
            base.Saludar();
            Console.WriteLine($"[PATO] Soy un pato y tengo {_numeroPlumas}");
        }

        /// <summary>
        /// ¿Qué está pasando aquí?
        /// </summary>
        public void Mover()
        {
            Console.WriteLine($"[PATO] {base.Nombre} se va nadando.");
        }
    }
}
