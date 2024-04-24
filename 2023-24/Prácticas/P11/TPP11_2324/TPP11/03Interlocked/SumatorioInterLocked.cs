using System.Threading;

namespace _03Interlocked
{
    class SumatorioInterLocked : Sumatorio//herencia
    {
        public SumatorioInterLocked(long valor, int numHilos) : base(valor, numHilos)
        {

        }

        protected override void DecrementarValor()
        {

            Interlocked.Decrement(ref base.valor);//funciona porque es una única línea de código
        }
    }
}
