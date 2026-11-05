using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moje
{
    internal class Moj_InsertionSort:MojSort
    {
        public Moj_InsertionSort(GlavnaForma f) : base(f) { }
        public override void Sortiraj(int[] a)
        {
            base.Sortiraj(a);
            InsertionSort(a);
            f1.Refresh();
        }
        public void InsertionSort(int[] a)
        {
            int j;
            for (int i = 1; i < duzinaNiza; i++)
            {
                f1.sortiran = i;
                f1.MojRefresh();
                j = i - 1;
                while (j >= 0 && a[j] > a[j + 1])
                {
                    Zamena(j, j + 1, a);
                    f1.tek1 = j; f1.tek2 = j + 1;
                    f1.MojRefresh();
                    j = j - 1;
                }
            }
            f1.sortiran++;
        }
    }
}
