using PaintCeunah.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintCeunah
{
    public partial class Form1 : Form
    {
        private Point startPoint; // Titik awal
        private Point endPoint; // Titik akhir
        private bool isDrawing;
        private EnumShape currentActiveShape= EnumShape.NONE;
        private List<Shape> tumpukanGambar;
        private Shape tempShape;

        private bool isCircle = false; //Untuk toggle ellipse dan circle
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
                Debug.WriteLine("Mouse ditekan");

                switch (currentActiveShape)
                {
                    case EnumShape.CIRCLE:
                        tempShape = new Circle(currentActiveShape, startPoint, startPoint,
                            Color.Red, Color.Green, new Pen(Color.Green, 10));
                        isCircle = (e.Button== MouseButtons.Right)?false:true;
                        break;
                    case EnumShape.SQUARE:
                        tempShape = new Square(currentActiveShape, startPoint, startPoint,
                            Color.Red, Color.Green, new Pen(Color.Green, 10));
                        break;
                    case EnumShape.RECTANGLE:
                        tempShape = new RectangleDrawer(currentActiveShape, startPoint, startPoint,
                            Color.Red, Color.Green, new Pen(Color.Green, 10));
                        break;
                    case EnumShape.LINE:
                        tempShape = new LineDrawer(currentActiveShape, startPoint, startPoint,
                            Color.Red, Color.Green, new Pen(Color.Green, 10));
                        break;
                    case EnumShape.PENCIL:
                        tempShape = new Pencil(currentActiveShape, startPoint, startPoint,
                            Color.Red, Color.Black, new Pen(Color.Green, 2));
                        break;
                    default:
                        // Default behavior
                        break;
                }
            }
        }

        private void CanvasPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && currentActiveShape != EnumShape.NONE)
            {

                if (currentActiveShape == EnumShape.PENCIL && e.Button == MouseButtons.Left)
                {
                    tempShape.AddPoint(e.Location);
                    canvasPanel.Invalidate();
                }
                else
                {
                    endPoint = e.Location;
                    canvasPanel.Invalidate(); // Meminta panel untuk digambar ulang
                }
            }
        }

        private void CanvasPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (currentActiveShape != EnumShape.NONE)
            {
                endPoint = e.Location;
                isDrawing = false;
                tumpukanGambar.Add(tempShape);
                canvasPanel.Invalidate();
            }
        }

        private void CanvasPanel_Paint(object sender, PaintEventArgs e)
        {
            if (isDrawing && currentActiveShape != EnumShape.NONE)
            {
                tempShape.EndPoint = endPoint;

                if(currentActiveShape == EnumShape.CIRCLE)
                {
                    (tempShape as Circle).SetDrawingCircle(isCircle);
                }
                tempShape.Draw(e.Graphics);
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
            else if (currentActiveShape == EnumShape.RECTANGLE)
            {
                btnRectangle.BackColor = Color.Aqua;
            }
            else if (currentActiveShape == EnumShape.LINE)
            {
                btnLine.BackColor = Color.Aqua;
            }
            else if (currentActiveShape == EnumShape.PENCIL)
            {
                btnPencil.BackColor = Color.Aqua;
            }
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            currentActiveShape = EnumShape.SQUARE;
            panel1.Invalidate();
            panel1.Refresh();
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            currentActiveShape = EnumShape.RECTANGLE;
            panel1.Invalidate();
            panel1.Refresh();
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            currentActiveShape = EnumShape.LINE;
            panel1.Invalidate();
            panel1.Refresh();
        }

        private void btnPencil_Click(object sender, EventArgs e)
        {
            currentActiveShape = EnumShape.PENCIL;
            panel1.Invalidate();
            panel1.Refresh();
        }
    }
}
