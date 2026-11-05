using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moje
{
    internal class Moj_BubbleSort:MojSort
    {
        public Moj_BubbleSort(GlavnaForma f) : base(f) { }
        public override void Sortiraj(int[] a)
        {
            base.Sortiraj(a);
            BubbleSort(a);
            f1.Refresh();
        }
        public void BubbleSort(int[] a)
        {

            for (int i = 0; i < duzinaNiza - 1; i++)
            {

                for (int j = 0; j < duzinaNiza - 1 - i; j++)
                {

                    if (a[j] > a[j + 1])
                    {
                        Zamena(j, j + 1, a);
                    }
                    f1.tek1 = j; f1.tek2 = j + 1;
                    f1.MojRefresh();
                }
                f1.sortiran++;
                f1.MojRefresh();
            }
            f1.sortiran++;
        }
    }
    
}
