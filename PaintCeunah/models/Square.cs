using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintCeunah.models
{
    public class Square : Shape
    {
        public Square(EnumShape shapeType, Point startPoint, Point endPoint, Color fillColor, 
            Color borderColor, Pen borderWidth, 
            float rotationAngle = 0) 
            : base(shapeType, startPoint, endPoint, fillColor, borderColor, borderWidth, rotationAngle)
        {
        }

        public override void Draw(Graphics graphics)
        {
            // Hitung koordinat dan dimensi persegi
            int x = Math.Min(StartPoint.X, EndPoint.X) + Translation.X;
            int y = Math.Min(StartPoint.Y, EndPoint.Y) + Translation.Y;
            int size = Math.Max(Math.Abs(StartPoint.X - EndPoint.X), Math.Abs(StartPoint.Y - EndPoint.Y));
            //for rotation
            int width = Math.Abs(StartPoint.X - EndPoint.X);
            int height = Math.Abs(StartPoint.Y - EndPoint.Y);
            graphics.TranslateTransform((float)(x + width / 2), (float)(y + height / 2));
            graphics.RotateTransform(RotationAngle);
            graphics.TranslateTransform(-(float)(x + width / 2), -(float)(y + height / 2));

            // Menggambar persegi
            graphics.DrawRectangle(BorderWidth, x, y, size, size);
            graphics.FillRectangle(BrushColor, x, y, size, size);
            //resetting transform
            graphics.ResetTransform();
        }
    }
}
