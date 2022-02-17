using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

namespace bj

{
    public class Student : IComparable
    {
        public string name;
        public int korean, english, math;

        public int CompareTo(object obj)
        {
            Student other = obj as Student;
            if (korean != other.korean) return other.korean - korean; //내림차순
            if (english != other.english) return english - other.english; //오름차순
            if (math != other.math) return other.math - math; //내림차순
            return name.CompareTo(other.name); //이름끼리 비교
        }
    }
    public class Score : MonoBehaviour
    {
        static List<Student> stdList = new List<Student>();
        static StringBuilder sb = new StringBuilder();

        static void Main()
        {
            var stdCount = Console.ReadLine();
            for (int i = 0; i < int.Parse(stdCount); i++)
            {
                var stdInfo = Console.ReadLine();
                string[] stdInfoArr = stdInfo.Split(' ');
                Student std = new Student();
                std.name = stdInfoArr[0];
                std.korean = int.Parse(stdInfoArr[1]);
                std.english = int.Parse(stdInfoArr[2]);
                std.math = int.Parse(stdInfoArr[3]);
                stdList.Add(std);
            }
            stdList.Sort();
            for (int i = 0; i < int.Parse(stdCount); i++)
            {
                sb.Append(stdList[i].name).Append("\n");
            }
            Console.WriteLine(sb);
        }
    }
}
