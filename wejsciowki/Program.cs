using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wejsciowki
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] tab = { 1, 2, 3, 3, 3, 4, 5, -1, 6, -1 };
      Console.WriteLine("Tab we = " + arrayToString(tab) + "\n\n");

      Console.WriteLine("Min = " + fMin(tab));
      Console.WriteLine("Max = " + fMax(tab));
      Console.WriteLine("Uniq = " + arrayToString(fUniq(tab)));

      int[][] matrix =
      {
        new int[] {1,2,3,4,5},
        new int[] {1,2,3,4,2},
        new int[] {1,99,3,4,5},
        new int[] {1,2,3,4,2},
        new int[] {1,2,3,4,5}
      };
      Console.WriteLine("fCol = " + arrayToString(fCol(matrix, 1)));
      Console.WriteLine("fSum = " + fSum(tab));
      Console.WriteLine("fCzestosc = " + String.Join(",", fCzesctosc((tab))));
      Console.WriteLine("fKolumnaJezeli = " + arrayToString(fKolumnaJezeli(matrix, 0, 4, 5)));


      Regula r = new Regula();
      r.dekstryptor.Add(2, "1");
      r.dekstryptor.Add(3, "1");
      r.decyzja = "1";


      string[] obiekt = new string[] { "1", "1", "1", "1", "3", "1", "1" };

      Console.WriteLine("Czy obiekt spelnia regole: " + czySpelniaRegole(obiekt, r));

      Console.ReadKey();
    }

    public static string arrayToString(int[] tab)
    {
      string result;
      result = String.Join(",", tab);
      return result;
    }

    public static int fMin(int[] tab)
    {
      int min = tab[0];
      for (int i = 1; i < tab.Length; i++)
      {
        if (tab[i] < min)
          min = tab[i];
      }
      return min;
    }

    public static int fMax(int[] tab)
    {
      int max = tab[0];
      for (int i = 1; i < tab.Length; i++)
      {
        if (tab[i] > max)
          max = tab[i];
      }
      return max;
    }

    public static int[] fUniq(int[] tab)
    {
      List<int> tempList = new List<int>();
      for (int i = 0; i < tab.Length; i++)
      {
        if (!tempList.Contains(tab[i]))
          tempList.Add(tab[i]);
      }
      return tempList.ToArray();

    }

    public static int[] fCol(int[][] matrix, int n)
    {
      int[] result = new int[matrix.Length];

      for (int i = 0; i < matrix.Length; i++)
      {
        result[i] = matrix[i][n];
      }

      return result;
    }

    public static int fSum(int[] tab)
    {
      int sumResult = 0;
      for (int i = 0; i < tab.Length; i++)
      {
        sumResult += tab[i];
      }
      return sumResult;
    }

    public static Dictionary<T, int> fCzesctosc<T>(T[] tab)
    {
      Dictionary<T, int> dictionary = new Dictionary<T, int>();
      for (int i = 0; i < tab.Length; i++)
      {
        if (dictionary.ContainsKey(tab[i]))
          dictionary[tab[i]] += 1;
        else
          dictionary.Add(tab[i], 1);

      }
      return dictionary;
    }

    public static T[] fKolumnaJezeli<T>(T[][] tab2d, int orgin, int warunek, T klasa)
    {
      List<T> temp = new List<T>();

      for (int i = 0; i < tab2d.Length; i++)
        if (tab2d[i][warunek].Equals(klasa))
          temp.Add(tab2d[i][orgin]);


      return temp.ToArray();
    }

    public static bool czySpelniaRegole(string[] obiekt, Regula regola)
    {

      foreach (var val in regola.dekstryptor)
      {
        if (obiekt[val.Key - 1] != val.Value)
          return false;
      }

      if (obiekt[obiekt.Length - 1] != regola.decyzja)
        return false;

      return true;
    }

    public static Regula podajRegole(string[] obiekt, int[] kombinacje)
    {
      Regula regola = new Regula();

      for (int i = 0; i < kombinacje.Length; i++)
      {
        regola.dekstryptor.Add(kombinacje[i], obiekt[kombinacje[i]]);
      }

      regola.decyzja = obiekt.Last();

      return regola;
    }

    public static bool czyRegulaNieSprzeczna(Regula regula, string[][] system)
    {
      for (int i = 0; i < system.Length; i++)
      {
        if (czySpelniaRegole(system[i], regula) && system[i].Last() != regula.decyzja)
        {
          return false;
        }
      }
      return true;
    }

    /**
     * Rrgóła 
     *  deskrytory 
     *  decyzja
     *  support(ile obiektów ich popiera)
     */

    /**
     * DESKRYTPOR
     * Słownik<int, string>
     */

    /**
     * Decyzja
     *  String
     */

    /**
     * Support 
     *   Int 
     */

    // 1. Przechowywanie regoly
    // 2. Czy regoła sprzeczna
    // 3. Czy obiekt spełnia regołę
    // 4. Kombinacje bez powtórzeń (KWCombinatroics)
    // 5. Tworzenie regoly
    // 6. Liczenie supportu


    // 1. Macierz nieodróznialnosci
    // a) komórka 
    // 2. Kombinacje
    // 3. Czy kombinacja występuje
    //  a) w komórce 
    //  b) w kolumnie
    //  4. Sprawdzamy czy ma podrgule


    public static int[] PodajKomorke(Obiekt obiekt1, Obiekt obiekt2)
    {
      List<int> wynik = new List<int>();
      if (obiekt1.decyzja == obiekt2.decyzja)
        return null;

      foreach (var deksryptor in obiekt1.deskryptory)
        if (obiekt2.deskryptory[deksryptor.Key] == deksryptor.Value)
          wynik.Add(deksryptor.Key);

      return wynik.ToArray();
    }

    public static int[][][] podajMacierzNieOdroznialnosci(List<Obiekt> system)
    {
      int[][][] result = new int[system.Count][][];

      for (int i = 0; i < system.Count; i++)
      {
        result[i] = new int[system.Count][];
        for (int j = 0; j < system.Count; j++)
        {
          result[i][j] = PodajKomorke(system[i], system[j]);
        }
      }

      return result;
    }

    public static bool czyJestWKomorce(int[] komorka, int[] kombinacja)
    {
      for (int i = 0; i < kombinacja.Length; i++)
        if (!komorka.Contains(kombinacja[i]))
          return false;

      return true;
    }

    public static bool czyJestWWierszu(int[][] wiersz, int[] kombinacja)
    {
      for (int i = 0; i < wiersz.Length; i++)
      {
        if (czyJestWKomorce(wiersz[i], kombinacja))
          return true;
      }

      return false;
    }

    public static bool czyZawieraRegule(Regula r1, Regula r2)
    {
      foreach (var desk2 in r2.dekstryptor)
      {
        if (!r1.dekstryptor.ContainsKey(desk2.Key) || r1.dekstryptor[desk2.Key] != desk2.Value)
          return false;
      }
      
      return true;
    }

    public static bool czyZaweieraPodregule(Regula regula, Regula[] reguly)
    {
      foreach (var reg in reguly)
        if (czyZawieraRegule(regula, reg))
          return true;

      return false;
    }


    //  LEM 2
    // 1. Dzielimy system na koncepty
    // 2. Pobieranie konceptów
    // 3. 

    /* ALGORYTM APRIORI */
    // moc zbioru musi być conajmniej k
    // 1. czyZawiera(string[], string) (boolean)
    // 2. ileRazySieMiesci(string[][], string[]) (int)
    // 2.1. sprawdzCzyZaweieraSie(string[], string[]) (boolean)
    // 3. podzbior(string[], kombinacja) (string[])
    // 4. przeciecie wlasnosci apriori
  }
}
