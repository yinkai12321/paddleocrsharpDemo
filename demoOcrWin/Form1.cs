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
using PaddleOCRSharp;

namespace demoOcrWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.*|*.bmp;*.jpg;*.jpeg;*.tiff;*.tiff;*.png";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            var imagebyte = File.ReadAllBytes(ofd.FileName);
            Bitmap bitmap = new Bitmap(new MemoryStream(imagebyte));

            OCRModelConfig config = null;
            OCRParameter oCRParameter = null;
            OCRResult ocrResult = new OCRResult();
            using (PaddleOCREngine engine = new PaddleOCREngine(config, oCRParameter))
            {
                ocrResult = engine.DetectText(bitmap);
            }
            if (ocrResult != null)
            {
                textBox1.Text = ocrResult.Text;
            }
        }
    }
}
