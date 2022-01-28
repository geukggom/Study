using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MergeSort : MonoBehaviour
{
    public List<int> mergeSort(List<int> list)
    {
        if (list.Count <= 1) return list;
        int cutNum = list.Count / 2;

        List<int> leftList = list.ToList();
        List<int> rightList = list.ToList();

        leftList.RemoveRange(cutNum, list.Count - cutNum);
        leftList = mergeSort(leftList);

        rightList.RemoveRange(0, cutNum);
        rightList = mergeSort(rightList);

        return mergeList(leftList, rightList);
    }

    public List<int> mergeList(List<int> leftList, List<int> rightList)
    {
        List<int> mergedList = new List<int>();
        int leftIndex = 0;
        int rightIndex = 0;
        while (leftList.Count > leftIndex && rightList.Count > rightIndex)
        {
            if (leftList[leftIndex] <= rightList[rightIndex])
            {
                mergedList.Add(leftList[leftIndex]);
                leftIndex++;
            }
            else
            {
                mergedList.Add(rightList[rightIndex]);
                rightIndex++;
            }
        }
        if (leftList.Count > leftIndex)
        {
            for (int i = leftIndex; i < leftList.Count; i++)
            {
                mergedList.Add(leftList[i]);
            }
        }
        else if (rightList.Count > rightIndex)
        {
            for (int i = rightIndex; i < rightList.Count; i++)
            {
                mergedList.Add(rightList[i]);
            }
        }
        return mergedList;
    }
}
