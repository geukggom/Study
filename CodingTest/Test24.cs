using System;
using System.Linq;
using System.Collections.Generic;

public class Test24 //2주차
{
    public class Solution
    {
        public string solution(int[,] scores)
        {
            int studentCount = scores.GetLength(0);
            string[] answer = new string[studentCount];
            for (int i = 0; i < studentCount; i++)
            {
                List<int> Scores = new List<int>();
                for (int j = 0; j < studentCount; j++)
                {
                    Scores.Add(scores[j, i]);
                }
                List<int> newScores = Scores.ToList();
                newScores.Sort();
                int myScore = scores[i, i];
                if ((newScores[0] == myScore && newScores[1] != myScore)) Scores.RemoveAt(i);
                else if (newScores[studentCount - 1] == myScore && newScores[studentCount - 2] != myScore) Scores.RemoveAt(i);
                myScore = (int)Scores.Average();
                if (myScore >= 90) answer[i] = "A";
                else if (myScore >= 80) answer[i] = "B";
                else if (myScore >= 70) answer[i] = "C";
                else if (myScore >= 50) answer[i] = "D";
                else answer[i] = "F";
            }
            return string.Join("", answer);
        }
    }
}
