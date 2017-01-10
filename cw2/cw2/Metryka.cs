using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2
{
    static class Metryka
    {
        public static List<double> Euklides(int rzad, int[][] testowy, int[][] treningowy)
        {
            List<double> wyniki = new List<double>();
            int szerokoscTestowego = testowy[0].Length;
            int wysokoscTreningowego = treningowy.Length;

            for (int j = 0; j < wysokoscTreningowego; j++)
            {
                double wynik = 0;
                //szerokosc - 1, bo liczymy bez ostatniej kolumy, czyli decyzji
                for (int i = 0; i < szerokoscTestowego - 1; i++)
                {
                    wynik += Math.Pow((testowy[rzad][i] - treningowy[j][i]), 2);
                }
                wynik = Math.Sqrt(wynik);
                wyniki.Add(wynik);
            }
            return wyniki;
        }

        public static List<double> Manhattan(int rzad, int[][] testowy, int[][] treningowy)
        {
            List<double> wyniki = new List<double>();
            int szerokoscTestowego = testowy[0].Length;
            int wysokoscTreningowego = treningowy.Length;

            for (int j = 0; j < wysokoscTreningowego; j++)
            {
                double wynik = 0;
                for (int i = 0; i < szerokoscTestowego - 1; i++)
                {
                    wynik += Math.Abs(testowy[rzad][i] - treningowy[j][i]);
                }
                wyniki.Add(wynik);
            }
            return wyniki;
        }

        public static List<double> Canberr(int rzad, int[][] testowy, int[][] treningowy)
        {
            List<double> wyniki = new List<double>();
            int szerokoscTestowego = testowy[0].Length;
            int wysokoscTreningowego = treningowy.Length;

            double licznik;
            double mianownik;

            for (int j = 0; j < wysokoscTreningowego; j++)
            {
                double wynik = 0;
                for (int i = 0; i < szerokoscTestowego - 1; i++)
                {
                    licznik = testowy[rzad][i] - treningowy[j][i];
                    mianownik = testowy[rzad][i] + treningowy[j][i];

                    wynik += Math.Abs(licznik / mianownik);
                }
                wyniki.Add(wynik);
            }
            return wyniki;
        }

        public static List<double> Czybyszew(int rzad, int[][] testowy, int[][] treningowy)
        {
            List<double> wyniki = new List<double>();

            int szerokoscTestowego = testowy[0].Length;
            int wysokoscTreningowego = treningowy.Length;

            double[] tablicaMax = new double[szerokoscTestowego];

            for (int j = 0; j < wysokoscTreningowego; j++)
            {
                double wynik = 0;
                for (int i = 0; i < szerokoscTestowego - 1; i++)
                {
                    wynik = Math.Abs(testowy[rzad][i] - treningowy[j][i]);
                    tablicaMax[i] = wynik;
                }

                wyniki.Add(tablicaMax.Max());
            }
            return wyniki;
        }



        public static List<double> Pearson(int rzad, int[][] testowy, int[][] treningowy)
        {
            List<double> wyniki = new List<double>();
            int wysokoscTreningowego = treningowy.Length;

            for (int rzadY = 0; rzadY < wysokoscTreningowego; rzadY++)
            {
                double wynik = 0;
                wynik = 1 - Math.Abs(obliczR(rzad, rzadY, testowy, treningowy));
                wyniki.Add(wynik);
            }

            return wyniki;
        }

        //Oblicza r dla podanego rzędu x i rzedu y
        private static double obliczR(int rzadX, int rzadY, int[][] testowy, int[][] treningowy)
        {
            int szerokoscTestowego = testowy[0].Length;
            int wysokoscTestowego = testowy.Length;

            int szerokoscTrenigowego = treningowy[0].Length;
            int wysokoscTreningowego = treningowy.Length;

            double x = 0;
            double y = 0;
            double r = 0;

            double sredniaX = 0;
            double sredniaY = 0;

            double mianownikX = 0;
            double mianownikY = 0;


            for (int i = 0; i < szerokoscTestowego - 1; i++)
            {
                x += testowy[rzadX][i];
                y += treningowy[rzadY][i];
            }
            //Dzielimy sumę przez liczbę atrybutów
            sredniaX = x / (szerokoscTestowego - 1);
            sredniaY = y / (szerokoscTestowego - 1);

            double wynikX = 0;
            double wynikY = 0;

            for (int i = 0; i < szerokoscTestowego - 1; i++)
            {
                wynikX += Math.Pow((testowy[rzadX][i] - sredniaX), 2);
                wynikY += Math.Pow((treningowy[rzadY][i] - sredniaY), 2);
            }

            mianownikX = Math.Sqrt((wynikX / (szerokoscTestowego - 1)));
            mianownikY = Math.Sqrt((wynikY / (szerokoscTestowego - 1)));

            double wynikGlowny = 0;

            for (int i = 0; i < szerokoscTestowego - 1; i++)
            {
                wynikGlowny += ((testowy[rzadX][i] - sredniaX) / mianownikX) * ((treningowy[rzadY][i] - sredniaY) / mianownikY);
            }

            r = (wynikGlowny / (szerokoscTestowego - 1));
            return r;
        }
    }
}
