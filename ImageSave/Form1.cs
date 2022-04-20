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

namespace ImageSave
{
    public partial class Form1 : Form
    {
        SelectedImageInfoDto selectedImageInfoDto = new SelectedImageInfoDto();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, Filter = "All files (*.*)|*.*" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                    FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                    selectedImageInfoDto.FullName = fileInfo.FullName;
                    selectedImageInfoDto.Name = fileInfo.Name;
                    selectedImageInfoDto.Extension = fileInfo.Extension;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string folderUrl = Application.StartupPath + "\\" + "Photos";
            if (!Directory.Exists(folderUrl))
            {
                Directory.CreateDirectory(folderUrl);
            }
            
            pictureBox1.Image.Save(folderUrl + "\\" + selectedImageInfoDto.Name);
        }

        private class SelectedImageInfoDto
        {
            public string FullName { get; set; }
            public string Name { get; set; }
            public string Extension { get; set; }
        }
    }
}
