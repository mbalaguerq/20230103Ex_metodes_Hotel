using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230103Ex_metodes_Hotel
{
    internal class opcio6
    {
        opcio6 app = new opcio6();

        void EntrarReserva(String[,] hotel, String[,] clients)
        {
            int nHab;
            int tipusHab;


            Console.WriteLine("Sel.leccioni el nº d'habitacions que desitja: ");
            nHab = int.Parse(Console.ReadLine());
            Console.WriteLine("Sel.leccioni el tipus d'habitació: ");
            Console.Write("-1 Simple\t"  + "2-doble\t" + "3-Triple\t" );

        }


    }
}
