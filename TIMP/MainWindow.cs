using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ListView = System.Windows.Forms.ListView;

namespace TIMP
{
    public partial class Form1 : Form
    {
        string DirectoryPath1 = "C:\\";
        string DirectoryPath2 = "D:\\";
        DirectoryInfo dir1 = new DirectoryInfo("C:\\");
        DirectoryInfo dir2 = new DirectoryInfo("D:\\");
        //string DirectoryPath1 = "C:\\Users\\petus";
        //string DirectoryPath2 = "C:\\Users\\petus";
        public Form1()
        {
            InitializeComponent();
            Instalization(dir1, listView1);
            Instalization(dir2, listView2);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }
        public void Instalization(DirectoryInfo directoryInfo, ListView listView)
        {
            Output.OutputDirectory(directoryInfo, listView);
            Output.OutputFiles(directoryInfo, listView);
            PropertiesDirectory(directoryInfo);
        }
        private void UpdateListBox()
        {
            Output.OutputDirectory(dir1, listView1);
            Output.OutputFiles(dir1, listView1);
            Output.OutputDirectory(dir2, listView2);
            Output.OutputFiles(dir2, listView2);
        }
        public void PropertiesDirectory(DirectoryInfo directory)
        {
            try
            {
                if (Directory.Equals(directory, dir1))
                {
                    label2.Text = dir1.FullName;
                    label6.Text = "Bytes: " + DirectoryProperties.GetDirectorySize(DirectoryPath1) + "MB  files: " + dir1.GetFiles().Length + "    folders: " + dir1.GetDirectories().Length;
                }
                else
                {
                    label3.Text = dir2.FullName;
                    label7.Text = "Bytes: " + DirectoryProperties.GetDirectorySize(DirectoryPath2) + "MB  files: " + dir2.GetFiles().Length + "   folders: " + dir2.GetDirectories().Length;
                }
            }
            catch(System.NullReferenceException) {} catch(System.UnauthorizedAccessException) {}
        }
        
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listView1.FocusedItem.Text != null)
                {
                    MoveToDirectory.MoveToDirectoryAndOpenFiles(ref dir1, ref listView1, ref DirectoryPath1);
                    PropertiesDirectory(dir1);
                }
            }
            catch(System.NullReferenceException) { }
        }
        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listView2.FocusedItem.Text != null)
                {
                    MoveToDirectory.MoveToDirectoryAndOpenFiles(ref dir2, ref listView2, ref DirectoryPath2);
                    PropertiesDirectory(dir2);
                }
            }
            catch (System.NullReferenceException) { }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Нажат enter
                MoveToDirectory.MoveToDirectoryAndOpenFiles(ref dir1, ref listView1, ref DirectoryPath1);
            else
            {
                int result = HotKeys.KeyControl(e, DirectoryPath1, DirectoryPath2, listView1);
                if (result == 0)
                    UpdateListBox();
                else if (result == 1)
                    this.Close();
            }
        }
        private void listView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Нажат enter
                MoveToDirectory.MoveToDirectoryAndOpenFiles(ref dir2, ref listView2, ref DirectoryPath2);
            else
            {
                int result = HotKeys.KeyControl(e, DirectoryPath2, DirectoryPath1, listView2);
                if (result == 0)
                    UpdateListBox();
                else if (result == 1)
                    this.Close();
            }
        }
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            DirectoryProperties.InformationAboutDirectory(label4, label5, e, DirectoryPath1);
        }

        private void listView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            DirectoryProperties.InformationAboutDirectory(label9, label8, e, DirectoryPath2);
        }
    }
}
