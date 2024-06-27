using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace TIMP
{
    public static class DirectoryProperties
    {
        public static string GetDirectorySize(string p)
        {
            string[] a = Directory.GetFiles(p, "*.*");
            long b = 0;
            foreach (string name in a)
            {
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            return Convert.ToString(b / 1000000); // Возвращает размер в мегабайтах
        }
        public static void InformationAboutDirectory(Label label1, Label label2, ListViewItemSelectionChangedEventArgs e, string DirectoryPath)
        {
            label1.Text = e.Item.Text;
            string tempPath = DirectoryPath + "\\" + e.Item.Text;
            string sizeFile = "0";
            try
            {
                FileInfo info = new FileInfo(tempPath);
                sizeFile = Convert.ToString(info.Length);
            }
            catch
            {
                sizeFile = "Folder";
            }
            try
            {
                label2.Text = sizeFile + "  " + Convert.ToString(Directory.GetCreationTime(tempPath));
            }
            catch (System.NotSupportedException)
            {
                label2.Text = "";
            }
        }
    }
}
