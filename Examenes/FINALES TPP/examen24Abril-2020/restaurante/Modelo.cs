using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP.Examen.PL5.Restaurante
{
    public static class Modelo
    {
        public static IDictionary<string, IEnumerable<string>> GetMenu()
        {
            IDictionary<string, IEnumerable<string>> defaultLibroRecetas = new Dictionary<string, IEnumerable<string>>();
            defaultLibroRecetas["Pizza Margarita"] = new string[] { "Masa fina", "Salsa de tomate", "Mozzarella" };
            defaultLibroRecetas["Pizza Marinara"] = new string[] { "Masa fina", "Salsa de tomate", "Tomate en rodajas", "Albahaca" };
            defaultLibroRecetas["Pizza Napolitana"] = new string[] { "Masa fina", "Salsa de tomate", "Mozzarella", "Anchoas", "Acapararas", "Oregano" };
            defaultLibroRecetas["Pizza con cebolla y pesto"] = new string[] { "Masa fina", "Salsa de tomate", "Salsa pesto", "Cebolla" };
            defaultLibroRecetas["Pizza Caprichosa"] = new string[] { "Masa fina", "Salsa de tomate", "Alcachofa", "Champiñones", "Aceitunas", "Mozzarella" };
            defaultLibroRecetas["Pizza Cuatro Estaciones"] = new string[] { "Masa fina", "Champiñones", "Alcachofa", "Aceitunas", "Mejillones", "Ajo" };
            defaultLibroRecetas["Pizza Cuatro Quesos"] = new string[] { "Masa fina", "Mozzarella", "Parmesano", "Emmental", "Gorgonzola" };
            defaultLibroRecetas["Pizza Sarda"] = new string[] { "Masa fina", "Queso de oveja", "Anchoas", "Tomate troceado", "Parmesano", "Pimienta" };
            defaultLibroRecetas["Pizza estilo Palermo"] = new string[] { "Masa fina", "Cebolla", "Anchoas", "Tomate troceado", "Queso Pecorino" };
            defaultLibroRecetas["Pizza Siciliana"] = new string[] { "Masa fina", "Salsa de tomate", "Albahaca", "Aceitunas", "Cebolla", "Queso Pecorino", "Anchoas" };
            defaultLibroRecetas["Pizza de alcachofas"] = new string[] { "Masa fina", "Mozzarella", "Alcachofa", "Pimienta" };
            defaultLibroRecetas["Pizza con jamon y champiñones"] = new string[] { "Masa fina", "Jamon", "Champiñones", "Mozzarella", "Pimienta" };
            defaultLibroRecetas["Pizza carne picada y cebolla"] = new string[] { "Masa fina", "Cebolla", "Tomate en rodajas", "Ternera picada" };
            //Pizzas de masa gruesa
            defaultLibroRecetas["Pizza Margarita (masa gruesa)"] = new string[] { "Masa gruesa", "Salsa de tomate", "Mozzarella" };
            defaultLibroRecetas["Pizza Marinara (masa gruesa)"] = new string[] { "Masa gruesa", "Salsa de tomate", "Tomate en rodajas", "Albahaca" };
            defaultLibroRecetas["Pizza Napolitana (masa gruesa)"] = new string[] { "Masa gruesa", "Salsa de tomate", "Mozzarella", "Anchoas", "Acapararas", "Oregano" };
            defaultLibroRecetas["Pizza Caprichosa (masa gruesa)"] = new string[] { "Masa gruesa", "Salsa de tomate", "Alcachofa", "Champiñones", "Aceitunas", "Mozzarella" };
            defaultLibroRecetas["Pizza Cuatro Estaciones (masa gruesa)"] = new string[] { "Masa gruesa", "Champiñones", "Alcachofa", "Aceitunas", "Mejillones", "Ajo" };
            defaultLibroRecetas["Pizza Cuatro Quesos (masa gruesa)"] = new string[] { "Masa gruesa", "Mozzarella", "Parmesano", "Emmental", "Gorgonzola" };
            defaultLibroRecetas["Pizza Sarda (masa gruesa)"] = new string[] { "Masa gruesa", "Queso de oveja", "Anchoas", "Tomate troceado", "Parmesano", "Pimienta" };
            defaultLibroRecetas["Pizza Siciliana (masa gruesa)"] = new string[] { "Masa gruesa", "Salsa de tomate", "Albahaca", "Aceitunas", "Cebolla", "Queso Pecorino", "Anchoas" };
            defaultLibroRecetas["Pizza con jamon y champiñones (masa gruesa)"] = new string[] { "Masa gruesa", "Jamon", "Champiñones", "Mozzarella", "Pimienta" };
            //Pizzas de masa sin gluten
            defaultLibroRecetas["Pizza Margarita (sin gluten)"] = new string[] { "Masa sin gluten", "Salsa de tomate", "Mozzarella" };
            defaultLibroRecetas["Pizza Marinara (sin gluten)"] = new string[] { "Masa sin gluten", "Salsa de tomate", "Tomate en rodajas", "Albahaca" };
            defaultLibroRecetas["Pizza Napolitana (sin gluten)"] = new string[] { "Masa sin gluten", "Salsa de tomate", "Mozzarella", "Anchoas", "Acapararas", "Oregano" };
            defaultLibroRecetas["Pizza con cebolla y pesto (sin gluten)"] = new string[] { "Masa sin gluten", "Salsa de tomate", "Salsa pesto", "Cebolla" };
            defaultLibroRecetas["Pizza Caprichosa (sin gluten)"] = new string[] { "Masa sin gluten", "Salsa de tomate", "Alcachofa", "Champiñones", "Aceitunas", "Mozzarella" };
            defaultLibroRecetas["Pizza Cuatro Estaciones (sin gluten)"] = new string[] { "Masa sin gluten", "Champiñones", "Alcachofa", "Aceitunas", "Mejillones", "Ajo" };
            defaultLibroRecetas["Pizza Cuatro Quesos (sin gluten)"] = new string[] { "Masa sin gluten", "Mozzarella", "Parmesano", "Emmental", "Gorgonzola" };
            defaultLibroRecetas["Pizza Sarda (sin gluten)"] = new string[] { "Masa sin gluten", "Queso de oveja", "Anchoas", "Tomate troceado", "Parmesano", "Pimienta" };
            defaultLibroRecetas["Pizza estilo Palermo (sin gluten)"] = new string[] { "Masa sin gluten", "Cebolla", "Anchoas", "Tomate troceado", "Queso Pecorino" };
            defaultLibroRecetas["Pizza Siciliana (sin gluten)"] = new string[] { "Masa sin gluten", "Salsa de tomate", "Albahaca", "Aceitunas", "Cebolla", "Queso Pecorino", "Anchoas" };
            defaultLibroRecetas["Pizza de alcachofas (sin gluten)"] = new string[] { "Masa sin gluten", "Mozzarella", "Alcachofa", "Pimienta" };
            defaultLibroRecetas["Pizza con jamon y champiñones (sin gluten)"] = new string[] { "Masa sin gluten", "Jamon", "Champiñones", "Mozzarella", "Pimienta" };
            defaultLibroRecetas["Pizza carne picada y cebolla (sin gluten)"] = new string[] { "Masa sin gluten", "Cebolla", "Tomate en rodajas", "Ternera picada" };

            return defaultLibroRecetas;
        }

        public static IEnumerable<Ingrediente> GetIngredientes()
        {
            IList<Ingrediente> ingredientes = new List<Ingrediente>();
            ingredientes.Add(new IngredienteConAlergeno("Masa fina", "gluten"));
            ingredientes.Add(new IngredienteConAlergeno("Masa gruesa", "gluten"));
            ingredientes.Add(new Ingrediente("Masa sin gluten"));
            ingredientes.Add(new Ingrediente("Salsa de tomate"));
            ingredientes.Add(new Ingrediente("Tomate en rodajas"));
            ingredientes.Add(new IngredienteConAlergeno("Mozzarella", "lactosa"));
            ingredientes.Add(new IngredienteConAlergeno("Nata", "lactosa"));
            ingredientes.Add(new IngredienteConAlergeno("Nueces", "frutos con cáscara"));
            ingredientes.Add(new Ingrediente("Albahaca"));
            ingredientes.Add(new IngredienteConAlergeno("Anchoas", "pescado"));
            ingredientes.Add(new IngredienteConAlergeno("Atun", "pescado"));
            ingredientes.Add(new Ingrediente("Acapararas"));
            ingredientes.Add(new Ingrediente("Oregano"));
            ingredientes.Add(new IngredienteConAlergeno("Salsa pesto", "lactosa (trazas), frutos con cáscara, huevo (trazas)"));
            ingredientes.Add(new Ingrediente("Cebolla"));
            ingredientes.Add(new Ingrediente("Alcachofa"));
            ingredientes.Add(new Ingrediente("Champiñones"));
            ingredientes.Add(new Ingrediente("Aceitunas"));
            ingredientes.Add(new IngredienteConAlergeno("Mejillones", "moluscos"));
            ingredientes.Add(new Ingrediente("Ajo"));
            ingredientes.Add(new IngredienteConAlergeno("Emmental", "lactosa"));
            ingredientes.Add(new IngredienteConAlergeno("Gorgonzola", "lactosa"));
            ingredientes.Add(new IngredienteConAlergeno("Queso de oveja", "lactosa"));
            ingredientes.Add(new IngredienteConAlergeno("Parmesano", "lactosa"));
            ingredientes.Add(new Ingrediente("Pimienta"));
            ingredientes.Add(new Ingrediente("Tomate troceado"));
            ingredientes.Add(new IngredienteConAlergeno("Queso Pecorino", "lactosa"));
            ingredientes.Add(new Ingrediente("Jamon"));
            ingredientes.Add(new Ingrediente("Ternera picada"));
            return ingredientes;
        }

        public static IEnumerable<string> GetPedidoAleatorio()
        {
            return new string[] { "Pizza Cuatro Estaciones", "Pizza Margarita (sin gluten)", "Pizza con jamon y champiñones",
                 "Pizza de alcachofas", "Pizza Cuatro Estaciones (sin gluten)", "Pizza Cuatro Quesos (sin gluten)", "Pizza Sarda",
                 "Pizza Marinara (sin gluten)", "Pizza Siciliana (masa gruesa)", "Pizza Margarita (sin gluten)",
                 "Pizza Caprichosa (masa gruesa)", "Pizza con jamon y champiñones", "Pizza Sarda (masa gruesa)",
                 "Pizza Caprichosa (sin gluten)", "Pizza Margarita (sin gluten)", "Pizza Sarda (sin gluten)",
                 "Pizza Caprichosa (sin gluten)", "Pizza Siciliana (sin gluten)", "Pizza Marinara (sin gluten)",
                 "Pizza estilo Palermo (sin gluten)", "Pizza Napolitana", "Pizza Sarda (sin gluten)", "Pizza Margarita",
                 "Pizza Napolitana", "Pizza Napolitana (masa gruesa)", "Pizza Sarda (sin gluten)", "Pizza Sarda (masa gruesa)",
                 "Pizza Sarda", "Pizza Napolitana (masa gruesa)", "Pizza Caprichosa", "Pizza de alcachofas (sin gluten)",
                 "Pizza Cuatro Estaciones (sin gluten)", "Pizza Sarda (masa gruesa)", "Pizza de alcachofas (sin gluten)",
                 "Pizza Cuatro Estaciones", "Pizza Caprichosa (sin gluten)", "Pizza de alcachofas",
                 "Pizza carne picada y cebolla (sin gluten)", "Pizza Caprichosa (masa gruesa)", "Pizza Caprichosa",
                 "Pizza con cebolla y pesto (sin gluten)", "Pizza con cebolla y pesto", "Pizza Siciliana (masa gruesa)",
                 "Pizza con cebolla y pesto", "Pizza Marinara (sin gluten)", "Pizza Margarita", "Pizza Cuatro Estaciones (sin gluten)",
                 "Pizza con cebolla y pesto", "Pizza carne picada y cebolla (sin gluten)", "Pizza Cuatro Quesos",
                 "Pizza estilo Palermo", "Pizza con jamon y champiñones", "Pizza Cuatro Quesos (masa gruesa)",
                 "Pizza Cuatro Estaciones", "Pizza estilo Palermo (sin gluten)", "Pizza Cuatro Quesos (masa gruesa)",
                 "Pizza Cuatro Quesos (sin gluten)", "Pizza carne picada y cebolla (sin gluten)", "Pizza Margarita (sin gluten)",
                 "Pizza Caprichosa (masa gruesa)", "Pizza estilo Palermo (sin gluten)", "Pizza carne picada y cebolla",
                 "Pizza de alcachofas", "Pizza de alcachofas", "Pizza Sarda", "Pizza Caprichosa (sin gluten)",
                 "Pizza con jamon y champiñones (sin gluten)", "Pizza con cebolla y pesto", "Pizza carne picada y cebolla",
                 "Pizza Cuatro Estaciones (masa gruesa)", "Pizza Cuatro Quesos (sin gluten)",
                 "Pizza con jamon y champiñones (sin gluten)", "Pizza con jamon y champiñones (masa gruesa)",
                 "Pizza con jamon y champiñones", "Pizza Cuatro Estaciones", "Pizza Cuatro Estaciones (sin gluten)",
                 "Pizza Siciliana (masa gruesa)" };
        }
    }
}
