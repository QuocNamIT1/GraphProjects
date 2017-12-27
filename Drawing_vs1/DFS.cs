using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Drawing_vs1
{
    class DFS : Algorithms
    {
        public DFS():base() 
        {
       
        }
        public override void Run(int verIDStart, int verIDStartEnd = 0)
        { 
            List<int> listV = PhatSinhDinh(verIDStart);
            Form1.getInstance().MainListVertex[verIDStart].Color = Color.Blue;
            
            Form1.getInstance().fInvalidate();//reset lai cua so ve
            Thread.Sleep(Form1.timeSleep);//

            Visited.Add(verIDStart);
            if(listV.Count != 0){
                foreach (int i in listV) {
                    int e = GetEdgeFromVertex(verIDStart, i);
                    
                    if (!IsVertexVisited(i))
                    {
                        Form1.getInstance().MainListEdge[e].Color = Color.Blue;
                        Form1.getInstance().DrawMoveV(verIDStart, i);
                        Thread.Sleep(Form1.timeSleep);

                        Run(i);
                        Form1.getInstance().DrawMoveV(i, verIDStart);
                        Thread.Sleep(Form1.timeSleep);

                    }
                    else {
                        Form1.getInstance().MainListEdge[e].Color = Color.Red;
                        Form1.getInstance().fInvalidate();
                        Thread.Sleep(Form1.timeSleep * 20);
                    }
                    if (Form1.getInstance().MainListEdge[e].Color == Color.Red)
                        Form1.getInstance().MainListEdge[e].Color = Color.LightSlateGray;
                }
            }
            
        }
    }
}
