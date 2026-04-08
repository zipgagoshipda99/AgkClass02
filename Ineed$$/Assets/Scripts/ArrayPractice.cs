using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayPractice : MonoBehaviour
{   //점수 5개를 저장할 int 형 배열(array) 생성
    public int[] scores = new int[5];
    


    // Start is called before the first frame update
    void Start()
    {   //배열의 각 칸에 점수 넣기 0~4
        scores[0] = 60;
        scores[1] = 70;
        scores[2] = 67;
        scores[3] = 77;
        scores[4] = 99;

        // array -> class 같은 느낌 얘 안에 Length가 선언되어있는거야

        //총합을 저장할 int형 변수
        int sum = 0;
        //최고 점수를 저장할 int형 변수
        int maxScore = 0;
        int average = 0;
        Debug.Log("배열(Array) 실습");
        //for (변수 선언, 조건, 증감식 ++ or --)
        for (int i = 0; i < scores.Length; i++)
                            //scores. Length 는 5
                            // 0부터 4번째까지 실행
        {
            Debug.Log($"{i + 1} 번째 점수 : {scores[i]}");

            //총합에 현재 점수 더하기
            sum += scores[i]; //sum = sum + scores[i]
            if (scores[i] > maxScore)
            {
                maxScore = scores[i];
            }
            
        }
        average =  sum / scores.Length;
        float avrg = (float)sum / scores.Length; 
        Debug.Log("총합: " + sum);
        Debug.Log("최고점수: " + maxScore);
        Debug.Log("평균: " + average + "float ver: " + avrg);

        //  when adding a  comma  it tells C# that the first message is finished and you are starting a second,
        //  totally different piece of information the debug.log function only wants one part
        // In programming, commas are like separators used to hand over a list of items to a function.

        //def add(self, a)

        // 더하기(int i, int e) { }
        // Log(string i)

    }

    // Update is called once per frame
}
