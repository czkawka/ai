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
        new int[] {1,2,3,4,5},
        new int[] {1,99,3,4,5},
        new int[] {1,2,3,4,5},
        new int[] {1,2,3,4,5}
      };
      Console.WriteLine("fCol = " + arrayToString(fCol(matrix, 1)));
      Console.WriteLine("fSum = " + fSum(tab));
      Console.WriteLine("fCzestosc = " + String.Join(",", fCzesctosc((tab))));
      

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

    public static Dictionary<int, int> fCzesctosc(int[] tab)
    {
      Dictionary<int, int> dictionary = new Dictionary<int, int>();
      for (int i = 0; i < tab.Length; i++)
      {
        if (dictionary.ContainsKey(tab[i]))
          dictionary[tab[i]] += 1;
        else
          dictionary.Add(tab[i], 1);
  
      }

      return dictionary;
    }
  }
}
