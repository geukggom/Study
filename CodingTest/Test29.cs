using System;

public class Test29
{
    public static int solution(int bridge_length, int weight, int[] truck_weights)
    {
        int weightSum = 0;
        int time = 0;
        int nextIndex = 0;
        int startIndex = 0;
        int[] truck_times = new int[truck_weights.Length];
        while (true)
        {
            for (int i = startIndex; i < nextIndex; i++)
            {
                truck_times[i]++;
                if (truck_times[i] >= bridge_length)
                {
                    weightSum -= truck_weights[startIndex];
                    Console.WriteLine("차나간다" + truck_weights[startIndex]);
                    startIndex++;
                }
            }
            if (nextIndex < truck_weights.Length && weightSum + truck_weights[nextIndex] <= weight)
            {
                weightSum += truck_weights[nextIndex];
                Console.WriteLine("차들어온다" + truck_weights[nextIndex]);
                nextIndex += 1;
            }
            Console.WriteLine(time + ":" + startIndex + "~" + nextIndex);
            time++;
            if (startIndex >= truck_weights.Length) break;
        }
        Console.WriteLine(time + "초");
        return time;
    }
}
