using System;
using System.Collections.Generic;
using System.Linq;

public class Test20  // : 게임 맵 최단거리
{
    /// <summary>
    /// 게임 맵 최단거리 찾기
    /// </summary>
    /// <param name="maps">게임 맵 상태 배열</param>
    /// <returns></returns>
    public int solution(int[,] maps)
    {
        mapRow = maps.GetLength(0);
        mapColumn = maps.GetLength(1);
        int maxN = mapRow * mapColumn;
        if (maxN == 2) return maxN;
        int answer = 0;
        int distance = 1;
        rowNum.Clear();
        columnNum.Clear();
        Changemaps(mapRow - 1, mapColumn - 1, maps, distance);
        for (int i = 2; i < maxN; i++)
        {
            if (rowNum.Count == 0)
            {
                answer = -1;
                i = maxN;
            }
            else
            {
                int n = rowNum.Count;
                for (int k = n - 1; k >= 0; k--)
                {
                    if (rowNum[k] > 0 && maps[rowNum[k] - 1, columnNum[k]] == 1) Changemaps(rowNum[k] - 1, columnNum[k], maps, i);
                    if (rowNum[k] < mapRow - 1 && maps[rowNum[k] + 1, columnNum[k]] == 1) Changemaps(rowNum[k] + 1, columnNum[k], maps, i);
                    if (columnNum[k] > 0 && maps[rowNum[k], columnNum[k] - 1] == 1) Changemaps(rowNum[k], columnNum[k] - 1, maps, i);
                    if (columnNum[k] < mapColumn - 1 && maps[rowNum[k], columnNum[k] + 1] == 1) Changemaps(rowNum[k], columnNum[k] + 1, maps, i);
                    rowNum.RemoveAt(k);
                    columnNum.RemoveAt(k);
                }
                for (int j = 0; j < rowNum.Count; j++)
                {
                    if ((rowNum[j] == 0 && columnNum[j] == 1) || (rowNum[j] == 1 && columnNum[j] == 0))
                    {
                        answer = i + 1;
                        j = rowNum.Count - 1;
                        i = maxN - 1;
                    }
                }
            }
        }
        if (answer == 0) answer = -1;
        return answer;
    }
    public int mapRow;
    public int mapColumn;
    List<int> rowNum = new List<int>();
    List<int> columnNum = new List<int>();
    void Changemaps(int row, int column, int[,] maps, int N)
    {
        maps[row, column] = N;
        rowNum.Add(row);
        columnNum.Add(column);
    }
}
