using LibrarieModele;
using System.IO;

namespace NivelStocareDate
{
public class AdministrareElevi_FisierText
{
    private const int NR_MAX_ELEVI = 50;
    private string numeFisier;

    public AdministrareElevi_FisierText(string numeFisier)
    {
        this.numeFisier = numeFisier;
        Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
        streamFisierText.Close();
    }

    public void AddElev(Elev elev)
    {
      
        using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
        {
            streamWriterFisierText.WriteLine(elev.ConversieLaSir_PentruFisier());
        }
    }

    public Elev[] GetElevi(out int nrElevi)
    {
        Elev[] elevi = new Elev[NR_MAX_ELEVI];

        
        using (StreamReader streamReader = new StreamReader(numeFisier))
        {
            string linieFisier;
            nrElevi = 0;
                      while ((linieFisier = streamReader.ReadLine()) != null)
            {
                elevi[nrElevi++] = new Elev(linieFisier);
            }
        }

        return elevi;
    }
}
}