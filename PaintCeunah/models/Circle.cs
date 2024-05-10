using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintCeunah.models
{
    public class Circle : Shape
    {
        public Circle(EnumShape shapeType, Point startPoint, Point endPoint, Color fillColor, Color borderColor, Pen borderWidth)
            : base(shapeType, startPoint, endPoint, fillColor, borderColor, borderWidth)
        {
        }

        public override void Draw(Graphics graphics)
        {
            // Hitung koordinat dan dimensi lingkaran
            int x = Math.Min(StartPoint.X, EndPoint.X);
            int y = Math.Min(StartPoint.Y, EndPoint.Y);
            int width = Math.Abs(StartPoint.X - EndPoint.X);
            int height = Math.Abs(StartPoint.Y - EndPoint.Y);

            // Menggambar lingkaran
            Rectangle rec = GetCircleRectangle();
            graphics.DrawEllipse(BorderWidth,rec);
            graphics.FillEllipse(BrushColor, rec);

        }
        public Rectangle GetCircleRectangle()
        {
            int diameter = Math.Max(Math.Abs(EndPoint.X - StartPoint.X), Math.Abs(EndPoint.Y - StartPoint.Y));
            int x = Math.Min(StartPoint.X, EndPoint.X);
            int y = Math.Min(StartPoint.Y, EndPoint.Y);
            return new Rectangle(x, y, diameter, diameter);
        }
    }
}
