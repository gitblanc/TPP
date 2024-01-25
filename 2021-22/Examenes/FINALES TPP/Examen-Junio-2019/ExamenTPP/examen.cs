	internal IEnumerable<int>diferenciaInfinito(IEnumerable<int>a,IEnumerable<int>b)
		{
			int i=0;
			 while (true) {
				 if(b.Contains(a.ElememtAt(i)))
				 {
					 yield return a.ElememtAt(i);
				 }
				 i++;
			 }
		}
		
		static IEnumerable<int>diferenciaInfinito(this IEnumerable<int>a,IEnumerable<int>a)
		{
			 return diferenciaInfinito(a,b).Skip(0).Take(a.Count());
		}
		
		internal IEnumerable<int>generador(float r)
		{
			int potencia=0;
			 while (true) {
				 
					 yield return Math.pow(r,potencia);
					 potencia++;
				 }
		
		}
		public static Func< int,Func<int,int>> sumarTresNumeros(int a)
        {
            return b => c => a + b + c;
        }
		
		public Func< float,Func<float,float>> ejercicioExamen(float r)
		{
			return a=>b=>Math.Pow(Math.Sin(a) * Math.Pow(r, b), r);
		}
		Console.Write(ejercicioExamen(2)(3)(4));