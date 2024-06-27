using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIMP
{
    public partial class SmallWindow : Form
    {
        private string path;
        private string oldNameFile;
        public string Path{ get => path; set { path = value; } }
        public Label Label1 { get { return label1; } set { label1 = value; } }
        public TextBox TextBox1 { get { return textBox1; } set { textBox1 = value; } }

        public SmallWindow()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            oldNameFile = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (label1.Text == "Переименовать файл?")
                {
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Поле ввода должно быть заполнено");
                        textBox1.BackColor = Color.Red;
                    }
                    if (File.Exists(Path + "//" + oldNameFile))
                    {
                        string[] format = oldNameFile.Split('.');
                        string formatFile = format.Last();
                        string[] newFormat = textBox1.Text.Split('.');
                        if (formatFile == newFormat.Last())
                            File.Move(Path + "//" + oldNameFile, Path + "//" + textBox1.Text);
                        else
                            File.Move(Path + "//" + oldNameFile, Path + "//" + textBox1.Text + "." + formatFile);
                    }
                    else if (Directory.Exists(Path + "//" + oldNameFile))
                    {
                        Directory.Move(Path + "//" + oldNameFile, Path + "//" + textBox1.Text);
                    }
                    Form.ActiveForm.Close();
                }
                else
                {
                    if (File.Exists(Path))
                    {
                        File.Delete(Path);
                    }
                    else if (Directory.Exists(Path))
                    {
                        Directory.Delete(Path, true);
                    }
                    Form.ActiveForm.Close();
                }
            }
            catch
            {
                MessageBox.Show("Введите корректне параметры в поле ввода");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }


    }
}
