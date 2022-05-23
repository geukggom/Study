using System;
using System.Collections.Generic;

public class Test21  // : 위장
{
    /// <summary>
    /// 매일 다른 옷을 조합
    /// </summary>
    /// <param name="clothes"></param>
    /// <returns></returns>
    public int solution(string[,] clothes)
    {
        List<string> clotheType = new List<string>();
        for (int i = 0; i < clothes.GetLength(0); i++)
        {
            clotheType.Add(clothes[i, 1]);
        }
        clotheType.Sort();
        List<int> clotheNum = new List<int>();
        string clothename = "";
        for (int i = 0; i < clotheType.Count; i++)
        {
            if (clothename != clotheType[i])
            {
                clotheNum.Add(1);
                clothename = clotheType[i];
            }
            else clotheNum[clotheNum.Count - 1]++;
        }
        int answer = 1;
        for (int i = 0; i < clotheNum.Count; i++)
        {
            answer *= (clotheNum[i] + 1);
        }
        return answer - 1;
    }

    //2022-05-23. 문제 재풀이!
    public static int solution(string[,] clothes)
    {
        int answer = 1;
        Dictionary<string, int> clothCount = new Dictionary<string, int>();
        for (int i = 0; i < clothes.GetLength(0); i++)
        {
            if (clothCount.ContainsKey(clothes[i, 1])) clothCount[clothes[i, 1]] += 1;
            else clothCount[clothes[i, 1]] = 1;
        }
        foreach (var a in clothCount)
        {
            answer *= (a.Value + 1);
        }
        return answer - 1;
    }
}
