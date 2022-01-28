using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSort : MonoBehaviour
{
    private void Start()
    {
        List<int> testList = new List<int>();
        testList.Add(8);
        testList.Add(2);
        testList.Add(7);
        testList.Add(4);
        testList.Add(1);
        testList.Add(6);
        testList.Add(5);
        testList.Add(3);
        testList = quickSort(testList);
        for (int i = 0; i < testList.Count; i++)
        {
            Debug.Log(testList[i]);
        }
    }

    public List<int> quickSort(List<int> list)
    {
        if (list.Count <= 1) return list;
        int pivot = list[0];
        List<int> left_List = new List<int>();
        List<int> right_List = new List<int>();
        for (int i = 1; i < list.Count; i++)
        {
            if (pivot >= list[i]) left_List.Add(list[i]);
            else right_List.Add(list[i]);
        }

        left_List = quickSort(left_List);
        right_List = quickSort(right_List);

        left_List.Add(pivot);
        left_List.AddRange(right_List);
        return left_List;
    }
}
