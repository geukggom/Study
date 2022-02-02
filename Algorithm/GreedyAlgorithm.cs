using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreedyAlgorithm : MonoBehaviour , IComparable, IComparer
{
    int weight, value;
    public GreedyAlgorithm(int weight, int value)
    {
        this.weight = weight;
        this.value = value;
    }

    void Start()
    {
        //부분 배낭 문제
        // 무게 제한이 k인 배낭에 최대 가치를 가지도록 물건을 넣는 문제

        //풀이 방법 : 무게 당 가치가 높은 물건 먼저 가방에 넣음

        GreedyAlgorithm[] objectArray = new GreedyAlgorithm[5];
        objectArray[0] = new GreedyAlgorithm(10, 10);
        objectArray[1] = new GreedyAlgorithm(30, 5);
        objectArray[2] = new GreedyAlgorithm(25, 8);
        objectArray[3] = new GreedyAlgorithm(20, 10);
        objectArray[4] = new GreedyAlgorithm(15, 12);

        sortObjects(50, objectArray);
    }

    public int CompareTo(object obj) //IComparable 메서드
    {
        GreedyAlgorithm nowObj = obj as GreedyAlgorithm;
        if (nowObj.weight == 0) Debug.Log("개체x");
        return (weight / value).CompareTo(nowObj.weight / nowObj.value);
    }

    public void sortObjects(int totalWeight, GreedyAlgorithm[] objectArray)
    {
        Array.Sort(objectArray); //CompareTo 메서드를 이용해 정렬
        Array.Sort(objectArray, new GreedyAlgorithm[5]);
        int totalValue = 0;
        int nowWeight = totalWeight;
        for (int i = 0; i < objectArray.Length; i++)
        {
            if(totalWeight > objectArray[i].weight)
            {
                totalWeight -= objectArray[i].weight;
                totalValue += objectArray[i].value;
            }
            
        }
        Debug.Log(totalValue);
    }

    public int Compare(object x, object y)
    {
        GreedyAlgorithm _x = x as GreedyAlgorithm;
        GreedyAlgorithm _y = y as GreedyAlgorithm;
        return (_x.weight /_x.value) - (_y.weight / _y.value);
    }
}
