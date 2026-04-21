using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class BattleManager : MonoBehaviour

{
    public class Character
    {
        // 클래스 내부에 있는 변수 == 필드(field)
        public string name;
        public int health;
        public int attackPower;

        public  bool isAlive = true;

        public void takeDamage(int attackPower)
        {
            health = health - attackPower;
            if (health < 0)
            {
                    isAlive = false;
                }
        }
        public void Attack(Character target)
        //                 ↑ 여기서 받은 값을 target이라는 이름으로 사용
        {
            target.takeDamage(attackPower);
        }
        public void aliveorDead()
        {
            if (isAlive == true && health > 0)
            {
                Debug.Log($"{name}, 상태 : 생존중");
            }
            else
            {
                Debug.Log($"{name}, 상태 : DEAD RIP.");
                
            }
        }

    }
    public class Player : Character //똑같은 코드를 여러번 쓰지 않기 위해서 Charcter Class 상속
    {
        public Dictionary<string, int> inv = new Dictionary<string, int>();
        public void usePotion()
        {
            if (inv.ContainsKey("healthPotion") && inv["healthPotion"] > 0)
            {
                health = health +20;
                inv["healthPotion"] = inv["healthPotion"] - 1;
                Debug.Log("체력 회복 포션 사용함.");
            }

        }

    }

    public class Enemy : Character
    {
        public class Slime : Enemy
        {
            public Slime() //생성자
            {
                name = "슬라임";
                health = 30;
                attackPower = 5;
            }
        }
        public class Goblin : Enemy
        {
            public Goblin() //생성자
            {
                name = "고블린";
                health = 50;
                attackPower = 8;
            }
        }
    }
    public class battleManager
    {
        public Player player = new Player();
        public List<Enemy> enemyList = new List<Enemy>();
        
        public void battleScript()
        {
            //1. Player 객체 생성 파트 potion & character 객체 생성 파트 name health attackPower etc
            player.name = "Arnold Swarzenegger";
            player.health = 100;
            player.attackPower = 10;
            player.inv.Add("healthPotion", 1);
            //2. Enemy 객체 생성 후 enemyList에 추가 (슬라임, 고블린)
            enemyList.Add(new Enemy.Slime());  // 호출하는 순간 이미 체력 30, 이름 "슬라임" 공격력 5인 슬라임이 만들어짐
            enemyList.Add(new Enemy.Goblin());
            //3. 전투 메시지 출력
            Debug.Log($"플레이어 {player.name}(님)이 전투에 참여.");
            Debug.Log($"----FIGHT----");
            //4. Player가 첫번째 적인 Slime을 공격
            player.Attack(enemyList[0]);
            Debug.Log($"플레이어 {player.name}(님)이 {enemyList[0].name}을 공격.");
            //5. Slime이 Player를 공격
            Debug.Log($"{enemyList[0].name}이 {player.attackPower}의 피해를 입힘.");
            //6. 첫번째 적인 Slime의 hp 출력
            Debug.Log($"{enemyList[0].name}의 남은 체력 : {enemyList[0].health}");
            
            
            //7.player가 포션 사용
            player.usePotion();
            //8. Player의 포션 개수와 hp 출력
            Debug.Log($"플레이어 {player.name}(님)이 포션을 사용하여 체력을 회복 +20. 남은 포션 개수 : {player.inv["healthPotion"]}");
            Debug.Log($"플레이어 {player.name}(님)의 남은 체력 : {player.health}");
        }
    }
    // Start is called before the first frame update
    
    void Start()
    {
        battleManager Manager = new battleManager();
        Character charc = new Character();
        Manager.battleScript();
        Manager.player.aliveorDead();

    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
