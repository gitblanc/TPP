using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamUtils;

namespace ConsoleApp1
{
    class Program
    {
        static List<InformacionMD5> lista = new List<InformacionMD5>();
        static InformacionMD5 user1 = new InformacionMD5("tpp", "1");
        static InformacionMD5 user2 = new InformacionMD5("tp", "1");
        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 2 Manera no perezosa");
            IEnumerable<String>lista=Ejercicio2(() => Utils.GetRandomString(4, 8), 2);
			 foreach (var e in lista)
            {
                Console.WriteLine(e);
            }
			
			//llamada ejercicio 2, forma lazy
			IEnumerable<String>lista2=Ejercicio2Lazy(() => Utils.GetRandomString(4, 8), 8).Skip(0).Take(10);
			 foreach (var e in lista2)
            {
                Console.WriteLine(e);
            }
        }

        //Apartado 1 del ejercicio2-------------------------------
        public static IEnumerable<String> Ejercicio2(Func<String> f, int size)
        {
            List<String> aux = new List<string>();
			
            for(int i = 0; i < size; i++)
            {
                aux.Add(f());
            }

           

            return aux;

        }

        //Apartado 2 del ejercicio 2 ---------------------------------------------------------
        public static IEnumerable<String> Ejercicio2Lazy(Func<String> f, int size)
        {
           
			while(true)
			{
				String cadena=f();
				if(cadena.Length()<=size)
				{
				 yield return cadena;
				}
			}
	
        }
		//Ejercicio 3, parte a-------------------------------------------------------------
        public static IEnumerable<String> Ejercicio3A()
        {
            List<String> lista = new List<string>(100);
			
			lista=lista.Agregate<String,List<String>>(lista,(l,cad)=>
			{
				   cad = Utils.GetRandomString(50);
                   l.Add(cad);
				   return l;
			});
			
			//List<String> lista = new List<string>();
           /* var resultado = lista.Where(x =>
             {
                 while (lista.Count() < 100)
                 {
                     x = Utils.GetRandomString(50);
                     lista.Add(x);
                 }

                 return true;
             });*/

            foreach (var r in lista)
            {
                Console.WriteLine(r);
            }
         
            return lista;
        }
		//Ejercicio 3 parte B--------------------------------------------------
		  public static int Ejercicio3B()
		  {
			  Random r = new Random();
			  List<String> lista=Ejercicio3A();
			  int pos=r.Next(lista.Count());
			  InformacionMD5 infoMD5=new InformacionMD5("tpp",lista[pos]);
			  
			  var r=lista.Where(c=>c.Equals(lista[pos]));
			  Console.Write(r.Count());	
			 return	r.Count();	 	  
		  }
	//Ejercicio 3 parte c--------------------------------------------------
	public void ejercicio3C()
	{
		 List<String> lista = new List<string>();
		 String resultado="";
		 for(int i=0;i<200;i++)
		 {
			 lista.Add(Utils.GetRandomString(500));			 
		 }
		 resultado=lista.Where(s=>s.Length()<150).Select(s=>s.ToUpper()).Aggregate(resultado,(r,cad)=>{
			 {
				 r+=cad+";";
				 return r;
			 });
		 Console.Write(resultado);		
    }
}







