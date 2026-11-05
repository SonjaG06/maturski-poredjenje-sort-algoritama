using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Reflection;
using System.Security.Policy;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace moje
{
    public partial class GlavnaForma : Form
    {
        const int standardnaSirina = 1000;
        const int standardnaVisina = 500;
        enum MetodSortiranja
        {
            Bubble,
            Selection,
            Insertion,
            Merge,
            Quick
        }
        enum VelicinaNiza
        {
            XS,
            S,
            M,
            L,
            XL
        }

        //niz koji sortiramo
        int[] niz;
        //duzina niza
        public int duzinaNiza;
        //algoritam koji se koristi
        MetodSortiranja izabraniMetodSortiranja;
        double minVremeIzmedjuCrtanja = 0.001f;
        //vreme poslednjeg crtanja
        DateTime PoslednjeCrtanje;
        double[,] matrica = new double[5, 5];
        //pomoćne koje prate koji element se boji
        public int tek1, tek2, srednjiElement;
        public bool[] pivot;
        //broj elemenata koji su sortirani
        public int sortiran;
        //da li crtamo novi niz
        bool prviPut = false;
        int x, y;
        Brush cetka;
        //int indexSort;

        public GlavnaForma()
        {
            InitializeComponent();
            InicijalizujMatricu();
        }

        private void GlavnaForma_Load(object sender, EventArgs e)
        {
            InicijalizujComboBox();
        }
        public void InicijalizujMatricu()
        {
            matrica[(int)MetodSortiranja.Bubble, (int)VelicinaNiza.XS] = 0.000006;
            matrica[(int)MetodSortiranja.Bubble, (int)VelicinaNiza.S] = 0.000003;
            matrica[(int)MetodSortiranja.Bubble, (int)VelicinaNiza.M] = 0.000004;
            matrica[(int)MetodSortiranja.Bubble, (int)VelicinaNiza.L] = 0.000004;
            matrica[(int)MetodSortiranja.Bubble, (int)VelicinaNiza.XL] = 0.000002;

            matrica[(int)MetodSortiranja.Selection, (int)VelicinaNiza.XS] = 0.000009;
            matrica[(int)MetodSortiranja.Selection, (int)VelicinaNiza.S] = 0.000005;
            matrica[(int)MetodSortiranja.Selection, (int)VelicinaNiza.M] = 0.000004;
            matrica[(int)MetodSortiranja.Selection, (int)VelicinaNiza.L] = 0.000004;
            matrica[(int)MetodSortiranja.Selection, (int)VelicinaNiza.XL] = 0.000003;

            matrica[(int)MetodSortiranja.Insertion, (int)VelicinaNiza.XS] = 0.000005;
            matrica[(int)MetodSortiranja.Insertion, (int)VelicinaNiza.S] = 0.000003;
            matrica[(int)MetodSortiranja.Insertion, (int)VelicinaNiza.M] = 0.000003;
            matrica[(int)MetodSortiranja.Insertion, (int)VelicinaNiza.L] = 0.000001;
            matrica[(int)MetodSortiranja.Insertion, (int)VelicinaNiza.XL] = 0.000001;

            matrica[(int)MetodSortiranja.Merge, (int)VelicinaNiza.XS] = 0.000001;
            matrica[(int)MetodSortiranja.Merge, (int)VelicinaNiza.S] = 0.00002;
            matrica[(int)MetodSortiranja.Merge, (int)VelicinaNiza.M] = 0.00003;
            matrica[(int)MetodSortiranja.Merge, (int)VelicinaNiza.L] = 0.00002;
            matrica[(int)MetodSortiranja.Merge, (int)VelicinaNiza.XL] = 0.00002;

            matrica[(int)MetodSortiranja.Quick, (int)VelicinaNiza.XS] = 0.00001;
            matrica[(int)MetodSortiranja.Quick, (int)VelicinaNiza.S] = 0.00004;
            matrica[(int)MetodSortiranja.Quick, (int)VelicinaNiza.M] = 0.00002;
            matrica[(int)MetodSortiranja.Quick, (int)VelicinaNiza.L] = 0.000009;
            matrica[(int)MetodSortiranja.Quick, (int)VelicinaNiza.XL] = 0.00001;
        }

        public void MojRefresh()
        {
            DateTime trenutnoVreme = DateTime.Now;
            if (trenutnoVreme.Subtract(PoslednjeCrtanje).TotalMilliseconds < minVremeIzmedjuCrtanja)
            {
                return;
            }
            Refresh();
            Thread.Sleep(20);
            PoslednjeCrtanje = DateTime.Now;
        }

        public double MinVremeIzmedjuCrtanja()
        {
            double y;
            if (izabraniMetodSortiranja == MetodSortiranja.Merge || izabraniMetodSortiranja == MetodSortiranja.Quick)
            {
                y = duzinaNiza * Math.Log(duzinaNiza) * matrica[(int)izabraniMetodSortiranja, OdrediVelicinuNiza()];
                return y;
            }
            else
            {
                y = duzinaNiza * duzinaNiza * matrica[(int)izabraniMetodSortiranja, OdrediVelicinuNiza()];
                return y;
            }
        }

        public int OdrediVelicinuNiza()
        {
            if (duzinaNiza <= 50)
                return (int)VelicinaNiza.XS;
            if (duzinaNiza <= 80)
                return (int)VelicinaNiza.S;
            if (duzinaNiza <= 150)
                return (int)VelicinaNiza.M;
            if (duzinaNiza <= 300)
                return (int)VelicinaNiza.L;
            return (int)VelicinaNiza.XL;
        }


        public void InicijalizujComboBox()
        {
            comboBox1.Items.Add("Bubble Sort");
            comboBox1.Items.Add("Selection Sort");
            comboBox1.Items.Add("Insertion Sort");
            comboBox1.Items.Add("Merge Sort");
            comboBox1.Items.Add("Quick Sort");
            comboBox1.SelectedIndex = 0;
        }

        //Funkcija za menjanje velicine pictureBox-a
        public void PodesiVelicinuPictureBoxa()
        {
            x = (int)MathF.Ceiling(standardnaSirina / (float)duzinaNiza);
            y = (int)MathF.Ceiling(standardnaVisina / (float)duzinaNiza);
            cetka = new SolidBrush(Color.Red);
            pictureBox1.Width = duzinaNiza * x;
            pictureBox1.Height = duzinaNiza * y;
        }

        private void NacrtajRandomNiz(Graphics g)
        {
            g.Clear(Color.White);
            cetka = new SolidBrush(Color.Red);

            for (int i = 0; i < duzinaNiza; i++)
            {
                g.FillRectangle(cetka, i * x, pictureBox1.Height - niz[i] * y, x, niz[i] * y);
                g.DrawRectangle(Pens.Black, i * x, pictureBox1.Height - niz[i] * y, x, niz[i] * y);
            }
            prviPut = false;
        }

        //Svo ostalo crtanje
        private void CrtanjeSortova(Graphics g)
        {
            for (int i = 0; i < duzinaNiza; i++)
            {
                if (i == tek1 || i == tek2)
                    cetka = new SolidBrush(Color.Green);
                else
                    cetka = new SolidBrush(Color.Red);
                switch (izabraniMetodSortiranja)
                {
                    case MetodSortiranja.Bubble:
                        if (i > duzinaNiza - sortiran - 1)
                        {
                            cetka = new SolidBrush(Color.DimGray);
                        }
                        break;
                    case MetodSortiranja.Selection:
                        if (i < sortiran)
                            cetka = new SolidBrush(Color.DimGray);
                        break;
                    case MetodSortiranja.Insertion:
                        if (sortiran == i)
                            cetka = new SolidBrush(Color.Black);
                        if (sortiran == niz.Length)
                            cetka = new SolidBrush(Color.DimGray);
                        break;
                    case MetodSortiranja.Merge:
                        if (sortiran == niz.Length)
                            cetka = new SolidBrush(Color.DimGray);
                        else if (i == srednjiElement)
                            cetka = new SolidBrush(Color.Black);
                        break;
                    case MetodSortiranja.Quick:
                        if (sortiran == niz.Length)
                            cetka = new SolidBrush(Color.DimGray);
                        else if (pivot[i] == true)
                            cetka = new SolidBrush(Color.Black);
                        break;
                }
                g.FillRectangle(cetka, i * x, pictureBox1.Height - niz[i] * y, x, niz[i] * y);
                g.DrawRectangle(Pens.Black, i * x, pictureBox1.Height - niz[i] * y, x, niz[i] * y);
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (prviPut)
            {
                NacrtajRandomNiz(e.Graphics);
            }
            else
            {
                CrtanjeSortova(e.Graphics);
            }
        }

        //Dugme za pravljenje i crtanje novog niza
        private void GenerisiNizButton_Click(object sender, EventArgs e)
        {
            prviPut = true;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Niste uneli velicinu niza.");
                return;
            }
            if (ProveriUlaznePodatke())
            {
                KreirajRandomNiz();
                PodesiVelicinuPictureBoxa();
                Refresh();
            }
        }

        //Funkcija koja proverava ulazne podatke
        private bool ProveriUlaznePodatke()
        {
            if (!Int32.TryParse(textBox1.Text, out duzinaNiza))
            {
                MessageBox.Show("Unesite ceo broj između 20 i 500");
                return false;
            }

            if (duzinaNiza < 20 || duzinaNiza > 500)
            {
                MessageBox.Show("Unesite ceo broj između 20 i 500");
                return false;
            }
            return true;
        }
        //Funkcija koja napravi nasumican niz popunjen brojevima od 1 do n
        private void KreirajRandomNiz()
        {
            niz = new int[duzinaNiza];
            Random r = new Random();
            int k;
            for (int i = 1; i <= duzinaNiza; i++)
            {
                k = r.Next(0, duzinaNiza);
                while (niz[k] != 0)
                {
                    k++;
                    if (k == duzinaNiza)
                        k = 0;
                }
                niz[k] = i;
            }
        }

        //Dugme koje zapocinje sort
        private void SortirajButton_Click(object sender, EventArgs e)
        {
            if (duzinaNiza == 0) 
            {
                MessageBox.Show("Niste nacrtali niz");
                return;
            }
            sortiran = 0;
            tek1 = -1;
            tek2 = -1;
            MojSort ms;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    izabraniMetodSortiranja = MetodSortiranja.Bubble;
                    ms = new Moj_BubbleSort(this);
                    break;
                case 1:
                    izabraniMetodSortiranja = MetodSortiranja.Selection;
                    ms = new Moj_SelectionSort(this);
                    break;
                case 2:
                    izabraniMetodSortiranja = MetodSortiranja.Insertion;
                    ms = new Moj_InsertionSort(this);
                    break;
                case 3:
                    izabraniMetodSortiranja = MetodSortiranja.Merge;
                    ms = new Moj_MergeSort(this);
                    break;
                case 4:
                    izabraniMetodSortiranja = MetodSortiranja.Quick;
                    ms = new Moj_QuickSort(this);
                    pivot = new bool[duzinaNiza];
                    break;
                default:
                    throw new ArgumentException("Neispravna vrednost nacina sortiranja", "indexSort");
            }

            minVremeIzmedjuCrtanja = MinVremeIzmedjuCrtanja();
            Debug.WriteLine("minVremeIzmedjuCrtanja: " + minVremeIzmedjuCrtanja);

            ms.Sortiraj(niz);
        }
    }
}