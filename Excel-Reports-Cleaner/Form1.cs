using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Reports_Cleaner
{
    public partial class frmCleaner : Form
    {
        int[,] states;

        public frmCleaner()
        {
            states = new int[,]{ {  1,  0,  0,  0,  0,  0,  0,  0,  0 }, 
                                 {  1,  2,300,300,300,300,300,300,300 },
                                 {300,  2,100,100,100,100,  3,100,100 },
                                 {  4,301,301,301,301,301,301,301,301 },
                                 {  4,  5,301,301,301,301,301,301,301 },
                                 {301,  5,301,301,301,301,301,101,101 }};
            InitializeComponent();
        }

        private void pbCargar_Click(object sender, EventArgs e)
        {

        }
    }
}
