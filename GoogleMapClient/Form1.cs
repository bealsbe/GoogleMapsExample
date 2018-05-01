﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using Geocode;

namespace GoogleMapClient
{
    public partial class GoogleMapForm : Form
    {
        //List of strings that will hold values for each column in the CSV.
        //List<string> listA = new List<String>();
        //List<string> listB = new List<String>();
        //List<string> listC = new List<String>();
        //List<string> listD = new List<String>();


        public GoogleMapForm()
        {
            InitializeComponent();
        }

        private void CSVButton_Click(object sender, EventArgs e)
        {
            OpenFile(CSVTextBox);
        }

        private void HTMLButton_Click(object sender, EventArgs e)
        {
            OpenFile(HTMLPathTextBox);
        }

        //Dialog for opening a file
        private void OpenFile(TextBox t)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.Stream myStream = null;
                    if ((myStream = ofd.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            t.Text = ofd.FileName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You must select a file path" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void WriteFileButton_Click(object sender, EventArgs e)
        {

        }

        //Example: https://danashurst.com/parsing-a-csv-file/
        private void ReadCSV()
        {
            TextFieldParser parser = new TextFieldParser(CSVTextBox.Text);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
        }
    }
}
