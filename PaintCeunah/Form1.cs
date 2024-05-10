using PaintCeunah.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintCeunah
{
    public partial class Form1 : Form
    {
        private Point startPoint; // Titik awal ketika mouse ditekan
        private Point endPoint; // Titik akhir ketika mouse dilepas
        private Rectangle circleRect; // Rectangle yang mengelilingi lingkaran
        private bool isDrawing; // Untuk menandai apakah sedang dalam mode menggambar
        private EnumShape currentActiveShape= EnumShape.NONE;
        private List<Shape> tumpukanGambar;
        private Shape tempShape;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            tumpukanGambar = new List<Shape>();
            canvasPanel.MouseDown += CanvasPanel_MouseDown;
            canvasPanel.MouseMove += CanvasPanel_MouseMove;
            canvasPanel.MouseUp += CanvasPanel_MouseUp;
            canvasPanel.Paint += CanvasPanel_Paint;
            panel1.Paint += panel1_Paint;
        }


        private void CanvasPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentActiveShape != EnumShape.NONE)
            {
                startPoint = e.Location;
                isDrawing = true;
            }
        }

        private void CanvasPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && currentActiveShape != EnumShape.NONE)
            {
                endPoint = e.Location;
                canvasPanel.Invalidate(); // Meminta panel untuk digambar ulang
            }
        }

        private void CanvasPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (currentActiveShape != EnumShape.NONE)
            {
                endPoint = e.Location;
                isDrawing = false;
                if (currentActiveShape == EnumShape.CIRCLE)
                {
                    tumpukanGambar.Add(tempShape);
                    canvasPanel.Invalidate();
                }
            }
        }

        private void CanvasPanel_Paint(object sender, PaintEventArgs e)
        {
            if (isDrawing && currentActiveShape != EnumShape.NONE)
            {

                if(currentActiveShape == EnumShape.CIRCLE)
                {
                     tempShape= new Circle(currentActiveShape, startPoint, endPoint, 
                        Color.Red, Color.Green, new Pen(Color.Green, 10));
                    tempShape.Draw(e.Graphics);
                    
                }
                foreach (Shape item in tumpukanGambar)
                {
                    item.Draw(e.Graphics);
                }

            }
            else if (!startPoint.IsEmpty && !endPoint.IsEmpty)
            {
                foreach (Shape item in tumpukanGambar)
                {
                    item.Draw(e.Graphics);
                }
            }
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            currentActiveShape = EnumShape.CIRCLE;
            panel1.Invalidate();
            panel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (currentActiveShape != EnumShape.NONE)
            {
                foreach (Control c in panel1.Controls)
                {
                    c.BackColor = SystemColors.Control;
                }
            }
            if(currentActiveShape == EnumShape.CIRCLE)
            {
                btnCircle.BackColor = Color.Aqua;
            }
            else if(currentActiveShape == EnumShape.SQUARE)
            {
                btnSquare.BackColor = Color.Aqua;
            }
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            currentActiveShape = EnumShape.SQUARE;
            panel1.Invalidate();
            panel1.Refresh();
        }
    }
}
