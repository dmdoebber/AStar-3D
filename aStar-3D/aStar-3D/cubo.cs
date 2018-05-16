using System;
using System.Collections.Generic;

namespace aStar_3D
{
    class Cubo
    {
        private int sizeX, sizeY, sizeZ;
        public Node[,,] grid { get; private set; }

        public Cubo(int _sizeX, int _sizeY, int _sizeZ)
        {
            sizeX = _sizeX;
            sizeY = _sizeY;
            sizeZ = _sizeZ;
            createGrid();
        }

        public void createGrid()
        {
            int peso = 0;
            bool    walkable;
            Random  rnd = new Random();
            grid = new Node[sizeX, sizeY, sizeZ];
            
            for (int x = 0; x < sizeX; x++)
            {
                for(int y = 0; y < sizeY; y++)
                {
                    for(int z = 0; z < sizeZ; z++)
                    {
                        if (rnd.Next(2) == 1) { walkable = false; }
                        else { walkable = true; peso = rnd.Next(1, 9); }
                        grid[x, y, z] = new Node(x, y, z, walkable, peso);
                    }
                }
            }
        }

        public List<Node> getNeighbours(Node node)
        {
            List<Node> neighbours = new List<Node>();

            if (node.x + 1 < sizeX && node.walkable) neighbours.Add(grid[node.x + 1, node.y, node.z]);
            if (node.x - 1 >= 0 && node.walkable)    neighbours.Add(grid[node.x - 1, node.y, node.z]);
            if (node.y + 1 < sizeY && node.walkable) neighbours.Add(grid[node.x, node.y + 1, node.z]);
            if (node.y - 1 >= 0 && node.walkable)    neighbours.Add(grid[node.x, node.y - 1, node.z]);
            if (node.z + 1 < sizeZ && node.walkable) neighbours.Add(grid[node.x, node.y, node.z + 1]);
            if (node.z - 1 >= 0 && node.walkable)    neighbours.Add(grid[node.x, node.y, node.z - 1]);

            return neighbours;
        }

        public Node getNodeFromGrid(int posX, int posY, int posZ)
        {           
            if ((posX < sizeX && posX >= 0) && (posY < sizeY && posY >= 0) && (posZ < sizeZ && posZ >= 0))
                return grid[posX, posY, posZ];     
            return null;
        }
    }
}