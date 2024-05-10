using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintCeunah.models
{
    public class LineDrawer : Shape
    {
        public LineDrawer(EnumShape shapeType, Point startPoint, Point endPoint, Color fillColor, Color borderColor, Pen borderWidth) : base(shapeType, startPoint, endPoint, fillColor, borderColor, borderWidth)
        {
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(BorderWidth,StartPoint,EndPoint);
        }
    }
}
