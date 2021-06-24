using System;
using System.Collections.Generic;

public class Test15  // : 소수찾기
{
    public int solution(string numbers)
    {
        char[] numberArray = numbers.ToCharArray();
        List<int> numberList = new List<int>();
        List<int> indexList = new List<int>();
        for (int i = 0; i < numberArray.Length; i++)
        {
            numberList.Add(numberArray[i] - '0');
        }
        for (int i = 1; i <= numberArray.Length; i++)  //몇글자인지
        {
            plusNum(i, numberList, indexList, "");
        }
        int answer = 0;
        for (int i = 0; i < answerlist.Count; i++)
        {
            if (is_prime(answerlist[i])) answer++;
        }
        return answer;
    }
    public List<int> answerlist = new List<int>();
    void plusNum(int stringNum, List<int> numberList, List<int> indexList, string makeNum)
    {
        string tempmakeNum = makeNum;
        for (int i = 0; i < numberList.Count; i++)
        {
            if (!indexList.Contains(i))
            {
                makeNum = tempmakeNum + numberList[i].ToString();
                indexList.Add(i);
                int n = int.Parse(makeNum);
                if (stringNum == makeNum.Length && !answerlist.Contains(n)) answerlist.Add(n);
                else if (stringNum != makeNum.Length) plusNum(stringNum, numberList, indexList, makeNum);
                indexList.RemoveAt(indexList.Count - 1);
            }

        }
    }
    bool is_prime(int num)
    {
        if (num < 2) return false;
        bool is_true = true;
        for (int i = 2; i <= num / 2; i++)
        {
            if (num % i == 0) is_true = false;
        }
        return is_true;
    }
}
