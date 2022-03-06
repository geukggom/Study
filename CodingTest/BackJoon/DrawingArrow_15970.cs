using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingArrow_15970 : MonoBehaviour
{
    void Start()
    {
        Main();
    }

    static void Main()
    {
        //var dotCount = int.Parse(Console.ReadLine());
        var dotCount = 7;
        int[,] test = new int[7, 2] { { 6, 1 }, { 7, 2 }, { 9, 1 }, { 10, 2 }, { 0, 1 }, { 3, 1 }, { 4, 1 } };

        Dictionary<int, int> dotList = new Dictionary<int, int>();
        int num = 0;
        int color = 0;
        for (int i = 0; i < dotCount; i++)
        {
            //var str = Console.ReadLine().Split();
            var str = test;

            //num = int.Parse(str[0]);
            //color = int.Parse(str[1]);            
            num = test[i, 0];
            color = test[i, 1];
            dotList.Add(num, color);
        }
        var sortedList = dotList.OrderBy(x => x.Key);
        sortedList = sortedList.OrderBy(x => x.Value);

        int sum = 0;
        int distance = -1;
        int exdistance = -1;
        int dotIndex = 0;
        color = -1;
        foreach (var v in sortedList)
        {
            Debug.Log(distance + ":" + exdistance);
            dotIndex++;
            exdistance = distance; //전전 점과 이전 점의 거리
            distance = v.Key - num; //바로 이전 점과 현재 점의 거리
            num = v.Key;
            if(color != -1 && color != v.Value) //맨 처음 점이 아니고, 색이 바뀌었을 때
            {
                sum = SumNumber(sum, exdistance);
                color = v.Value;
                dotIndex = 1;
            }
            else if(dotIndex == 1) //맨 처음 점일 때
            {
                color = v.Value;
            }
            else if(dotIndex == 2) //두번째 점일 때
            {
                sum = SumNumber(sum, distance);
                color = v.Value;
            }
            else //세번째부터 ㅇㅅㅇ
            {
                if (distance <= exdistance) sum = SumNumber(sum, distance);
                else sum = SumNumber(sum, exdistance);
            }
        }
        sum = SumNumber(sum, distance);
        Debug.Log(sum);
    }

    public static int SumNumber(int num, int plus)
    {
        Debug.Log(num + "+" + plus);
        return num + plus;
    }
}
