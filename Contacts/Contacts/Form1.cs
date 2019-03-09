using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contacts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Path to the text files.
        String namePath = @"C:\Users\Abdulkarim Mulla\Desktop\Programming\C#\Contacts\Names.txt";
        String numberPath = @"C:\Users\Abdulkarim Mulla\Desktop\Programming\C#\Contacts\Numbers.txt";
        String emailPath = @"C:\Users\Abdulkarim Mulla\Desktop\Programming\C#\Contacts\Emails.txt";

        //Tab for making space.
        String tab = "\t";

        private void NewBtn_Click(object sender, EventArgs e)
        {
            //Adds a new contact to the phonebook and Enables the buttons.
            panel1.Enabled = true;
            EnableTextBox();
            NameBox.Focus();

        }
        

        //Cancel button for disabling the text boxes.
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DisableTextBox();   
        }

        //Method for disabling textboxes
        private  void DisableTextBox()
        {
            NameBox.Enabled = false;
            NumberBox.Enabled = false;
            EmailBox.Enabled = false;
            SaveBtn.Enabled = false;
        }
        private void ClearContent()
        {
            NameBox.Clear();
            NumberBox.Clear();
            EmailBox.Clear();
        }

        //Method for Enabling textboxes
        private void EnableTextBox()
        {
            NameBox.Enabled = true;
            NumberBox.Enabled = true;
            EmailBox.Enabled = true;
            SaveBtn.Enabled = true;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (NumberBox.Text == "" && EmailBox.Text == "")
            {
                MessageBox.Show("Email or Phone Number cannot be empty!", "ALERT!");
            }
            else if (NameBox.Text == "")
            {
                MessageBox.Show("Name cannot be empty!", "ALERT!");
            }
            else if (NumberBox.Text == "" && EmailBox.Text != "")
            {
                System.IO.File.AppendAllText(namePath, NameBox.Text + "\r\n");
                System.IO.File.AppendAllText(numberPath, tab + "\r\n");
                System.IO.File.AppendAllText(emailPath, EmailBox.Text + "\r\n");
                ClearContent();
            }
            else if (NumberBox.Text != "" && EmailBox.Text == "")
            {
                System.IO.File.AppendAllText(namePath, NameBox.Text + "\r\n");
                System.IO.File.AppendAllText(numberPath, NumberBox.Text + "\r\n");
                System.IO.File.AppendAllText(emailPath, tab + "\r\n");
                ClearContent();
            }
            else
            {
                System.IO.File.AppendAllText(namePath, NameBox.Text + "\r\n");
                System.IO.File.AppendAllText(numberPath, NumberBox.Text + "\r\n");
                System.IO.File.AppendAllText(emailPath, EmailBox.Text + "\r\n");
                ClearContent();
            }
        }

        private void DisplayBtn_Click(object sender, EventArgs e)
        {

            String names = System.IO.File.ReadAllText(namePath, Encoding.UTF8);
            String numbers = System.IO.File.ReadAllText(numberPath, Encoding.UTF8);
            String email = System.IO.File.ReadAllText(emailPath, Encoding.UTF8);

            NameDisplayBox.Text = names;
            NumberDisplayBox.Text = numbers;
            EmailDisplayBox.Text = email;
        }

    }
}
