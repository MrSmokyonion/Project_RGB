using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Monster ENUM

//몬스터 고유번호.
public enum MonsterCode
{
    //부모는 그저 상속될 뿐. (존재는 해야함.)
    PARENT,

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

#endregion

#region Monster Info DataBase

public class MonsterInfo
{

    //생성자
    public MonsterInfo(MonsterCode code, bool isb, string name, MonsterState state,
                           int damege, int defense, int hp, int speed,
                           int goldamount, int droprate, GameObject dropitem)
    {
        monsterCode = code;
        isBoss = isb;
        monsterName = name;
        monsterState = state;

        monsterDamege = damege;
        monsterDefense = defense;
        monsterHp = hp;
        monsterSpeed = speed;

        monsterDropGoldAmount = goldamount;
        monsterDropRate = droprate;
        monsterDropItem = dropitem;
    }

    public MonsterCode monsterCode;     //고유코드
    public bool isBoss;                 //등급 (보스인지 판단)
    public string monsterName;          //이름
    public MonsterState monsterState;   //상태

    public int monsterDamege;           //공격력
    public int monsterDefense;          //방어력
    public int monsterHp;               //체력
    public int monsterSpeed;            //이동속도

    public int monsterDropGoldAmount;   //드랍 골드량
    public int monsterDropRate;         //드랍률
    public GameObject monsterDropItem;  //드랍 아이템  (장비, 스킬, 아이템) ????
}

public class MonsterInfoList
{
    List<MonsterInfo> monsterInfoList = new List<MonsterInfo>();

    public MonsterInfoList()
    {
        // 몬스터 코드, 등급, 이름, 상태, 공격력, 방어력, 체력, 이동속도, 드랍골드량, 드랍률, 드롭 아이템
        //?????????아이템에도 몬스터 코드가 있어야하나? 아니면 몬스터가 아이템 코드를 가지고 있어야하나?

        monsterInfoList.Add(new MonsterInfo(MonsterCode.WALK_MONSTER_1, false, "작은 꽃", MonsterState.IDLE, 10, 10, 100, 100, 100, 0, null));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.WALK_MONSTER_2, false, "화난 돌", MonsterState.IDLE, 10, 10, 100, 100, 100, 0, null));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.WALK_MONSTER_3, false, "부끄럼 나무", MonsterState.IDLE, 10, 10, 100, 100, 100, 0, null));


        monsterInfoList.Add(new MonsterInfo(MonsterCode.FLY_MONSTER_1, false, "과일 박쥐", MonsterState.IDLE, 10, 10, 100, 100, 100, 0, null));


        monsterInfoList.Add(new MonsterInfo(MonsterCode.BOSS_1, true, "숲의 여왕", MonsterState.IDLE, 10, 10, 100, 100, 100, 0, null));
    }

    public MonsterInfo MonsterDataLoadWithCode(MonsterCode mCode)
    {
        foreach (MonsterInfo mInfo in monsterInfoList)
        {
            if (mCode == mInfo.monsterCode)
            {
                return mInfo;
            }
        }
        return null;
    }

}

#endregion

public class MonsterParent : MonoBehaviour
{

    public MonsterCode myMonsterCode;   //고유코드 (Inspector)
    MonsterInfo myMonsterInfo;          //이 몬스터의 정보

    public GameObject DropGoldObject;   //드랍 골드 오브젝트 (Inspector)
    public Animator monsterAnimator;    //애니메이터

    public virtual void Start()
    {
        if (myMonsterCode != MonsterCode.PARENT)    //부모 일 경우 정보 불러오지 않음
        {
        MonsterInfoList monsterInfoDataBase = new MonsterInfoList();    //메모리 절약을 위해 전역변수가 아닌 1회성 지역변수로 사용.
        monsterAnimator = GetComponent<Animator>();
        myMonsterInfo = monsterInfoDataBase.MonsterDataLoadWithCode(myMonsterCode);
        Debug.Log(name+" "+myMonsterInfo.monsterName);
        }
    }

    void Update()
    {

    }
}
