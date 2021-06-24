using System;
using System.Collections.Generic;

public class Test16   // : 타겟넘버
{
    /// <summary>
    /// 타겟 넘버
    /// </summary>
    /// <param name="numbers">사용할 수 있는 숫자가 담긴 배열</param>
    /// <param name="target">만들어야 하는 숫자</param>
    /// <returns></returns>
    public int solution(int[] numbers, int target)
    {
        Calculate(-1, 0, numbers);
        int count = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            count *= 2;
        }
        while (true)
        {
            if (numList.Count == count) break;
        }
        int answer = 0;
        for (int i = 0; i < numList.Count; i++)
        {
            if (numList[i] == target) answer++;
        }
        return answer;
    }
    public List<int> numList = new List<int>();
    void Calculate(int repeatCount, int num, int[] numbers)
    {
        repeatCount++;
        if (repeatCount == numbers.Length)
        {
            numList.Add(num);
            return;
        }
        Calculate(repeatCount, num + PlusMinus(numbers[repeatCount], true), numbers);
        Calculate(repeatCount, num + PlusMinus(numbers[repeatCount], false), numbers);
    }
    int PlusMinus(int num, bool is_true)
    {
        if (is_true) return num;
        else return (-1) * num;
    }
}
