using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
 

namespace Excel_Reports_Cleaner
{
    public partial class frmCleaner : Form
    {
        List<string> cells;
        Excel.Application excelApp;
        int[,] states;

        public frmCleaner()
        {
            cells = new List<string>();
            excelApp = new Excel.Application();
            states = new int[,]{ {  1,  0,  0,  0,  0,  0,  0,  0,  0,  0 }, 
                                 {  1,  2,300,300,300,300,300,300,300,300 },
                                 {300,  2,100,100,100,100,  3,100,100,100 },
                                 {  4,301,301,301,301,301,301,301,301,301 },
                                 {  4,  5,301,301,301,301,301,301,301,301 },
                                 {301,  5,301,301,301,301,301,101,101,101 }};
            InitializeComponent();
            pBarClean.Step = 1;
        }

        private void pbCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel (*.xlsx;*.xls)|*.xlsx;*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbFile.Text = ofd.FileName;
                pbClean.Enabled = true;
            }            
        }
        private void readData(dynamic[,] range)
        {
            int rows = range.GetLength(0);
            int columns = range.GetLength(1);

            for (int i = 1; i<= rows; i++)
            {
                for(int j = 1; j<=columns; j++)
                {
                    string cell = Convert.ToString(range[i,j]);
                    if (cell == null || cell.Length == 0)
                        continue;

                    if (cell.Substring(0, 1) == "=")
                        readCell(cell.Substring(1));
                }
            }
            pBarClean.PerformStep();
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
                        cells.Add(token);
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
            Excel.Workbook excelBook = excelApp.Workbooks.Open(tbFile.Text);
            int nSheets = excelBook.Worksheets.Count;
            pBarClean.Value = 0;
            pBarClean.Maximum = nSheets * 2;

            for (int i = 1; i <= nSheets; i++)
            {
                Excel.Worksheet sheet = excelBook.Worksheets[i];
                cells.Clear();
                readData(sheet.UsedRange.Formula);
                foreach(string cell in cells)
                {
                    string[] token = cell.Split(':');
                    try
                    {
                        if (token.Length > 1)
                            sheet.Range[token[0], token[1]].Value2 = "";
                        else
                            sheet.Range[token[0], token[0]].Value2 = "";
                    }catch(Exception ex) {}
                }
                pBarClean.PerformStep();
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel (*.xlsx;*.xls)|*.xlsx;*.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                excelBook.SaveAs(sfd.FileName);
            }
                
            excelBook.Close(false);
        }

        private void frmCleaner_FormClosed(object sender, FormClosedEventArgs e)
        {
            excelApp.Quit();
        }
    }
}
