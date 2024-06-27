using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIMP
{
    public static class MoveToDirectory
    {
        public static void MoveToDirectoryAndOpenFiles(ref DirectoryInfo directoryInfo, ref ListView listView, ref string DirectoryPath)
        {
            if (listView.FocusedItem.Text == "...")
            {
                try
                {
                    directoryInfo = directoryInfo.Parent;
                    DirectoryPath = directoryInfo.FullName;
                    Output.OutputDirectory(directoryInfo, listView);
                    Output.OutputFiles(directoryInfo, listView);
                }
                catch (System.NullReferenceException)
                {
                    GetDrivaInfo(ref listView, DirectoryPath);
                }

            }
            else if (Directory.Exists(DirectoryPath + "\\" + listView.FocusedItem.Text))
            {
                DirectoryPath += "\\" + listView.FocusedItem.Text;
                DirectoryInfo dirTMP = new DirectoryInfo(directoryInfo.FullName + "\\" + listView.FocusedItem.Text + "\\");
                directoryInfo = dirTMP;
                Output.OutputDirectory(directoryInfo, listView);
                Output.OutputFiles(directoryInfo, listView);
            }
            else if (File.Exists(DirectoryPath + "\\" + listView.FocusedItem.Text))
            {
                ProcessStartInfo procInfo = new ProcessStartInfo();
                procInfo.FileName = DirectoryPath + "\\" + listView.FocusedItem.Text;
                Process.Start(procInfo);
            }
            else
            {
                directoryInfo = new DirectoryInfo(listView.FocusedItem.Text);
                DirectoryPath = listView.FocusedItem.Text;
                Output.OutputDirectory(directoryInfo, listView);
                Output.OutputFiles(directoryInfo, listView);
            }
        }
        private static void GetDrivaInfo(ref ListView listView, string DirectoryPath)
        {
            listView.Clear();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                listView.Items.Add(drive.Name);
            }
            foreach (ListViewItem b in listView.Items)
                b.ForeColor = Color.White;
        }

    }
}
