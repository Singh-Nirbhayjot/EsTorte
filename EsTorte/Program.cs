using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsTorte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<CDolce> dolci = new List<CDolce>();
            dolci.Add(new CCrostata("Crostata di More", 8));
            dolci.Add(new CCrostata("Crostata di Mele", 7));
            dolci.Add(new CTorta("Torta al Cioccolato", 9));
            dolci.Add(new CTorta("Torta al Limone", 6));

            bool continua = true;

            while (continua)
            {
                Console.WriteLine("\nCOPPA DEL LAGO DI FIMON");
                Console.WriteLine("1. Visualizza tutti i dolci");
                Console.WriteLine("2. Prova di Croccantezza (Crostata -4)");
                Console.WriteLine("3. Prova di Sofficenza (Torta -6)");
                Console.WriteLine("4. Raffina un dolce (+3..7)");
                Console.WriteLine("5. Finale di Degustazione (raffina tutti)");
                Console.WriteLine("6. Esci");
                Console.Write("\nScelta: ");
                string scelta = Console.ReadLine();
                switch (scelta)
                {
                    case "1":
                        VisualizzaDolci(dolci);
                        break;
                    case "2":
                        ProvaCroccantezza(dolci);
                        break;
                    case "3":
                        ProvaSofficenza(dolci);
                        break;
                    case "4":
                        RaffinaDolce(dolci);
                        break;
                    case "5":
                        FinaleDegustazione(dolci);
                        break;
                    case "6":
                        continua = false;
                        Console.WriteLine("\nArrivederci dalla Coppa del Lago di Fimon!");
                        break;
                    default:
                        Console.WriteLine("Opzione non valida.");
                        break;
                }
            }
        }
        static void VisualizzaDolci(List<CDolce> dolci)
        {
            Console.WriteLine("--- DOLCI ---");
            foreach (CDolce d in dolci)
            {
                Console.WriteLine(d);
            }
        }
        static void ProvaCroccantezza(List<CDolce> dolci)
        {
            List<CCrostata> crostate = new List<CCrostata>();
            foreach (CDolce d in dolci)
            {
                if (d is CCrostata)
                    crostate.Add((CCrostata)d);
            }

            if (crostate.Count == 0)
            {
                Console.WriteLine("Nessuna crostata in gara.");
                return;
            }

            Console.WriteLine("\nSCEGLI LA CROSTATA");
            for (int i = 0; i < crostate.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {crostate[i].Nome} (Punti: {crostate[i].Punteggio})");
            }
            Console.Write("Numero: ");
            int num = int.Parse(Console.ReadLine());

            if (num >= 1 && num <= crostate.Count)
            {
                CCrostata c = crostate[num - 1];
                int puntPrima = c.Punteggio;
                int persi = c.ProvaCroccantezza();
                Console.WriteLine($"PROVA CROCCANTEZZA {c.Nome}");
                Console.WriteLine($"Punteggio prima: {puntPrima}");
                Console.WriteLine($"Punti persi: {persi}");
                Console.WriteLine($"Punteggio dopo: {c.Punteggio}/10");
            }
            else
            {
                Console.WriteLine("Scelta non valida.");
            }
        }
        static void ProvaSofficenza(List<CDolce> dolci)
        {
            List<CTorta> torte = new List<CTorta>();
            foreach (CDolce d in dolci)
            {
                if (d is CTorta)
                    torte.Add((CTorta)d);
            }

            if (torte.Count == 0)
            {
                Console.WriteLine("Nessuna torta in gara.");
                return;
            }

            Console.WriteLine("\nSCEGLI LA TORTA ");
            
            for (int i = 0; i < torte.Count; i++)
                Console.WriteLine($"{i + 1}. {torte[i].Nome} (Punti: {torte[i].Punteggio})");

            Console.Write("Numero: ");
            int num = int.Parse(Console.ReadLine());

            if (num >= 1 && num <= torte.Count)
            {
                CTorta t = torte[num - 1];
                int puntPrima = t.Punteggio;
                int persi = t.ProvaSofficenza();
                Console.WriteLine($"\nPROVA SOFFICEZZA {t.Nome}");
                Console.WriteLine($"Punteggio prima: {puntPrima}");
                Console.WriteLine($"Punti persi: {persi}");
                Console.WriteLine($"Punteggio dopo: {t.Punteggio}/10");
            }
            else
            {
                Console.WriteLine("Scelta non valida.");
            }
        }
        static void RaffinaDolce(List<CDolce> dolci)
        {
            if (dolci.Count == 0)
            {
                Console.WriteLine("Nessun dolce in gara.");
                return;
            }

            Console.WriteLine("\nSCEGLI IL DOLCE DA RAFFINARE");
            for (int i = 0; i < dolci.Count; i++)
                Console.WriteLine($"{i + 1}. {dolci[i].Nome} [{dolci[i].GetTipologia()}] (Punti: {dolci[i].Punteggio})");

            Console.Write("Numero: ");
            int num = int.Parse(Console.ReadLine());

            if (num >= 1 && num <= dolci.Count)
            {
                CDolce scelto = dolci[num - 1];
                int puntPrima = scelto.Punteggio;
                int guadagnati = scelto.Raffina();
                Console.WriteLine($"\nRAFFINAZIONE {scelto.Nome}");
                Console.WriteLine($"Punteggio prima: {puntPrima}");
                Console.WriteLine($"Punti recuperati: +{guadagnati}");
                Console.WriteLine($"Punteggio dopo: {scelto.Punteggio}/10");
            }
            else
            {
                Console.WriteLine("Scelta non valida.");
            }
        }
        static void FinaleDegustazione(List<CDolce> dolci)
        {
            if (dolci.Count == 0)
            {
                Console.WriteLine("Nessun dolce in gara.");
                return;
            }

            Console.WriteLine("\nFINALE DI DEGUSTAZIONE");
            foreach (CDolce d in dolci)
            {
                int puntPrima = d.Punteggio;
                int guadagnati = d.Raffina();
                Console.WriteLine($"{d.GetTipologia()} {d.Nome}: {puntPrima} -> {d.Punteggio}/10 (+{guadagnati})");
            }
            Console.WriteLine("\nFinale conclusa");
        }
    }
}
