using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaAurora
{
    class Dado
    {
        public int[] Faces { get; set; } = new int[5];
        public int[] FaceSequencia { get; set; } = new int[5];


        Random random = new Random();

        public int RodarDados()
        {
            return random.Next(1, 7);            
        }
    }
}
