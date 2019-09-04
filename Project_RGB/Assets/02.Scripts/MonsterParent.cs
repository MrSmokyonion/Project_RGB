using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterParent : MonoBehaviour
{
    //몬스터 고유번호.
    public enum MonsterCode
    {
        //Walk Monster 100~199
        WALK_MONSTER_1 = 100, WALK_MONSTER_2, WALK_MONSTER_3,

        //Fly Monster 200~299
        FLY_MONSTER_1 = 200, FLY_MONSTER_2, FLY_MONSTER_3,

        //Boss Monster 300~399
        BOSS_1 = 300, BOSS_2, BOSS_3
    }

    //몬스터 상태.
    public enum MonsterState
    {
        IDLE,       //대기
        MOVE,       //이동
        ATTACK,     //공격
        JUMP,       //점프
        ATTACKED,   //피격
        DEAD        //죽음
    }

    public bool isBoss;                 //등급 (보스인지 판단)
    public string monsterName;          //이름
    public MonsterCode monsterCode;     //고유코드 (Inspector)
    public MonsterState monsterState;   //상태 (Inspector)

    public int monsterDamege;           //공격력
    public int monsterDefense;          //방어력
    public int monsterHp;               //체력
    public int monsterSpeed;            //이동속도

    public int monsterDropGoldAmount;   //드랍 골드량
    public int monsterDropRate;         //드랍률
    public GameObject DropGoldObject;   //드랍 골드 오브젝트 (Inspector)
    //public GameObject monsterDropItem;//드랍 아이템  (장비, 스킬, 아이템) ????

    public Animator monsterAnimator;    //애니메이터

    void Start()
    {
        monsterAnimator = GetComponent<Animator>();
        MonsterInfoUpdateWithCode();
    }

    void MonsterInfoUpdateWithCode()
    {
        switch (monsterCode)
        {                           //등급, 이름, 상태, 공격력, 방어력, 체력, 이동속도, 드랍골드량, 드랍률

            //---------------------------------- Walk Monsters ----------------------------------
            case MonsterCode.WALK_MONSTER_1:
                MonsterInfoUpdate(false, "작은 꽃", MonsterState.IDLE, 10, 10, 100, 100, 100, 0); break;
            case MonsterCode.WALK_MONSTER_2:
                MonsterInfoUpdate(false, "화난 돌", MonsterState.IDLE, 10, 10, 100, 100, 100, 0); break;
            case MonsterCode.WALK_MONSTER_3:
                MonsterInfoUpdate(false, "부끄럼 나무", MonsterState.IDLE, 10, 10, 100, 100, 100, 0); break;



            //---------------------------------- Fly  Monsters ----------------------------------
            case MonsterCode.FLY_MONSTER_1:
                MonsterInfoUpdate(false, "박쥐", MonsterState.IDLE, 10, 10, 100, 100, 100, 0); break;


            //---------------------------------- Boss Monsters ----------------------------------
            case MonsterCode.BOSS_1:
                MonsterInfoUpdate(false, "숲의 여왕", MonsterState.IDLE, 10, 10, 100, 100, 100, 0); break;

        }
    }

    void MonsterInfoUpdate(bool isboss, string name, MonsterState state,
                           int damege, int defense, int hp, int speed,
                           int goldamount, int droprate)
    {
        isBoss = isboss;
        monsterName = name;
        monsterState = state;
        monsterDamege = damege;
        monsterDefense = defense;
        monsterHp = hp;
        monsterSpeed = speed;
        monsterDropGoldAmount = goldamount;
        monsterDropRate = droprate;
    }

    void Update()
    {

    }
}
