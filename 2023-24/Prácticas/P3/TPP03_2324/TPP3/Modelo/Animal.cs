﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    /// <summary>
    /// Clase abstracta. 
    /// ¿Para qué se utilizan?
    /// </summary>
    public abstract class Animal
    {
        public string Nombre { get; set; }
        public Animal(string nombre)
        {
            this.Nombre = nombre;
        }

        //¿Podemos crear métodos abstractos? ¿Y propiedades?
        //¿Qué implicaciones tiene en las clases derivadas?

        /// <summary>
        /// Habilitamos Enlace Dinámico, utilizamos virtual.
        /// </summary>
        public virtual void Saludar()
        {
            Console.WriteLine($"[ANIMAL] Mi nombre es {Nombre}.");
        }

        /// <summary>
        /// Método Mover.
        /// </summary>
        public void Mover()//no tiene habilitado el enlace dinámico
        {
            Console.WriteLine($"[ANIMAL] {Nombre} se mueve.");
        }



    }
}
