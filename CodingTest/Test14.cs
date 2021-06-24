using System;

public class Test14  // : 풍선 터뜨리기
{
    /// <summary>
    /// 인접한 두 풍선 중에서 번호가 더 작은 풍선을 터트리는 행위는 최대 1번만 할 수 있습니다. 
    /// 즉, 어떤 시점에서 인접한 두 풍선 중 번호가 더 작은 풍선을 터트렸다면, 그 이후에는 인접한 두 풍선을 고른 뒤 번호가 더 큰 풍선만을 터트릴 수 있습니다.
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public int solution(int[] a)
    {
        int answer = 2;
        int smallest = a[0];
        int smallestNum = 0;
        for (int i = 1; i < a.Length; i++)
        {
            if (smallest > a[i])
            {
                smallest = a[i];
                smallestNum = i;
            }
        }
        int left = a[0];
        int right = a[a.Length - 1];
        for (int i = a.Length - 2; i > smallestNum; i--)
        {
            if (right > a[i + 1]) right = a[i + 1];
            if (a[i] < right) answer++;
        }
        for (int i = 1; i < smallestNum; i++)
        {
            if (left > a[i - 1]) left = a[i - 1];
            if (a[i] < left) answer++;
        }
        if (smallestNum != 0 && smallestNum != a.Length - 1) answer++;
        return answer;
    }
}
