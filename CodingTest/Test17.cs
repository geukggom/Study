using System;

public class Test17  // : 음양더하기
{
    /// <summary>
    /// 정수들의 절댓값을 차례대로 담은 정수 배열 absolutes와 이 정수들의 부호를 차례대로 담은 불리언 배열 signs
    /// </summary>
    /// <param name="absolutes"></param>
    /// <param name="signs"></param>
    /// <returns></returns>
    public int solution(int[] absolutes, bool[] signs)
    {
        int answer = 0;
        for (int i = 0; i < signs.Length; i++)
        {
            if (signs[i]) answer += absolutes[i];
            else answer += absolutes[i] * (-1);
        }
        return answer;
    }
}
