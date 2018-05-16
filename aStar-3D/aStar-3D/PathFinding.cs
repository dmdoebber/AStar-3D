using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace aStar_3D
{
    class PathFinding
    {
        Cubo cubo;

		public PathFinding(int sizeX, int sizeY, int sizeZ)
        {
            cubo = new Cubo(sizeX, sizeY, sizeZ);
        }

        public List<Node> FindPath(int xStart, int yStart, int zStart, int xEnd, int yEnd, int zEnd)
        {
            Node startNode = cubo.getNodeFromGrid(xStart, yStart, zStart);
            Node targetNode = cubo.getNodeFromGrid(xEnd, yEnd, zEnd);

            //verifica se os pontos existem no cubo
            if (startNode == null)  { Console.Write("Ponto inicial invalido \n");  return null; }
            if (targetNode == null) { Console.Write("Ponto final invalido \n");    return null; }

            //setando os pontos de inicio e fim para acessivel (o rand nao colabora para os testes)
            startNode.walkable = true;
            targetNode.walkable = true;

            //lista de nodes fechados e abertos
            List <Node> openSet = new List<Node>();
            HashSet<Node> closedSet = new HashSet<Node>();

            openSet.Add(startNode);

            //enquando existir 
            while (openSet.Count > 0)
            {
                Node currentNode = openSet[0];

                for (int i = 1; i < openSet.Count; i++)
                    if(openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)    
                        currentNode = openSet[i];    

                Console.Write("\nCurrent Node = (" + currentNode.x + "," + currentNode.y + "," + currentNode.z + ") ");

                openSet.Remove(currentNode);
                closedSet.Add(currentNode);

                Console.Write("\nclosedSet = {");
                foreach (Node CS in closedSet)
                {
                    Console.Write("(" + CS.x + "," + CS.y + "," + CS.z + ") ");
                }
                Console.Write("}\n");

                if (currentNode == targetNode)
                {
                    List<Node> path = new List<Node>();
                    for (Node currNode = targetNode; currNode != startNode; currNode = currNode.parent)
                        path.Add(currNode);
                    path.Reverse();
                    return path;
                }
                //Console.Write("neighbours = {");
                foreach (Node neighbour in cubo.getNeighbours(currentNode))
                {
                    //Console.Write("(" +neighbour.x + "," + neighbour.y + "," + neighbour.z + ") ");
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

                //ARVORE DE BUSCA PRODUZIDA
                Console.Write("openSet = {");
                foreach (Node OS in openSet)
                {
                    Console.Write("(" + OS.x + "," + OS.y + "," + OS.z + ")["+OS.gCost+"] ");
                }
                Console.Write("}\n");
            }
            Console.Write("\ncaminho não encontrado!");
            return null;
        }

        public int getDistance(Node nStart, Node nEnd)
        {
            return Convert.ToInt32(Math.Sqrt(Math.Pow(nStart.x - nEnd.x, 2) + Math.Pow(nStart.y - nEnd.y, 2) + Math.Pow(nStart.z - nEnd.z, 2)));
        }
    }
}
