//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Windows.Forms;

namespace InterfazManoRobotica
{
    public partial class InterfazManoRobotica : Form
    {
        int count = 0;

        public InterfazManoRobotica() => InitializeComponent();

        private void InterfazManoRobotica_KeyDown(object sender, KeyEventArgs e)
        {
            this.Text = ""+count++;
        }
    }
}
