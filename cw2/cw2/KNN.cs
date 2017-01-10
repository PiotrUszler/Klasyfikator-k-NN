using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2
{
    class KNN
    {
        private int[][] systemTreningowy;
        private int[][] systemTestowy;
        private int metryka;
        private int liczbaSasiadow;

        public KNN(int[][] systemTrn, int[][] systemTst, int metryka,int liczbaSasiadow)
        {
            this.systemTreningowy = systemTrn;
            this.systemTestowy = systemTst;
            this.metryka = metryka;
            this.liczbaSasiadow = liczbaSasiadow + 1;//Dodajemy 1 ponieważ w comboBox'ie indeksowanie zaczyna się od zera
        }

        //Zwraca listę z mocą glosowania klas
        private List<double[]> GlosyNajblizszychSasiadow(double[] glosy,int[] decyzje)
        {
            int[] unikalneDecyzje = UnikalneDecyzje(decyzje);
            List<double> mocKlasy = new List<double>();
            //Lista z sasiadami. Elementy listy zawieraja pod ideksem 0 moc glosow, pod indeksem 1 klasę.
            List<double[]> glosyKlas = new List<double[]>();

            foreach (int decyzja in unikalneDecyzje)
            {
                mocKlasy.Clear();
                //Dopóki nie znajdziemy tylu najmniejszych glosow dla danej klasy ile wynosi liczbaSasiadow
                while(liczbaSasiadow > mocKlasy.Count)
                {
                    double najmniejszyGlos = 10000;
                    int najmniejszyIndeks = 0;
                    for (int i = 0; i < glosy.Length; i++)
                    {
                        if(najmniejszyGlos > glosy[i] && systemTreningowy[i][systemTreningowy[i].Length - 1] == decyzja)
                        {
                            najmniejszyGlos = glosy[i];
                            najmniejszyIndeks = i;
                        }
                    }
                    glosy[najmniejszyIndeks] = 10000;//Przypisujemy mu wartość 10000(Nie będzie już brany pod uwagę)
                    mocKlasy.Add(najmniejszyGlos);
                }
                glosyKlas.Add(new double[] {mocKlasy.Sum(), decyzja });//Dodajemy do listy głosów nową tablicę z sumą najmniejszych głosów oraz decyzją
            }
            return glosyKlas;
        }

        //Zwraca tablicę z klasyfikacja. Indeks 0 - Najmniejsza Moc(Najblizszy sąsiad), 1 - decyzja sąsiada
        private double[] Klasyfikuj(List<double[]> sasiedzi)
        {
            double decyzja = 0;
            double najMoc = 0;
            double[] klasyfikacja = new double[2];
            for (int i = 0; i < sasiedzi.Count; i++)
            {
                decyzja = sasiedzi[i][1];
                najMoc = sasiedzi[i][0];
                for (int j = 0; j < sasiedzi.Count; j++)
                {
                    if (j == i) continue; 
                    //Nie można uchwycić
                    if(sasiedzi[j][0] == najMoc)
                    {
                        decyzja = -1;
                        najMoc = -1;
                    }
                    else if(sasiedzi[j][0] < najMoc)
                    {
                        decyzja = sasiedzi[j][1];
                        najMoc = sasiedzi[j][0];
                    }
                }
            }

            klasyfikacja[0] = najMoc;
            klasyfikacja[1] = decyzja;
            return klasyfikacja;
        }

        //Funckja dodaje dane do Macierzy Predykacji
        private void DodajDoMacierzyPredykacji(double[] klasyfikacja, int decyzjaObiektuTestowego)
        {
            //Poprawnie sklasyfikowane
            if (decyzjaObiektuTestowego == klasyfikacja[1])
            {
                if(!MacierzPredykacji.klasy.Contains(decyzjaObiektuTestowego)){
                    MacierzPredykacji.klasy.Add(decyzjaObiektuTestowego);
                }

                if (!MacierzPredykacji.obiektyWKlasie.ContainsKey(decyzjaObiektuTestowego)){
                    MacierzPredykacji.obiektyWKlasie.Add(decyzjaObiektuTestowego, 1);
                }
                else
                {
                    MacierzPredykacji.obiektyWKlasie[decyzjaObiektuTestowego]++;
                }

                if (!MacierzPredykacji.poprawnieSklasyfikowane.ContainsKey(decyzjaObiektuTestowego))
                {
                    MacierzPredykacji.poprawnieSklasyfikowane.Add(decyzjaObiektuTestowego, 1);
                }
                else
                {
                    MacierzPredykacji.poprawnieSklasyfikowane[decyzjaObiektuTestowego]++;
                }

                if (!MacierzPredykacji.chwyconeWKLasie.ContainsKey(decyzjaObiektuTestowego))
                {
                    MacierzPredykacji.chwyconeWKLasie.Add(decyzjaObiektuTestowego, 1);
                }
                else
                {
                    MacierzPredykacji.chwyconeWKLasie[decyzjaObiektuTestowego]++;
                }

                //Dodajemy klucz do błędnie sklasyfikowanych, żeby nie wyrzucało błędu o nie znalezionym kluczu jeśli nie ma żadnego błędnie sklasyfikowanego obiektu dla danej klasy
                if (!MacierzPredykacji.blednieSklasyfikowane.ContainsKey(decyzjaObiektuTestowego))
                {
                    MacierzPredykacji.blednieSklasyfikowane.Add(decyzjaObiektuTestowego, 0);
                }

            }
            //Nie można uchwycić obiektu, wiecej niż jeden obiekt mają taką samą, najmniejszą moc
            else if (klasyfikacja[1] == -1)
            { 
                if (!MacierzPredykacji.klasy.Contains(decyzjaObiektuTestowego))
                {
                    MacierzPredykacji.klasy.Add(decyzjaObiektuTestowego);
                }

                if (!MacierzPredykacji.obiektyWKlasie.ContainsKey(decyzjaObiektuTestowego))
                {
                    MacierzPredykacji.obiektyWKlasie.Add(decyzjaObiektuTestowego, 1);
                }
                else
                {
                    MacierzPredykacji.obiektyWKlasie[decyzjaObiektuTestowego]++;
                }

            }
            //Błędnie sklasyfikowano
            else if (decyzjaObiektuTestowego != klasyfikacja[1])
            {
                if (!MacierzPredykacji.klasy.Contains(decyzjaObiektuTestowego))
                {
                    MacierzPredykacji.klasy.Add(decyzjaObiektuTestowego);
                }

                if (!MacierzPredykacji.obiektyWKlasie.ContainsKey(decyzjaObiektuTestowego))
                {
                    MacierzPredykacji.obiektyWKlasie.Add(decyzjaObiektuTestowego, 1);
                }
                else
                {
                    MacierzPredykacji.obiektyWKlasie[decyzjaObiektuTestowego]++;
                }

                if (!MacierzPredykacji.chwyconeWKLasie.ContainsKey(decyzjaObiektuTestowego))
                {
                    MacierzPredykacji.chwyconeWKLasie.Add(decyzjaObiektuTestowego, 1);
                }
                else
                {
                    MacierzPredykacji.chwyconeWKLasie[decyzjaObiektuTestowego]++;
                }

                //Dodajemy klucz do poprawnie sklasyfikowanych, żeby nie wyrzucało błędu o nie znalezionym kluczu jeśli nie ma żadnego poprawnie sklasyfikowanego obiektu dla danej klasy
                if (!MacierzPredykacji.poprawnieSklasyfikowane.ContainsKey(decyzjaObiektuTestowego))
                {
                    MacierzPredykacji.poprawnieSklasyfikowane.Add(decyzjaObiektuTestowego, 0);
                }

                //Dodajemy do błędnie sklasyfikowanych w klasie znalezionej w klasyfikacji
                if (!MacierzPredykacji.blednieSklasyfikowane.ContainsKey((int)klasyfikacja[1]))
                {
                    MacierzPredykacji.blednieSklasyfikowane.Add((int)klasyfikacja[1], 1);
                }
                else
                {
                    MacierzPredykacji.blednieSklasyfikowane[(int)klasyfikacja[1]]++;
                }
            }
        }

        public void Algorytm()
        {
            int[] tablicaDecyzji = ZnajdzKlasy(systemTreningowy);
            switch (metryka)
            {
                case 0:
                    for (int i = 0; i < systemTestowy.Length; i++)
                    {
                        List<double[]> glosySasiadow = GlosyNajblizszychSasiadow(Metryka.Euklides(i, systemTestowy, systemTreningowy).ToArray(),tablicaDecyzji);
                        double[] klasyfikacja = Klasyfikuj(glosySasiadow);
                        int decyzja = systemTestowy[i][systemTestowy[i].Length - 1];//decyzja obiektu testowego
                        DodajDoMacierzyPredykacji(klasyfikacja, decyzja);
                    }
                    break;
                case 1:
                    for (int i = 0; i < systemTestowy.Length; i++)
                    {
                        List<double[]> sasiedzi = GlosyNajblizszychSasiadow(Metryka.Canberr(i, systemTestowy, systemTreningowy).ToArray(), tablicaDecyzji);
                        double[] klasyfikacja = Klasyfikuj(sasiedzi);
                        int decyzja = systemTestowy[i][systemTestowy[i].Length - 1];
                        DodajDoMacierzyPredykacji(klasyfikacja, decyzja);
                    }
                    break;
                case 2:
                    for (int i = 0; i < systemTestowy.Length; i++)
                    {
                        List<double[]> sasiedzi = GlosyNajblizszychSasiadow(Metryka.Manhattan(i, systemTestowy, systemTreningowy).ToArray(), tablicaDecyzji);
                        double[] klasyfikacja = Klasyfikuj(sasiedzi);
                        int decyzja = systemTestowy[i][systemTestowy[i].Length - 1];
                        DodajDoMacierzyPredykacji(klasyfikacja, decyzja);
                    }
                    break;
                case 3:
                    for (int i = 0; i < systemTestowy.Length; i++)
                    {
                        List<double[]> sasiedzi = GlosyNajblizszychSasiadow(Metryka.Czybyszew(i, systemTestowy, systemTreningowy).ToArray(), tablicaDecyzji);
                        double[] klasyfikacja = Klasyfikuj(sasiedzi);
                        int decyzja = systemTestowy[i][systemTestowy[i].Length - 1];
                        DodajDoMacierzyPredykacji(klasyfikacja, decyzja);
                    }
                    break;
                case 4:
                    for (int i = 0; i < systemTestowy.Length; i++)
                    {
                        List<double[]> sasiedzi = GlosyNajblizszychSasiadow(Metryka.Pearson(i, systemTestowy, systemTreningowy).ToArray(), tablicaDecyzji);
                        double[] klasyfikacja = Klasyfikuj(sasiedzi);
                        int decyzja = systemTestowy[i][systemTestowy[i].Length - 1];
                        DodajDoMacierzyPredykacji(klasyfikacja, decyzja);
                    }
                    break;
                default:
                    break;
            }
        }

        //Funkcja znajduje klasy dla każdego obiektu(systemu treningowego)
        private int[] ZnajdzKlasy(int[][] macierz)
        {
            int szerokosc = macierz[0].Length - 1;
            int wysokosc = macierz.Length;
            int[] klasy = new int[wysokosc];
            for (int i = 0; i < wysokosc; i++)
                klasy[i] = macierz[i][szerokosc];
            return klasy;
        }

        //Zwraca tablicę z unikalnymi decyzjami
        private int[] UnikalneDecyzje(int[] decyzje)
        {
            List<int> unikalneDecyzje = new List<int>();
            for (int i = 0; i < decyzje.Length; i++)
                if (!unikalneDecyzje.Contains(decyzje[i]))
                    unikalneDecyzje.Add(decyzje[i]);
            return unikalneDecyzje.ToArray();
        }

    }
}
