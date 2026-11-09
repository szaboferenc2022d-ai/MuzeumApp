using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MuzeumApp
{
    public class Mutargy
    {
        public string Azonosito { get; set; }
        protected int becsultErtek;
        public int BecsultErtek
        {
            get { return becsultErtek; }
            set
            {
                if (value < 0)
                {
                    value = 50000;
                }
                becsultErtek = value;
            }
        }
        private static int osszesMutargySzama;
        public static int OsszesMutargySzama { get; }


        public Mutargy(string azonosito, int becsultErtek, int osszesMutargySzama)
        {
            Azonosito = azonosito;
            BecsultErtek = becsultErtek;
        }

        public virtual int BiztositasDij()
        {
            return (int)(BecsultErtek * 0.02);
        }

        public override string ToString()
        {
            return $"\"Műtárgy {Azonosito} | Becsült érték: {BecsultErtek} Ft | Biztosítás: {BiztositasDij()} Ft\" ";
        }
    }
}
