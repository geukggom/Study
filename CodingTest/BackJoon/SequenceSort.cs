using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Text;

public class SequenceSort : MonoBehaviour
{
    void Start()
    {
        Main();
    }

    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        //int count = 8;
        var str = Console.ReadLine().Split();
        //string input = "4 1 6 1 3 6 1 4";
        //string[] str = input.Split(' ');
        sortIndex(count, str);
    }

    static void sortIndex(int count, string[] str)
    {
        int[] numArray = new int[count];
        int[] indexArray = new int[count];
        for (int i = 0; i < count; i++) // string 배열을 int 배열로 바꿈
        {
            numArray[i] = int.Parse(str[i]);
            indexArray[i] = i;
        }
        for (int i = 0; i < count - 1; i++)
        {
            if (numArray[i] > numArray[i + 1])
            {
                Debug.Log(i + " " + numArray[i] + "랑 " + numArray[i + 1] + "바꿈");
                int temp = numArray[i];
                numArray[i] = numArray[i + 1];
                numArray[i + 1] = temp;

                int indexTemp = indexArray[i];
                indexArray[i] = indexArray[i + 1];
                indexArray[i + 1] = indexTemp;

                i -= 2;
                if (i < -1) i = -1;
            }
        }
        int[] answer = new int[count];
        for (int i = 0; i < count; i++)
        {
            answer[indexArray[i]] = i;
        }
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++)
        {
            sb.Append(answer[i].ToString()).Append(" ");
        }
        Debug.Log(sb);
        Console.WriteLine(sb);
    }
}
