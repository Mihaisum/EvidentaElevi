using System;

namespace LibrarieModele
{
    public class Elev
    {
        //constante
        private const char SEPARATOR_PRINCIPAL_FISIER = '_';
        private const bool SUCCES = true;

        private const int ID = 0;
        private const int NUME = 1;
        private const int PRENUME = 2;
        int[] note;
 

        
        public int idElev; 
        private string nume;
        private string prenume;


        public int[] GetNote()
        {
            return (int[])note.Clone();
        }
        //contructor implicit
        public Elev()
        {
            nume = prenume = string.Empty;
        }


        //constructor cu parametri
        public Elev(int idElev, string nume, string prenume)
        {

            this.idElev = idElev;
            this.nume = nume;
            this.prenume = prenume;


        }

        public Elev(string nume,string prenume,int [] _note)
        {
            this.nume = nume;
            this.prenume = prenume;
            this.note = new int[_note.Length];
            _note.CopyTo(note, 0);
        }
      

        public Elev(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            
            idElev = Convert.ToInt32(dateFisier[ID]);
            nume = dateFisier[NUME];
            prenume = dateFisier[PRENUME];
        }

        public void CitireTastatura()
        {
            
            Console.WriteLine("Numele si prenumele studentului:");
            nume=Console.ReadLine();
            prenume = Console.ReadLine();
        }

        public void SetIdElev(int val)
        {
            idElev = val;
        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectElevPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                idElev.ToString(),
                (nume ?? " NECUNOSCUT "),
                (prenume ?? " NECUNOSCUT "));

            return obiectElevPentruFisier;
        }

        public int GetIdElev()
        {
            return idElev;
        }

        public string GetNume()
        {
            return nume;
        }

        public string GetPrenume()
        {
            return prenume;
        }
       
    }
}
