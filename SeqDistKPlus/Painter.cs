using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeqDistKPlus
{
    class Painter
    {
        #region Properties
        public Graphics Graphics
        {
            get
            {
                return _graphics;
            }
            set
            {
                _graphics = value;
            }
        }
        public float Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                RefreshCellSize();
            }
        }
        public float Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                RefreshCellSize();
            }
        }
        public int Mode
        {
            get
            {
                return _mode;
            }
            set
            {
                _mode = value;
            }
        }
        public BinaryNode TreeRoot { get => _treeRoot; }
        public Dictionary<PointF, BinaryNode> nodePositions { get; set; } = new Dictionary<PointF, BinaryNode>();
        #endregion

        #region private fields

        private Graphics _graphics;
        private float _width;
        private float _height;
        private string _treeDesc;
        private int _mode;
        private Font _font;

        private BinaryNode _treeRoot;
        private float cellWidth;
        private float cellHeight;
        private float cellRadius;
        private float cellAngle;
        #endregion

        public Painter(Graphics graphics, float width, float height, BinaryNode treeRoot, int mode, Font font)
        {
            _graphics = graphics;
            _treeRoot = treeRoot;
            _width = width;
            _height = height;
            _mode = mode;
            _font = font;
            RefreshCellSize();
            Repaint();
        }

        public void Repaint()
        {
            _graphics.Clear(Color.White);
            nodePositions.Clear();
            PaintTree(_treeRoot, new PointF(0f, 0f), out _, out _);
        }

        private void RefreshCellSize()
        {
            var depth = _treeRoot.depth;
            var childCount = _treeRoot.childCount;
            cellWidth = Width / (depth + 2);
            cellHeight = Height / childCount;
            cellRadius = Math.Min(Width, Height) / 2 / depth - 2;
            cellAngle = (float)Math.PI * 2 / childCount;
        }

        public static BinaryNode BuildTree(string treeDesc)
        {
            return BuildNode(treeDesc, 0, out _);
        }

        private static BinaryNode BuildNode(string treeDesc, int begin, out int end)
        {
            var node = new BinaryNode();
            var builder = new StringBuilder();
            end = 0;
            if (treeDesc[begin] == '(')
            {
                node.leftChild = BuildNode(treeDesc, begin + 1, out end);
                node.rightChild = BuildNode(treeDesc, end + 1, out end);
                end++;
            }
            else
            {
                for (end = begin; treeDesc[end] != ':' && treeDesc[end] != ',' && treeDesc[end] != ')'; end++)
                {
                    builder.Append(treeDesc[end]);
                }
                node.value = builder.ToString();
            }
            builder.Clear();
            if (end >= treeDesc.Length)
            {
                return node;
            }
            if (treeDesc[end] == ':')
            {
                for (end++; treeDesc[end] != ',' && treeDesc[end] != ')' && end < treeDesc.Length; end++)
                {
                    builder.Append(treeDesc[end]);
                }
                node.combound = double.Parse(builder.ToString());
            }
            return node;
        }
    
        private PointF PaintTree(BinaryNode node, PointF pos, out Color color, out float handleHeight)
        {
            Func<PointF, PointF> PolarToCartesian = (PointF polarPoint) => new PointF(Width / 2 + polarPoint.X * (float)Math.Cos(polarPoint.Y), Height / 2 + polarPoint.X * (float)Math.Sin(polarPoint.Y));
            switch (Mode)
            {
                case 0: // Standard
                    if (node.value == null)
                    {
                        Color leftColor, rightColor;
                        var mid = PaintTree(node.leftChild, new PointF(pos.X + cellWidth, pos.Y), out leftColor, out float handleHeightA);
                        mid.X = pos.X + cellWidth;
                        var end = PaintTree(node.rightChild, mid, out rightColor, out float handleHeightB);
                        if (leftColor == rightColor)
                        {
                            color = leftColor;
                        }
                        else
                        {
                            color = Color.Black;
                        }
                        //DrawText(new PointF(pos.X, (pos.Y + end.Y) / 2), string.Format("{0:e3}", node.combound), color, StringAlignment.Far);
                        handleHeight = (handleHeightA + handleHeightB) / 2;
                        DrawLine(new PointF(pos.X, handleHeight), new PointF(mid.X, handleHeight), color);
                        // DrawLine(new PointF(mid.X, handleHeightA), new PointF(mid.X, handleHeightB), color);
                        DrawLine(new PointF(mid.X, handleHeightA), new PointF(mid.X, handleHeight), leftColor);
                        DrawLine(new PointF(mid.X, handleHeight), new PointF(mid.X, handleHeightB), rightColor);
                        nodePositions[new PointF(mid.X, handleHeight)] = node;
                        return end;
                    }
                    else
                    {
                        SequenceData sd;
                        if (frmMain.sequenceDatas.TryGetValue(node.value, out sd))
                        {
                            color = sd.color;
                        }
                        else
                        {
                            color = Color.Black;
                        }
                        DrawText(pos, node.value, color);
                        handleHeight = pos.Y + cellHeight / 2;
                        return new PointF(pos.X + cellWidth, pos.Y + cellHeight);
                    }
                case 1: // Circular
                    if (node.value == null)
                    {
                        Color leftColor, rightColor;
                        var mid = PaintTree(node.leftChild, new PointF(pos.X + cellRadius, pos.Y), out leftColor, out float handleHeightA);
                        mid.X = pos.X + cellRadius;
                        var end = PaintTree(node.rightChild, mid, out rightColor, out float handleHeightB);
                        if (leftColor == rightColor)
                        {
                            color = leftColor;
                        }
                        else
                        {
                            color = Color.Black;
                        }
                        //DrawText(PolarToCartesian(new PointF(pos.X, (pos.Y + end.Y) / 2)), string.Format("{0:f3}", node.combound), StringAlignment.Far);
                        handleHeight = (handleHeightA + handleHeightB) / 2;
                        DrawLine(PolarToCartesian(new PointF(pos.X, handleHeight)), PolarToCartesian(new PointF(mid.X, handleHeight)), color);
                        //DrawArc(new PointF(Width / 2, Height / 2), mid.X, handleHeightA, handleHeightB, color);
                        DrawArc(new PointF(Width / 2, Height / 2), mid.X, handleHeightA, handleHeight, leftColor);
                        DrawArc(new PointF(Width / 2, Height / 2), mid.X, handleHeight, handleHeightB, rightColor);
                        nodePositions[PolarToCartesian(new PointF(mid.X, handleHeight))] = node;
                        return end;
                    }
                    else
                    {
                        SequenceData sd;
                        if (frmMain.sequenceDatas.TryGetValue(node.value, out sd))
                        {
                            color = sd.color;
                        }
                        else
                        {
                            color = Color.Black;
                        }
                        var pos2 = pos;
                        pos2.Y += cellAngle / 2;
                        var pos3 = pos2;
                        pos3.X = cellRadius * (_treeRoot.depth - 1);
                        DrawLine(PolarToCartesian(pos2), PolarToCartesian(pos3), color);
                        DrawTextAngled(PolarToCartesian(pos2), node.value, color, StringAlignment.Near, pos.Y);
                        handleHeight = pos.Y + cellAngle / 2;
                        return new PointF(pos.X + cellRadius, pos.Y + cellAngle);
                    }
                case 2: // Align Text
                    if (node.value == null)
                    {
                        Color leftColor, rightColor;
                        var mid = PaintTree(node.leftChild, new PointF(pos.X + cellWidth, pos.Y), out leftColor, out float handleHeightA);
                        mid.X = pos.X + cellWidth;
                        var end = PaintTree(node.rightChild, mid, out rightColor, out float handleHeightB);
                        if (leftColor == rightColor)
                        {
                            color = leftColor;
                        }
                        else
                        {
                            color = Color.Black;
                        }
                        //DrawText(new PointF(pos.X, (pos.Y + end.Y) / 2), string.Format("{0:e3}", node.combound), color, StringAlignment.Far);
                        handleHeight = (handleHeightA + handleHeightB) / 2;
                        DrawLine(new PointF(pos.X, handleHeight), new PointF(mid.X, handleHeight), color);
                        // DrawLine(new PointF(mid.X, handleHeightA), new PointF(mid.X, handleHeightB), color);
                        DrawLine(new PointF(mid.X, handleHeightA), new PointF(mid.X, handleHeight), leftColor);
                        DrawLine(new PointF(mid.X, handleHeight), new PointF(mid.X, handleHeightB), rightColor);
                        nodePositions[new PointF(mid.X, handleHeight)] = node;
                        return end;
                    }
                    else
                    {
                        SequenceData sd;
                        if (frmMain.sequenceDatas.TryGetValue(node.value, out sd))
                        {
                            color = sd.color;
                        }
                        else
                        {
                            color = Color.Black;
                        }
                        DrawText(new PointF(TreeRoot.depth * cellWidth, pos.Y), node.value, color);
                        handleHeight = pos.Y + cellHeight / 2;
                        DrawLine(new PointF(pos.X, handleHeight), new PointF(TreeRoot.depth * cellWidth, handleHeight), color);
                        return new PointF(pos.X + cellWidth, pos.Y + cellHeight);
                    }
                case 3: // Triangular
                    if (node.value == null)
                    {
                        Color leftColor, rightColor;
                        var mid = PaintTree(node.leftChild, new PointF(pos.X + cellWidth, pos.Y), out leftColor, out float handleHeightA);
                        mid.X = pos.X + cellWidth;
                        var end = PaintTree(node.rightChild, mid, out rightColor, out float handleHeightB);
                        if (leftColor == rightColor)
                        {
                            color = leftColor;
                        }
                        else
                        {
                            color = Color.Black;
                        }
                        //DrawText(new PointF(pos.X, (pos.Y + end.Y) / 2), string.Format("{0:e3}", node.combound), color, StringAlignment.Far);
                        handleHeight = (handleHeightA + handleHeightB) / 2;
                        //DrawLine(new PointF(pos.X, handleHeight), new PointF(mid.X, handleHeight), color);
                        DrawLine(new PointF(mid.X - cellWidth, handleHeight), new PointF(mid.X, handleHeightA), leftColor);
                        DrawLine(new PointF(mid.X - cellWidth, handleHeight), new PointF(mid.X, handleHeightB), rightColor);
                        nodePositions[new PointF(mid.X - cellWidth, handleHeight)] = node;
                        return end;
                    }
                    else
                    {
                        SequenceData sd;
                        if (frmMain.sequenceDatas.TryGetValue(node.value, out sd))
                        {
                            color = sd.color;
                        }
                        else
                        {
                            color = Color.Black;
                        }
                        DrawText(new PointF(pos.X, pos.Y), node.value, color);
                        handleHeight = pos.Y + cellHeight / 2;
                        //DrawLine(new PointF(pos.X, handleHeight), new PointF(pos.X + cellWidth, handleHeight), color);
                        return new PointF(pos.X + cellWidth, pos.Y + cellHeight);
                    }
                case 4: // Bezier
                    if (node.value == null)
                    {
                        Color leftColor, rightColor;
                        var mid = PaintTree(node.leftChild, new PointF(pos.X + cellWidth, pos.Y), out leftColor, out float handleHeightA);
                        mid.X = pos.X + cellWidth;
                        var end = PaintTree(node.rightChild, mid, out rightColor, out float handleHeightB);
                        if (leftColor == rightColor)
                        {
                            color = leftColor;
                        }
                        else
                        {
                            color = Color.Black;
                        }
                        //DrawText(new PointF(pos.X, (pos.Y + end.Y) / 2), string.Format("{0:e3}", node.combound), color, StringAlignment.Far);
                        handleHeight = (handleHeightA + handleHeightB) / 2;
                        //DrawLine(new PointF(pos.X, handleHeight), new PointF(mid.X, handleHeight), color);
                        DrawBezier(new PointF(mid.X - cellWidth, handleHeight), new PointF(mid.X, handleHeightA), leftColor);
                        DrawBezier(new PointF(mid.X - cellWidth, handleHeight), new PointF(mid.X, handleHeightB), rightColor);
                        nodePositions[new PointF(mid.X - cellWidth, handleHeight)] = node;
                        return end;
                    }
                    else
                    {
                        SequenceData sd;
                        if (frmMain.sequenceDatas.TryGetValue(node.value, out sd))
                        {
                            color = sd.color;
                        }
                        else
                        {
                            color = Color.Black;
                        }
                        DrawText(new PointF(pos.X, pos.Y), node.value, color);
                        handleHeight = pos.Y + cellHeight / 2;
                        //DrawLine(new PointF(pos.X, handleHeight), new PointF(pos.X + cellWidth, handleHeight), color);
                        return new PointF(pos.X + cellWidth, pos.Y + cellHeight);
                    }
                case 5: // Circular Triangular
                    if (node.value == null)
                    {
                        Color leftColor, rightColor;
                        var mid = PaintTree(node.leftChild, new PointF(pos.X + cellRadius, pos.Y), out leftColor, out float handleHeightA);
                        mid.X = pos.X + cellRadius;
                        var end = PaintTree(node.rightChild, mid, out rightColor, out float handleHeightB);
                        if (leftColor == rightColor)
                        {
                            color = leftColor;
                        }
                        else
                        {
                            color = Color.Black;
                        }
                        //DrawText(PolarToCartesian(new PointF(pos.X, (pos.Y + end.Y) / 2)), string.Format("{0:f3}", node.combound), StringAlignment.Far);
                        handleHeight = (handleHeightA + handleHeightB) / 2;
                        //DrawLine(PolarToCartesian(new PointF(pos.X, handleHeight)), PolarToCartesian(new PointF(mid.X, handleHeight)), color);
                        //DrawArc(new PointF(Width / 2, Height / 2), mid.X, handleHeightA, handleHeightB, color);
                        DrawLine(PolarToCartesian(new PointF(mid.X - cellRadius, handleHeight)), PolarToCartesian(new PointF(mid.X, handleHeightA)), leftColor);
                        DrawLine(PolarToCartesian(new PointF(mid.X - cellRadius, handleHeight)), PolarToCartesian(new PointF(mid.X, handleHeightB)), rightColor);
                        nodePositions[PolarToCartesian(new PointF(mid.X - cellRadius, handleHeight))] = node;
                        return end;
                    }
                    else
                    {
                        SequenceData sd;
                        if (frmMain.sequenceDatas.TryGetValue(node.value, out sd))
                        {
                            color = sd.color;
                        }
                        else
                        {
                            color = Color.Black;
                        }
                        var pos2 = pos;
                        pos2.Y += cellAngle / 2;
                        var pos3 = pos2;
                        pos3.X = cellRadius * (_treeRoot.depth - 1);
                        DrawLine(PolarToCartesian(pos2), PolarToCartesian(pos3), color);
                        DrawTextAngled(PolarToCartesian(pos2), node.value, color, StringAlignment.Near, pos.Y);
                        handleHeight = pos.Y + cellAngle / 2;
                        return new PointF(pos.X + cellRadius, pos.Y + cellAngle);
                    }
                case 6: // Circular Bezier
                    if (node.value == null)
                    {
                        Color leftColor, rightColor;
                        var mid = PaintTree(node.leftChild, new PointF(pos.X + cellRadius, pos.Y), out leftColor, out float handleHeightA);
                        mid.X = pos.X + cellRadius;
                        var end = PaintTree(node.rightChild, mid, out rightColor, out float handleHeightB);
                        if (leftColor == rightColor)
                        {
                            color = leftColor;
                        }
                        else
                        {
                            color = Color.Black;
                        }
                        //DrawText(PolarToCartesian(new PointF(pos.X, (pos.Y + end.Y) / 2)), string.Format("{0:f3}", node.combound), StringAlignment.Far);
                        handleHeight = (handleHeightA + handleHeightB) / 2;
                        //DrawLine(PolarToCartesian(new PointF(pos.X, handleHeight)), PolarToCartesian(new PointF(mid.X, handleHeight)), color);
                        //DrawArc(new PointF(Width / 2, Height / 2), mid.X, handleHeightA, handleHeightB, color);
                        _graphics.DrawBezier(new Pen(new SolidBrush(leftColor)),
                            PolarToCartesian(new PointF(mid.X - cellRadius, handleHeight)),
                            PolarToCartesian(new PointF(mid.X, handleHeight)),
                            PolarToCartesian(new PointF(mid.X - cellRadius, handleHeightA)),
                            PolarToCartesian(new PointF(mid.X, handleHeightA)));
                        _graphics.DrawBezier(new Pen(new SolidBrush(rightColor)),
                            PolarToCartesian(new PointF(mid.X - cellRadius, handleHeight)),
                            PolarToCartesian(new PointF(mid.X, handleHeight)),
                            PolarToCartesian(new PointF(mid.X - cellRadius, handleHeightB)),
                            PolarToCartesian(new PointF(mid.X, handleHeightB)));
                        nodePositions[PolarToCartesian(new PointF(mid.X - cellRadius, handleHeight))] = node;
                        return end;
                    }
                    else
                    {
                        SequenceData sd;
                        if (frmMain.sequenceDatas.TryGetValue(node.value, out sd))
                        {
                            color = sd.color;
                        }
                        else
                        {
                            color = Color.Black;
                        }
                        var pos2 = pos;
                        pos2.Y += cellAngle / 2;
                        var pos3 = pos2;
                        pos3.X = cellRadius * (_treeRoot.depth - 1);
                        DrawLine(PolarToCartesian(pos2), PolarToCartesian(pos3), color);
                        DrawTextAngled(PolarToCartesian(pos2), node.value, color, StringAlignment.Near, pos.Y);
                        handleHeight = pos.Y + cellAngle / 2;
                        return new PointF(pos.X + cellRadius, pos.Y + cellAngle);
                    }
                default:
                    color = Color.Black;
                    handleHeight = 0;
                    return new PointF();
            }

        }

        private void DrawLine(PointF start, PointF end, Color color)
        {
            _graphics.DrawLine(new Pen(new SolidBrush(color), 2), start, end);
        }

        private void DrawText(PointF pos, string text, Color color, StringAlignment alignment = StringAlignment.Center)
        {
            //_graphics.RotateTransform(angle * 180 / (float)Math.PI);
            color = SystemColors.ControlText;
            _graphics.DrawString(text, _font, new SolidBrush(color), new PointF(pos.X, pos.Y + cellHeight / 2 - _graphics.MeasureString(text, _font).Height / 2));
            //_graphics.RotateTransform(-angle * 180 / (float)Math.PI);
            //_graphics.DrawEllipse(new Pen(new SolidBrush(color)), new RectangleF(
            //    new PointF(pos.X, pos.Y + cellHeight / 2 - _graphics.MeasureString(text, _font).Height / 2),
            //    new SizeF(cellHeight, cellHeight)
            //));
        }

        private void DrawTextAngled(PointF pos, string text, Color color, StringAlignment alignment = StringAlignment.Center, float angle = 0)
        {
            color = SystemColors.ControlText;

            _graphics.TranslateTransform(Width / 2, Height / 2);
            angle += cellAngle / 2;
            _graphics.RotateTransform(angle * 180 / (float)Math.PI);
            _graphics.DrawString(text, _font, new SolidBrush(color), new PointF(cellRadius * (_treeRoot.depth - 1), -_graphics.MeasureString(text, _font).Height / 2));
            _graphics.RotateTransform(-angle * 180 / (float)Math.PI);
            _graphics.TranslateTransform(-Width / 2, -Height / 2);
        }

        private void DrawArc(PointF center, float radius, float startAngle, float endAngle, Color color)
        {
            if (radius > 0)
            {
                var rectangle = new RectangleF(center.X - radius, center.Y - radius, radius * 2, radius * 2);
                _graphics.DrawArc(new Pen(new SolidBrush(color), 2), rectangle, startAngle * 180 / (float)Math.PI, (endAngle - startAngle) * 180 / (float)Math.PI);
            }
        }

        private void DrawBezier(PointF start, PointF end, Color color)
        {
            _graphics.DrawBezier(new Pen(new SolidBrush(color), 2),
                start,
                new PointF(end.X, start.Y),
                new PointF(start.X, end.Y),
                end);
        }
    }
}
