using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace aStar_3D
{
    class PathFinding
    {
        Cubo cubo;
        bool PathSucess = false;

		public PathFinding(int sizeX, int sizeY, int sizeZ)
        {
            cubo = new Cubo(sizeX, sizeY, sizeZ);
        }

        public List<Node> FindPath()
        {
            Node startNode = cubo.getNodeFromGrid(0, 0, 0);
            Node targetNode = cubo.getNodeFromGrid(4, 4, 4);

            if (startNode == null)  { Console.Write("Ponto inicial invalido \n");  return null; }
            if (targetNode == null) { Console.Write("Ponto final invalido \n");    return null; }

            List <Node> openSet = new List<Node>();
            HashSet<Node> closedSet = new HashSet<Node>();

            openSet.Add(startNode);
            Console.Write("raiz = ("+startNode.x+","+startNode.y+","+startNode.z+")\n");

            while (openSet.Count > 0)
            {
                Node currentNode = openSet[0];

                for (int i = 1; i < openSet.Count; i++)
                    if(openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)    
                        currentNode = openSet[i];    

                Console.Write("Current Node = (" + currentNode.x + "," + currentNode.y + "," + currentNode.z + ") ");

                openSet.Remove(currentNode);
                closedSet.Add(currentNode);

                if(currentNode == targetNode)
                {
                    List<Node> path = new List<Node>();
                    for (Node currNode = targetNode; currNode != startNode; currNode = currNode.parent)
                        path.Add(currNode);
                    path.Reverse();
                    return path;
                }
                Console.Write("neighbours = {");
                foreach (Node neighbour in cubo.getNeighbours(currentNode))
                {
                    Console.Write("(" +neighbour.x + "," + neighbour.y + "," + neighbour.z + ") ");
                    if (!neighbour.walkable || closedSet.Contains(neighbour))
                        continue;
                    int newMovementeCostToNeighbour = currentNode.gCost + neighbour.gCost;
                    if(newMovementeCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        neighbour.gCost = newMovementeCostToNeighbour;
                        neighbour.hCost = getDistance(neighbour, targetNode);
                        neighbour.parent = currentNode;

                        if (!openSet.Contains(neighbour))
                            openSet.Add(neighbour);
                    }
                    
                }
                Console.Write("}\n");
            }
            return null;
        }

        public int getDistance(Node nStart, Node nEnd)
        {
            return Convert.ToInt32(Math.Sqrt(Math.Pow(nStart.x - nEnd.x, 2) + Math.Pow(nStart.y - nEnd.y, 2) + Math.Pow(nStart.z - nEnd.z, 2)));
        }
    }
}
