using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class SubsequenceSum
{
    static int count = 0;

    static void Main()
    {
        string input1 = "5 0";
        string input2 = "-7 -3 -2 5 8";
        string[] str1 = input1.Split(' ');
        string[] str2 = input2.Split(' ');

        //var str1 = Console.ReadLine().Split();
        //var str2 = Console.ReadLine().Split();

        List<int> numbers = new List<int>();
        int goal = int.Parse(str1[1]);
        for (int i = 0; i < str2.Length; i++)
        {
            numbers.Add(int.Parse(str2[i]));
        }
        numbers.Sort();

        subsequence(numbers, goal, null);
        Console.WriteLine(count);
        //Debug.Log(count);
    }

    static void subsequence(List<int> numbers, int goal, int? num)
    {
        if (goal == num)
        {
            count++;
            List<int> tempList1 = numbers.ToList();
            subsequence(tempList1, 0, null);
            return;
        }
        if (numbers.Count == 0) return;

        int plus = numbers[0];
        if (plus >= 0 && num > goal) return;

        List<int> tempList2 = numbers.ToList();
        tempList2.RemoveAt(0);

        subsequence(tempList2, goal, num);
        if (num == null) num = 0;
        subsequence(tempList2, goal, num + plus);
    }
}

