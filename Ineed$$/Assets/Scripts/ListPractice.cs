using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ListPractice : MonoBehaviour
{
    [SerializeField] private List<string> inventory = new List<string>();
    //<- private 변수를 유니티가 저장/불러오기(직렬화) 가능한 상태로 만들어, inspector에 노출시키는 역할
    // Start is called before the first frame update

    public string checkStr = string.Empty;
    void Start()
    {
        inventory.Add("포션");
        inventory.Add("검");
        inventory.Add("방패");
        Debug.Log("아이템 3개를 추가함");

        //현재 인벤토리 출력
        for (int i = 0; i < inventory.Count; i++)
        {
            Debug.Log($"{i + 1}번째 아이템 : {inventory[i]}");
        }
        inventory.Remove("포션");
        //inventory.RemoveAt(0); //해당함수 inventory.Remove()를 사용하면 [0] 번째였던 포션이 없어지고 검, 방패가 앞으로 땡겨짐
        Debug.Log("포션을 사용해서 제거했습니다");

        //삭제 후 인벤토리 목록 호출 //
        for (int i = 0; i < inventory.Count; i++)
        {
            Debug.Log($"{i + 1}번째 아이템 : {inventory[i]}");
        }

        if (inventory.Contains(checkStr))
        {
            Debug.Log($"{checkStr}이 있습니다");
        }
        else
        {
            Debug.Log($"{checkStr}이 없습니다");
        }
      

        // Update is called once per frame
        //    void Update()
        //{
    }

}
