using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing_vs1
{
    class Edge
    {
        private String name;
        SolidBrush brush;
        Vertex _v1, _v2;

        internal Vertex V1
        {
            get { return _v1; }
            set { _v1 = value; }
        }

        internal Vertex V2
        {
            get { return _v2; }
            set { _v2 = value; }
        }

        Color _color;

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public SolidBrush Brush
        {
            get { return brush; }
            set{ brush = value;}
        }
        private Pen pen;

        public Pen Pen
        {
            get { return pen; }
            set { pen = value; }
        }
        
        int _g;
        public int G
        {
            get { return _g; }
            set { _g = value; }
        }
        
        bool _canhdoi;//canh doi

        public bool Canhdoi
        {
            get { return _canhdoi; }
            set { _canhdoi = value; }
        }

        Point p1, p2;//luu diem  da ve

        //Method
        public Edge() {
            _g = 1;
            _color = Color.LightSlateGray;
            
            _canhdoi = false;
        }
        
        public void Ve(Graphics g){
            pen = new Pen(_color, 3f);
            p1 = lineDDA( _v1.I.X, _v1.I.Y, _v2.I.X, _v2.I.Y);
            p2 = lineDDA(_v2.I.X, _v2.I.Y, _v1.I.X, _v1.I.Y);
            //p1 = _v1.I;
            //p2 = _v2.I;
            g.SmoothingMode = SmoothingMode.AntiAlias;
           
            
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.ArrowAnchor;

            if (kc(V1.I, V2.I) > 2*V1.R)
            {
                if (_canhdoi)
                {
                    p1 = Ve2Chieu(p1, V1.I, 30);
                    p2 = Ve2Chieu(p2, V2.I, -30);
                }

                g.DrawLine(pen, p1, p2);
                g.DrawString(_g.ToString(), new Font("Arial", 12, FontStyle.Italic), new SolidBrush(Color.Sienna), new Point((p1.X + p2.X) / 2 - 1, (p1.Y + p2.Y) / 2 - 1));
            }
            
        }
        

        public Point Ve2Chieu(Point P, Point TamXoay, int GocXoay) {
            Point p = new Point();
            //tinh tien ve goc toa do
            p.X = P.X - TamXoay.X;
            p.Y = P.Y - TamXoay.Y;
            //xoay quanh tam xoay
            Point q = new Point();//diem sau xoay
            double x = (p.X * Math.Cos(GocXoay) - p.Y * Math.Sin(GocXoay));
            q.X = Round((float)x);
            double y = (p.X * Math.Sin(GocXoay) + p.Y * Math.Cos(GocXoay));
            q.Y = Round((float)y);
            //tinh tien den dung vi tri
            Point Q = new Point();
            Q.X = q.X + TamXoay.X;
            Q.Y = q.Y + TamXoay.Y;
           
            return Q;
        }
        public Point lineDDA(int x1, int y1, int x2, int y2)
        {       // thuat toan DDA
            int x_unit = 1, Dx = x2 - x1, Dy = y2 - y1; // Init first value
            int x = x1;
            float y = y1;
            float y_unit = 1;

            if (Dx < 0)
                x_unit = -1;
            if (Dy < 0)
                y_unit = -1;

            if (x1 == x2)   // duong thang dung
            {
                while (y != y2)
                {
                   
                    y += y_unit;
                    if (!checkVertex(x, Round(y)))
                    {
                        //PutPixel(g,x,(int)y,Color.Red);
                        return new Point(x, Round(y));
                    }
                }
            }
            else if (y1 == y2)  // duong ngang
            {
                while (x != x2)
                {
                    
                    x += x_unit;
                    if (!checkVertex(x, Round(y)))
                    {
                        //PutPixel(g, x, (int)y, Color.Red);
                        return new Point(x, Round(y));
                    }
                }
            }
            else if (x1 != x2 && y1 != y2)// duong xien
            {
                float m = (float)Math.Abs(Dy) / Math.Abs(Dx);
                x_unit = 1;
                y_unit = m;
                x = x1;
                y = y1;

                if (Dx < 0)
                    x_unit = -1;        // ve x giam
                if (Dy < 0)
                    y_unit = -m;        // ve y giam
                //if (!checkVertex(x, (int)y))
                //    PutPixel(g, x, (int)y, Color.Red);
                if (m<=1)
                {
                    while (x != x2)
                    {

                        x += x_unit;
                        y += y_unit;
                        if (!checkVertex(x, Round(y)))
                        {
                            //PutPixel(g, x, (int)y, Color.Red);
                            return new Point(x, Round(y));
                        }
                    }
                }
                else {
                    m = 1 / m;
                    float ix = m;
                    int iy = 1;
                    x = x1;
                    y = y1;
                    if (Dx < 0)
                        ix = -m;        // ve x giam
                    if (Dy < 0)
                        iy = -1; ;        // ve y giam

                    while (y != y2)
                    {

                        x += Round(ix);
                        y += iy;
                        if (!checkVertex(x, Round(y)))
                        {
                            //PutPixel(g, x, (int)y, Color.Red);
                            return new Point(x, Round(y));
                        }
                    }
                }
            }
            return new Point(-100, -100);
        }
        int Round(float i) {
            if (i > (int)i + 0.5) return (int)i + 1;
            else return (int)i;
        }
        public  bool checkVertex(int x, int y) {
            double kc = Math.Sqrt((x - V1.I.X) * (x - V1.I.X) + (y - V1.I.Y) * (y - V1.I.Y));
            if (kc < V1.R) return true;
            kc = Math.Sqrt((x - V2.I.X) * (x - V2.I.X) + (y - V2.I.Y) * (y - V2.I.Y));
            if (kc < V1.R) return true;
            return false;
        }
       
        public bool getCursor(Point sr) {//kiem tra vi tri gia tri g
            Point _i = new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
            if (Math.Sqrt((_i.X - sr.X) * (_i.X - sr.X) + (_i.Y - sr.Y) * (_i.Y - sr.Y)) < V1.R) {
                return true;
            }
            return false;
        }
        public double kc(Point p1, Point p2) {
            double kc = Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
            return kc;
        }//tinh khoang cach 2 diem
        
    }
}
