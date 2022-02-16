using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class OperatorInput : MonoBehaviour
{
    static List<int> answerList = new List<int>();
    static int numCount;

    void Start()
    {
        //var input = Console.ReadLine();
        string input = "6\n1 2 3 4 5 6\n2 1 1 1";
        //string input = "3\n5 6 7\n2 0 0 0";
        string[] str = input.Split('\n');
        numCount = int.Parse(str[0]);
        string[] numbers = str[1].Split(' ');
        string[] str_operation = str[2].Split(' ');
        
        operInput(numbers, str_operation, int.Parse(numbers[0]), numCount-1);

        answerList.Sort();
        int min = answerList[0];
        int max = answerList[answerList.Count - 1];
        Debug.Log(min);
        Debug.Log(max);
    }

    static void operInput(string[] numbers, string[] operators, int num, int count)
    {
        if (count == 0)
        {
            if (!answerList.Contains(num)) answerList.Add(num);
            return;
        }

        string[] tempOperators = new string[4];
        for (int i = 0; i < 4; i++)
        {
            int newNum = num;
            int newCount = count;
            tempOperators = operators.ToArray();
            int n = int.Parse(tempOperators[i]);
            if (n > 0)
            {
                switch (i)
                {
                    case 0:
                        //Debug.Log(newNum + "+" + numbers[numCount - count]);
                        newNum += int.Parse(numbers[numCount - count]);
                        break;
                    case 1:
                        //Debug.Log(newNum + "-" + numbers[numCount - count]);
                        newNum -= int.Parse(numbers[numCount - count]);
                        break;
                    case 2:
                        //Debug.Log(newNum + "*" + numbers[numCount - count]);
                        newNum *= int.Parse(numbers[numCount - count]);
                        break;
                    case 3:
                        //Debug.Log(newNum + "/" + numbers[numCount - count]);
                        newNum /= int.Parse(numbers[numCount - count]);
                        break;
                }
                n -= 1;
                newCount -= 1;
                tempOperators[i] = n.ToString();
                operInput(numbers, tempOperators, newNum, newCount);
            }
            
        }
    }

    //처음 만들었던 함수 -> 불필요한 중복이 생겨서 기각
    static void operInput1(string[] numbers, List<int> operList, int num)
    {
        if (operList.Count == 0)
        {
            if (!answerList.Contains(num)) answerList.Add(num);
            return;
        }

        List<int> tempList = new List<int>();
        for (int i = 0; i < operList.Count; i++)
        {
            int newNum = num;
            switch (operList[i])
            {
                case 1:
                    Debug.Log(newNum + "+" + numbers[numCount - operList.Count]);
                    newNum += int.Parse(numbers[numCount - operList.Count]);
                    break;
                case 2:
                    Debug.Log(newNum + "-" + numbers[numCount - operList.Count]);
                    newNum -= int.Parse(numbers[numCount - operList.Count]);
                    break;
                case 3:
                    Debug.Log(newNum + "*" + numbers[numCount - operList.Count]);
                    newNum *= int.Parse(numbers[numCount - operList.Count]);
                    break;
                case 4:
                    Debug.Log(newNum + "/" + numbers[numCount - operList.Count]);
                    newNum /= int.Parse(numbers[numCount - operList.Count]);
                    break;
            }
            tempList = operList.ToList();
            tempList.RemoveAt(i);
            operInput1(numbers, tempList, newNum);
        }
    }
}
