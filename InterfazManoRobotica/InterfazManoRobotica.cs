using System;
using System.Threading;
using System.Windows.Forms;

namespace InterfazManoRobotica
{
    public partial class InterfazManoRobotica : Form
    {

        BarraDeValor indice, corazon, anular, menique, pulgar;

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;
        }

        private void InterfazManoRobotica_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serial.IsOpen)
                serial.Close();
        }

        public InterfazManoRobotica()
        {
            InitializeComponent();
            serial.PortName = "COM3";
            serial.Open();
            indice = new BarraDeValor();
            indice.valueChange += (bar, valor) => { barraIndice.Value = valor;serial.WriteLine("I" + valor); };
            corazon = new BarraDeValor();
            corazon.valueChange += (bar, valor) => { barraCorazon.Value = valor; serial.WriteLine("C" + valor); };
            anular = new BarraDeValor();
            anular.valueChange += (bar, valor) => { barraAnular.Value = valor; serial.WriteLine("A" + valor); };
            menique = new BarraDeValor();
            menique.valueChange += (bar, valor) => { barraMenique.Value = valor; serial.WriteLine("M" + valor); };
            pulgar = new BarraDeValor();
            pulgar.valueChange += (bar, valor) => { barraPulgar.Value = valor; serial.WriteLine("P" + valor); };
        }

        private void InterfazManoRobotica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == ((int)Keys.Q))
            {
                menique.ban = true;
                if (!timer1.Enabled)
                    timer1.Start();
            }
            if (e.KeyValue == ((int)Keys.W))
            {
                anular.ban = true;
                if (!timer1.Enabled)
                    timer1.Start();
            }
            if (e.KeyValue == ((int)Keys.E))
            {
                corazon.ban = true;
                if (!timer1.Enabled)
                    timer1.Start();
            }
            if (e.KeyValue == ((int)Keys.R))
            {
                indice.ban = true;
                if (!timer1.Enabled)
                    timer1.Start();
            }
            if (e.KeyValue == ((int)Keys.Space))
            {
                pulgar.ban = true;
                if (!timer1.Enabled)
                    timer1.Start();
            }
        }

        private void InterfazManoRobotica_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == ((int)Keys.Q))
                menique.ban = false;
            if (e.KeyValue == ((int)Keys.W))
                anular.ban = false;
            if (e.KeyValue == ((int)Keys.E))
                corazon.ban = false;
            if (e.KeyValue == ((int)Keys.R))
                indice.ban = false;
            if (e.KeyValue == ((int)Keys.Space))
                pulgar.ban = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            indice.ejecutar();
            corazon.ejecutar();
            anular.ejecutar();
            menique.ejecutar();
            pulgar.ejecutar();
        }
    }
}