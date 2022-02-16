using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_M : MonoBehaviour
{
    int N;
    int M;

    void Start()
    {
        N = 4;
        M = 2;
        nm_3(0, new int[M]);
    }

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

    
}
