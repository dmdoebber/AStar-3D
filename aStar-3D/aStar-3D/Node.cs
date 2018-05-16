using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aStar_3D
{
    class Node
    {
        public int  x, y, z; //variaveis que indicam a posicao x, y, z no cubo
        public int  gCost, hCost; //gCost - indica o custo para chegar no ponto determinado |hCoas - acumula o custo
        public bool walkable; //identifica se é possivel se movimentar para a posicao
        public Node parent; //pai - serve para recosntruir a arvore

        public Node(int _x, int _y, int _z, bool _walkable, int _gCost)
        {
            walkable = _walkable;
            gCost = _gCost;
            x = _x;
            y = _y;
            z = _z;
        }

        //
        public int fCost { get { return gCost + hCost; } } 
    }
}
