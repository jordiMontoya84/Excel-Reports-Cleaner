using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop;
 

namespace Excel_Reports_Cleaner
{
    public partial class frmCleaner : Form
    {
        Microsoft.Office.Interop.Excel.Application excelApp;
        List<string> cells = new List<string>();
        List<string> ranges = new List<string>();
        int[,] states;

        public frmCleaner()
        {
            excelApp = new Microsoft.Office.Interop.Excel.Application();
            states = new int[,]{ {  1,  0,  0,  0,  0,  0,  0,  0,  0,  0 }, 
                                 {  1,  2,300,300,300,300,300,300,300,300 },
                                 {300,  2,100,100,100,100,  3,100,100,100 },
                                 {  4,301,301,301,301,301,301,301,301,301 },
                                 {  4,  5,301,301,301,301,301,301,301,301 },
                                 {301,  5,301,301,301,301,301,101,101,101 }};
            InitializeComponent();
        }

        private void pbCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName == null)
                return;

            tbFile.Text = ofd.FileName;
            pbClean.Enabled = true;
        }
        // 462, 134
        private void readData(Microsoft.Office.Interop.Excel.Workbook book)
        {
            Microsoft.Office.Interop.Excel.Worksheet sheet =
                (Microsoft.Office.Interop.Excel.Worksheet)book.Sheets[1];
            int rows = sheet.UsedRange.Rows.Count;
            int columns = sheet.UsedRange.Columns.Count;
            

            for (int i = 0; i<= rows; i++)
            {
                for(int j = 0; j<=columns; j++)
                {
                    string cell = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)sheet.Cells[i + 1, j + 1]).Formula);
                    if (cell == null || cell.Length == 0)
                        continue;

                    if (cell.Substring(0, 1) == "=")
                        readCell(cell.Substring(1));
                }
            }
        }

        private void readCell(string cell)
        {
            cell += " ";
            int state = 0;
            string token = "";
            char ch;
            for(int i = 0; i< cell.Length; i++)
            {
                ch = Convert.ToChar(cell.Substring(i, 1));
                state = states[state, getIndex(ch)];

                if (state >= 100)
                {
                    if (state < 300)
                    {
                        if (state == 100)
                            listBox1.Items.Add(token);
                        else
                            listBox2.Items.Add(token);
                    }
                    state = 0;
                    token = "";
                }
                else if (state != 0)
                    token += ch;
            }
        }

        private int getIndex(char c)
        {
            if (c >= 'A' && c <= 'Z')
                return 0;
            else if (c >= '0' && c <= '9')
                return 1;
            else
            {
                switch (c)
                {
                    case '+':
                        return 2;
                    case '-':
                        return 3;
                    case '/':
                        return 4;
                    case '*':
                        return 5;
                    case ':':
                        return 6;
                    case '(':
                        return 7;
                    case ')':
                        return 8;
                    case ' ':
                        return 9;
                    default:
                        return 0;
                }
            }
        }

        private void pbClean_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(tbFile.Text);
            readData(excelBook);
        }
    }
}
