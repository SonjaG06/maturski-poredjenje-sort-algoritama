using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moje
{
    internal class Moj_MergeSort:MojSort
    {
        public Moj_MergeSort(GlavnaForma f):base(f) { }
        public override void Sortiraj(int[] a)
        {
            base.Sortiraj(a);
            sort(a, 0, duzinaNiza - 1);
            f1.sortiran = duzinaNiza;
            f1.Refresh();
        }
        void merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            i = 0;
            j = 0;

            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
                f1.MojRefresh();
            }
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
                f1.MojRefresh();
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
                f1.MojRefresh();
            }

        }
        void sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                f1.srednjiElement = m;
                f1.MojRefresh();

                sort(arr, l, m);
                sort(arr, m + 1, r);
                f1.srednjiElement = -1;

                merge(arr, l, m, r);
            }
        }
    }
}
