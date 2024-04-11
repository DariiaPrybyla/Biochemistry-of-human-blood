using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm2 = new Form2();
            newForm2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Перевіряємо, чи відкрита Form2
            if (Application.OpenForms.OfType<Form2>().Any())
            {
                Form2 form2 = Application.OpenForms.OfType<Form2>().FirstOrDefault();
                form2.Close();
            }

            Form3 newForm3 = new Form3();
            newForm3.Show();
        }
    }
}
