using System.Collections.Generic;
using System;
using System.Linq;

public class Test25 
{
    public string solution(string[] table, string[] languages, int[] preference)
    {
        List<string> JobName = new List<string>();
        List<int> JobScore = new List<int>();
        for (int i = 0; i < table.Length; i++)
        {
            string[] table2 = table[i].Split(' ');
            List<string> TrimedTable = new List<string>();
            for (int j = 0; j < table2.Length; j++)
            {
                table2[j].Trim();
                TrimedTable.Add(table2[j]);
            }
            JobName.Add(table2[0]);
            JobScore.Add(0);
            for (int j = 0; j < languages.Length; j++)
            {
                for (int k = 0; k < table2.Length; k++)
                {
                    if (table2[k] == languages[j]) JobScore[i] += (6 - k) * preference[j];
                }
            }
        }
        List<int> ScoreSort = JobScore.ToList();
        ScoreSort.Sort();
        int bestScore = ScoreSort[ScoreSort.Count - 1];
        List<string> BestScoreJob = new List<string>();
        for (int i = 0; i < JobScore.Count; i++)
        {
            if (JobScore[i] == bestScore) BestScoreJob.Add(JobName[i]);
        }
        BestScoreJob.Sort();
        string answer = BestScoreJob[0];
        return answer;
    }
}
