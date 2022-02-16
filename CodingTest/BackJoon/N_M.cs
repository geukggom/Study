using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class N_M :MonoBehaviour
{
    static int N;
    static int M;

    private void Start()
    {
        N = 4;
        M = 4;
        List<int> forNM_1 = new List<int>();
        for (int i = 1; i <= N; i++)
        {
            forNM_1.Add(i);
        }
        nm_2(0, new int[M], forNM_1);
    }

    static void Main(string[] args)
    {
        //var str = Console.ReadLine().Split();
        //N = int.Parse(str[0]);
        //M = int.Parse(str[1]);

        N = 1;
        M = 1;

        //nm_3(0, new int[M]);

        List<int> forNM_1 = new List<int>();
        for (int i = 1; i <= N; i++)
        {
            forNM_1.Add(i);
        }
        //nm_1(0, new int[M], forNM_1);

        //nm_4(0, 1, new int[M]);

        nm_2(0, new int[M], forNM_1);
    }

    //N과 M (3) : N개 중 중복을 허용 + M개를 순서있게 나열
    static void nm_3(int index, int[] array)
    {
        if(index >= M) //M개의 숫자가 정해졌을 경우 출력
        {
            StringBuilder answer = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                answer.Append(array[i] + " ");
            }
            Debug.Log(answer);
            return;
        }
        //1부터 N까지의 숫자를 재귀용법을 통해 담기
        for (int i = 1; i <= N; i++)
        {
            array[index] = i;
            nm_3(index + 1, array);
        }
    }

    //N과 M (1) : N개 중 중복을 허용하지 않음 + M개를 순서있게 나열
    static void nm_1(int index, int[] array, List<int> candidate)
    {
        if (index >= M) //M개의 숫자가 정해졌을 경우 출력
        {
            StringBuilder answer = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                answer.Append(array[i]+" ");
            }
            Debug.Log(answer);
            return;
        }

        List<int> tempList = new List<int>();

        //1부터 N까지의 숫자를 재귀용법을 통해 담기
        for (int i = 0; i < candidate.Count; i++)
        {
            array[index] = candidate[i];
            tempList = candidate.ToList();
            tempList.RemoveAt(i);
            nm_1(index + 1, array, tempList);
        }
    }

    //N과 M (3) : N개 중 중복을 허용 + M개를 오름차순으로만 나열
    static void nm_4(int index,int startIndex, int[] array)
    {
        if (index >= M) //M개의 숫자가 정해졌을 경우 출력
        {
            StringBuilder answer = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                answer.Append(array[i] + " ");
            }
            Debug.Log(answer);
            return;
        }
        //1부터 N까지의 숫자를 재귀용법을 통해 담기
        for (int i = startIndex; i <= N; i++)
        {
            array[index] = i;
            nm_4(index + 1, i,  array);
        }
    }

    //N과 M (2) : N개 중 중복을 허용하지 않음 + M개를 오름차순으로만 나열
    static void nm_2(int index, int[] array, List<int> candidate)
    {
        if (index >= M) //M개의 숫자가 정해졌을 경우 출력
        {
            StringBuilder answer = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                answer.Append(array[i]);
            }
            Debug.Log(answer);
            return;
        }

        List<int> tempList = new List<int>();

        //1부터 N까지의 숫자를 재귀용법을 통해 담기
        for (int i = 0; i < candidate.Count; i++)
        {
            array[index] = candidate[i];
            tempList = candidate.GetRange(i + 1, candidate.Count - i - 1).ToList();
            tempList.Remove(i);
            nm_2(index + 1, array, tempList);
        }
    }
}
