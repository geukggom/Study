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
        List<int> release = new List<int>();
        Queue<int> days = new Queue<int>();
        int day = 0;
        int nextDay = 0;
        for (int i = 0; i < progresses.Length; i++)
        {
            day = (100 - progresses[i]) / speeds[i];
            if ((100 - progresses[i]) % speeds[i] != 0) day++;
            days.Enqueue(day);
        }
        day = days.Dequeue();
        int dayCount = 1;
        while (days.Count != 0)
        {
            nextDay = days.Dequeue();
            if (day >= nextDay) dayCount++;
            else
            {
                day = nextDay;
                release.Add(dayCount);
                dayCount = 1;
            }
        }
        release.Add(dayCount);
        return release.ToArray();
    }
}
