using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class N_M : MonoBehaviour
{
    int N;
    int M;

    void Start()
    {
        N = 4;
        M = 4;

        //nm_3(0, new int[M]);

        List<int> forNM_1 = new List<int>();
        for (int i = 1; i <= N; i++)
        {
            forNM_1.Add(i);
        }
        nm_1(0, new int[M], forNM_1);
    }

    //N과 M (3) : N개 중 중복을 허용 + M개를 순서있게 나열
    public void nm_3(int index, int[] array)
    {
        if(index >= M) //M개의 숫자가 정해졌을 경우 출력
        {
            string answer = "";
            for (int i = 0; i < array.Length; i++)
            {
                answer += array[i].ToString();
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
    public void nm_1(int index, int[] array, List<int> candidate)
    {
        if (index >= M) //M개의 숫자가 정해졌을 경우 출력
        {
            string answer = "";
            for (int i = 0; i < array.Length; i++)
            {
                answer += array[i].ToString();
            }
            Debug.Log(answer);
            return;
        }

        //1부터 N까지의 숫자를 재귀용법을 통해 담기
        for (int i = 0; i < candidate.Count; i++)
        {
            array[index] = candidate[i];
            List<int> tempList = candidate.ToList();
            tempList.RemoveAt(i);
            nm_1(index + 1, array, tempList);
        }
    }

}
