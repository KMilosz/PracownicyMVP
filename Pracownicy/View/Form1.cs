using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using RadioButton = System.Windows.Forms.RadioButton;

namespace Pracownicy.View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            setValues(null, null, DateTime.Now, 1000, 2, true, false, false);

        }
        public event Action AddUser;
        public event Action Serialization;
        public event Action Deserialization;
        public event Action<string> TextBox1TextChanged;
        public event Action<string> TextBox2TextChanged;
        public event Action<string> DateTimePickerChanged;
        public event Action<string> NumericUpDownChanged;
        public event Action<string> ComboBoxChanged;
        public event Action<string> RadioButtonChanged;
        public event Action<string> LoadSelectedData;
        public string DisplayText
        {
            set
            {
                listBox1.BeginUpdate();
                listBox1.Items.Add(value);
                listBox1.EndUpdate();
            }
            get
            {
                string data = "";
                foreach (string item in listBox1.Items)
                {
                    data += item + ",";
                }
                if (data.Length > 0)
                    data = data.Substring(0, data.Length - 1);

                return data;
            }
        }
        private void add_user(object sender, EventArgs e)
        {
            AddUser?.Invoke();
            setValues("", "", DateTime.Now, 1000, 2, true, false, false);
        }
        public void setValues(string name, string surname, DateTime date, decimal salary, int position, bool r1, bool r2, bool r3)
        {
            textBox1.Text = name;
            textBox2.Text = surname;
            dateTimePicker1.Value = date;
            numericUpDown1.Value = salary;
            comboBox1.SelectedIndex = position;
            radioButton1.Checked = r1;
            radioButton2.Checked = r2;
            radioButton3.Checked = r3;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var n = textBox1.Text;
            TextBox1TextChanged?.Invoke(n);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var n = textBox2.Text;
            TextBox2TextChanged?.Invoke(n);

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            var n = dateTimePicker1.Value.ToString("d");
            DateTimePickerChanged?.Invoke(n);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            var n = numericUpDown1.Value.ToString();
            NumericUpDownChanged?.Invoke(n);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var n = comboBox1.Text;
            ComboBoxChanged?.Invoke(n);
        }

        private void radioButtons_Checked(object sender, EventArgs e)
        {
            var button = sender as RadioButton;
            var n = button.Text.ToString();
            RadioButtonChanged?.Invoke(n);
        }
        
        void nameValidating(object sender, CancelEventArgs e)
        {
            if(String.IsNullOrEmpty(textBox1.Text))
                errorProvider1.SetError(sender as TextBox, "Pole Imię jest puste!");
        }
        void lastnameValidating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))
                errorProvider2.SetError(sender as TextBox, "Pole Nazwisko jest puste!");
        }
        void dateValidating(object sender, CancelEventArgs e)
        {
            if ((dateTimePicker1.Value).ToString() == null || dateTimePicker1.Value > DateTime.Now)
                errorProvider3.SetError(sender as DateTimePicker, "Pole Data jest nieprawidłowe!");
        }
        private void tbData_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lbSender = sender as ListBox;
            if (lbSender.SelectedItem != null)
                LoadSelectedData?.Invoke(lbSender.SelectedItem.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Serialization?.Invoke();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Deserialization?.Invoke();
        }
    }
}
