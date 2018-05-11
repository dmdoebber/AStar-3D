using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace aStar_3D
{
    class PathFinding
    {
        Cubo grid;

		public PathFinding()
        {
            grid = new Cubo(10, 10, 10);
        }

        List<Node> FindPath()
        {
            Node startNode = grid.getNodeFromGrid(0, 0, 0);
            Node targetNode = grid.getNodeFromGrid(9, 9, 9);

            if (startNode == null) { Console.Write("Ponto inicial invalido \n");  return null; }
            if (targetNode == null) { Console.Write("Ponto final invalido \n"); return null; }

            List<Node> openSet = new List<Node>();
            HashSet<Node> closedSet = new HashSet<Node>();

            openSet.Add(startNode);
        
				

            return null;
        }

        public int getDistance(Node nStart, Node nEnd)
        {
            return Convert.ToInt32(Math.Sqrt(Math.Pow(nStart.x - nEnd.x, 2) + Math.Pow(nStart.y - nEnd.y, 2) + Math.Pow(nStart.z - nEnd.z, 2)));
        }
    }
}
