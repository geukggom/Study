using System;

public class Test5  // : K번째 수
{
    public int[] solution(int[] array, int[,] commands)
    {
        int[] answer = new int[commands.GetLength(0)];
        int startIndex = 0;
        int endIndex = 0;
        int findIndex = 0;
        List<int> arrayToList = new List<int>();
        for (int i = 0; i < commands.GetLength(0); i++)
        {
            startIndex = commands[i, 0] - 1;
            endIndex = commands[i, 1] - 1;
            findIndex = commands[i, 2] - 1;
            arrayToList = array.ToList();
            arrayToList = arrayToList.GetRange(startIndex, endIndex - startIndex + 1);
            arrayToList.Sort();
            answer[i] = arrayToList[findIndex];
        }
        return answer;
    }
}
