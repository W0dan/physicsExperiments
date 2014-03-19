using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace PhysicsExperiments.Extensions
{
    public static class DrawingGroupExtensions
    {
        public static void DrawText(this DrawingGroup drawingGroup, int x, int y, string text)
        {
            var typeface = new Typeface("Arial");
            var formattedText = new FormattedText(text, CultureInfo.CurrentUICulture,
                                         FlowDirection.LeftToRight, typeface, 10, Brushes.Gray);
            var textgeometry = formattedText.BuildGeometry(new Point(x, y));
            var textDrawing = new GeometryDrawing(Brushes.Gray, new Pen(Brushes.Gray, 0), textgeometry);
            drawingGroup.Children.Add(textDrawing);
        }

        public static void DrawCircle(this DrawingGroup drawingGroup, Point centerPoint, double radius, SolidColorBrush brush, Pen pen = null)
        {
            if (pen == null)
                pen = new Pen(brush, 1);

            var circle = new EllipseGeometry(centerPoint, radius, radius);
            var circleDrawing = new GeometryDrawing(brush, pen, circle);
            drawingGroup.Children.Add(circleDrawing);
        }

        public static void DrawRectangle(this DrawingGroup drawingGroup, Rect rect, SolidColorBrush brush, Pen pen = null)
        {
            if (pen == null)
                pen = new Pen(brush, 1);

            var rectangleGeometry = new RectangleGeometry(rect);
            var rectangleDrawing = new GeometryDrawing(brush, pen, rectangleGeometry);
            drawingGroup.Children.Add(rectangleDrawing);

        }

        public static void DrawLine(this DrawingGroup drawingGroup, Point startPoint, Point endPoint, SolidColorBrush brush)
        {
            var line = new LineGeometry(startPoint, endPoint);
            var lineDrawing = new GeometryDrawing(brush, new Pen(brush, 1), line);
            drawingGroup.Children.Add(lineDrawing);

        }
    }
}