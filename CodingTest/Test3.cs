using System;

public class Test3  // : 로또 최고순위와 최저순위
{
    /// <summary>
    /// 민우의 동생이 로또에 낙서를 하여, 일부 번호를 알아볼 수 없게 되었습니다. 
    /// 당첨 번호 발표 후, 민우는 자신이 구매했던 로또로 당첨이 가능했던 최고 순위와 최저 순위를 알아보고 싶어 졌습니다.
    /// 알아볼 수 없는 번호를 0으로 표기.
    /// 순서와 상관없이, 구매한 로또에 당첨 번호와 일치하는 번호가 있으면 맞힌 걸로 인정됩니다.
    /// 알아볼 수 없는 두 개의 번호를 각각 10, 6이라고 가정하면 3등에 당첨될 수 있습니다.
    /// 3등을 만드는 다른 방법들도 존재합니다. 하지만, 2등 이상으로 만드는 것은 불가능합니다.
    /// 알아볼 수 없는 두 개의 번호를 각각 11, 7이라고 가정하면 5등에 당첨될 수 있습니다.
    /// 5등을 만드는 다른 방법들도 존재합니다. 하지만, 6등(낙첨) 으로 만드는 것은 불가능합니다.
    /// </summary>
    /// <param name="lottos">민우가 산 로또(0이상 45이하)</param>
    /// <param name="win_nums">당첨 로또 번호(1이상 45이하)</param>
    /// <returns></returns>
    public int[] solution3(int[] lottos, int[] win_nums)
    {
        int[] answer = new int[2];
        int zeroNum = 0;
        int winNum = 0;
        for (int i = 0; i < lottos.Length; i++)
        {
            if (lottos[i] == 0) zeroNum++;
            else
            {
                for (int j = 0; j < win_nums.Length; j++)
                {
                    if (lottos[i] == win_nums[j]) winNum++;
                }
            }
        }
        for (int i = 0; i < answer.Length; i++)
        {
            int rank = 0;
            if (i == 0) rank = winNum + zeroNum;
            else rank = winNum;
            if (rank < 2) answer[i] = 6;
            else answer[i] = 7 - 1;
        }
        return answer;
    }
}
