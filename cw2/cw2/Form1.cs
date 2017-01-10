using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cw2
{
    public partial class Form1 : Form
    {
        int[][] macierzTestowa = null;
        int[][] macierzTreningowa = null;

        public Form1()
        {
            InitializeComponent();
            cb_Metryka.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ofd.Filter = "Text (.txt) |*.txt";
        }

        private void btn_Oblicz_Click(object sender, EventArgs e)
        {
            MacierzPredykacji.Wyczysc();
            KNN knn;
            switch (cb_Metryka.SelectedIndex)
            {
                case 0:
                    knn = new KNN(macierzTreningowa, macierzTestowa, 0, cb_Sasiedzi.SelectedIndex);
                    knn.Algorytm();
                    tb_Wynik.AppendText("Wyliczone Metryką Euklidesa");
                    tb_Wynik.AppendText(Environment.NewLine);
                    tb_Wynik.AppendText("------------------------------------------------------");
                    tb_Wynik.AppendText(Environment.NewLine);
                    tb_Wynik.AppendText(MacierzPredykacji.Raport());
                    tb_Wynik.AppendText(Environment.NewLine);
                    break;
                case 1:
                    knn = new KNN(macierzTreningowa, macierzTestowa, 1, cb_Sasiedzi.SelectedIndex);
                    knn.Algorytm();
                    tb_Wynik.AppendText("Wyliczone Metryką Manhattan");
                    tb_Wynik.AppendText(Environment.NewLine);
                    tb_Wynik.AppendText("------------------------------------------------------");
                    tb_Wynik.AppendText(Environment.NewLine);
                    tb_Wynik.AppendText(MacierzPredykacji.Raport());
                    tb_Wynik.AppendText(Environment.NewLine);
                    break;
                case 2:
                    knn = new KNN(macierzTreningowa, macierzTestowa, 2, cb_Sasiedzi.SelectedIndex);
                    knn.Algorytm();
                    tb_Wynik.AppendText("Wyliczone Metryką Canberra");
                    tb_Wynik.AppendText(Environment.NewLine);
                    tb_Wynik.AppendText("------------------------------------------------------");
                    tb_Wynik.AppendText(Environment.NewLine);
                    tb_Wynik.AppendText(MacierzPredykacji.Raport());
                    break;
                case 3:
                    knn = new KNN(macierzTreningowa, macierzTestowa, 3, cb_Sasiedzi.SelectedIndex);
                    knn.Algorytm();
                    tb_Wynik.AppendText("Wyliczone Metryką Czybyszewa");
                    tb_Wynik.AppendText(Environment.NewLine);
                    tb_Wynik.AppendText("------------------------------------------------------");
                    tb_Wynik.AppendText(Environment.NewLine);
                    tb_Wynik.AppendText(MacierzPredykacji.Raport());
                    tb_Wynik.AppendText(Environment.NewLine);
                    break;
                case 4:
                    knn = new KNN(macierzTreningowa, macierzTestowa, 4, cb_Sasiedzi.SelectedIndex);
                    knn.Algorytm();
                    tb_Wynik.AppendText("Wyliczone Metryką Pearson'a");
                    tb_Wynik.AppendText(Environment.NewLine);
                    tb_Wynik.AppendText("------------------------------------------------------");
                    tb_Wynik.AppendText(Environment.NewLine);
                    tb_Wynik.AppendText(MacierzPredykacji.Raport());
                    tb_Wynik.AppendText(Environment.NewLine);
                    break;
                default:
                    break;
            }
        }

        
        private int MaksymalnaLiczbaSasiadow()
        {
            int maksymalnaLiczbaSasiadow = 0;
            Dictionary<int, int> slownikKlasICzestosci = new Dictionary<int, int>();//Klucz: klasa, Wartość: częstość
            for (int i = 0; i < macierzTreningowa.Length; i++)
            {
                int decyzja = macierzTreningowa[i][macierzTreningowa[i].Length - 1];
                if (!slownikKlasICzestosci.ContainsKey(decyzja))
                {
                    slownikKlasICzestosci.Add(decyzja, 1);
                }
                else
                {
                    slownikKlasICzestosci[decyzja]++;
                }
            }
            maksymalnaLiczbaSasiadow = slownikKlasICzestosci.Values.Min();
            return maksymalnaLiczbaSasiadow;
        }

        #region Wczytywanie macierzy
        private void btn_WczytajTrening_Click(object sender, EventArgs e)
        {
            var wynik = ofd.ShowDialog();

            if (wynik != DialogResult.OK)
                return;

            if (wynik == DialogResult.OK)
            {
                tb_Treningowy.Text = ofd.FileName;
                string trescPliku = System.IO.File.ReadAllText(ofd.FileName);

                string[] poziomy = trescPliku.Split('\n');

                int[][] MacierzTreningowa = new int[poziomy.Length][];

                for (int i = 0; i < poziomy.Length; i++)
                {
                    string poziom = poziomy[i].Trim();
                    string[] miejscaParkingowe = poziom.Split(' ');
                    MacierzTreningowa[i] = new int[miejscaParkingowe.Length];
                    for (int j = 0; j < miejscaParkingowe.Length; j++)
                    {
                        MacierzTreningowa[i][j] = int.Parse(miejscaParkingowe[j]);
                    }
                }
                macierzTreningowa = MacierzTreningowa;
            }
            //Dodanie listy wyborow ilosci sasiadow do cb_Sasiedzi
            if (macierzTestowa != null)
            {
                for (int i = 1; i <= MaksymalnaLiczbaSasiadow(); i++)
                {
                    cb_Sasiedzi.Items.Add(i);
                }
                cb_Sasiedzi.SelectedIndex = 0;
            }
        }

        private void btn_WczytajTest_Click(object sender, EventArgs e)
        {
            var wynik = ofd.ShowDialog();

            if (wynik != DialogResult.OK)
                return;

            if (wynik == DialogResult.OK)
            {
                tb_Testowy.Text = ofd.FileName;
                string trescPliku = System.IO.File.ReadAllText(ofd.FileName);

                string[] poziomy = trescPliku.Split('\n');

                int[][] MacierzTestowa = new int[poziomy.Length][];

                for (int i = 0; i < poziomy.Length; i++)
                {
                    string poziom = poziomy[i].Trim();
                    string[] miejscaParkingowe = poziom.Split(' ');
                    MacierzTestowa[i] = new int[miejscaParkingowe.Length];
                    for (int j = 0; j < miejscaParkingowe.Length; j++)
                    {
                        MacierzTestowa[i][j] = int.Parse(miejscaParkingowe[j]);
                    }


                }
                macierzTestowa = MacierzTestowa;
            }
            //Dodanie listy wyborow ilosci sasiadow do cb_Sasiedzi
            if (macierzTreningowa != null)
            {
                for (int i = 1; i <= MaksymalnaLiczbaSasiadow(); i++)
                {
                    cb_Sasiedzi.Items.Add(i);
                }
                cb_Sasiedzi.SelectedIndex = 0;
            }
        }
        #endregion
    }
}
