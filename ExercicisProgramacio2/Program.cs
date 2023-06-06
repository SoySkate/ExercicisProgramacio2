using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using ExercicisProgramacio2.Models;

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
            catch { Console.WriteLine("Recordi fer-ho amb el format específic: dia/mes/any exemple: 24/04/2019");
                splitedData[0] = "dia erroni"; splitedData[1] = "mes erroni"; splitedData[2] = "any erroni";
            }
            bool fechaCorrecta = true;
            bool bisiesto = false;
            int[] numsdata = new int[3];
            for (int i=0; i<splitedData.Length; i++)
            {
                try
                {
                    numsdata[i] = int.Parse(splitedData[i]);
                }
                catch { Console.WriteLine("Recordi que ha d'introduir números enters...(Fecha incorrecta)"); fechaCorrecta = false; break; }
            }
            int any = numsdata[2];
            int mes = numsdata[1];
            int dia = numsdata[0];

            if (dia == 0 || mes == 0 || mes > 12 || dia > 31 || dia < 0 || mes < 0)
            {
                Console.WriteLine("ERROR: Los días no pueden ser ni 0 ni mayores que 31 y los meses no pueden tener un valor de 0 o superior a 12.(Fecha incorrecta)"); fechaCorrecta = false;
              
            }
            if (any % 4 == 0 && any % 100 == 0 && any % 400 == 0) { bisiesto = true;  }
            if (bisiesto)
            {
                if (mes == 2 && dia > 29)
                {
                    Console.WriteLine("El mes de febrero no puede tener más de 29 días.(Fecha incorrecta)"); fechaCorrecta = false;
                }
            }
            else if (mes == 2 && dia > 28) { Console.WriteLine("El mes de febrero no puede tener más de 28 días.(Fecha incorrecta)"); fechaCorrecta = false; }
            if ((mes == 4 || mes == 6 || mes == 9 || mes == 11) && dia > 30) { Console.WriteLine("El mes: " + numsdata[1] + "No puede tener más de 30 días.(Fecha incorrecta)"); fechaCorrecta = false; }
        
            if (fechaCorrecta == true) {
                Console.WriteLine("Fecha correcta: " + dia + "/" + mes + "/" + any);
                if (bisiesto == true) { Console.WriteLine("Este año es bisiesto."); }
            }
            int[] añoNormal = new int[12];
        
            for (int i=0; i<añoNormal.Length; i++)
            {
                if (i==0|| i == 2 || i == 4 || i == 6 || i == 7 || i == 9 || i == 11) { añoNormal[i] = 31; }
                else if(i == 3|| i ==5||i == 8 || i == 10) { añoNormal[i] = 30; }
                if(bisiesto == true) { añoNormal[1] = 29; } else { añoNormal[1] = 28; }
   
            }
            try { 
            int diasPasados = 0;
            for (int i=0; i<numsdata[1]-1; i++)
            {
                if (añoNormal[i] != numsdata[1])
                {
                    diasPasados += añoNormal[i];
                }
                else { break; }
            }
            diasPasados += dia;
            Console.WriteLine("Los días que han pasado en este de año son: " + diasPasados +" días.");
            }
            catch { Console.WriteLine("Error; numeros introducidos incorrectos."); }
        }
        static void ProvinciasXML()
        {

            StreamReader ruta = new StreamReader("C:\\DATOS\\ANDREU\\PROVINCIAS-2023.txt");
            string line;
            string[] splitline;
            int codi;
            string provincia;
            int poblacio;
            List<Provincia> Datos = new List<Provincia>();
            try
            {
                line = ruta.ReadLine();
                while(line != null)
                {
                    splitline = line.Split('|');
                    codi = int.Parse(splitline[0]);
                    provincia = splitline[1];
                    poblacio = int.Parse(splitline[2]);
                    Datos.Add(new Provincia(codi, provincia, poblacio));
                line = ruta.ReadLine();
            }
            //Vemos que tengo la data en una list
            //    for (int i=0; i<Datos.Count; i++)
            //{
            //    Console.WriteLine(Datos[i].EscribirData());

        //}
        //crear xml con los datos de la splitline ;))
        XmlDocument doc = new XmlDocument();

                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(xmlDeclaration, root);

            XmlElement xml = doc.CreateElement(string.Empty, "xml", string.Empty);
            doc.AppendChild(xml);
            

            for (int i = 0; i < Datos.Count; i++)
            {
                XmlElement separator = doc.CreateElement(string.Empty, "-", string.Empty);
                XmlElement elementcodi = doc.CreateElement(string.Empty, "Código", string.Empty);
                XmlText text1 = doc.CreateTextNode(Datos[i].codi.ToString());
                xml.AppendChild(elementcodi);
                elementcodi.AppendChild(text1);

                XmlElement elementprov = doc.CreateElement(string.Empty, "Provincia", string.Empty);
                XmlText text3 = doc.CreateTextNode(Datos[i].provincia.ToString());
                xml.AppendChild(elementprov);
                elementprov.AppendChild(text3);

                XmlElement elementpobl = doc.CreateElement(string.Empty, "Población", string.Empty);
                XmlText text2 = doc.CreateTextNode(Datos[i].poblacio.ToString());
                xml.AppendChild(elementpobl);
                elementpobl.AppendChild(text2);
                xml.AppendChild(separator);
            }
            doc.Save("C:\\DATOS\\ANDREU\\provincias.txt");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        static void fitxers()
        {
            
            List<Iva> listaIva = new List<Iva>();
            //listaIva.Add(new Iva(01,0.21));
            //listaIva.Add(new Iva(02, 0.10));
            //listaIva.Add(new Iva(03, 0.05));
            //listaIva.Add(new Iva(04, 0.04));
            //listaIva.Add(new Iva(05, 0.00));

            StreamReader rutaIva = new StreamReader("C:\\DATOS\\ANDREU\\fitxers2\\iva.txt");
            string line;
            try
            {
                line = rutaIva.ReadLine();
                string[] splitlineIva;
                while (line != null)
                {
                    splitlineIva = line.Split('|');
                    int codi = int.Parse(splitlineIva[0]);
                    double percent = double.Parse(splitlineIva[1]);
                    listaIva.Add(new Iva(codi,percent));
                    line = rutaIva.ReadLine();
                }
            }
            catch { Console.WriteLine("No se ha podido abrir la ruta del archivo IVA."); }
            rutaIva.Close();

            List<Article> listaArticles = new List<Article>();
            //listaArticles.Add(new Article(1001,listaIva[1]));
            //listaArticles.Add(new Article(1002, listaIva[0]));
            //listaArticles.Add(new Article(1003, listaIva[4]));
            //listaArticles.Add(new Article(1004, listaIva[3]));
            //listaArticles.Add(new Article(1005, listaIva[2]));

            StreamReader rutaArticles = new StreamReader("C:\\DATOS\\ANDREU\\fitxers2\\articles.txt");
            string line2;
            try
            {
                line2 = rutaArticles.ReadLine();
                string[] splitlineArt;
                while (line2 != null)
                {
                    splitlineArt = line2.Split('|');
                    int codi = int.Parse(splitlineArt[0]);
                    int codiIva = int.Parse(splitlineArt[1]); 
                    var buscarCodiIva = from cIva in listaIva
                                        where cIva.CodiIva == codiIva
                                        select cIva;
                    var listbuscarCodiIva = buscarCodiIva.ToList();
                    if (listbuscarCodiIva != null) { listaArticles.Add(new Article(codi, listbuscarCodiIva[0]));}
                    else { Console.WriteLine("No se ha encontrado ningún codigo iva que coincida en el documento."); }

                    //Le intento pasar el onject que me pide Codi Iva class es un objeto Iva. 
                    line2 = rutaArticles.ReadLine();
                }
            }
            catch { Console.WriteLine("No se ha podido abrir la ruta del archivo Articles."); }
            rutaArticles.Close();
           
            List<Albara> listaAlbarans = new List<Albara>();
            //listaAlbarans.Add(new Albara(1,listaArticles[0],15,1.35));
            //listaAlbarans.Add(new Albara(2, listaArticles[1], 30, 2.25));
            //listaAlbarans.Add(new Albara(3, listaArticles[2], 22, 5));
            //listaAlbarans.Add(new Albara(4, listaArticles[3], 9, 2.19));
            //listaAlbarans.Add(new Albara(5, listaArticles[4], 7, 6.09));
            //listaAlbarans.Add(new Albara(6, listaArticles[0], 9, 1.30));
            //listaAlbarans.Add(new Albara(7, listaArticles[3], 7, 2.34));
            StreamReader rutaAlbarans = new StreamReader("C:\\DATOS\\ANDREU\\fitxers2\\albarans.txt");
            string line3;
            try
            {
                line3 = rutaAlbarans.ReadLine();
                string[] splitALba;
                while (line3 != null)
                {
                    splitALba = line3.Split('|');
                    int codialba = int.Parse(splitALba[0]);
                    int codiArtiAlba = int.Parse(splitALba[1]);
                    int unidades = int.Parse(splitALba[2]);
                    double precio = double.Parse(splitALba[3]);
                    var buscarCodiArt = from cArt in listaArticles
                                       where cArt.CodiArt == codiArtiAlba
                                       select cArt;
                    var listByCodiArt = buscarCodiArt.ToList();
                    if (listByCodiArt != null) { listaAlbarans.Add(new Albara(codialba, listByCodiArt[0], unidades, precio)); }
                    else { Console.WriteLine("No se ha encontrado ningún codigo iva que coincida en el documento."); }
                    line3 = rutaAlbarans.ReadLine();
                }
            }
            catch(Exception e) { Console.WriteLine(e.Message); }
            rutaAlbarans.Close();

            //21%
            var queryIvaType1 = from alb in listaAlbarans
                           where alb.CodiClassArt.CodiClassIva.Percentatge == 21
                           select alb;
            //10%
            var queryIvaType2 = from alb in listaAlbarans
                           where alb.CodiClassArt.CodiClassIva.Percentatge == 10
                           select alb;
            //5%
            var queryIvaType3 = from alb in listaAlbarans
                                where alb.CodiClassArt.CodiClassIva.Percentatge == 5
                                select alb;
            //4%
            var queryIvaType4 = from alb in listaAlbarans
                                where alb.CodiClassArt.CodiClassIva.Percentatge == 4
                                select alb;
            //00%
            var queryIvaType5 = from alb in listaAlbarans
                                where alb.CodiClassArt.CodiClassIva.Percentatge == 0
                                select alb;

            var selectedbyIva = queryIvaType1.ToList();//21%
            var selectedbyIva2 = queryIvaType2.ToList();//10%
            var selectedbyIva3 = queryIvaType3.ToList();//5%
            var selectedbyIva4 = queryIvaType4.ToList();//4%
            var selectedbyIva5 = queryIvaType5.ToList();//00%



            //Havia pensat de fer objecte que es digues Base i poses les dades que estic recopilant en comptes de
            //Simplement escriure-les per consola.
            //21%
            double base1list = 0;
            double iva1list = selectedbyIva[0].CodiClassArt.CodiClassIva.Percentatge;
           
            for (int i=0; i<selectedbyIva.Count; i++)
            {
                base1list += (selectedbyIva[i].PrecioArt * selectedbyIva[i].UnidadesArt);
            }
            double quota1list = base1list * iva1list;
            double total1list = quota1list + base1list;
            Console.WriteLine("BASE: " + base1list + " | IVA: " + iva1list + "% | Quota: " + quota1list+ "| Total: " + total1list+" eu");

            //10%
            double base2list = 0;
            double iva2list = selectedbyIva2[0].CodiClassArt.CodiClassIva.Percentatge;
            for (int i = 0; i < selectedbyIva2.Count; i++)
            {
                base2list += (selectedbyIva2[i].PrecioArt * selectedbyIva2[i].UnidadesArt);
            }
            double quota2list = base2list * iva2list;
            double total2list = quota2list + base2list;
            Console.WriteLine("BASE: " + base2list + " | IVA: " + iva2list + "% | Quota: " + quota2list + "| Total: " + total2list + " eu");

            //5%
            double base3list = 0;
            double iva3list = selectedbyIva3[0].CodiClassArt.CodiClassIva.Percentatge;
            for (int i = 0; i < selectedbyIva3.Count; i++)
            {
                base3list += (selectedbyIva3[i].PrecioArt * selectedbyIva3[i].UnidadesArt);
            }
            double quota3list = base3list * iva3list;
            double total3list = quota3list + base3list;
            Console.WriteLine("BASE: " + base3list + " | IVA: " + iva3list + "% | Quota: " + quota3list + "| Total: " + total3list + " eu");

            //4%
            double base4list = 0;
            double iva4list = selectedbyIva4[0].CodiClassArt.CodiClassIva.Percentatge;
            for (int i = 0; i < selectedbyIva4.Count; i++)
            {
                base4list += (selectedbyIva4[i].PrecioArt * selectedbyIva4[i].UnidadesArt);
            }
            double quota4list = base4list * iva4list;
            double total4list = quota4list + base4list;
            Console.WriteLine("BASE: " + base4list + " | IVA: " + iva4list + "% | Quota: " + quota4list + "| Total: " + total4list + " eu");

            //0%
            double base5list = 0;
            double iva5list = selectedbyIva5[0].CodiClassArt.CodiClassIva.Percentatge;
            for (int i = 0; i < selectedbyIva5.Count; i++)
            {
                base5list += (selectedbyIva5[i].PrecioArt * selectedbyIva5[i].UnidadesArt);
            }
            double quota5list = base5list * iva5list;
            double total5list = quota5list + base5list;
            Console.WriteLine("BASE: " + base5list + " | IVA: " + iva5list + "% | Quota: " + quota5list + "| Total: " + total5list + " eu");

            double basetotal = base1list + base2list + base3list + base4list + base5list;
            double quotatotal = quota1list + quota2list + quota3list + quota4list + quota5list;
            double Total = basetotal + quotatotal;
            Console.WriteLine("\nBaseTotal: " + basetotal + "|| QuotaTotal: " + quotatotal+ "|| TOTAL: " + Total +" eu\n");

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
                        ProvinciasXML();
                        break;
                    case 3:
                        Console.WriteLine("Calcular la base de iva els preu final i la suma del preus del mateix iva.\n");
                        fitxers();
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
