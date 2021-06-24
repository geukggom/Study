using System;
using System.Collections.Generic;

public class Test10  // : 두 개 뽑아서 더하기
{
    /// <summary>
    /// 정수 배열 numbers가 주어집니다. 
    /// numbers에서 서로 다른 인덱스에 있는 두 개의 수를 뽑아 더해서 만들 수 있는 모든 수를 배열에 오름차순으로 담아 
    /// return 하도록 solution 함수를 완성해주세요.
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public int[] solution(int[] numbers)
    {
        List<int> answerNum = new List<int>();
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < numbers.Length; j++)
            {
                if (j > i)
                {
                    int plusNum = numbers[i] + numbers[j];
                    bool is_same = false;
                    for (int k = 0; k < answerNum.Count; k++)
                    {
                        if (plusNum == answerNum[k]) is_same = true;
                    }
                    if (!is_same) answerNum.Add(plusNum);
                }
            }
        }
        for (int i = 1; i < answerNum.Count; i++)
        {
            if (answerNum[i] < answerNum[i - 1])
            {
                int temp = answerNum[i];
                answerNum[i] = answerNum[i - 1];
                answerNum[i - 1] = temp;
                i = 0;
            }
        }
        return answerNum.ToArray();
    }
    public int[] solution10Again(int[] numbers)
    {
        List<int> answerNum = new List<int>();
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                int plusNum = numbers[i] + numbers[j];
                if (answerNum.Contains(plusNum)) answerNum.Add(plusNum);
            }
        }
        answerNum.Sort();
        return answerNum.ToArray();
    }
}
