
using System;


namespace TPP.FinalJunio
{

	internal class Persona : IComparable {
		public Persona(string nombre = null, string apellido1 = null, string apellido2 = null ) {
			this.Nombre = nombre;
            this.Apellido1 = apellido1;
            this.Apellido2 = apellido2;
		}

		public string Nombre { get; set; }
		public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
		public int Edad {
			get { return DateTime.Now.Year - AñoNacimiento; }
			set { AñoNacimiento = DateTime.Now.Year - value; }
		}
		public string Nacionalidad { get; set; }
		public int AñoNacimiento { get; set; }
        public int CompareTo(object otro) {

            return this.Nombre.Equals((otro as Persona).Nombre) ? 0  : 1;
        }
 
		public override string ToString() {
			return Nombre;
		}

	}


}
