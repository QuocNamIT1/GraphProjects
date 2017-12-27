using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing_vs1
{
    public partial class Form1 : Form
    {
        Input input;
        public static int timeSleep = 20;
        Graphics g;
        AObject AlgorithmObject;
        int vStart = -1;//dinh bat dau
        int vEnd = -1;//dinh ket thuc
        bool CheckGoalClick = false;//kiem tra xem click dinh ket thuc chua
        List<Edge> mainListEdge;

        internal List<Edge> MainListEdge
        {
            get { return mainListEdge; }
            set { mainListEdge = value; }
        }


        List<Vertex> mainListVertex;

        internal List<Vertex> MainListVertex
        {
            get { return mainListVertex; }
            set { mainListVertex = value; }
        }
        private static Form1 INSTANCE=null;
        public static Form1 getInstance()
        {
            if(INSTANCE==null)
                INSTANCE=new Form1();
            return INSTANCE;
        }
        public static Form1 setInstance(Form1 frm)
        {
            if (INSTANCE == null)
                INSTANCE = frm;
            return INSTANCE;
        }
       
        public Form1()
        {
            InitializeComponent();
            input = new Input(this);
            g = ptbArea.CreateGraphics();

            mainListEdge = new List<Edge>();
            mainListVertex = new List<Vertex>();
            verIDStart.Maximum = 0;
            verIDEnd.Maximum = 0;
            
        }
        public void ChangValue(int m_verIdStart, int m_verIdEnd)
        {
            verIDStart.Maximum = m_verIdStart;
            verIDEnd.Maximum = m_verIdEnd;
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            input = new Input(this);
            input.ListEdge = mainListEdge.ToList<Edge>();
            input.ListVertex = mainListVertex.ToList<Vertex>();
            Input.NumberV = mainListVertex.Count();
            input.ShowDialog();
            
        }
        public void fInvalidate() {
            //g.Clear(Color.White);
            //this.DoubleBuffered = true;
            //foreach (Vertex v in mainListVertex)
            //    v.Ve(g);
            //foreach (Edge edge in mainListEdge)
            //    edge.Ve(g); 

            using (BufferedGraphicsContext context = new BufferedGraphicsContext()) 
            using (BufferedGraphics buffer = context.Allocate(g,new Rectangle (0,0,ptbArea.Width,ptbArea.Height))){
                Bitmap bm = new Bitmap(ptbArea.Width, ptbArea.Height);
                using (Graphics gp = Graphics.FromImage(bm)){
                    foreach (Vertex v in mainListVertex)
                        v.Ve(gp);
                    foreach (Edge edge in mainListEdge)
                        edge.Ve(gp);
                }
                buffer.Graphics.FillRectangle(Brushes.White, 0, 0, ptbArea.Width, ptbArea.Height);
                buffer.Graphics.DrawImage(bm, 0, 0);
                buffer.Render(g);
            }
            //Invalidate();
        }

        private void ptbArea_Paint(object sender, PaintEventArgs e)
        {
            g.Clear(Color.White);
            foreach (Vertex v in mainListVertex)
                v.Ve(g);
            foreach (Edge edge in mainListEdge)
                edge.Ve(g);
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FactoryAlgorithms.getAlgorithms(AObject.DFS).Run((int)verIDStart.Value);
        }
        public void DrawMoveV(int IDv1, int IDv2){//ham trung gian ve su di chuyen dinh
            //DrawMoveVertex(mainListVertex[0],mainListVertex[1]);
            Vertex v1 = mainListVertex[IDv1];
            Vertex v2 = mainListVertex[IDv2];
            DrawMoveVertex(v1.I.X,v1.I.Y,v2.I.X,v2.I.Y);
        }
      
        private void DrawMoveVertex(int x1, int y1, int x2, int y2)//ve di chuyen cua dinh
        {
            
            if (Math.Abs(x2 - x1) > Math.Abs(y2 - y1))
            {
                //Dx > Dy
                int counter = 1;
                if (x1 > x2) counter = -1;
                int x = x1;
                float y = y1;
                float m = ((float)(y2 - y1) / (x2 - x1));
                m = Math.Abs(m);
                if (y2 < y1) m = -m;
                while (x != x2)
                {
                    x += counter;
                    y += m;
                    g.DrawEllipse(new Pen(Color.Blue,3f), new Rectangle(x - 15, (int)y - 15, 30, 30));
                    Thread.Sleep(timeSleep);
                    fInvalidate();
                }
            }
            else { 
               //Dx < Dy
                int counter = 1;
                if (y1 > y2) counter = -1;
                float x = x1;
                int y = y1;
                float m = (float)(x2 - x1) / (y2 - y1);
                m = Math.Abs(m);
                if (x2 < x1) m = -m;
                while (y != y2) {
                    y += counter;
                    x += m;
                    g.DrawEllipse(new Pen(Color.Blue,3f), new Rectangle((int)x - 15, y - 15, 30, 30));
                    Thread.Sleep(timeSleep);
                    fInvalidate();
                }
            }
        }

        public int[,] ConverMatrix() {//ma tran lien ket cho cac dinh
            int[,] Matrix;
            Matrix = new int[mainListVertex.Count, mainListVertex.Count];//ma tran lien ket cac dinh
            for (int i = 0; i < mainListVertex.Count; i++)//init matrix
            {
                for (int j = 0; j < mainListVertex.Count; j++)
                {
                    Matrix[i, j] = -1;
                }
            }
            //copy data from listedge
            foreach (Edge edge in mainListEdge) {
                Matrix[edge.V1.Name, edge.V2.Name] = edge.G;
            }
            return Matrix;
        }

        private void ptbArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (input.checkCursorVertex(e.Location))
            {
                ptbArea.Cursor = Cursors.Hand;
            }
            else {
                ptbArea.Cursor = Cursors.Default;
            }
        }

        private void ptbArea_MouseClick(object sender, MouseEventArgs e)
        {
            int v = input.checkClickVertex(e.Location);
            if (v > -1) {
                switch (AlgorithmObject) {
                    case AObject.BFS:
                        break;
                    case AObject.DFS: FactoryAlgorithms.getAlgorithms(AObject.DFS).Run(v);
                        break;
                    case AObject.Floyd: {
                        if (!CheckGoalClick)
                        {
                            vStart = v;
                            mainListVertex[v].Color = Color.Blue;
                            fInvalidate();
                            CheckGoalClick = true;
                            MessageBox.Show("click chon dinh ket thuc");
                        }
                        else {
                            vEnd = v;
                            mainListVertex[v].Color = Color.Red;
                            fInvalidate();
                            CheckGoalClick = false;
                            FactoryAlgorithms.getAlgorithms(AObject.Floyd).Run(vStart,vEnd);
                        }
                        break;
                    }
                    case AObject.Dijkstra:
                        {
                            if (!CheckGoalClick)
                            {
                                vStart = v;
                                mainListVertex[v].Color = Color.Blue;
                                fInvalidate();
                                CheckGoalClick = true;
                                MessageBox.Show("click chon dinh ket thuc");
                            }
                            else
                            {
                                vEnd = v;
                                mainListVertex[v].Color = Color.Red;
                                fInvalidate();
                                CheckGoalClick = false;
                                FactoryAlgorithms.getAlgorithms(AObject.Dijkstra).Run(vStart,vEnd);
                            }
                            break;
                        }
                    case AObject.FB: {
                        if (!CheckGoalClick)
                        {
                            vStart = v;
                            mainListVertex[v].Color = Color.Blue;
                            fInvalidate();
                            CheckGoalClick = true;
                            MessageBox.Show("click chon dinh ket thuc");
                        }
                        else
                        {
                            vEnd = v;
                            mainListVertex[v].Color = Color.Red;
                            fInvalidate();
                            CheckGoalClick = false;
                            FactoryAlgorithms.getAlgorithms(AObject.FB).Run(vStart, vEnd);
                        }
                        break;
                    }
                    case AObject.Kruskal:
                        FactoryAlgorithms.getAlgorithms(AObject.Kruskal).Run(v);
                        break;
                }
            }
            fInvalidate();
        }

        private void btnBFS_Click(object sender, EventArgs e)
        {
            FactoryAlgorithms.getAlgorithms(AObject.BFS).Run((int)verIDStart.Value);
        }

        private void btnFloyd_Click(object sender, EventArgs e)
        {
            FactoryAlgorithms.getAlgorithms(AObject.Floyd).Run((int)verIDStart.Value, (int)verIDEnd.Value);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mainListVertex.Count; i++)
            {
                mainListVertex[i].Color = Color.Black;
            }
            for (int i = 0; i < MainListEdge.Count; i++)
            {
                MainListEdge[i].Color = Color.Black;
            }
            fInvalidate();
        }

        private void dijkstra_btn_Click(object sender, EventArgs e)
        {
            FactoryAlgorithms.getAlgorithms(AObject.Dijkstra).Run((int)verIDStart.Value, (int)verIDEnd.Value);
        }

        private void btnFB_Click(object sender, EventArgs e)
        {
            FactoryAlgorithms.getAlgorithms(AObject.FB).Run((int)verIDStart.Value, (int)verIDEnd.Value);
        }

        private void verIDStart_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void verIDEnd_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void kruskalBtn_Click(object sender, EventArgs e)
        {
            FactoryAlgorithms.getAlgorithms(AObject.Kruskal).Run((int)verIDStart.Value);
        }
        
    }
}
