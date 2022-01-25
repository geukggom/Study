using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertionSort : MonoBehaviour
{
    public List<int> selectionSorting(List<int> list)
    {
        for (int i = 1; i < list.Count; i++)
        {
            int key = list[i];
            for (int j = i - 1; j >= 0; j--)
            {
                if (list[j] > key)
                {
                    list[j + 1] = list[j];
                    list[j] = key;
                }
                else j = 0;
            }
        }
        return list;
    }

    private void Start()
    {
        List<int> a = new List<int>();
        a.Add(3);
        a.Add(15);
        a.Add(16);
        a.Add(14);
        a.Add(13);
        a.Add(12);
        a.Add(1);
        selectionSorting(a);
    }
}