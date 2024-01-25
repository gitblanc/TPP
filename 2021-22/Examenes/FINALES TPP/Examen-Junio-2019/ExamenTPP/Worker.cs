
namespace TPP.Laboratory.Concurrency.Lab09 {

    internal class Worker {

        private string[] cadenas;
		
        private int fromIndex, toIndex;
		
		private UsuariosSha1 usuario=null;
		
        private IDictionary<int,UsuariosSha1>result;

      

        internal Worker(string[] cadenas, int fromIndex, int toIndex,UsuariosSha1 usuario,ref IDictionary<int,UsuariosSha1>result) {
            this.cadenas = cadenas;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
			this.usuario=usuario;
			this.result=result;
        }

        internal void Compute() {
		 for(int i=fromIndex;i<toIndex;i++)
		 {
			 if(usuario.Clave.Equals(cadenas[i]))
			 {
				 lock(ob){
				 result.add(i,usuario);
				 }
			 }
		 
		 }
		}
           

    }

}
