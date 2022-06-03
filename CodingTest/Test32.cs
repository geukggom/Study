using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Test32 
{
    static public int solution(int[] citations)
    {
        List<int> citationToList = citations.ToList();
        List<int> sortedCitations = quickSort(citationToList);
        int answer = 0;
        for (int i = 0; i < sortedCitations.Count; i++)
        {
            Console.WriteLine(sortedCitations[i]);
        }
        for (int i = 0; i < sortedCitations.Count; i++)
        {
            Console.WriteLine(sortedCitations[i] + ":" + answer);
            if (sortedCitations[i] <= answer) break;
            else answer++;
        }
        Console.WriteLine(answer);
        return answer;
    }

    static public List<int> quickSort(List<int> list)
    {
        if (list.Count <= 1) return list;
        int pivot = list[0];
        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();
        for (int i = 1; i < list.Count; i++)
        {
            if (list[i] < pivot) rightList.Add(list[i]);
            else leftList.Add(list[i]);
        }
        leftList = quickSort(leftList);
        rightList = quickSort(rightList);
        leftList.Add(pivot);
        leftList.AddRange(rightList);
        return leftList;
    }

    static void Main(string[] args)
    {
        solution(new int[] { 3, 0, 6, 1, 5 });
        for (; ; );
    }

}
