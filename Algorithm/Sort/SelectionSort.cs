using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSort : MonoBehaviour
{
    public List<int> selectionSorting(List<int> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            int idx_min = i;
            for (int j = i + 1; j < list.Count; j++)
            {
                // 더 작은 수를 발견했을 경우, 해당 index 번호를 저장함.
                if (list[idx_min] > list[j]) idx_min = j; 
            }
            if(i != idx_min) //최소값이 현재 index에 없을 경우에만 swap
            {
                int temp = list[idx_min];
                list[idx_min] = list[i];
                list[i] = temp;
            }
        }
        return list;
    }
}
