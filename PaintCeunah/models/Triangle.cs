using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PaintCeunah.models
{
    public class Triangle : Shape
    {
        public Triangle(EnumShape shapeType, Point startPoint, Point endPoint, Color fillColor, Color borderColor, Pen borderWidth, float rotationAngle = 0)
            : base(shapeType, startPoint, endPoint, fillColor, borderColor, borderWidth, rotationAngle)
        {
        }

        public override void Draw(Graphics graphics)
        {
            Point[] trianglePoints = GetEquilateralTrianglePoints(StartPoint, EndPoint);

            // Calculate the center point of the triangle
            Point centerPoint = new Point(
                (trianglePoints[0].X + trianglePoints[1].X + trianglePoints[2].X) / 3,
                (trianglePoints[0].Y + trianglePoints[1].Y + trianglePoints[2].Y) / 3
            );

            // Apply rotation and translation
            Matrix transformationMatrix = new Matrix();
            transformationMatrix.Translate(Translation.X, Translation.Y);
            transformationMatrix.RotateAt(RotationAngle, centerPoint);
            graphics.Transform = transformationMatrix;

            // Draw triangle
            graphics.DrawPolygon(BorderWidth, trianglePoints);
            graphics.FillPolygon(BrushColor, trianglePoints);

            // Reset transformation
            graphics.ResetTransform();
        }

        // Method to calculate equilateral triangle points based on center and base length
        private Point[] GetEquilateralTrianglePoints(Point startPoint, Point endPoint)
        {
            // Calculate triangle height based on the base length
            double triangleHeight = Math.Sqrt(3) / 2 * Math.Abs(endPoint.Y - startPoint.Y);

            // Calculate the third vertex (bottom vertex)
            int bottomX = startPoint.X + (endPoint.X - startPoint.X) / 2;
            int bottomY = startPoint.Y + (int)triangleHeight;

            Point[] points = new Point[3];
            points[0] = new Point((startPoint.X + endPoint.X) / 2, startPoint.Y); // top vertex
            points[1] = new Point(endPoint.X, endPoint.Y); // base right vertex
            points[2] = new Point(startPoint.X, endPoint.Y); // base left vertex

            return points;
        }
    }
}
