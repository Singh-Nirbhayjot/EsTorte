using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsTorte
{
    public class CTorta : CDolce
    {
        public CTorta(string nome, int punteggio) : base(nome, punteggio) { }
        public override string GetTipologia()
        {
            return "Torta";
        }
        public int ProvaSofficenza()
        {
            int prima = Punteggio;
            Punteggio = Punteggio - 6;
            return prima - Punteggio;
        }
    }
}
