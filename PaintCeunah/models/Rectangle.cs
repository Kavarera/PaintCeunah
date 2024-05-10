using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintCeunah.models
{
    public class RectangleDrawer : Shape
    {
        public RectangleDrawer(EnumShape shapeType, Point startPoint, Point endPoint, Color fillColor, Color borderColor, Pen borderWidth)
            : base(shapeType, startPoint, endPoint, fillColor, borderColor, borderWidth)
        {
        }

        public override void Draw(Graphics graphics)
        {
            // Hitung koordinat dan dimensi persegi panjang
            int x = Math.Min(StartPoint.X, EndPoint.X);
            int y = Math.Min(StartPoint.Y, EndPoint.Y);
            int width = Math.Abs(StartPoint.X - EndPoint.X);
            int height = Math.Abs(StartPoint.Y - EndPoint.Y);

            // Menggambar persegi panjang
            graphics.DrawRectangle(BorderWidth, x, y, width, height);
            graphics.FillRectangle(BrushColor, x, y, width, height);
        }
    }
}
