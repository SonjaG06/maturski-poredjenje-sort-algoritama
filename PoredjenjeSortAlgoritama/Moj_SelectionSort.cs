using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moje
{
    internal class Moj_SelectionSort:MojSort
    {
        public Moj_SelectionSort(GlavnaForma f):base(f) { }
        public override void Sortiraj(int[] a)
        {
            base.Sortiraj(a);
            SelectionSort(a);
            f1.Refresh();
        }
        public void SelectionSort(int[] a)
        {
            int min;
            for (int i = 0; i < duzinaNiza; i++)
            {
                min = i;
                for (int j = i + 1; j < duzinaNiza; j++)
                {
                    if (a[j] < a[min])
                        min = j;
                    f1.tek1 = min; f1.tek2 = j;
                    f1.MojRefresh();
                }
                f1.sortiran++;
                Zamena(min, i, a);
                f1.MojRefresh();
            }
        }
    }

}
