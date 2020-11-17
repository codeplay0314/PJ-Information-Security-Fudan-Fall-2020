using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;


namespace DES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string input = "", output = "";

        private bool Check()
        {
            string Key = tbKey.Text;
            string IV = tbIV.Text;
            bool res = true;
            Note0.Text = "";
            Note1.Text = "";
            Note2.Text = "";
            if (input == "")
            {
                Note0.Text = "Please Select File!";
                res = false;
            }
            if (Key.Length != 64)
            {
                Note1.Text = "64bits 0/1 string required!";
                res = false;
            }
            for (int i = 0; i < Key.Length; i++)
                if (Key[i] != '0' && Key[i] != '1')
                {
                    Note1.Text = "64bits 0/1 string required!";
                    res = false;
                    break;
                }
            if (IV.Length != 64)
            {
                Note2.Text = "64bits 0/1 string required!";
                res = false;
            }
            for (int i = 0; i < IV.Length; i++)
                if (IV[i] != '0' && IV[i] != '1')
                {
                    Note2.Text = "64bits 0/1 string required!";
                    res = false;
                    break;
                }
            return res;
        }

        private void FileBotton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "Please Select File";
            fileDialog.Filter = "Text File(*.txt)|*.txt";
            fileDialog.InitialDirectory = Application.StartupPath;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string display = fileDialog.FileName;
                input = Filename.Text = display;
            }
        }
        private void encodeBotton_Click(object sender, EventArgs e)
        {
            string Key = tbKey.Text;
            string IV = tbIV.Text;
            if (!Check()) return;

            SaveFileDialog SaveData = new SaveFileDialog();
            SaveData.Title = "Select File";
            SaveData.InitialDirectory = Application.StartupPath;
            SaveData.Filter = "Text File(*.txt)|*.txt";
            SaveData.FileName = "cipher";
            if (SaveData.ShowDialog() == DialogResult.OK)
            {
                output = SaveData.FileName;
            }
            else
            {
                return;
            }

            Process rsa = new Process();
            rsa.StartInfo.CreateNoWindow = true;         // 不创建新窗口
            rsa.StartInfo.UseShellExecute = false;       // 不启用shell启动进程
            rsa.StartInfo.RedirectStandardInput = true;  // 重定向输入
            rsa.StartInfo.RedirectStandardOutput = true; // 重定向标准输出
            rsa.StartInfo.RedirectStandardError = true;  // 重定向错误输出
            rsa.StartInfo.FileName = "cmd.exe";
            rsa.Start();
            rsa.StandardInput.WriteLine("cd " + Application.StartupPath);
            rsa.StandardInput.WriteLine("python RSA/encode.py");
            rsa.StandardInput.WriteLine(Key);
            string tmp = rsa.StandardOutput.ReadLine();
            while (tmp != Key) tmp = rsa.StandardOutput.ReadLine();
            Key = rsa.StandardOutput.ReadLine();
            rsa.Close();
            rsa.Start();
            rsa.StandardInput.WriteLine("cd " + Application.StartupPath);
            rsa.StandardInput.WriteLine("python RSA/encode.py");
            rsa.StandardInput.WriteLine(IV);
            tmp = rsa.StandardOutput.ReadLine();
            while (tmp != IV) tmp = rsa.StandardOutput.ReadLine();
            IV = rsa.StandardOutput.ReadLine();
            rsa.Close();

            tbKey.PasswordChar = '\0';
            tbKey.Text = "RSA encoded: " + Key;
            tbKey.ForeColor = Color.FromArgb(255, 140, 0, 0);
            Show1.Text = "hide";
            tbIV.PasswordChar = '\0';
            tbIV.Text = "RSA encoded: " + IV;
            tbIV.ForeColor = Color.FromArgb(255, 140, 0, 0);
            Show2.Text = "hide";

            Process p = new Process();
            p.StartInfo.CreateNoWindow = true;         // 不创建新窗口
            p.StartInfo.UseShellExecute = false;       // 不启用shell启动进程
            p.StartInfo.RedirectStandardInput = true;  // 重定向输入
            p.StartInfo.RedirectStandardOutput = true; // 重定向标准输出
            p.StartInfo.RedirectStandardError = true;  // 重定向错误输出
            p.StartInfo.FileName = "desCore.exe";
            p.Start();
            p.StandardInput.WriteLine("1");
            p.StandardInput.WriteLine(Key);
            p.StandardInput.WriteLine(IV);
            p.StandardInput.WriteLine(input);
            p.StandardInput.WriteLine(output);
            p.StandardInput.WriteLine("0");
            MessageBox.Show("Successful!");
            p.Close();
        }

        private void decodeBotton_Click(object sender, EventArgs e)
        {
            string Key = tbKey.Text;
            string IV = tbIV.Text;
            if (!Check()) return;

            SaveFileDialog SaveData = new SaveFileDialog();
            SaveData.Title = "Select File";
            SaveData.InitialDirectory = Application.StartupPath;
            SaveData.Filter = "Text File(*.txt)|*.txt";
            SaveData.FileName = "plain";
            if (SaveData.ShowDialog() == DialogResult.OK)
            {
                output = SaveData.FileName;
            }
            else
            {
                return;
            }

            Process rsa = new Process();
            rsa.StartInfo.CreateNoWindow = true;         // 不创建新窗口
            rsa.StartInfo.UseShellExecute = false;       // 不启用shell启动进程
            rsa.StartInfo.RedirectStandardInput = true;  // 重定向输入
            rsa.StartInfo.RedirectStandardOutput = true; // 重定向标准输出
            rsa.StartInfo.RedirectStandardError = true;  // 重定向错误输出
            rsa.StartInfo.FileName = "cmd.exe";
            rsa.Start();
            rsa.StandardInput.WriteLine("cd " + Application.StartupPath);
            rsa.StandardInput.WriteLine("python RSA/encode.py");
            rsa.StandardInput.WriteLine(Key);
            string tmp = rsa.StandardOutput.ReadLine();
            while (tmp != Key) tmp = rsa.StandardOutput.ReadLine();
            Key = rsa.StandardOutput.ReadLine();
            rsa.Close();
            rsa.Start();
            rsa.StandardInput.WriteLine("cd " + Application.StartupPath);
            rsa.StandardInput.WriteLine("python RSA/encode.py");
            rsa.StandardInput.WriteLine(IV);
            tmp = rsa.StandardOutput.ReadLine();
            while (tmp != IV) tmp = rsa.StandardOutput.ReadLine();
            IV = rsa.StandardOutput.ReadLine();
            rsa.Close();

            tbKey.PasswordChar = '\0';
            tbKey.Text = "RSA encoded: " + Key;
            tbKey.ForeColor = Color.FromArgb(255, 140, 0, 0);
            Show1.Text = "hide";
            tbIV.PasswordChar = '\0';
            tbIV.Text = "RSA encoded: " + IV;
            tbIV.ForeColor = Color.FromArgb(255, 140, 0, 0);
            Show2.Text = "hide";

            Process p = new Process();
            p.StartInfo.CreateNoWindow = true;         // 不创建新窗口    
            p.StartInfo.UseShellExecute = false;       // 不启用shell启动进程  
            p.StartInfo.RedirectStandardInput = true;  // 重定向输入    
            p.StartInfo.RedirectStandardOutput = true; // 重定向标准输出    
            p.StartInfo.RedirectStandardError = true;  // 重定向错误输出
            p.StartInfo.FileName = "desCore.exe";
            p.Start();
            p.StandardInput.WriteLine("2");
            p.StandardInput.WriteLine(Key);
            p.StandardInput.WriteLine(IV);
            p.StandardInput.WriteLine(input);
            p.StandardInput.WriteLine(output);
            p.StandardInput.WriteLine("0");
            MessageBox.Show("Successful!");
            p.Close();
        }

        private void Show1_Click(object sender, EventArgs e)
        {
            if (tbKey.PasswordChar == '*')
            {
                tbKey.PasswordChar = '\0';
                Show1.Text = "hide";
            }
            else
            {
                tbKey.PasswordChar = '*';
                Show1.Text = "show";
            }
        }

        private void Show2_Click(object sender, EventArgs e)
        {
            if (tbIV.PasswordChar == '*')
            {
                tbIV.PasswordChar = '\0';
                Show2.Text = "hide";
            }
            else
            {
                tbIV.PasswordChar = '*';
                Show2.Text = "show";
            }
        }
    }
}
