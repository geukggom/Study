using System;
using System.Collections.Generic;

public class Test9  // : 삼진법 뒤집기
{
    /// <summary>
    /// 자연수 n이 매개변수로 주어집니다. n을 3진법 상에서 앞뒤로 뒤집은 후, 이를 다시 10진법으로 표현한 수를 return 하도록 solution 함수를 완성해주세요.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int solution(int n)
    {
        List<int> List_Num = new List<int>();
        while (true)
        {
            List_Num.Add(n % 3);
            int newNum = n / 3;
            if (newNum == 0) break;
            else n = newNum;
        }
        int answer = 0;
        for (int i = 0; i < List_Num.Count; i++)
        {
            int a = 1;
            for (int j = 0; j < List_Num.Count - i - 1; j++) { a *= 3; }
            answer += List_Num[i] * a;
        }
        return answer;
    }
}
