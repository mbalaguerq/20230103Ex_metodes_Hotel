using Microsoft.Win32;
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

            } while (!salir);
            Console.WriteLine();



        }

        string DemanarOpcioMenu()
        {
            string opcio;
            do
            {
                Console.Write("Sel.lecciona opció: ");
                opcio = Console.ReadLine();
            } while (!"01234567".Contains(opcio));
            return opcio;
        }

        bool ExecutarMenu(String[,] hotel, String[,] clients, String opcio)
        {
            bool salir = false;
            switch (opcio)
            {
                case "1":
                    MostrarClients(clients);
                    break;
                case "2":
                    AltaClients(clients);
                    break; 
                case "3":
                    MostrarHotel(hotel);
                    break;
                case "0":
                    salir = true;
                    break;

            }
            return salir;
        }

       

        void AltaClients(String[,] clients)
        {
            string dniClient;
            dniClient = DemanaClient();
            //bool encontrado = false;
            int fila;
            fila = existsNif(dniClient, clients);
            string nomCLient;
            string mailCLient;
            int filaLliure= getNewFilaClientes(clients);

            if (fila != REGISTRE_INEXISTENT)
            {
                Console.WriteLine("El client ja existeix");
            }
            else
            {
                clients[filaLliure, CLI_NIF] = dniClient;
                Console.WriteLine("Introdueix el nom del client: ");
                nomCLient = Console.ReadLine();
                clients[filaLliure, CLI_NOM] = nomCLient;
                Console.WriteLine("Introdueix el e-mail del client: ");
                mailCLient = Console.ReadLine();
                clients[filaLliure, CLI_MAIL] = mailCLient;
            }
            
           /* while (fila < clients.GetLength(0) & !encontrado)
            {
                if (user.Equals(clients[fila, CLI_NIF]))
                {
                    encontrado = true;

                }
                fila++;
            }
            if (encontrado)
            {
                Console.WriteLine("El client ja té habitació assignada");
            }
            else
            {
                clients[fila, CLI_NIF] = dniClient;
                Console.WriteLine("Introdueix el nom del client: ");
                nomCLient= Console.ReadLine();
                clients[fila, CLI_NOM] = nomCLient;
                Console.WriteLine("Introdueix el e-mail del client: ");
                mailCLient= Console.ReadLine();
                clients[fila, CLI_MAIL] = mailCLient;
            }*/



        }
        int getNewFilaClientes(String[,] clientes) 
        {
            bool encontrado = false;
            int filaLliure = 0;
            while (filaLliure < clientes.GetLength(0) & !encontrado)
            {
                if (clientes[filaLliure, ID_CLIENT].Equals ("")) 
                {
                    encontrado = true;
                }
                else
                {
                    filaLliure++;
                }
            }
            if (encontrado)
            {
                return filaLliure;
            }
            else
            {
                return REGISTRE_INEXISTENT;
            }
        }

        int existsNif (String user, String [,] clients)
        {
            bool encontrado = false;
            int fila = 0;
            while (fila < clients.GetLength(0) & !encontrado)
            {
                if (user.Equals(clients[fila, CLI_NIF]))
                {
                    encontrado = true;
                    
                }
                fila++;
            }
            if (encontrado)
            {
                return fila;
            }
            else
            {
                return REGISTRE_INEXISTENT;
            }

        }

        string DemanaClient()
        {
            string dniClient;
            Console.Write("Introdueix Dni del CLient: ");
            dniClient = Console.ReadLine();
            return dniClient;
        }

        void MostrarHotel(String[,] hotel)
        {
            Console.WriteLine("\nNum Hab\tPis\tN Llits\tPreu\tDni Client");

            for (int i = 0; i < hotel.GetLength(0); i++)
            {
                for (int j = 0; j < hotel.GetLength(1); j++)
                {
                    if (hotel[i, j] != null)
                    {
                        Console.Write(hotel[i, j] + "\t");
                    }
                    else
                    {
                        Console.Write("Libre");
                    }
                    
                }
                Console.WriteLine();
            }
        }

        void MostrarClients(String[,] clients)
        {
            Console.WriteLine("\nNif\tNom\te-mail");
            for (int i = 0; i < clients.GetLength(0); i++)
            {
                for (int j = 0; j < clients.GetLength(1); j++)
                {

                    if (clients[i, j] != "")
                    {
                        Console.Write(clients[i, j] + "\t");
                    }
                    
                }
                if (clients[i, 0] != "")
                {
                    Console.WriteLine();
                }
                
            }
            Console.WriteLine();
        }

        string[,] DadesHotel()
        {

            String[,] hotel = {
            //num hab/ pis/ n llits/ preu/ null o dni pers
            {"101", "1", "2", "100", "11111111A"},
            {"102", "1", "2", "100", "11111111A"},
            {"103", "1", "2", "100", "22222222B"},
            {"104", "1", "3", "130", "22222222B"},
            {"105", "1", "3", "130", "33333333C"},
            {"106", "1", "1", "75",  "44444444D"},
            {"201", "2", "2", "100", "44444444D"},
            {"202", "2", "2", "100", "44444444D"},
            {"203", "2", "2", "100", "55555555E"},
            {"204", "2", "3", "130", null},
            {"205", "2", "3", "130", null},
            {"206", "2", "1", "75",  null},
            {"301", "3", "2", "100", null},
            {"302", "3", "2", "100", "55555555E"},
            {"303", "3", "2", "100", null},
            {"304", "3", "3", "130", null},
            {"305", "3", "3", "130", "12345678G"},
            {"306", "3", "1", "75", "45644056g"}};
            return hotel;
        }

        string[,] DadesClient()
        {
            //Nif/nom_CLient/email
            string[,] clients = {
            {"11111111A", "Josep Busquets", "jbusquets@gmail.com", },
            {"", "", "", },
            {"", "", "", },
            {"", "", "", },
            {"", "", "", },
            {"", "", "", },
            {"", "", "", },
            {"44444444D", "Hector Puig", "hp@gmail.com", },
            {"", "", "", },
            {"44444444D", "Hector Puig", "hp@gmail.com", },
            {"22222222B", "Maria Garcia", "mgarcia@hotmail.com", },
            {"22222222B", "Maria Garcia", "mgarcia@hotmail.com", },
            {"55555555E", "Isabel Casas", "isacasas@hotmail.com", },
            {"33333333C", "Albert Gonzalez", "gonzalbert@icloud.com", },
            {"55555555E", "Isabel Casas", "isacasas@hotmail.com", } };
            
            return clients;
        }

        void mostrarMenu()
        {
            Console.WriteLine("1. Mostrar clients ");
            Console.WriteLine("2. Alta clients");
            Console.WriteLine("3. Mostrar  habitacions Hotel");
            Console.WriteLine("4. Mostrar habitacions lliures");
            Console.WriteLine("5. Mostrar habitacions ocupades amb el nom");         
            //Console.WriteLine("6. Factura de la reserva a partir d'un Nif");
            //Console.WriteLine("7. Anul·lar reserva");
            Console.WriteLine("0. Sortir");
        }


        const int CLI_NIF = 0;
        const int CLI_NOM = 1;
        const int CLI_MAIL = 2;
        const int REGISTRE_INEXISTENT = -1;
        const int ID_CLIENT = 0;
    }
}
