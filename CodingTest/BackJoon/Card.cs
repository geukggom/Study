using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class Card : MonoBehaviour
{
    void Start()
    {
        Main();
    }

    static void Main()
    {
        //var count = int.Parse(Console.ReadLine());
        int count = 5;
        Dictionary<long, int> cardList = new Dictionary<long, int>();
        long num = 0;
        for (int i = 0; i < count; i++)
        {
            //num = long.Parse(Console.ReadLine());
            switch (i)
            {
                case 0: num = 1; break;
                case 1: num = 2; break;
                case 2: num = 1; break;
                case 3: num = 2; break;
                case 4: num = 2; break;
            }
            if (cardList.ContainsKey(num)) cardList[num] += 1;
            else cardList.Add(num, 1);
        }
        //var upCard = cardList.OrderBy(x => x.Value);
        var downCard = cardList.OrderByDescending(x => x.Value);
        bool is_first = true;
        long key = 0;
        int value = 0;
        foreach(var v in downCard)
        {
            if (is_first)
            {
                key = v.Key;
                value = v.Value;
            }
            else if (v.Value == value)
            {
                if (v.Key < key) key = v.Key; 
            }
            else break;
            is_first = false;
        }
        Debug.Log(key);
        Debug.Log(value);
    }
}
