using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moje
{
    internal class Moj_QuickSort :MojSort
    {
        public Moj_QuickSort(GlavnaForma f) : base(f) { }
        public override void Sortiraj(int[] a)
        {
            base.Sortiraj(a);
            quickSort(a, 0, duzinaNiza - 1);
            f1.sortiran = duzinaNiza;
            f1.Refresh();
        }
        public int podeli(int[]a, int l, int r)
        {
            int pivot = a[r];
            int i = l - 1;

            for (int j = l; j <= r-1; j++)
            {
                if (a[j] < pivot)
                {
                    i++;
                    Zamena(i, j,a);
                }
                f1.tek1=i; f1.tek2=j;
                f1.MojRefresh();
            }
            Zamena(i+1, r, a);
            f1.MojRefresh();
            return (i + 1);
        }

        public void quickSort(int []a, int l, int r)
        {
            if (l < r)
            {
                int pi = podeli(a, l, r);
                f1.pivot[pi] = true;
                f1.MojRefresh();

                quickSort(a, l, pi - 1);
                quickSort(a, pi + 1, r);
                
            }
        }
    }
}
