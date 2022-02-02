using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Test0 : MonoBehaviour
{
    public int fact0(List<int> dataList)
    {
        if (dataList.Count <= 0) return 0;
        else
        {
            int num = dataList[0];
            dataList.RemoveAt(0);
            return num + fact0(dataList);
        }
    }

    int caseNum = 0;
    public int fact1(int value)
    {
        switch (value)
        {
            case 1: return 1;
            case 2: return 2;
            case 3: return 4;
        }
        return fact1(value - 1) + fact1(value - 2) + fact1(value - 3);
    }

    public int fact2_Re(int data) //하향식
    {
        switch (data)
        {
            case 0: return 0;
            case 1: return 1;
        }
        return fact2_Re(data - 1) + fact2_Re(data - 2);
    }

    public int fact2_Dy(int data) //상향식
    {
        int[] numlist = new int[data + 1];
        numlist[0] = 0;
        numlist[1] = 1;
        for (int i = 2; i < data + 1; i++)
        {
            numlist[i] = numlist[i - 1] + numlist[i - 2];
        }
        return numlist[data];
    }

    public void nullable()
    {
        int?[] arr = new int?[3];

        arr[0] = 1;
        arr[1] = 2;
        arr[2] = null;

        for (int i = 0; i < 3; i++)
        {
            Debug.Log(arr[i].HasValue);
        }
    }

    public int searchIndex(int data, List<int> list)
    {
        if (list.Count == 0) return -1;
        //1. 순차탐색
        //for (int i = 0; i < list.Count; i++) 
        //{
        //    if (list[i] == data) return i;
        //}

        //2. 이진탐색
        int startIndex = 0;
        int endIndex = list.Count - 1;
        while(true)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (list[midIndex] == data) return midIndex;
            else if (list[midIndex] > data) endIndex = midIndex - 1;
            else startIndex = midIndex + 1;
            if (startIndex == endIndex)
            {
                if (list[endIndex] == data) return endIndex;
                break;
            }
        }
        return -1; //원하는 데이터가 없을 경우
    }

    public void coinFunc(int pric, List<int> coinList)
    {
        int totalCount = 0;
        int nowPrice = pric;
        for (int i = 0; i < coinList.Count; i++)
        {
            int nowCount = nowPrice / coinList[i];
            nowPrice -= coinList[i] * nowCount;
            totalCount += nowCount;
        }
    }

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

        //fact1(0, newList);
        //Debug.Log(fact2_Re(9));
        //Debug.Log(fact2_Dy(9));
        //nullable();
        //for (int i = 0; i < testList.Count; i++)
        //{
        //    Debug.Log(testList[i]);
        //}

        //List<int> money = new List<int>();
        //money.Add(500);
        //money.Add(100);
        //money.Add(50);
        //money.Add(10);
        //coinFunc(4720, money);
    }
}
