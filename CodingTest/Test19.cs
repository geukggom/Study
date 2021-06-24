using System;
using System.Collections.Generic;

public class Test19  // : 기능개발
{
    /// <summary>
    /// 몇 개의 기능이 배포되는지를 return(배포될 때마다)
    /// </summary>
    /// <param name="progresses">먼저 배포되어야 하는 순서대로 작업의 진도가 적힌 정수 배열 progresses</param>
    /// <param name="speeds">각 작업의 개발 속도가 적힌 정수 배열 speeds</param>
    /// <returns></returns>
    public int[] solution(int[] progresses, int[] speeds)
    {
        List<int> days = new List<int>();
        List<int> answer = new List<int>();
        days.Add(returnDays(progresses[0], speeds[0]));
        answer.Add(1);
        for (int i = 1; i < progresses.Length; i++)
        {
            int a = returnDays(progresses[i], speeds[i]);
            if (a <= days[days.Count - 1]) answer[answer.Count - 1]++;
            else
            {
                days.Add(a);
                answer.Add(1);
            }
        }

        return answer.ToArray();
    }
    int returnDays(int progress, int speed)
    {
        int n = 0;
        while (true)
        {
            if (progress >= 100) break;
            progress += speed;
            n++;
        }
        return n;
    }
}
