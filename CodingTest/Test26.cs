using System;
using UnityEngine;

public class Test26 : MonoBehaviour
{
    public int solution2(string s) // 제일 깔끔했던 정답 예시 가져옴
    {
        string answer_string = s;
        answer_string = answer_string.Replace("zero", "0");
        answer_string = answer_string.Replace("one", "1");
        answer_string = answer_string.Replace("two", "2");
        answer_string = answer_string.Replace("three", "3");
        answer_string = answer_string.Replace("four", "4");
        answer_string = answer_string.Replace("five", "5");
        answer_string = answer_string.Replace("six", "6");
        answer_string = answer_string.Replace("seven", "7");
        answer_string = answer_string.Replace("eight", "8");
        answer_string = answer_string.Replace("nine", "9");
        return int.Parse(answer_string);
    }

    public int solution(string s)
    {

        char[] array_s = s.ToCharArray();
        string answer_num = "";
        string now_num = "";
        for (int i = 0; i < array_s.Length; i++)
        {
            int num = -1;
            if(int.TryParse(array_s[i].ToString(), out num)) answer_num += array_s[i].ToString();
            else
            {
                now_num += array_s[i].ToString();
                int n = num_maker(now_num);
                if (n != -1)
                {
                    answer_num += n;
                    now_num = "";
                }
            }
        }
        return int.Parse(answer_num);
    }

    public int num_maker(string s)
    {
        int num = -1;
        switch (s)
        {
            case "zero": num = 0; break;
            case "one": num = 1; break;
            case "two": num = 2; break;
            case "three": num = 3; break;
            case "four": num = 4; break;
            case "five": num = 5; break;
            case "six": num = 6; break;
            case "seven": num = 7; break;
            case "eight": num = 8; break;
            case "nine": num = 9; break;
        }
        return num;
    }
}
