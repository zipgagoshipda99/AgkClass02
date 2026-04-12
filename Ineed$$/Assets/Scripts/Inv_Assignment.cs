using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
/*
배열 , 리스트 , 딕셔너리 복습
과제

딕셔너리를 사용하여 간단한 인벤토리 관리 프로그램을 작성하시오.

조건
Dictionary<string, int>를 사용하여 아이템 이름과 개수를 저장할 것
아이템을 최소 3종류 이상 등록할 것
아이템을 획득하면 개수가 1 증가하도록 만들 것
아이템을 사용하면 개수가 1 감소하도록 만들 것
존재하지 않는 아이템을 사용하려고 하면 안내 문장을 출력할 것
아이템 개수가 0이면 사용할 수 없도록 처리할 것 
반복문을 사용하여 현재 인벤토리 전체 목록을 출력할 것 
코드에 주석을 작성할 것
가장 많이 가진 아이템 출력하기
총 아이템 갯수 합계 출력하기
*/
public class Inv_Assignment : MonoBehaviour
{
    public Dictionary<string, int> 
    inv = new Dictionary<string, int>();
    string addedItem =  "dragonBlade"; 
    //추가 되는 아이템을 문자열 변수에 저장.
    string usedItem = "mythicBlade";
    //사용되는 아이템을 문자열 변수에 저장

    //  inv, addedItem, usedItem 변수는 Start() 밖에 선언 →  클래스 전체에서 접근 가능하도록 하기 위해
    // Start is called before the first frame update
    void Start()
    { //(str, int) format
        inv.Add("dragonBlade", 1); //딕셔너리에 Key-Value 쌍을 3개 추가.
        inv.Add("mythicBlade", 2);
        inv.Add("rareBlade", 4);
        Debug.Log("----------Your Inventory----------");
        foreach(KeyValuePair<string, int> sword in inv)
        //<Key, Value>
        {
            Debug.Log($"검: {sword.Key}, 재고: {sword.Value}"); /*
            foreach 문을 사용하여  을 사용하여 sword 이라는 변수에 inv 라는 딕셔너리에 있는 모든 Key-Value값Pair(쌍)을 돌게하고 하나씩 하니씩 돌때마다 sword.Key 와 sword.Value를 각각 프린트 하게 한다*/
            
        } 

        if (inv.ContainsKey("dragonBlade")) //조건문 if를 사용하여 inv 딕셔너리에 "dragonBlade"라는 키가 있는지 확인하는 부분 
        {
            inv["dragonBlade"]++; //"dragonBlade"라는 키가 있으면 dragonBlade의 value 값을 +1 증가(획득한거여서)
            Debug.Log($"아이템: {addedItem} 이 획득되어 인벤토리에 가지고 있는 재고 : {inv[addedItem]}");
            //위에 조건에  Debug.Log()함수로 아이템 이름과 +1 추가된 아이템 문자열을 저장한 변수에 value 값을 출력하도록 함
        }
            else //만약 "dragonBlade"라는 키가 inv 딕셔너리에 없으면 존재하지 않는 아이템이라고 표현
            {
            Debug.Log("존재하지 않는 아이템은 사용 불가능합니다");
            }
        if (inv.ContainsKey("mythicBlade") && inv[usedItem] >= 1) //조건문 if를 사용하여 inv 딕셔너리에 "mythicBlade" 라는 키가 있고  usedItem(문자열 변수)의 키 값이 1보다 같거나 큰지 확인하는 부분
        { // && = 두 조건 모두 true일 때만 실행 (AND 연산자)
          // 키가 존재하고, AND 개수가 1 이상일 때만 사용 가능
            inv["mythicBlade"]--;//만약 "mythicBlade"라는 키가 있으면 mythicBlade의 value 값을 -1 감소(사용되었던거니)
            Debug.Log($"아이템: {usedItem} 이 사용되었습니다(-1). 인벤토리에 가지고 있는 재고 : {inv[usedItem]}");
            //위에 조건에  Debug.Log()함수로 아이템 이름과 -1 감소된 아이템 문자열을 저장한 변수에 value 값을 출력하도록 함
        }
            else //만약 "mythicBlade"라는 키가 inv 딕셔너리에 없으면 존재하지 않는 아이템이라고 표현
            {
            Debug.Log("존재하지 않는 아이템은 사용 불가능 합니다"); 

            }
        int maxValue = 0; //inv 딕셔너리에서 가장 큰 Value값을 저장하는 변수.  
        // 0으로 초기화한 이유 -> inv딕셔너리의 모든 value는 0 이상이므로, 첫 번째 아이템이 무조건 maxValue보다 커서 자동으로 maxItem에 저장됨
        string maxItem = ""; // 제일 큰 값을 가진 key를 저장하는 변수 .
        

        foreach(KeyValuePair<string, int> item in inv) // foreach(KeyvaluePair<>)을 사용하여 item 이라는 변수에 inv 라는 딕셔너리에 있는 모든 Key-Value값Pair(쌍)을 돌아서
        {
            if (item.Value > maxValue) //item에 현재 저장된 딕셔너리에 value값이 maxvalue 변수값 보다 클때
            {
                maxValue = item.Value;// maxValue변수값을  item.Value와 같도록 지정하고
                maxItem = item.Key;//maxItem 문자열을 저장한 변수를 item.Key와 같도록 지정.
            }
        } //foreach 끝
        Debug.Log($"당신이 가장 많이 가지고 있는 아이템: ({maxItem}, {inv[maxItem]})"); // 사용자가 가장 많이 가지고 있는 아이템을 포문 바깥에 프린트(foreach)문에 있으면 계속 프린트해서!!

        int totalalladdedItem = 0;
        
        foreach(KeyValuePair<string, int> allItems in inv)
        {
            totalalladdedItem += allItems.Value; //totalalladdedItem = totalalladdedItem + allItems.Value

        }
        Debug.Log($"총 아이템 갯수: {totalalladdedItem}");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
