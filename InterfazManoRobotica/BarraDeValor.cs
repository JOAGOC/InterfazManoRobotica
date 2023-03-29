using System.Threading;
using System.Windows.Forms;

namespace InterfazManoRobotica
{
    public class BarraDeValor
    {
        int x = 0;
        int y = 13;
        static int paso = 2;
        private int valor = 0;
        public int Valor
        {
            get { return valor; }
        }
        Mutex mutex;
        public delegate void ValueBarHandler(BarraDeValor barraDeValor, int valor);
        public event ValueBarHandler valueChange;
        public bool ban;

        public void ejecutar()
        {
            if (!ban)
                decrementar();
            else
                incrementar();
        }

        public void incrementar()
        {
            if (valor == 180)
                return;
            x++;
            valor +=
                (x % paso == 0)
                    ? (y == 1)
                        ? 1
                        : --y
                    : y;
            valor = (valor > 180) ? 180 : valor;
            this.valueChange?.Invoke(this, valor);
        }

        public void decrementar()
        {
            if (valor == 0){
                x = 0;
                return;
            }
            x--;
            valor -= (x % paso == 0) ? ++y : y;
            valor = (valor < 0) ? 0 : valor;
            this.valueChange?.Invoke(this, valor);
        }

        public BarraDeValor()
        {
        }
    }
}
