using System;
using System.IO;
using System.Windows.Forms;

namespace Caesar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Clear();
                using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                {
                    textBox1.Text = reader.ReadToEnd();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                Cipher cipher = new Cipher(int.Parse(toolStripTextBox1.Text));
                textBox3.Text = cipher.EncryptOrDecrypt(textBox1.Text, true);
            }
            else MessageBox.Show("Заполните поле для исходного текста!","Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                Cipher cipher = new Cipher(int.Parse(toolStripTextBox1.Text));
                textBox4.Text = cipher.EncryptOrDecrypt(textBox2.Text, false);
            }
            else MessageBox.Show("Заполните поле для исходного текста!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void очиститьВсеПоляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;
        }

        private void сохранитьЗашифрованноеСообщениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                {
                    writer.WriteLineAsync(textBox3.Text);
                }
            }
        }
    }
}
