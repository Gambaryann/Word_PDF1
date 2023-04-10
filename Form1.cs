using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using exportWord = Microsoft.Office.Interop.Word;

namespace Word_PDF1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            exportWord.Application wordapp = new exportWord.Application();
            wordapp.Visible = true;
            exportWord.Document worddoc;
            object wordobj = System.Reflection.Missing.Value;
            worddoc = wordapp.Documents.Add(ref wordobj);
            wordapp.Selection.TypeText(textBox1.Text);
            wordapp = null;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("MONTHLY BILL ", new Font("TimesNewRoman", 20, FontStyle.Bold), Brushes.Black, new Point(10, 10));
            e.Graphics.DrawString("OFFICE ADDRESS ", new Font("TimesNewRoman", 10, FontStyle.Regular), Brushes.Black, new Point(10, 150));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintDialog printdialog1 = new PrintDialog();
            printdialog1.Document = printDocument1;

            DialogResult result = printdialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
