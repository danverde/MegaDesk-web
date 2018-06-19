using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk4
{
    class Desk
    {
        public enum Surface
        {
            Laminate = 100,
            Oak = 200,
            Pine = 50,
            Rosewood = 300,
            Veneer = 125
        }

        public decimal Depth { get; set; }

        public decimal Width { get; set; }

        public int NumDrawers { get; set; }

        public int SurfaceMaterial { get; set; }
    }
}
