using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsTorte
{
    public class CCrostata : CDolce
    {
        public CCrostata(string nome, int punteggio) : base(nome, punteggio) { }
        public override string GetTipologia()
        {
            return "Crostata";
        }
        public int ProvaCroccantezza()
        {
            int prima = Punteggio;
            Punteggio = Punteggio - 4;
            return prima - Punteggio;
        }
    }
}
