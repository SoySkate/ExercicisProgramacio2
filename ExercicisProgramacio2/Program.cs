using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicisProgramacio2
{
    class Program
    {

        static void datafunction(string dataInicial)
        {
            string[] splitedData = new string[3];
            try { 
            splitedData = dataInicial.Split('/');
            }
            catch { Console.WriteLine("Recordi fer-ho ab el format específic: dia/mes/any exemple: 24/04/2019");
                splitedData[0] = "dia erroni"; splitedData[1] = "mes erroni"; splitedData[2] = "any erroni";
            }
            
            int[] numsdata = new int[3];
            for (int i=0; i<splitedData.Length; i++)
            {
                try
                {
                    numsdata[i] = int.Parse(splitedData[i]);
                 
                }
                catch { Console.WriteLine("Recordi que ha d'introduir números enters..."); }
            }

            int any = numsdata[2];
            int mes = numsdata[1];
            int dia = numsdata[0];

            Console.WriteLine(any+mes+dia);

            int[][] jaggedArray = new int[12][];

            for (int i = 0; i < 12; i++)
            {
                if (i == 1)
                {
                    jaggedArray[i] = new int[29];

                }
                else if (i == 3 || i == 5 || i == 8 || i == 10)
                {
                    jaggedArray[i] = new int[30];
                }
                else
                {
                    jaggedArray[i] = new int[31];
                }
            }

            
        }
        static void Main(string[] args)
        {
            bool menu = true;
        
            do
            {

                Console.WriteLine("Menú");
                Console.WriteLine("1. Exercici 1 Format data.");
                Console.WriteLine("2. Exercici 2 pasar Provincias.txt a XML.");
                Console.WriteLine("3. Calcular total de base iva i albarà.");
                Console.WriteLine("4. Sortir.");

                int option;
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { Console.WriteLine("Has d'introduir un número enter!"); option = default; }
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Entra una data de forma: dd/mm/aaaa: ");
                       string data = Console.ReadLine();
                        datafunction(data);

                        break;
                    case 2:
                        Console.WriteLine("Convertir l'arxiu de text provincias.txt a XML provincias.xml");

                        break;
                    case 3:
                        Console.WriteLine("Calcular la base de iva els preu final i la suma del preus del mateix iva.");
                        break;
                    case 4:
                        Console.WriteLine("Sortint...");
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("Has d'introduir una opció vàlida.");
                        break;
                }


            } while (menu == true);
            Console.ReadKey();
        }
    }
}
