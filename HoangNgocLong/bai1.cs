// See https://aka.ms/new-console-template for more information
using System.Drawing;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
//Chẵn lẻ
string[] Number = File.ReadAllLines("number.dat");
using (var odd = File.CreateText("odd.txt"))
using (var even = File.CreateText("even.txt"))
{
    foreach (string line in Number)
    {
        int lines = Convert.ToInt32(line);
       if (lines % 2 == 0)
        {
            even.WriteLine(lines);
        }
        else
        {
            odd.WriteLine(lines);
        }

    }
}
//Số nguyên tố
static bool IsPrime(int number)
{
    if (number <= 1) return false;
    if (number == 2) return true;
    if (number % 2 == 0) return false;

    var boundary = (int)Math.Floor(Math.Sqrt(number));

    for (int i = 3; i <= boundary; i += 2)
        if (number % i == 0)
            return false;

    return true;
}

using (var Prime = File.CreateText("Prime.txt"))
{
    foreach (string line in Number)
    {
        int lines = Convert.ToInt32(line);
        if (IsPrime(lines))
        {
            Prime.WriteLine(lines);
        }
    }
}
//Tổng số
using (var Sum = File.CreateText("Sum.txt"))
{
        long sum = Number.Sum(x => Convert.ToInt64(x));
        Sum.WriteLine(sum);
    }
//Quicksort
using (var Quicksort = File.CreateText("Quicksort.txt"))
{

    string[] lines = File.ReadLines("number.dat").ToArray();
    GenericQuickSort<string>.QuickSort(lines, 0, lines.Length - 1);
    Quicksort.WriteLine(String.Join(',',lines));
    

}
class GenericQuickSort<T> where T : IComparable
{

    public static void QuickSort(T[] ar, int lBound, int uBound)
    {
        if (lBound < uBound)
        {
            var loc = Partition(ar, lBound, uBound);
            QuickSort(ar, lBound, loc - 1);
            QuickSort(ar, loc + 1, uBound);
        }
    }

    private static int Partition(T[] ar, int lBound, int uBound)
    {
        var start = lBound;
        var end = uBound;
        var pivot = ar[uBound];
        // switch to first value as pivot
        // var pivot = ar[lBound];
        while (start < end)
        {
            while (ar[start].CompareTo(pivot) < 0)
            {
                start++;
            }
            while (ar[end].CompareTo(pivot) > 0)
            {
                end--;
            }
            if (start < end)
            {
                if (ar[start].CompareTo(ar[end]) == 0)
                {
                    start++;
                }
                else
                {
                    swap(ar, start, end);
                }
            }
        }
        return end;
    }
    private static void swap(T[] ar, int i, int j)
    {
        var temp = ar[i];
        ar[i] = ar[j];
        ar[j] = temp;
    }
}


