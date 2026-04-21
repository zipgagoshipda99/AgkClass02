using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class ClassPractice : MonoBehaviour
{
    public class ArrayClass
    {
        

        

        public void SortedScores(int[] scores)
        {
            
            System.Array.Sort(scores);
            for (int i = 0; i < scores.Length; i++)
            {
                Debug.Log($"{i + 1} 번째 점수 : {scores[i]}");
            }
        }
    }

    public static class ArrayClassVer2
    {
        public static void sortAlgroithim(int [] sort)
        {

            for (int i = 0; i < sort.Length - 1; i++)
            {
                for (int j = 0; j < sort.Length - 1 - i; j++) 
                {
                    if (sort[j] > sort[j + 1])
                    {
                        int what = sort[j];
                        sort[j] = sort[j + 1];
                        sort[j + 1] = what;
                        
                    }
                }
            }
        }
    }
    void Start()
    {
        
        ArrayClass arrayClass = new ArrayClass(); // 클래스의 인스턴스 생성
        int [] cool = new int[5] { 80, 60, 67, 17, 99 };
            arrayClass.SortedScores(cool);
            ArrayClassVer2.sortAlgroithim(cool); //ArrayClassver2는 static이기 때문에 인스턴스 생성 없이 바로 사용 가능
            // static은 프로그램이 시작할때 메모리에 딱 하나만 만들어지고, 모두가 공유함. 그래서 인스턴스 생성 없이 바로 사용 가능하다'
            //클래스는 설계도고, 인스턴스는 설계도로 찍어낸 실제 물건(?)이라고 생각하면 됨. 그래서 클래스는 하나만 만들어지고, 인스턴스는 여러개 만들어질 수 있다.
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
