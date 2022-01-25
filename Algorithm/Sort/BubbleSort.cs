using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : MonoBehaviour
{
    public List<int> bubbleSorting(List<int> list)
    {
        for (int j = 0; j < list.Count - 1; j++)
        {
            bool is_changed = false; //이미 정렬이 끝난 상태면 더 돌지 않고 끝냄
            //정렬이 끝난 뒤의 수를 제외하고 for문을 다시 돌림
            for (int i = 0; i < list.Count - 1 - j; i++)
            {
                if (list[i] > list[i + 1]) //인접한 두개의 수 크기 비교
                {
                    int temp = list[i];
                    list[i] = list[i + 1];
                    list[i + 1] = temp;
                    is_changed = true;
                }
            }
            if (!is_changed) return list;
        }
        return list;
    }
}
