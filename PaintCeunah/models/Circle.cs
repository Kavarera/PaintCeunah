using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintCeunah.models
{
    public class Circle : Shape
    {
        private bool isDrawingCircle = false; // Menandai apakah sedang menggambar lingkaran
        public Circle(EnumShape shapeType, Point startPoint, Point endPoint, Color fillColor, Color borderColor, Pen borderWidth)
            : base(shapeType, startPoint, endPoint, fillColor, borderColor, borderWidth)
        {
        }

        public override void Draw(Graphics graphics)
        {
            // Hitung koordinat dan dimensi lingkaran atau elips
            // Menggambar lingkaran atau elips
            if (isDrawingCircle)
            {
                // Jika tombol "Alt" kiri ditekan, gambar lingkaran
                Rectangle rec = GetCircleRectangle();
                graphics.DrawEllipse(BorderWidth, rec);
                graphics.FillEllipse(BrushColor, rec);

                //DrawCircle(graphics);

            }
            else
            {
                // Jika tombol "Alt" kiri tidak ditekan, gambar elips
                int x = Math.Min(StartPoint.X, EndPoint.X);
                int y = Math.Min(StartPoint.Y, EndPoint.Y);
                int width = Math.Abs(EndPoint.X - StartPoint.X);
                int height = Math.Abs(EndPoint.Y - StartPoint.Y);
                Rectangle rec = new Rectangle(x, y, width, height);
                graphics.DrawEllipse(BorderWidth, rec);
                graphics.FillEllipse(BrushColor, rec);
            }
        }

        // Method untuk menetapkan apakah sedang menggambar lingkaran atau tidak
        public void SetDrawingCircle(bool isDrawing)
        {
            isDrawingCircle = isDrawing;
        }

        private void DrawCircle(Graphics graphics)
        {
            // Hitung koordinat dan dimensi lingkaran
            int x = Math.Min(StartPoint.X, EndPoint.X);
            int y = Math.Min(StartPoint.Y, EndPoint.Y);
            int width = Math.Abs(StartPoint.X - EndPoint.X);
            int height = Math.Abs(StartPoint.Y - EndPoint.Y);

            // Menggambar lingkaran
            Rectangle rec = GetCircleRectangle();
            graphics.DrawEllipse(BorderWidth, rec);
            graphics.FillEllipse(BrushColor, rec);

        }
        private Rectangle GetCircleRectangle()
        {
            int diameter = Math.Max(Math.Abs(EndPoint.X - StartPoint.X), Math.Abs(EndPoint.Y - StartPoint.Y));
            int x = Math.Min(StartPoint.X, EndPoint.X);
            int y = Math.Min(StartPoint.Y, EndPoint.Y);
            return new Rectangle(x, y, diameter, diameter);
        }
    }
}
