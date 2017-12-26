using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Drawing_vs1
{
    class Vertex 
    {
        int _name;//ten dinh
        Point _i;//tam eclip
        static int  r = 15;//ban kinh hinh eclip

        public int R
        {
            get { return r; }
            set { r = value; }
        }
        
        Pen pen;

        public Pen Pen
        {
            get { return pen; }
            set { pen = value; }
        }
        public Point I {
            get { return _i; }
            set { _i = value; }
        }
        public int Name {
            get { return _name; }
            set { _name = value; }
        }
        Color _color;

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public Vertex(int name, Point i) {
            this._name = name;
            this._i = i;
            _color = Color.Black;
            
        }
        
        public Vertex() { }
        public bool getCursor(Point sr) {
            double kc = Math.Sqrt((_i.X - sr.X) * (_i.X - sr.X) + (_i.Y - sr.Y) * (_i.Y - sr.Y));
            if (kc <= r) return true;
            return false;
        }
        public void Ve(Graphics g) {
            pen = new Pen(_color, 2.0f);
            //g.FillEllipse(brush, new Rectangle(_i.X - r, _i.Y - r, 2 * r, 2 * r));
            //g.DrawString(_name.ToString(), new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Black), new Point(_i.X + r*4/3, _i.Y));
            g.DrawEllipse(pen, new Rectangle(_i.X - r, _i.Y - r, 2 * r, 2 * r));
            g.DrawString(_name.ToString(), new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), new Point(I.X - r / 2, I.Y - r / 2));

        }
        
    }
}
