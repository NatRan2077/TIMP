using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIMP
{
    public partial class OperationsWindow : Form
    {
        public string pathfile;
        public TextBox TextBox1 { get { return textBox1; } set { textBox1 = value; } }
        public Label Label1 { get { return label1; } set { label1 = value; } }
        public Button Button1 { get { return button1; } set { button1 = value; } }
        public OperationsWindow()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "")
            {
                MessageBox.Show("Поле ввода должно быть заполнено");
                textBox1.BackColor = Color.Red;
            }
            else
            {
                try
                {
                    textBox1.BackColor = Color.Teal;
                    if (Button1.Text == "Копировать")
                    {
                        FileInfo fileInf = new FileInfo(pathfile);
                        if (fileInf.Exists)
                        {
                            string tmp = TextBox1.Text;
                            string[] format = tmp.Split('\\');
                            string newPath = "";
                            for (int i = 0; i < format.Length - 1; i++)
                            {
                                newPath += format[i] + "\\";
                            }
                            if (Directory.Exists(newPath))
                            {
                                fileInf.CopyTo(newPath + format[format.Length - 1]);
                                Form.ActiveForm.Close();
                            }
                            else
                            {
                                MessageBox.Show("Некорректный путь");
                                textBox1.BackColor = Color.Red;
                            }
                        }

                    }
                    if (Button1.Text == "Переместить")
                    {
                        FileInfo fileInf = new FileInfo(pathfile);
                        if (fileInf.Exists)
                        {
                            string tmp = TextBox1.Text;
                            string[] format = tmp.Split('\\');
                            string newPath = "";
                            for (int i = 0; i < format.Length - 1; i++)
                            {
                                newPath += format[i] + "\\";
                            }
                            if (Directory.Exists(newPath))
                            {
                                fileInf.MoveTo(newPath + format[format.Length - 1]);
                                Form.ActiveForm.Close();
                            }
                            else
                            {
                                MessageBox.Show("Некорректный путь");
                                textBox1.BackColor = Color.Red;
                            }
                        }
                    }
                    if (Button1.Text == "Создать")
                    {
                        DialogResult result = MessageBox.Show("Вы хотите создать папку?", "Создание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string tmp = TextBox1.Text;
                            string[] format = tmp.Split('\\');
                            string newPath = "";
                            for (int i = 0; i < format.Length - 1; i++)
                            {
                                newPath += format[i] + "\\";
                            }
                            if (Directory.Exists(newPath))
                            {
                                Directory.CreateDirectory(newPath + format[format.Length - 1]);
                                Form.ActiveForm.Close();
                            }
                            else
                            {
                                MessageBox.Show("Некорректный путь");
                                textBox1.BackColor = Color.Red;
                            }

                        }
                        else if (result == DialogResult.No)
                        {
                            string tmp = TextBox1.Text;
                            string[] format = tmp.Split('\\');
                            string newPath = "";
                            for (int i = 0; i < format.Length - 1; i++)
                            {
                                newPath += format[i] + "\\";
                            }
                            if (Directory.Exists(newPath))
                            {
                                File.Create(newPath + format[format.Length - 1]);
                                Form.ActiveForm.Close();
                            }
                            else
                            {
                                MessageBox.Show("Некорректный путь");
                                textBox1.BackColor = Color.Red;
                            }
                        }
                        else
                            Form.ActiveForm.Close();
                    }
                }
                catch(UnauthorizedAccessException)
                {
                    MessageBox.Show("Отказано в доступе. Попробуйте запустить программу в режиме администратора");
                }
                catch(System.IO.IOException)
                {
                    MessageBox.Show("Файл с таким именем уже создан");
                }
                
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }
    }
}
