using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DictionaryPractice : MonoBehaviour
{
    //왼쪽이 키고, 오른쪽이 값이다
    //키와 값의 자료형엔 제한이 없다
    public Dictionary<string, int> library = new Dictionary<string, int>();
    //library 라는 딕셔너리를 새로 추가함
    // Start is called before the first frame update
    void Start()
    { //딕셔너리 값 추가 (딕셔너리 이름.Add(키, 값))
        library.Add("해리포터", 1);
        library.Add("원피스", 2);
        library.Add("원더", 3);
        library.Add("어린왕자", 6);
        

        // 딕셔너리 값 변경 -- (딕션너리이름[키] = 변경할 값 -- 구조
        
        //library["해리포터"] = 2;

        // 처음부터 끝까지 돌게 하는 딕션네리에 포함한 함수
        // 구조 --> for each(데이터타입, 변수명 in 컬렉션
        foreach (KeyValuePair<string, int> book in library)
        // 딕션네리 구조 Dictionary<string, int>를 맞춰줘야함
        {
            //Debug.Log("책 제목: " + book.Key + "재고" + book.Value);
            Debug.Log($"책제목: {book.Key}" + $"재고: {book.Value}");
        }
        if (library.ContainsKey("해리포터"))
        {
            Debug.Log("해리포터의 현재 재고" + library["해리포터"]);
            //Key를 print하면 value가 나오는 구조
        }
        library["해리포터"]++;
        //해리포터 딕션네리 key 값이 1 증가
        //("해리포터", 2)

        //책을 대출 & 반납 만들기
        // 빌릴 & 반납할 책 변수를 선언하고 책의 재고가 1권이상 있어야지 대출할수 잇습니다.
        string bookLoan = "해리포터";
        string bookReturn = "원피스";
        //2 조건식이 둘다 true 일때 && 쓰삼
        if (library.ContainsKey(bookLoan) && library[bookLoan] >= 1)
        {
                Debug.Log($"{bookLoan} - > 대출 가능한 책입니다");
                
        }
        else
        {
            Debug.Log("대출 불가능한 책입니다");
        }
        if (library.ContainsKey(bookReturn))
        {
            library[bookReturn] += 1; //library[bookReturn] = library[bookReturn] + 1;  (&  library[bookReturn]++;) 이것도 가능
            Debug.Log($"책 : {bookReturn} 반납완료");
        }
        else
        {
            Debug.Log("반납 불가능합니다.");
        }
        //int[] arr = new int[3];
        //foreach (int i in arr)
    }

    // Update is called once per frame
//   void Update()
//    {
        
//    }
}
