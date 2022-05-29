using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csdl
{

    public class DistOriginal
    {
        public int distance;
        public int parentVert;
        public DistOriginal(int pv, int d)
        {
            distance = d;
            parentVert = pv;
        }
    }
    public class Vertex
    {
        public string label;
        public bool isIntree;
        public Vertex(string lab)
        {
            label = lab;
            isIntree = false;
        }
    }
    public class Graph
    {
        private const int max_verts = 20;
        int infinity = 2000;
        Vertex[] vertexlist;
        int[,] adjMat;
        int nVerts;
        int nTree;
        DistOriginal[] sPath;
        int currentVert;
        int startToCurrent;
        string[] walk = new string[20];
        int[] step = new int[20];
        int k = 0;

        public Graph()
        {
            vertexlist = new Vertex[max_verts];
            adjMat = new int[max_verts, max_verts];
            nVerts = 0;
            nTree = 0;
            for (int i = 0; i <= max_verts - 1; i++)
                for (int j = 0; j <= max_verts - 1; j++)
                {
                    adjMat[i, j] = infinity;
                }
            sPath = new DistOriginal[max_verts];
        }
        public void AddVertex(String lab)
        {
            vertexlist[nVerts] = new Vertex(lab);
            nVerts++;
        }
        public void AddEdge(int start, int theEnd, int weight)
        {
            adjMat[start - 1, theEnd - 1] = weight;
        }
        public void Path(int startTree, int endTree)
        {
            startTree--;
            endTree--;
            int start = 0;
            int end = 0;
            
            if (startTree == endTree) Console.WriteLine("chi phí là 0 , vì hai nhà kho đó là một ");
            else
            {
                if (startTree > endTree)
                {
                    start = endTree;
                    end = startTree;
                }
                else
                {
                    start = startTree;
                    end = endTree;
                }
                walk[0] =walk[0]+ ""+start;
                vertexlist[start].isIntree = true;
                nTree = 1;
                
                for (int i = 0; i <= nVerts; i++)
                {
                    int tempDist = adjMat[start, i];
                    sPath[i] = new DistOriginal(start, tempDist);
                }
                currentVert = start;
                while (nTree < nVerts)
                {

                int indexMin = GetMin(end);
                int minDist = sPath[indexMin].distance;
                currentVert = indexMin;
                startToCurrent = sPath[indexMin].distance;
                vertexlist[currentVert].isIntree = true;
                nTree++;
                AdjustShortPath();
                }
                Console.Write("Từ " + vertexlist[startTree].label);
                DisplayPaths(endTree, start, end);
                nTree = 0;

                Console.WriteLine();
                for (int i = 0; i <= nVerts - 1; i++)
                    vertexlist[i].isIntree = false;
                k = 0;
                for (int i = 0; i < walk.Length; i++)
                    walk[i] = null;
            }
        }
        public int GetMin(int end)
        {   
            int minDist = infinity;
            int indexMin = 0;
            for (int j = 0; j <= nVerts-1; j++)
                if (!(vertexlist[j].isIntree) && sPath[j].distance < minDist)
                {
                    minDist = sPath[j].distance; indexMin = j;
                    walk[k] = vertexlist[ sPath[end].parentVert].label;
                    k++;
                }
            
            return indexMin;
        }
        public void AdjustShortPath()
        {
            int column = 1;
            while (column < nVerts)
                if (vertexlist[column].isIntree) column++;
                else
                {
                    int currentToFring = adjMat[currentVert, column];
                    int startToFringe = startToCurrent + currentToFring;
                    int sPathDist = sPath[column].distance;
                    if (startToFringe < sPathDist)
                    {
                        sPath[column].parentVert = currentVert;
                        sPath[column].distance = startToFringe;
                    }
                    column++;
                }
        }
        public void DisplayPaths(int endtree, int start, int endd)
        {
            if (sPath[endd].distance == infinity)
                Console.Write(" Không có con đường để đi ");
            else
                Console.Write(" phải chi khoản tiền nhỏ nhất là  " + sPath[endd].distance + " để");
            Console.Write(" đến " + vertexlist[endtree].label);
            Console.WriteLine();
            if (sPath[endd].distance != infinity)
            {
                walk[k] = vertexlist[endtree].label;
                Console.Write("con đường : ");   
                filter(walk);
            }
        }
        public void filter(string [] a)
        {
            for (int i = 0; i < k+1; i++)
            {
                if (a[i] != a[i + 1]) 
                    if(i==k ) Console.Write(a[i]); else
                Console.Write(a[i] + " - > ");
            }
        }
    }
}