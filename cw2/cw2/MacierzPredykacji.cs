using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace cw2
{
    static class MacierzPredykacji
    {
        public static List<int> klasy = new List<int>();
        public static Dictionary<int, int> obiektyWKlasie = new Dictionary<int, int>();
        public static Dictionary<int, int> chwyconeWKLasie = new Dictionary<int, int>();
        public static Dictionary<int, int> poprawnieSklasyfikowane = new Dictionary<int, int>();
        public static Dictionary<int, int> blednieSklasyfikowane = new Dictionary<int, int>();

        #region Funkcje liczące dane do raportu
        public static string ACC()
        {
            string accuracy = "";
            double acc; 
            foreach (var item in klasy)
            {
                acc = (double)poprawnieSklasyfikowane[item] / chwyconeWKLasie[item];
                accuracy += String.Format("Accuracy klasy {0} = {1:0.000}", item, acc);
                accuracy += Environment.NewLine;
            }
            return accuracy;
        }

        private static string COV()
        {
            string coverage = "";
            double cov;
            foreach (var item in klasy)
            {
                cov = (double)chwyconeWKLasie[item] / obiektyWKlasie[item];
                coverage += String.Format("Coverage klasy {0} = {1:0.000}", item, cov);
                coverage += Environment.NewLine;
            }
            return coverage;
        }

        private static string TPR()
        {
            string tprStr = "";
            double tpr;
            foreach (var item in klasy)
            {
                tpr = (double)poprawnieSklasyfikowane[item] / (poprawnieSklasyfikowane[item] + blednieSklasyfikowane[item]);
                tprStr += String.Format("TPR klasy {0} = {1:0.000}", item, tpr);
                tprStr += Environment.NewLine;
            }
            return tprStr;
        }

        private static string GlobalAcc()
        {
            string accGlobal = "";
            double acc;
            int poprawnieSklasyfikowaneWCalymTST = 0;
            int chwyconeWCalymTST = 0;
            foreach (var item in klasy)
            {
                poprawnieSklasyfikowaneWCalymTST += poprawnieSklasyfikowane[item];
                chwyconeWCalymTST += chwyconeWKLasie[item];
            }
            acc = (double)poprawnieSklasyfikowaneWCalymTST / chwyconeWCalymTST;
            accGlobal = String.Format("Global accuracy = {0:0.000}", acc);
            return accGlobal;
        }

        private static string GlobalCov()
        {
            string covGlobal = "";
            double cov;
            int chwyconeWTST = 0;
            int obiektyWTST = 0;
            foreach (var item in klasy)
            {
                chwyconeWTST += chwyconeWKLasie[item];
                obiektyWTST += obiektyWKlasie[item];
            }
            cov = (double)chwyconeWTST / obiektyWTST;
            covGlobal = String.Format("Global coverage = {0:0.000}", cov);
            return covGlobal;
            
        }
        #endregion

        public static string Raport()
        {
            string raport = "";
            raport += ACC();
            raport += Environment.NewLine;
            raport += COV();
            raport += Environment.NewLine;
            raport += TPR();
            raport += Environment.NewLine;
            raport += GlobalAcc();
            raport += Environment.NewLine;
            raport += GlobalCov();
            raport += Environment.NewLine;
            return raport;
        }

        public static void Wyczysc()
        {
            klasy.Clear();
            obiektyWKlasie.Clear();
            chwyconeWKLasie.Clear();
            poprawnieSklasyfikowane.Clear();
            blednieSklasyfikowane.Clear();
        }
    }
}
