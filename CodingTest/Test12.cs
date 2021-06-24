using System;
using System.Collections.Generic;

public class Test12  // : 이진 변환 반복하기
{
    /// <summary>
    /// 0과 1로 이루어진 어떤 문자열 x에 대한 이진 변환을 다음과 같이 정의합니다.
    /// x의 모든 0을 제거합니다.
    /// x의 길이를 c라고 하면, x를 "c를 2진법으로 표현한 문자열"로 바꿉니다.
    /// </summary>
    /// <param name="s">문자 길이</param>
    /// <returns>[이진 변환의 횟수, 변환 과정에서 제거된 모든 0의 개수]</returns>
    public int[] solution(string s)
    {
        int[] answer = new int[2];
        string newS = s;
        while (true)
        {
            answer[0]++;
            char[] chars = newS.ToCharArray();
            int num1 = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '0') answer[1]++;
                else num1++;
            }
            int a = num1;
            List<int> list1 = new List<int>();
            while (true)
            {
                list1.Add(a % 2);
                if (a / 2 == 0) break;
                else a = a / 2;
            }
            newS = "";
            for (int i = list1.Count - 1; i > -1; i--) { newS += list1[i].ToString(); }
            if (newS == "1") break;
        }
        return answer;
    }
}
