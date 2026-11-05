using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moje
{
    internal class MojSort
    {
        protected GlavnaForma f1;
        protected int duzinaNiza;
        public MojSort(GlavnaForma f) { f1 = f; }
        virtual public void Sortiraj(int[] a) 
        {
            duzinaNiza = a.Length;
        }
        protected void Zamena(int i1, int i2, int[] a)
        {
            int pomocni = a[i1];
            a[i1] = a[i2];
            a[i2] = pomocni;
        }
    }
}
