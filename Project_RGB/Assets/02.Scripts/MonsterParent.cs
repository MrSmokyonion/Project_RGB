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
public enum MonsterState    //상의★몬스터 현 상태를 굳이 알아야하는가?
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
                           int damege, int defense, int hp, int speed, int range,
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
        monsterAttackRange = range;

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
    public int monsterAttackRange;      //공격거리

    public int monsterDropGoldAmount;   //드랍 골드량
    public int monsterDropRate;         //드랍률 0~100%
    public GameObject monsterDropItem;  //드랍 아이템  (장비, 스킬, 아이템) ????
}

public class MonsterInfoList
{
    List<MonsterInfo> monsterInfoList = new List<MonsterInfo>();

    public MonsterInfoList()
    {
        // 몬스터 코드, 등급, 이름, 상태, 
        // 공격력, 방어력, 체력, 이동속도, 공격거리
        // 드랍골드량, 드랍률, 드롭 아이템

        //Walk Monsters
        monsterInfoList.Add(new MonsterInfo(MonsterCode.WALK_MONSTER_1, false, "작은 꽃", MonsterState.IDLE,
            10, 10, 100, 4, 0,
            101, 0, null));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.WALK_MONSTER_2, false, "화난 돌", MonsterState.IDLE,
            10, 10, 100, 5, 5,
            150, 0, null));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.WALK_MONSTER_3, false, "부끄럼 나무", MonsterState.IDLE,
            10, 10, 200, 0, 3,
            50, 0, null));

        //Fly Monsters
        monsterInfoList.Add(new MonsterInfo(MonsterCode.FLY_MONSTER_1, false, "과일 박쥐", MonsterState.IDLE,
            10, 10, 100, 7, 0,
            100, 0, null));

        //Boss Monsters
        monsterInfoList.Add(new MonsterInfo(MonsterCode.BOSS_1, true, "숲의 여왕", MonsterState.IDLE,
            10, 10, 100, 0, 10,
            500, 80, null));
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
    public MonsterInfo myMonsterInfo;   //이 몬스터의 정보

    public GameObject DropGoldObject;   //드랍 골드 오브젝트 (Inspector)
    public Animator myMonsterAnimator;  //애니메이터
    public Rigidbody2D myMonsterRigid;  //리지드바디

    public GameObject PlayerObject;     //현재 이 맵의 Player 오브젝트 (Find)

    public Vector2 pPosXY;
    public Vector2 mPosXY;
    public int isLRM;
    public int isUDM;

    public bool attackOrder;            //공격해라 (명령)
    public bool isAttacking;            //공격중인가? (판단)
    public float attackingRunTime;      //공격 애니메이션 실행 시간
    public bool isDameged;              //데미지 입었는가? (피격 상태 판단)

    public void Awake()
    {
        PlayerObject = GameObject.Find("MonsterPlayer_Sample");

        if (myMonsterCode != MonsterCode.PARENT)                                            //부모 일 경우 정보 불러오지 않음
        {
            MonsterInfoList monsterInfoDataBase = new MonsterInfoList();                    //메모리 절약을 위해 전역변수가 아닌 1회성 지역변수로 사용.
            myMonsterAnimator = GetComponent<Animator>();
            myMonsterRigid = GetComponent<Rigidbody2D>();
            myMonsterInfo = monsterInfoDataBase.MonsterDataLoadWithCode(myMonsterCode);


            //Debug.Log(myMonsterInfo.monsterHp + "HP" + myMonsterInfo.monsterName);          //Debug log 몬스터확인.
        }
    }

    public void DropGoldAndItems()
    {
        //-----------------------------------골드 드랍-----------------------------------
        DroppedGold gold = Instantiate(DropGoldObject).GetComponent<DroppedGold>();

        int mDropGold = myMonsterInfo.monsterDropGoldAmount;
        gold.GoldAmount = Random.Range(mDropGold - 50, mDropGold + 1);                      // (몬스터 골드량 -50) ~ (몬스터의 골드량)을 전달 함.
        gold.name = myMonsterInfo.monsterName + " 드롭 골드량:" + gold;

        int ranX = Random.Range(-100, 101);     //min ~ max-1
        int ranY = Random.Range(100, 201);      //min ~ max-1
        gold.transform.position = GetComponent<Transform>().position;
        gold.GetComponent<Rigidbody2D>().AddForce(new Vector3(ranX, ranY, 0));              //위 방향으로 랜덤 발사


        //-------------------------보스일 때 확률적으로 아이템 드랍-------------------------
        if ((int)myMonsterCode >= (int)MonsterCode.BOSS_1)
        {
            if (Random.Range(0, 101)/*0~100*/ >= myMonsterInfo.monsterDropRate)
            {
                DropItem();
            }
        }
    }

    public void DropItem()
    {
        //어떤 식으로든 아이템에게 아이템 달라고 요청. 그 후 생성 및 뿌림.
        //아이템 클래스에게 MonsterCode를 넘김 
        //아이템 클래스에서 그 MonsterCode에 맞는 아이템을 뿌림. (아이템이 MonsterCode 소지하고 있음.)
    }

    public void DeadCheck()
    {
        if (myMonsterInfo.monsterHp <= 0)
        {
            //죽는 애니메이션과 동시에 아이템 드롭. 그 후 사라짐
            DropGoldAndItems();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Player의 무기/스킬/함정에 접촉 처리.
        //데미지 만큼 myMonsterInfo.monsterHp 깎음
        //자폭 몬스터 있나?..
        DeadCheck();
    }
}
