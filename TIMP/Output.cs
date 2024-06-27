using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIMP
{
    public static class Output
    {
        public static void OutputFiles(DirectoryInfo directory, ListView listView)
        {
            try
            {
                int n = listView.Items.Count;
                FileInfo[] FilesDirectory = directory.GetFiles();
                if (directory.GetFiles().Length > 0)
                {
                    foreach (FileInfo f in FilesDirectory)
                    {
                        if (f.Attributes.HasFlag(FileAttributes.Hidden))
                            listView.Items.Add(f.Name).ForeColor = Color.DarkCyan;
                        else
                        {
                            string[] format = Convert.ToString(f.Name).Split('.');
                            if(format.Last() == "exe" || format.Last() == "cmd")
                                listView.Items.Add(f.Name).ForeColor = Color.Lime;
                            else if (format.Last() == "zip" || format.Last() == "ZIP" || format.Last() == "msi" || format.Last() == "7z")
                                listView.Items.Add(f.Name).ForeColor = Color.Fuchsia;
                            else
                                listView.Items.Add(f.Name).ForeColor = Color.Cyan;
                        }
                            
                    }
                }
                if (listView.Items.Count == n)
                {
                    listView.Items.Add("В этом каталоге нет файлов");
                    listView.Items[n].ForeColor = Color.Cyan;
                }
            }
            catch (System.UnauthorizedAccessException) { }

        }
        public static void OutputDirectory(DirectoryInfo directory, ListView listView)
        {
            listView.Clear();
            listView.Items.Add("...");
            listView.Items[0].ForeColor = Color.White;
            try
            {
                if (directory.GetDirectories().Length > 0)//throw написать
                {
                    DirectoryInfo[] FilesDirectories = directory.GetDirectories();
                    foreach (DirectoryInfo Directory in FilesDirectories)
                    {
                        if (Directory.Attributes.HasFlag(FileAttributes.Hidden))
                            listView.Items.Add(Directory.Name).ForeColor = Color.DarkCyan;
                        else
                            listView.Items.Add(Directory.Name).ForeColor = Color.White;
                    }
                }
                if (listView.Items.Count == 1)
                {
                    listView.Items.Add("В этом каталоге нет папок");
                    listView.Items[1].ForeColor = Color.Cyan;
                }
            }
            catch(System.UnauthorizedAccessException)
            {

                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                if(principal.IsInRole(WindowsBuiltInRole.Administrator) || principal.IsInRole(0x1F4) || principal.IsInRole(0x220) || principal.IsInRole(0x200))
                {
                    listView.Items.Add("В этом каталоге нет файлов");
                    listView.Items.Add("В этом каталоге нет папок");
                    listView.Items[1].ForeColor = Color.Cyan;
                    listView.Items[2].ForeColor = Color.Cyan;
                }
                else
                    MessageBox.Show("Отказано в доступе. Попробуйте запустить программу в режиме администратора");
            }
            
        }
    }
}
