using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230103Ex_metodes_Hotel
{
    internal class Aplicacio
    {

//1. Mostrar Hotel 
//2. Mostrar habitacions lliures
//3. Mostrar habitacions ocupades amb el nom
//4. Entrar reserva
//5. Llista reserves a partir d'un Nif
//6. Factura de la reserva a partir d'un Nif
//7. Anul·lar reserva
        public void Inici()
        {
            String[,] hotel = DadesHotel();
            String[,] clients = DadesClient();

            bool salir = false;
            string opcio;

            do
            {
                mostrarMenu();
                opcio = DemanarOpcioMenu();
                salir = ExecutarMenu(hotel, clients, opcio);
            
            }while(!salir);


        }

        string DemanarOpcioMenu()
        {
            string opcio;
            do
            {
                Console.Write("Sel.lecciona opció: ");
                opcio= Console.ReadLine();
            }while (!"01234567".Contains(opcio));
            return opcio;
        }

        bool ExecutarMenu(String[,] hotel, String[,]clients, String opcio) 
        { 
            bool salir = false;
            switch(opcio) 
            {
                case "1":
                    MostrarHotel(hotel);
                    break;
                case "0":
                    salir = true;
                    break;

            }
            return salir;
        }

        void MostrarHotel (String[,] hotel)
        {
            string nifReserva = null;
            nifReserva = "Habitació buida";
            Console.WriteLine("\nNum Hab\tPis\tN Llits\tPreu\tDni Client");

            for (int i=0; i < hotel.GetLength(0); i++)
            {
                for (int j = 0; j < hotel.GetLength(1); j++) 
                {
                    
                    Console.Write(hotel[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }


        string[,] DadesHotel()
        {

            String[,] hotel = {
            //num hab/ pis/ n llits/ preu/ null o dni pers
            {"101", "1", "2", "100", null},
            {"102", "1", "2", "100", null},
            {"103", "1", "2", "100", null},
            {"104", "1", "3", "130", null},
            {"105", "1", "3", "130", null},
            {"106", "1", "1", "75", null},
            {"201", "2", "2", "100", null},
            {"202", "2", "2", "100", null},
            {"203", "2", "2", "100", null},
            {"204", "2", "3", "130", null},
            {"205", "2", "3", "130", null},
            {"206", "2", "1", "75", null},
            {"301", "3", "2", "100", null},
            {"302", "3", "2", "100", null},
            {"303", "3", "2", "100", null},
            {"304", "3", "3", "130", null},
            {"305", "3", "3", "130", null},
            {"306", "3", "1", "75", null}};
            return hotel;
        }

        string[,] DadesClient()
        {

            string[,] clients = new String[15, 2];
            //Nif/nom_CLient
            return clients;
        }

        void mostrarMenu()
        {
            Console.WriteLine("1. Mostrar Hotel ");
            Console.WriteLine("2. Mostrar habitacions lliures");
            Console.WriteLine("3. Mostrar habitacions ocupades amb el nom");
            Console.WriteLine("4. Entrar reserva");
            Console.WriteLine("5. Llista reserves a partir d'un Nif");
            Console.WriteLine("6. Factura de la reserva a partir d'un Nif");
            Console.WriteLine("7. Anul·lar reserva");
            Console.WriteLine("0. Sortir");
        }

    }
}
