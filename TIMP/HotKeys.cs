using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ListView = System.Windows.Forms.ListView;

namespace TIMP
{
    public static class HotKeys
    {
        public static int KeyControl(KeyEventArgs e, string path, string newpath, ListView listView)//path - путь откуда берется файл, newpath - путь куда идёт файл
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    MessageBox.Show("Far Manager - это файловый менеджер, который позволяет работать с файлами и директориями на компьютере. " +
                        "Он отличается от других менеджеров тем, что предоставляет пользователю удобный интерфейс для работы с файлами и папками." +
                        "Команды для работы: \nF1 - Помощь\nF2 - Копировать файл\nF3 - Переместить файл\nSHIFT+F3 - Переименовать файл\nF4 - Удалить файл\nF10 - Выйти из программы");
                    return 0;
                }

                else if (e.KeyCode == Keys.F2)
                {
                    OperationsWindow A = new OperationsWindow();
                    A.Label1.Text = "Копировать файл в директорию ";
                    A.Button1.Text = "Копировать";
                    A.pathfile = path + "\\" + listView.FocusedItem.Text; // Путь откуда берем
                    A.TextBox1.Text = newpath + "\\" + listView.FocusedItem.Text; ; //Путь куда копируем
                    A.ShowDialog();
                    return 0;
                }
                else if (e.KeyCode == Keys.F3 && Control.ModifierKeys == Keys.Shift)
                {
                    SmallWindow A = new SmallWindow();
                    A.Label1.Text = "Переименовать файл?";
                    A.TextBox1.Text = listView.FocusedItem.Text;
                    A.Path = path;
                    A.ShowDialog();
                    return 0;
                }
                else if (e.KeyCode == Keys.F3)
                {
                    OperationsWindow A = new OperationsWindow();
                    A.Label1.Text = "Переместить файл в директорию ";
                    A.Button1.Text = "Переместить";
                    A.pathfile = path + "\\" + listView.FocusedItem.Text; // Путь откуда берем
                    A.TextBox1.Text = newpath + "\\" + listView.FocusedItem.Text; ; //Путь куда копируем
                    A.ShowDialog();
                    return 0;
                }
                else if (e.KeyCode == Keys.F4)
                {
                    SmallWindow A = new SmallWindow();
                    A.Label1.Text = "Вы действительно хотите удалить файл?";
                    A.TextBox1.Visible = false;
                    A.Path = path + "\\" + listView.FocusedItem.Text;
                    A.ShowDialog();
                    return 0;
                }
                else if (e.KeyCode == Keys.F5)
                {
                    OperationsWindow A = new OperationsWindow();
                    A.Label1.Text = "Создать файл в директорию ";
                    A.Button1.Text = "Создать";
                    A.TextBox1.Text = path + "\\"; //Путь куда копируем
                    A.ShowDialog();
                    return 0;
                }
                else if (e.KeyCode == Keys.F10)
                {
                    DialogResult result = MessageBox.Show("Вы хотите закрыть программу?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        return 1;
                    }
                    else if (result == DialogResult.No)
                    {
                        return -1;
                    }
                    return 1;
                }
                else
                    return -1;
            }
            catch (System.NullReferenceException) { return -1; }

        }
    }
}
