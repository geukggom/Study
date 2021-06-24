using System;

public class Test23  // : 카펫
{
    public int[] solution(int brown, int yellow)
    {
        int[] answer = new int[2];
        int n = brown + yellow;
        for (int i = 3; i < brown; i++)
        {
            int a = i;
            if (n % a == 0)
            {
                int b = n / a;
                if (a + b == brown / 2 + 2)
                {
                    answer[1] = a;
                    i = brown - 1;
                }
            }
        }
        answer[0] = n / answer[1];
        return answer;
    }
}
