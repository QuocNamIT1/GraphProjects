using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing_vs1
{
    public partial class Input : Form
    {
        //Graphics g;
        //Pen pen;
        //SolidBrush brush;
        
        
        //Point p1, p2;
        //static int number = 0;
        enum DoiTuongVe { canh, dinh,move };
        Form1 fm1;
        Graphics g;
        DoiTuongVe objectShape;
        List<Vertex> listVertex;
        int edge_number_in_list;//dung khi click thay doi g

        internal List<Vertex> ListVertex
        {
            get { return listVertex; }
            set { listVertex = value; }
        }
        List<Edge> listEdge;

        internal List<Edge> ListEdge
        {
            get { return listEdge; }
            set { listEdge = value; }
        }
        static int numberV = 0;

        public static int NumberV
        {
            get { return Input.numberV; }
            set { Input.numberV = value; }
        }

        
        public int[,] matrixRe;
        int MaxVertex = 100;
        TextBox txtg;
        bool bHD = true;//show huong dan 1 lan
        public Input(Form1 fm1)
        {
            InitializeComponent();
            this.fm1 = fm1;
            g = ptbArea.CreateGraphics();
            objectShape = DoiTuongVe.dinh;
            listVertex = new List<Vertex>();
            listEdge = new List<Edge>();
            txtg = new TextBox();
            
           
        }

        public void TextHuongDan(Graphics e) { 
            //khi click lan dau tien
            String taodinh = "Tạo đỉnh đồ thị bằng cách click vào vùng trống";
            String dichuyendinh = "Di chuyển đỉnh bằng cách Shift+ kéo thả đỉnh đến vị trí mong muốn";
            String taocanh = "Tạo cạnh bằng cách click vào đỉnh vào kéo thả đến đỉnh còn lại";
            String thaydoitrongsocanh = "Thay đôi trọng số cạnh bằng cách click vào vị trí trọng số,\n nhập trọng số mới và ấn Enter";

            String HuongDan = taodinh +'\n'+ dichuyendinh +'\n'+ taocanh +'\n'+ thaydoitrongsocanh;
            e.DrawString(HuongDan, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), new Point(0,0));
            
        }
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            listEdge.Clear();
            listVertex.Clear();
            this.Close();
            
        }
        private void ptbArea_MouseDown(object sender, MouseEventArgs e)
        {
           
            if (checkCursorEdge(new Point(e.X, e.Y))) {
                edit_g_edge(new Point(e.X, e.Y));
            }
            else if (!checkCursorVertex(new Point(e.X, e.Y)) && objectShape == DoiTuongVe.dinh)
            {
                CreateVertex(new Point(e.X, e.Y));
                ptbArea.Invalidate();
            }
            else if(checkCursorVertex(new Point(e.X, e.Y)) && Control.ModifierKeys == Keys.Shift){
                //di chuyen dinh
                objectShape = DoiTuongVe.move;
            }
            else if (checkCursorVertex(new Point(e.X, e.Y))) {
                int temp = checkClickVertex(new Point(e.X, e.Y));
                Vertex v = listVertex[temp];
                try
                {
                    CreateEdge(temp);
                    objectShape = DoiTuongVe.canh;
                    listEdge[listEdge.Count - 1].V2 = listVertex[temp];
                }
                catch (Exception ex) { MessageBox.Show(ex.Message);}

                ptbArea.Invalidate();
            }
            
        }
        public void edit_g_edge(Point sr) {
            txtg.Show();
            txtg.Location = sr;
            txtg.KeyDown += new KeyEventHandler(txtg_keyDown);
            ptbArea.Controls.Add(txtg);
            edge_number_in_list = checkClickEdge(sr);
            txtg.Text = "" + listEdge[edge_number_in_list].G;
        }
        void txtg_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                try
                {
                    int a = Int32.Parse(txtg.Text);
                    if(a > 0)
                        listEdge[edge_number_in_list].G = a;
                }
                catch (Exception ex) { MessageBox.Show("loi edit g"); }
                txtg.Hide();
            }
        }
        private void ptbArea_MouseMove(object sender, MouseEventArgs e)
        {

            if (checkCursorVertex(new Point(e.X, e.Y)) || checkCursorEdge(new Point(e.X,e.Y))) 
                ptbArea.Cursor = Cursors.Hand;
            else ptbArea.Cursor = Cursors.Cross;

            if (e.Button == MouseButtons.Left && objectShape == DoiTuongVe.canh)
            {
                Vertex v = new Vertex(-1, new Point(e.X, e.Y));
                listEdge[listEdge.Count - 1].V2 = v;
            }
            else if (e.Button == MouseButtons.Left && objectShape == DoiTuongVe.move) { 
                //di chuyen
                DichuyenDinh(new Point(e.X, e.Y));
                ptbArea.Invalidate();
            }
            ptbArea.Invalidate();
        }
        private void ptbArea_MouseUp(object sender, MouseEventArgs e)
        {
            //if (listEdge.Count > 0)
            //{
            //    listEdge[listEdge.Count - 1].Point2 = new Point(e.X, e.Y);
                
            //}
            //checkDrawE = true;
            if (objectShape == DoiTuongVe.canh) {
                AddEdge(new Point(e.X, e.Y));

            }

            objectShape = DoiTuongVe.dinh;
            ptbArea.Invalidate();
        }
        private void ptbArea_MouseClick(object sender, MouseEventArgs e)
        {           
        }
        public void DichuyenDinh(Point temp) { 
            int V_temp = checkClickVertex(temp);
            if (V_temp > -1)
            {
                Vertex v = listVertex[V_temp];
                v.I = temp;
            }
        }
        public void AddEdge(Point temp) {
            int V_temp = checkClickVertex(temp);
            if (V_temp > -1)
            {
                Vertex v = listVertex[V_temp];
                listEdge[listEdge.Count - 1].V2 = v;
                listEdge[listEdge.Count - 1].Name = listEdge[listEdge.Count - 1].V1.Name + "_" + listEdge[listEdge.Count - 1].V2.Name;
                if (listEdge[listEdge.Count - 1].V1 == listEdge[listEdge.Count - 1].V2)
                {
                    listEdge.RemoveAt(listEdge.Count - 1);
                }

                for (int i = 0; i < listEdge.Count - 1; i++)
                {
                    if ((listEdge[i].V1 == listEdge[listEdge.Count - 1].V1) && (listEdge[i].V2 == listEdge[listEdge.Count - 1].V2))
                    {
                        listEdge.RemoveAt(listEdge.Count - 1);
                        break;
                    }
                    else if ((listEdge[i].V1 == listEdge[listEdge.Count - 1].V2) && (listEdge[i].V2 == listEdge[listEdge.Count - 1].V1))
                    {
                        //listEdge.RemoveAt(listEdge.Count - 1);
                        //listEdge[listEdge.Count - 1].Chieu_mui_ten = 2;
                        listEdge[i].Canhdoi = true;
                        listEdge[listEdge.Count - 1].Canhdoi = true;
                        break;
                    }
                }
            }
            else {
                listEdge.RemoveAt(listEdge.Count - 1);
            }
        }
        public void CreateVertex(Point I) {
            Vertex v;
            v = new Vertex(numberV, I);
            numberV++;
            listVertex.Add(v);
        }

        private void btnDone_MouseClick(object sender, MouseEventArgs e)
        {
            if (listVertex.Count != 0 || ListEdge.Count != 0)
            {
                fm1.MainListEdge = ListEdge.ToList<Edge>();
                fm1.MainListVertex = listVertex.ToList<Vertex>();
                this.Close();
                Form1.getInstance().ChangValue(listVertex.Count-1, listVertex.Count - 1);
                fm1.fInvalidate();
            }
        }

        
        public void CreateEdge(int temp) {
            Vertex v = listVertex[temp];
            Edge edge = new Edge();
            edge.V1 = v;
            listEdge.Add(edge);

        }
        public bool checkCursorVertex(Point sr) {
            for (int i = 0; i < listVertex.Count; i++)
            {
                if (listVertex[i].getCursor(sr) )
                {
                    return true;
                }
            }
            return false;
        }
        public bool checkCursorEdge(Point sr) {
            for (int i = 0; i < listEdge.Count; i++)
            {
                if (listEdge[i].getCursor(sr))
                {
                    return true;
                }
            }
            return false;
        }
        public int checkClickVertex(Point sr) {
            int v = -1;
            for (int i = 0; i < listVertex.Count; i++)
            {
                if (listVertex[i].getCursor(sr))
                {
                    v = i;
                    break;
                }
            }
            return v;    
        }
        public int checkClickEdge(Point sr) {
            int e = -1;
            for (int i = 0; i < listEdge.Count; i++)
            {
                if (listEdge[i].getCursor(sr))
                {
                    e = i;
                    break;
                }
            }
            return e; 
        }
        private void ptbArea_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.Clear(Color.White);
            foreach (Vertex v in listVertex)
                v.Ve(e.Graphics);
            foreach (Edge edge in listEdge)
                edge.Ve(e.Graphics);
           
            if (bHD && listEdge.Count == 0 && listVertex.Count == 0)
            {
                TextHuongDan(e.Graphics);
            }
            else { bHD = false; }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listVertex.Clear();
            ListEdge.Clear();
            numberV = 0;
            g.Clear(Color.White);
            bHD = false;
            txtg.Hide();
            Invalidate();
        }

        private void btnhd_Click(object sender, EventArgs e)
        {
            //xoa het
            listVertex.Clear();
            ListEdge.Clear();
            numberV = 0;
            g.Clear(Color.White);
            //bat huong dan 
            TextHuongDan(g);
            bHD = true;
        }

       
    }
}
