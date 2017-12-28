using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace cmd____
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            cmdrootstringcount = richTextBox1.Text.Length;
            cmdrootstring = richTextBox1.Lines[richTextBox1.Lines.Count()-1].ToString();

            richTextBox1.Focus();
        }

        private int cmdrootstringcount = 0;
        private int cmdlinecount = 1;
        private string cmdrootstring = "";

        private void createEndline()
        {
            
            richTextBox1.Text += "\n" + cmdrootstring;
            cmdlinecount++;
            richTextBox1.Focus();
            //MessageBox.Show(richTextBox1.Text.Length.ToString());
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            //richTextBox1.SelectionStart = richTextBox1.Text.Length-1;
            //richTextBox1.SelectionLength = 0;
        }


        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            int lineCount = richTextBox1.Lines.Count();
            if (cmdrootstringcount >= richTextBox1.Lines[lineCount - 1].ToString().Length)
            {
                if (e.KeyCode == Keys.Back)
                {
                    e.SuppressKeyPress = true;
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                
                if (cmdrootstringcount >= richTextBox1.Lines[lineCount - 1].ToString().Length)
                {
                    e.SuppressKeyPress = true;
                    
                    richTextBox1.Text += "\n" + cmdrootstring;
                    cmdlinecount++;
                    richTextBox1.Focus();
                    //MessageBox.Show(richTextBox1.Text.Length.ToString());
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    //richTextBox1.SelectionStart = richTextBox1.Text.Length-1;
                    //richTextBox1.SelectionLength = 0;
                  
                   
                    
                }
                else
                {
                    e.SuppressKeyPress = true;
                    if (richTextBox1.Lines[lineCount - 1].ToString().Length == cmdrootstringcount)
                    {

                        MessageBox.Show("Please enter a command.", "Enter Command");

                    }
                    else
                    {
                        String theLines = richTextBox1.Lines[lineCount - 1].ToString();
                        String thecmdline = theLines.Remove(0, cmdrootstringcount);
                        int a = thecmdline.Length + 1;

                        String thecmdworkingdirectory = theLines.Remove(cmdrootstringcount - 1, a);
                        executeCommad(thecmdline, thecmdworkingdirectory);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int lineCount = richTextBox1.Lines.Count();
            
            if (richTextBox1.Lines[lineCount-1].ToString().Length == cmdrootstringcount)
            {

                richTextBox1.Text += "Ipconfig";
                
            }
            else
            {
                richTextBox1.Lines[lineCount - 1].Remove(cmdrootstringcount - 1);
                richTextBox1.Lines[lineCount - 1].Insert(cmdrootstringcount, "ipconfig");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int lineCount = richTextBox1.Lines.Count();

            if (richTextBox1.Lines[lineCount - 1].ToString().Length == cmdrootstringcount)
            {

                MessageBox.Show("Please enter a command.","Enter Command");

            }
            else
            {
                String theLines = richTextBox1.Lines[lineCount - 1].ToString();
                String thecmdline = theLines.Remove(0, cmdrootstringcount);
                int a = thecmdline.Length +1;
                
                String thecmdworkingdirectory = theLines.Remove(cmdrootstringcount-1,a);
                executeCommad(thecmdline,thecmdworkingdirectory);
            }
        }

        private void executeCommad(String cmdline,String workingdirectory)
        {
            var proc1 = new Process();
            string anyCommand = cmdline;
            proc1.StartInfo.UseShellExecute = true;

            proc1.StartInfo.WorkingDirectory = @workingdirectory;//@"C:\Users\Villar";

            proc1.StartInfo.FileName = @"cmd.exe";
            proc1.StartInfo.Verb = "runas";
            proc1.StartInfo.Arguments = "/c " + anyCommand;
            proc1.StartInfo.UseShellExecute = false;
            proc1.StartInfo.RedirectStandardOutput = true;
            proc1.StartInfo.RedirectStandardError = true;
            proc1.StartInfo.CreateNoWindow = true;
            proc1.Start();
            string output = proc1.StandardOutput.ReadToEnd();
            string outputerror = proc1.StandardError.ReadToEnd();
            if (output != null)
            {
                richTextBox1.Text += "\n" + output;
            }else if(outputerror != null ){
                richTextBox1.Text += "\n" + outputerror;
            }

            createEndline();
            
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
