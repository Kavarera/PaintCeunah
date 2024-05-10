using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintCeunah.models
{
    public abstract class Shape
    {
        public EnumShape ShapeType { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Color FillColor { get; set; }
        public Color BorderColor { get; set; }
        public Pen BorderWidth { get; set; }
        public Brush BrushColor;

        public Shape(EnumShape shapeType, Point startPoint, Point endPoint, Color fillColor, Color borderColor, Pen borderWidth)
        {
            ShapeType = shapeType;
            StartPoint = startPoint;
            EndPoint = endPoint;
            FillColor = fillColor;
            BorderColor = borderColor;
            BorderWidth = borderWidth;
            BrushColor = new SolidBrush(fillColor);
        }

        public abstract void Draw(Graphics graphics); // Metode abstract untuk menggambar bentuk


        public virtual void AddPoint(Point point)
        {

        }
    }
}
