using System;

public class Test18  // : 약수의 개수와 덧셈
{
    /// <summary>
    /// 두 정수 left와 right가 매개변수로 주어집니다. 
    /// left부터 right까지의 모든 수들 중에서, 약수의 개수가 짝수인 수는 더하고, 약수의 개수가 홀수인 수는 뺀 수를 return 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public int solution(int left, int right)
    {
        int answer = 0;
        for (int i = left; i <= right; i++)
        {
            answer += primate(i);
        }
        return answer;
    }
    int primate(int n)
    {
        int a = 0;
        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0) a++;
        }
        if (a % 2 == 0) return n;
        else return n * (-1);
    }
}
