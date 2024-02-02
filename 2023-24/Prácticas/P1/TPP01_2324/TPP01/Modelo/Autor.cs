using System;

//¿Qué es un namespace?
namespace TPP01.Modelo//ES SOLO UNA SEPARACIÓN LÓGICA (NO GENERA CARPETAS, QUE ES LA SEPARACIÓN FÍSICA)
{

    /// <summary>
    /// Las clases, por defecto, son internal.
    /// Es decir, accesibles sólo desde el mismo ensamblado...
    /// Modificadores de acceso en C#: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
    /// </summary>
    public class Autor
    {

        // Los campos se crean con el modificador "private" por defecto.
        string _nombre; //equivalente a -> private string _nombre;
        //el _ es estándar

        // Creamos una propiedad de lectura (get) y escritura (set) para encapsular el campo _nombre
        public string Nombre // las propiedades empiezan pormayúscula
        {
            get
            {
                return String.IsNullOrEmpty(_nombre) ? "Anónimo" : _nombre;
            }
            set
            {
                _nombre = value;//el value es lo que se recibe en el set
            }
        }

        // El compilador puede crear campos para las propiedades de forma transparente.

        // ¿Qué ocurre si queremos comprobar en el set que el nuevo valor tenga longitud > 1?
        string _apellido;
        public string Apellido {
            get {
                return String.IsNullOrEmpty(_apellido) ? "Anónimo" : _apellido;
            }
            set { 
                if(value.Length > 1)
                    _apellido = value;
                // Hacer esto implica un bucle infinito: Apellido = value;
            } 
        }


        // En ocasiones, necesitamos propiedades de solo lectura.

        // ¿Cómo se crearía una propiedad de solo escritura?
        public string Iniciales//esto es una propiedad derivada (las iniciales se conforman con el nombre y el apellido)
        {
            get//esta propiedad es de solo lectura
            {
                return $"{Nombre[0]}.{Apellido[0]}";
            }
        }

        //Fíjate en esta propiedad de sólo lectura y dónde se le puede asignar valor.
        public DateTime CreatedAt { get; }


        /// <summary>
        /// Constructor por defecto.
        /// Si hay otro constructor, hay que declararlo explícitamente.
        /// </summary>
        public Autor()
        {
            CreatedAt = DateTime.Now;
#if DEBUG//si se cambia a release es código que no se compila
            Console.WriteLine("Entrando en el constructor por defecto");
#endif
        }

        /// <summary>
        /// Otro constructor, por eso está declarado el anterior.
        /// Vamos a ver qué pasa si quitamos el otro.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        public Autor(string nombre, string apellido)
        {

            Nombre = nombre;
            Apellido = apellido;
            CreatedAt = DateTime.Now;
#if DEBUG
            Console.WriteLine("Entrando en el constructor con valores: {0}, {1}", nombre, apellido);
#endif
        }


        /// <summary>
        /// Método ToString. ¡OJO al override y la T mayúscula!
        /// </summary>
        /// <returns>Estado del objeto</returns>
        public override string ToString()
        {
            return $"{Nombre} {Apellido} ({Iniciales})";
        }


        /// <summary>
        /// Esto es un finalizador (anteriormente conocido como destructor).
        /// Se implementa únicamente cuando es necesario liberar recursos, conexiones...
        /// Implementarlo vacío supone una pérdida de rendimiento (como en este caso).
        /// Se invoca automáticamente.
        /// </summary>
        ~Autor()
        {
            Console.WriteLine($"Liberación de {ToString()}");
            // Liberación de recursos, conexiones... Más detalle en: https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/classes-and-structs/finalizers
        }

    }
}
