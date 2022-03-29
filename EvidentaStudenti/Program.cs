using System;
using System.Configuration;
using LibrarieModele;
using NivelStocareDate;

namespace EvidentaElevi
{
    class Program
    {
        static void Main()
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            AdministrareElevi_FisierText adminElevi = new AdministrareElevi_FisierText(numeFisier);
            int nrElevi = 0;
            int idElev = 0;
            
            



            Elev newElev = new Elev();
            adminElevi.GetElevi(out nrElevi);
            string optiune;
           Elev[] elevi = adminElevi.GetElevi(out nrElevi);
            do
            {
                Console.WriteLine("PROIECT ");
                Console.WriteLine("---------------------------------------------------------------");
                
                Console.WriteLine("C. Citire date de la tastatura");
                Console.WriteLine("S. Salvare elev in fisier");
                Console.WriteLine("F. Afisare elevi din fisier");
                Console.WriteLine("H. Citire elev din fisier");
                Console.WriteLine("P. Cautare student dupa nume");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("Alegeti o optiune:");
                Console.WriteLine("----------------------------------");
                optiune = Console.ReadLine();
                
                switch (optiune.ToUpper())
                {
                    case "S":
                        nrElevi++;
                        //adaugare elev in fisier
                        newElev.SetIdElev(nrElevi);
                        adminElevi.AddElev(newElev);
                        Console.WriteLine("S-a efectuat salvarea elevului in fisier");
                        break;
                    case "C":
                        //citire date de la tastatura
                        newElev.CitireTastatura();
                        break;
                    case "F":
                        elevi = adminElevi.GetElevi(out nrElevi);
                        AfisareElevi(elevi, nrElevi);
                        Console.WriteLine("Elevul a fost citit din fisier");
                        break;
                    case "H":
                        Elev elev = new Elev(idElev, "Ionel", "Matei");
                        adminElevi.AddElev(elev);
                        break;
                    case "P":
                        CautareNume( elevi, nrElevi,"Sumanariu ");
                        break;

                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }

        private static Elev[] CitireTastatura()
        {
            throw new NotImplementedException();
        }

        public static void AfisareElevi(Elev[] elevi, int nrElevi)
        {
            //Console.WriteLine("Elevii sunt:");
            for (int contor = 0; contor < nrElevi; contor++)
            {
                string infoElev = string.Format("Elevul ce are ID-ul {0} se numeste: {1} {2}",
                   elevi[contor].GetIdElev(),
                   elevi[contor].GetNume() ?? " NECUNOSCUT ",
                   elevi[contor].GetPrenume() ?? " NECUNOSCUT ");

                Console.WriteLine(infoElev);
            }
        }
        public static void CautareNume(Elev[] elevi, int nrElevi, string nume_cautat)
        {
            bool exista = false;

            for (int contor = 0; contor < nrElevi; contor++)
            {
                if (nume_cautat == elevi[contor].GetNume())
                {
                    exista = true;

                }
            }
            if (exista == true)
            {
                Console.WriteLine("Numele este valid");

            }
            else
                Console.WriteLine("Numele nu este valid");







            
        }
    }
}
