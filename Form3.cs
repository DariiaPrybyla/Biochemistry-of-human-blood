using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsApp1;
using System.IO;
using System.Linq;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        int sex, globulin;
                
        public Form3()
        {
            InitializeComponent();

            InitDataForComboBox();

            // Прив'язуємо обробник KeyPress до кожного текстового поля, у якому буде неціле число
            textBox5.KeyPress += TextBox_KeyPress_1;
            textBox6.KeyPress += TextBox_KeyPress_1;
            textBox7.KeyPress += TextBox_KeyPress_1;
            textBox8.KeyPress += TextBox_KeyPress_1;
            textBox10.KeyPress += TextBox_KeyPress_1;
            textBox11.KeyPress += TextBox_KeyPress_1;
            textBox12.KeyPress += TextBox_KeyPress_1;
            textBox13.KeyPress += TextBox_KeyPress_1;
            textBox15.KeyPress += TextBox_KeyPress_1;
            textBox16.KeyPress += TextBox_KeyPress_1;
            textBox17.KeyPress += TextBox_KeyPress_1;
            textBox18.KeyPress += TextBox_KeyPress_1;
            textBox20.KeyPress += TextBox_KeyPress_1;
            textBox21.KeyPress += TextBox_KeyPress_1;
            textBox22.KeyPress += TextBox_KeyPress_1;
            textBox23.KeyPress += TextBox_KeyPress_1;
            textBox27.KeyPress += TextBox_KeyPress_1;
            textBox31.KeyPress += TextBox_KeyPress_1;

            // Прив'язуємо обробник KeyPress до кожного текстового поля, у якому буде ціле число
            textBox2.KeyPress += TextBox_KeyPress_2;
            textBox3.KeyPress += TextBox_KeyPress_2;
            textBox4.KeyPress += TextBox_KeyPress_2;
            textBox9.KeyPress += TextBox_KeyPress_2;
            textBox14.KeyPress += TextBox_KeyPress_2;
            textBox19.KeyPress += TextBox_KeyPress_2;
            textBox24.KeyPress += TextBox_KeyPress_2;
            textBox25.KeyPress += TextBox_KeyPress_2;
            textBox26.KeyPress += TextBox_KeyPress_2;
            textBox28.KeyPress += TextBox_KeyPress_2;
            textBox29.KeyPress += TextBox_KeyPress_2;
            textBox30.KeyPress += TextBox_KeyPress_2;

            // Прив'язуємо обробник KeyPress до кожного текстового поля, у якому буде ПІБ
            textBox1.KeyPress += TextBox_KeyPress_3;

            // Прив'язуємо обробник KeyDown до кожного текстових полів, календаря та поля з розкривним списком
            textBox1.KeyDown += textBox1_KeyDown;
            dateTimePicker1.KeyDown += dateTimePicker1_KeyDown;
            comboBox1.KeyDown += comboBox1_KeyDown;
            textBox2.KeyDown += textBox2_KeyDown;
            textBox3.KeyDown += textBox3_KeyDown;
            textBox4.KeyDown += textBox4_KeyDown;
            textBox5.KeyDown += textBox5_KeyDown;
            textBox6.KeyDown += textBox6_KeyDown;
            textBox7.KeyDown += textBox7_KeyDown;
            textBox8.KeyDown += textBox8_KeyDown;
            textBox9.KeyDown += textBox9_KeyDown;
            textBox10.KeyDown += textBox10_KeyDown;
            textBox11.KeyDown += textBox11_KeyDown;
            textBox12.KeyDown += textBox12_KeyDown;
            textBox13.KeyDown += textBox13_KeyDown;
            textBox14.KeyDown += textBox14_KeyDown;
            textBox15.KeyDown += textBox15_KeyDown;
            textBox16.KeyDown += textBox16_KeyDown;
            textBox17.KeyDown += textBox17_KeyDown;
            textBox18.KeyDown += textBox18_KeyDown;
            textBox19.KeyDown += textBox19_KeyDown;
            textBox20.KeyDown += textBox20_KeyDown;
            textBox21.KeyDown += textBox21_KeyDown;
            textBox22.KeyDown += textBox22_KeyDown;
            textBox23.KeyDown += textBox23_KeyDown;
            textBox24.KeyDown += textBox24_KeyDown;
            textBox25.KeyDown += textBox25_KeyDown;
            textBox26.KeyDown += textBox26_KeyDown;
            textBox27.KeyDown += textBox27_KeyDown;
            textBox28.KeyDown += textBox28_KeyDown;
            textBox29.KeyDown += textBox29_KeyDown;
            textBox30.KeyDown += textBox30_KeyDown;

            // Використовуємо повні назви типів для різних варіантів
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();

            // Створюємо екземпляри ToolTip для кнопок і встановлюємо підказку
            System.Windows.Forms.ToolTip t_1 = new System.Windows.Forms.ToolTip();
            t_1.SetToolTip(button1, "Розшифровка абревіатур");
            System.Windows.Forms.ToolTip t_2 = new System.Windows.Forms.ToolTip();
            t_2.SetToolTip(button2, "Розшифровка абревіатур");
        }

        public void InitDataForComboBox() //Стать
        {
            var dataSource1 = new List<ClassNumber>();
            dataSource1.Add(new ClassNumber() { IdNumber = 0, NameNumber = "Чоловіча" });
            dataSource1.Add(new ClassNumber() { IdNumber = 1, NameNumber = "Жіноча" });

            comboBox1.DataSource = dataSource1;
            comboBox1.DisplayMember = "NameNumber";
            comboBox1.ValueMember = "IdNumber";

            comboBox1.SelectedIndex = -1; // Встановлює пустий вибір
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is ClassNumber selectedClassNumber)
            {
                sex = selectedClassNumber.IdNumber;
            }
        }

        //Визначення фраз для біохімічних показників
        //Вкладка "Білки"
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            if (double.TryParse(textBox2.Text, out double value))
            {
                string phrase = GetPhraseForTotalProtein(value);

                label76.Text = phrase;
            }
        }

        private string GetPhraseForTotalProtein(double value)
        {
            if (value > 85)
            {
                return "Показник вище норми";
            }
            else if (value < 65)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox3.Text, out double value))
            {
                string phrase = GetPhraseForAlbumin(value);

                label77.Text = phrase;
            }
        }

        private string GetPhraseForAlbumin(double value)
        {
            if (value > 50)
            {
                return "Показник вище норми";
            }
            else if (value < 35)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox4.Text, out int value))
            {
                string phrase = GetPhraseForGlobulin(value);

                label78.Text = phrase;

                globulin = value;
            }
        }

        private string GetPhraseForGlobulin(double value)
        {
            if (value > 35)
            {
                return "Показник вище норми";
            }
            else if (value < 25)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox5.Text, out double value))
            {
                string phrase = GetPhraseForGlobulinA1(value);

                label79.Text = phrase;
            }
        }
        
        private string GetPhraseForGlobulinA1(double value)
        {
            if (value > (6 / 100.0) * globulin)
            {
                return "Показник вище норми";
            }
            else if (value < (3 / 100.0) * globulin)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }
        
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox6.Text, out double value))
            {
                string phrase = GetPhraseForGlobulinA2(value);

                label80.Text = phrase;
            }
        }

        private string GetPhraseForGlobulinA2(double value)
        {
            if (value > (12 / 100.0) * globulin)
            {
                return "Показник вище норми";
            }
            else if (value < (6 / 100.0) * globulin)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }
        
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox7.Text, out double value))
            {
                string phrase = GetPhraseForGlobulinB(value);

                label81.Text = phrase;
            }
        }
        
        private string GetPhraseForGlobulinB(double value)
        {
            if (value > (12 / 100.0) * globulin)
            {
                return "Показник вище норми";
            }
            else if (value < (8 / 100.0) * globulin)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }
        
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox8.Text, out double value))
            {
                string phrase = GetPhraseForGlobulinC(value);

                label82.Text = phrase;
            }
        }

        private string GetPhraseForGlobulinC(double value)
        {
            if (value > (20 / 100.0) * globulin)
            {
                return "Показник вище норми";
            }
            else if (value < (15 / 100.0) * globulin)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }
        
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox9.Text, out double value))
            {
                string phrase = GetPhraseForFibrinogen(value);

                label83.Text = phrase;
            }
        }

        private string GetPhraseForFibrinogen(double value)
        {
            if (value > 4)
            {
                return "Показник вище норми";
            }
            else if (value < 2)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        //Вкладка "Ліпіди"
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox10.Text, out double value))
            {
                string phrase = GetPhraseForTotalLipid(value);

                label89.Text = phrase;
            }
        }

        private string GetPhraseForTotalLipid(double value)
        {
            if (value > 8.0)
            {
                return "Показник вище норми";
            }
            else if (value < 4.0)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }
                
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox11.Text, out double value))
            {
                string phrase = GetPhraseForTotalCholesterol(value);

                label90.Text = phrase;
            }
        }

        private string GetPhraseForTotalCholesterol(double value)
        {
            if (value > 8.0)
            {
                return "Показник вище норми";
            }
            else if (value < 3.0)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox12.Text, out double value))
            {
                string phrase = GetPhraseForTriglyceride(value);

                label91.Text = phrase;
            }
        }

        private string GetPhraseForTriglyceride(double value)
        {
            if (value > 1.8)
            {
                return "Показник вище норми";
            }
            else if (value < 0.5)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }
        
        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox13.Text, out double value))
            {
                string phrase = GetPhraseForTotalPhospholipid(value);

                label92.Text = phrase;
            }
        }

        private string GetPhraseForTotalPhospholipid(double value)
        {
            if (value > 2.9)
            {
                return "Показник вище норми";
            }
            else if (value < 2.52)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox14.Text, out double value))
            {
                string phrase = GetPhraseForLipoproteinsB(value);

                label93.Text = phrase;
            }
        }

        private string GetPhraseForLipoproteinsB(double value)
        {
            if (value > 55)
            {
                return "Показник вище норми";
            }
            else if (value < 35)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        //Вкладка "Білірубін"
        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox15.Text, out double value))
            {
                string phrase = GetPhraseForTotalBilirubin(value);

                label97.Text = phrase;
            }
        }

        private string GetPhraseForTotalBilirubin(double value)
        {
            if (value > 20.5)
            {
                return "Показник вище норми";
            }
            else if (value < 8.5)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox16.Text, out double value))
            {
                string phrase = GetPhraseForDirectBilirubin(value);

                label98.Text = phrase;
            }
        }

        private string GetPhraseForDirectBilirubin(double value)
        {
            if (value > 4.3)
            {
                return "Показник вище норми";
            }
            else if (value < 0.9)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox17.Text, out double value))
            {
                string phrase = GetPhraseForIndirectBilirubin(value);

                label99.Text = phrase;
            }
        }

        private string GetPhraseForIndirectBilirubin(double value)
        {
            if (value > 17.1)
            {
                return "Показник вище норми";
            }
            else if (value < 6.4)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        //Вкладка "Мінерали"
        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox18.Text, out double value))
            {
                string phrase = GetPhraseForPotassium(value);

                label107.Text = phrase;
            }
        }

        private string GetPhraseForPotassium(double value)
        {
            if (value > 5.1)
            {
                return "Показник вище норми";
            }
            else if (value < 3.5)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }
        
        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox19.Text, out double value))
            {
                string phrase = GetPhraseForNatrium(value);

                label108.Text = phrase;
            }
        }

        private string GetPhraseForNatrium(double value)
        {
            if (value > 156)
            {
                return "Показник вище норми";
            }
            else if (value < 130)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox20.Text, out double value))
            {
                string phrase = GetPhraseForCalcium(value);

                label109.Text = phrase;
            }
        }

        private string GetPhraseForCalcium(double value)
        {
            if (value > 3.0)
            {
                return "Показник вище норми";
            }
            else if (value < 2.1)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox21.Text, out double value))
            {
                string phrase = GetPhraseForMagnesium(value);

                label110.Text = phrase;
            }
        }

        private string GetPhraseForMagnesium(double value)
        {
            if (value > 1.15)
            {
                return "Показник вище норми";
            }
            else if (value < 0.7)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox22.Text, out double value))
            {
                string phrase = GetPhraseForIron(value, sex);

                label111.Text = phrase;
            }
        }

        private string GetPhraseForIron(double value, int sex)
        {
            if (sex == 0) { 
                if (value > 30.4)
                {
                    return "Показник вище норми";
                }
                else if (value < 14.3)
                {
                    return "Показник нижче норми";
                }
                else
                {
                    return "Показник в нормі";
                }
            }
            if (sex == 1)
            {
                if (value > 21.5)
                {
                    return "Показник вище норми";
                }
                else if (value < 10.7)
                {
                    return "Показник нижче норми";
                }
                else
                {
                    return "Показник в нормі";
                }
            }
            return "Невірне значення статі";
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox23.Text, out double value))
            {
                string phrase = GetPhraseForPhosphorus(value);

                label112.Text = phrase;
            }
        }

        private string GetPhraseForPhosphorus(double value)
        {
            if (value > 1.45)
            {
                return "Показник вище норми";
            }
            else if (value < 0.87)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox24.Text, out double value))
            {
                string phrase = GetPhraseForChlorine(value);

                label113.Text = phrase;
            }
        }

        private string GetPhraseForChlorine(double value)
        {
            if (value > 110)
            {
                return "Показник вище норми";
            }
            else if (value < 95)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        //Вкладка "Ферменти"
        private void textBox25_TextChanged_1(object sender, EventArgs e)
        {
            if (double.TryParse(textBox25.Text, out double value))
            {
                string phrase = GetPhraseForALAT(value);

                label121.Text = phrase;
            }
        }

        private string GetPhraseForALAT(double value)
        {
            if (value > 190)
            {
                return "Показник вище норми";
            }
            else if (value < 28)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox26.Text, out double value))
            {
                string phrase = GetPhraseForASAT(value);

                label122.Text = phrase;
            }
        }

        private string GetPhraseForASAT(double value)
        {
            if (value > 127)
            {
                return "Показник вище норми";
            }
            else if (value < 28)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox27.Text, out double value))
            {
                string phrase = GetPhraseForAmylaseA(value);

                label123.Text = phrase;
            }
        }

        private string GetPhraseForAmylaseA(double value)
        {
            if (value > 8.9)
            {
                return "Показник вище норми";
            }
            else if (value < 3.3)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox28.Text, out double value))
            {
                string phrase = GetPhraseForCPK(value);

                label124.Text = phrase;
            }
        }

        private string GetPhraseForCPK(double value)
        {
            if (value > 100)
            {
                return "Показник вище норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox29.Text, out double value))
            {
                string phrase = GetPhraseForLDH(value);

                label125.Text = phrase;
            }
        }

        private string GetPhraseForLDH(double value)
        {
            if (value > 3200)
            {
                return "Показник вище норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox30.Text, out double value))
            {
                string phrase = GetPhraseForALP(value);

                label126.Text = phrase;
            }
        }

        private string GetPhraseForALP(double value)
        {
            if (value > 830)
            {
                return "Показник вище норми";
            }
            else if (value < 278)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox31.Text, out double value))
            {
                string phrase = GetPhraseForCholinesterase(value);

                label127.Text = phrase;
            }
        }

        private string GetPhraseForCholinesterase(double value)
        {
            if (value > 95.0)
            {
                return "Показник вище норми";
            }
            else if (value < 45.0)
            {
                return "Показник нижче норми";
            }
            else
            {
                return "Показник в нормі";
            }
        }

        //Обмеження введення певних символів
        private void TextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = ','; // Роздільник десяткових чисел (кома)

            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != decimalSeparator && e.KeyChar != '\b') // Перевіряємо, чи є введений символ дозволеним
            {
                e.Handled = true; // Відхиляємо неприпустимі символи
            }
            else if (e.KeyChar == decimalSeparator)
            {
                if (textBox.Text.Length == 0 || textBox.Text.Contains(decimalSeparator.ToString()))
                {
                    e.Handled = true; // Відхиляємо кому як перший символ або якщо вже присутня інша кома
                }
            }
        }

        private void TextBox_KeyPress_2(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox; // Отримуємо текстове поле, на якому відбулася подія KeyPress

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b') // Перевіряємо, чи є введений символ дозволеним
            {
                e.Handled = true; // Відхиляємо неприпустимі символи
            }
        }

        private void TextBox_KeyPress_3(object sender, KeyPressEventArgs e)
        {
            char keyPressed = e.KeyChar;

            if (!char.IsLetter(keyPressed) && keyPressed != '\'' && keyPressed != '-' && keyPressed != ' ' && keyPressed != '\b')
            {
                e.Handled = true; // Відхиляємо неприпустимі символи
            }
        }

        //Перехід на наступні елементи
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker1.Focus();
                e.SuppressKeyPress = true; 
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox7.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox8.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox9.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControl1.SelectedTab = tabPage2;
                System.Windows.Forms.TextBox textBox10 = tabPage2.Controls.Find("textBox10", true).FirstOrDefault() as System.Windows.Forms.TextBox;
                textBox10?.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox11.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox12.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox13.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox14.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControl1.SelectedTab = tabPage3;
                System.Windows.Forms.TextBox textBox15 = tabPage3.Controls.Find("textBox15", true).FirstOrDefault() as System.Windows.Forms.TextBox;
                textBox15?.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox16.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox17.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox17_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControl1.SelectedTab = tabPage4;
                System.Windows.Forms.TextBox textBox18 = tabPage4.Controls.Find("textBox18", true).FirstOrDefault() as System.Windows.Forms.TextBox;
                textBox18?.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox19.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox20.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox21.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox21_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox22.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox22_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox23.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox23_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox24.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox24_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControl1.SelectedTab = tabPage5;
                System.Windows.Forms.TextBox textBox25 = tabPage5.Controls.Find("textBox25", true).FirstOrDefault() as System.Windows.Forms.TextBox;
                textBox25?.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox25_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox26.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox26_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox27.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox27_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox28.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox28_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox29.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox29_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox30.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox30_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox31.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 newForm4 = new Form4();
            newForm4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 newForm4 = new Form4();
            newForm4.Show();
        }

        //Збереження розшифровки аналізів в текстовий документ
        private void button3_Click(object sender, EventArgs e)
        {
            // Перевіряємо, чи відкрита Form4
            if (Application.OpenForms.OfType<Form4>().Any())
            {
                Form4 form4 = Application.OpenForms.OfType<Form4>().FirstOrDefault();
                form4.Close();
            }

            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.DefaultExt = "*.txt";
            saveFile1.Filter = "Text files|*.txt";

            saveFile1.FileName = $"{textBox1.Text}.txt"; // Задаємо пропоноване ім'я файлу на основі вмісту textBox1

            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile1.FileName.Length > 0)
            {
                using (StreamWriter sw = new StreamWriter(saveFile1.FileName, true))
                {
                    sw.WriteLine($"Загальні відомості\n");
                    sw.WriteLine($"ПІБ: {textBox1.Text}");
                    sw.WriteLine($"Дата народження: {dateTimePicker1.Text}");
                    sw.WriteLine($"Стать: {comboBox1.Text}");
                    sw.WriteLine($"\nРозшифровка аналізів\n");
                    sw.WriteLine($"Загальний білок: {label76.Text} ({textBox2.Text} г/л)\n");
                    sw.WriteLine($"Альбумін: {label77.Text} ({textBox3.Text} г/л)\n");
                    sw.WriteLine($"Глобулін: {label78.Text} ({textBox4.Text} г/л)\n");
                    sw.WriteLine($"α1-глобулін: {label79.Text} ({textBox5.Text} г/л)\n");
                    sw.WriteLine($"α2-глобулін: {label80.Text} ({textBox6.Text} г/л)\n");
                    sw.WriteLine($"β-глобулін: {label81.Text} ({textBox7.Text} г/л)\n");
                    sw.WriteLine($"γ-глобулін: {label82.Text} ({textBox8.Text} г/л)\n");
                    sw.WriteLine($"Фібриноген: {label83.Text} ({textBox9.Text} г/л)\n");
                    sw.WriteLine($"Ліпіди загальні: {label89.Text} ({textBox10.Text} г/л)\n");
                    sw.WriteLine($"Холестерин загальний: {label90.Text} ({textBox11.Text} ммоль/л)\n");
                    sw.WriteLine($"Тригліцериди: {label91.Text} ({textBox12.Text} ммоль/л)\n");
                    sw.WriteLine($"Ліпіди загальні: {label92.Text} ({textBox13.Text} ммоль/л)\n");
                    sw.WriteLine($"β-ліпопротеїди: {label93.Text} ({textBox14.Text} од.)\n");
                    sw.WriteLine($"Білірубін загальний: {label97.Text} ({textBox15.Text} мкмоль/л)\n");
                    sw.WriteLine($"Білірубін прямий: {label98.Text} ({textBox16.Text} мкмоль/л)\n");
                    sw.WriteLine($"Білірубін непрямий: {label99.Text} ({textBox17.Text} мкмоль/л)\n");
                    sw.WriteLine($"Калій: {label107.Text} ({textBox18.Text} мкмоль/л)\n");
                    sw.WriteLine($"Натрій: {label108.Text} ({textBox19.Text} мкмоль/л)\n");
                    sw.WriteLine($"Кальцій: {label109.Text} ({textBox20.Text} мкмоль/л)\n");
                    sw.WriteLine($"Магній: {label110.Text} ({textBox21.Text} мкмоль/л)\n");
                    sw.WriteLine($"Залізо: {label111.Text} ({textBox22.Text} мкмоль/л)\n");
                    sw.WriteLine($"Фосфор: {label112.Text} ({textBox23.Text} мкмоль/л)\n");
                    sw.WriteLine($"Хлор: {label113.Text} ({textBox24.Text} мкмоль/л)\n");
                    sw.WriteLine($"Аланін-амінотрансфераза (АлАТ): {label121.Text} ({textBox25.Text} нмоль/л)\n");
                    sw.WriteLine($"Аспартат-амінотрансфераза (АсАТ): {label122.Text} ({textBox26.Text} нмоль/л)\n");
                    sw.WriteLine($"α-амілаза: {label123.Text} ({textBox27.Text} мг/(с·л))\n");
                    sw.WriteLine($"Креатинфосфокіназа (КФК): {label124.Text} ({textBox28.Text} нмоль/л)\n");
                    sw.WriteLine($"Лактатдегідрогеназа (ЛДГ): {label125.Text} ({textBox29.Text} нмоль/л)\n");
                    sw.WriteLine($"Фосфатаза лужна (ФЛ): {label126.Text} ({textBox30.Text} нмоль/л)\n");
                    sw.WriteLine($"Холінестераза: {label127.Text} ({textBox31.Text} мкмоль/л)\n");

                    sw.Close();
                }
            }
            this.Close();
        }
    }
}