using System;

public class Test5  // : K번째 수
{
    /// <summary>
    /// 배열 array의 i번째 숫자부터 j번째 숫자까지 자르고 정렬했을 때, k번째에 있는 수를 구하려 합니다.
    /// 예를 들어 array가[1, 5, 2, 6, 3, 7, 4], i = 2, j = 5, k = 3이라면 array의 2번째부터 5번째까지 자르면[5, 2, 6, 3]입니다.
    /// 1에서 나온 배열을 정렬하면[2, 3, 5, 6]입니다.
    /// 2에서 나온 배열의 3번째 숫자는 5입니다.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="commands"></param>
    /// <returns></returns>
    public int[] solution(int[] array, int[,] commands)
    {
        int[] answer = new int[commands.Length / 3];
        for (int a = 0; a < commands.Length / 3; a++)
        {
            int ArrayLength = commands[a, 1] - commands[a, 0] + 1;
            int[] ArrayNew = new int[ArrayLength];
            int NewIndex = commands[a, 0] - 1;
            for (int i = 0; i < ArrayNew.Length; i++)
            {
                ArrayNew[i] = array[NewIndex + i];
            }
            for (int i = 0; i < ArrayNew.Length - 1; i++)
            {
                if (ArrayNew[i + 1] < ArrayNew[i])
                {
                    int temp = ArrayNew[i + 1];
                    ArrayNew[i + 1] = ArrayNew[i];
                    ArrayNew[i] = temp;
                    i = -1;
                }
            }
            answer[a] = ArrayNew[commands[a, 2] - 1];
        }
        return answer;
    }
}
