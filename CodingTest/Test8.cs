using System;
using System.Collections.Generic;

public class Test8  // : 행렬 테두리 회전하기
{
    /// <summary>
    /// rows x columns 크기인 행렬이 있습니다. 행렬에는 1부터 rows x columns까지의 숫자가 한 줄씩 순서대로 적혀있습니다. 
    /// 이 행렬에서 직사각형 모양의 범위를 여러 번 선택해, 테두리 부분에 있는 숫자들을 시계방향으로 회전시키려 합니다.
    /// 그 회전에 의해 위치가 바뀐 숫자들 중 가장 작은 숫자들을 순서대로 배열에 담아 return 하도록 solution 함수를 완성해주세요.
    /// </summary>
    /// <param name="rows">행</param>
    /// <param name="columns">열</param>
    /// <param name="queries">회전 행렬 목록(row1,column1,row2,column2)</param>
    /// <returns></returns>
    public int[] solution(int rows, int columns, int[,] queries)
    {
        int[] answer = new int[queries.GetLength(0)];
        int[,] TestArray = new int[rows, columns];
        int columnNum = 0;
        int rowNum = 0;
        for (int i = 0; i < TestArray.Length; i++)
        {
            TestArray[rowNum, columnNum] = i + 1; //처음 행렬 설정
            columnNum++;
            if (columnNum == columns)
            {
                rowNum++;
                columnNum = 0;
            }
        }
        List<int> chosenArray = new List<int>();
        for (int i = 0; i < answer.Length; i++)
        {
            chosenArray.Clear();
            int TempArrayNum = 2 * (queries[i, 2] + queries[i, 3] - queries[i, 1] - queries[i, 0]);
            int Row = queries[i, 0] - 1;
            int Column = queries[i, 1] - 1;
            int rowCount = queries[i, 3] - queries[i, 1];
            int columnCount = queries[i, 2] - queries[i, 0];
            for (int j = 0; j < TempArrayNum; j++)
            {
                chosenArray.Add(TestArray[Row, Column]);
                if (j != 0) TestArray[Row, Column] = chosenArray[j - 1];
                if (j < rowCount) Column++;
                else if (j >= rowCount && j < (rowCount + columnCount)) Row++;
                else if (j >= (rowCount + columnCount) && j < (rowCount * 2 + columnCount)) Column--;
                else Row--;
            }
            TestArray[queries[i, 0] - 1, queries[i, 1] - 1] = chosenArray[TempArrayNum - 1];
            int leastNum = chosenArray[0];
            for (int k = 1; k < chosenArray.Count; k++)
            {
                if (chosenArray[k] < leastNum) leastNum = chosenArray[k];

            }
            answer[i] = leastNum;
        }
        return answer;
    }
}
