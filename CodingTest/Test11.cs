using System;
using System.Collections.Generic;

public class Test11  // : 삼각달팽이
{
    /// <summary>
    /// 정수 n이 매개변수로 주어집니다. 
    /// 밑변의 길이와 높이가 n인 삼각형에서 맨 위 꼭짓점부터 반시계 방향으로 달팽이 채우기를 진행한 후, 
    /// 첫 행부터 마지막 행까지 모두 순서대로 합친 새로운 배열을 return 하도록 solution 함수를 완성해주세요.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int[] solution(int n)
    {
        int[,] indexNum = new int[n, n];
        int row = -1;
        int column = 0;
        int num2 = 1;

        for (int i = 0; i < n; i++)
        {
            int replayNum = n - i;
            for (int k = 0; k < replayNum; k++)
            {
                if (i % 3 == 0) row += 1;
                else if (i % 3 == 1) column += 1;
                else
                {
                    column -= 1;
                    row -= 1;
                }
                indexNum[row, column] = num2;
                num2++;
            }
        }
        List<int> answer = new List<int>();
        for (int i = 0; i < n; i++)
        {
            for (int k = 0; k < n; k++)
            {
                if (indexNum[i, k] != 0) answer.Add(indexNum[i, k]);
            }
        }
        return answer.ToArray();
    }
}
