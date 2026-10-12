using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace EsTorte
{
    public abstract class CDolce
    {
        private string nome;
        private int punteggio;
        private static Random rnd = new Random();
        public CDolce(string nome, int punteggio)
        {
            Nome = nome;
            if (punteggio < 1 || punteggio > 10)
                throw new Exception("Il punteggio iniziale deve stare tra 1 e 10");
            Punteggio = punteggio;
        }
        public string Nome
        {
            get => nome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Il nome non può essere vuoto");

                nome = value;
            }
        }
        public int Punteggio
        {
            get => punteggio;
            set
            {
                if (value < 0)
                    punteggio = 0;
                else if (value > 10)
                    punteggio = 10;
                else
                    punteggio = value;
            }
        }
        public abstract string GetTipologia();
        public int Raffina()
        {
            int prima = Punteggio;
            int bonus = rnd.Next(3, 8);
            Punteggio = Punteggio + bonus;
            return Punteggio - prima;
        }

        public string GetDescrizione()
        {
            return $"[{GetTipologia()}] {Nome} - Punteggio: {Punteggio}/10";
        }
        public override string ToString()
        {
            return GetDescrizione();
        }
    }

}
