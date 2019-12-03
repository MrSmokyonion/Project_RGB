using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBoss : MonsterParent
{
    int attackType = 0; //공격아님0, 기본 1, 특수 2, 특수 3 ...
    public List<GameObject> bossAttackPrefabList;
    public GameObject DropItemObject;   //드랍 아이템(장비,스킬류) 오브젝트 (Inspector)

    public override void MyStart()
    {
        Invoke("AttackRangeCheckSystem", 0.5f); //0.5초에 한번씩 범위 및 공격 체크.
        Invoke("PosAndMoveSystem", 0.2f);
    }

    #region MoveSystem

    public void PosAndMoveSystem()
    {
        if (myMonsterInfo.monsterState != MonsterState.DEAD)
        {
            //플레이어와 몬스터 각각의 x,y값
            pPosXY = new Vector2(PlayerObject.transform.position.x, PlayerObject.transform.position.y);
            mPosXY = new Vector2(this.transform.position.x, this.transform.position.y);

            isLRM = (pPosXY.x < mPosXY.x) ? 1 :
               ((pPosXY.x > mPosXY.x) ? 2 : 3);                                    //Player가 Left 1, Right 2, Midle 3 에 있음

            MoveSystem();

            Invoke("PosAndMoveSystem", 0.5f);
        }
    }

    public void MoveSystem()
    {
        //----------------------------이동----------------------------
        if (!isAttacking)                                                           //공격 중에는 move,rotate하면 안됨
        {
            //----------------------------좌우----------------------------
            Vector3 myLS = transform.localScale;

            if (isLRM == 1)                                                         //왼쪽에 플레이어가 있음
            {
                transform.localScale = new Vector3(myLS.x > 0 ? myLS.x : -myLS.x, myLS.y, myLS.z);
                myMonsterRigid.velocity = new Vector2(-myMonsterInfo.monsterSpeed, myMonsterRigid.velocity.y);
            }
            else if (isLRM == 2)                                                    //오른쪽에 플레이어가 있음
            {
                transform.localScale = new Vector3(myLS.x < 0 ? myLS.x : -myLS.x, myLS.y, myLS.z);
                myMonsterRigid.velocity = new Vector2(myMonsterInfo.monsterSpeed, myMonsterRigid.velocity.y);
            }
            else
            {
                myMonsterRigid.velocity = new Vector2(0, myMonsterRigid.velocity.y);
            }

        }
    }

    #endregion

    #region AttackSystem

    public void AttackRangeCheckSystem()
    {
        if (myMonsterInfo.monsterState != MonsterState.DEAD)
        {
            if (!isAttacking)
            {
                //--------------------------범위 체크--------------------------
                pPosXY = new Vector2(PlayerObject.transform.position.x, PlayerObject.transform.position.y);
                mPosXY = new Vector2(this.transform.position.x, this.transform.position.y);

                if (Mathf.Sqrt(((pPosXY.x - mPosXY.x) * (pPosXY.x - mPosXY.x)) + ((pPosXY.y - mPosXY.y) * (pPosXY.y - mPosXY.y))) < myMonsterInfo.monsterAttackRange)
                {
                    attackType = 1; //일반공격1
                }
                else
                {
                    attackType = Random.Range(2, 4); //특수공격2,3
                }
                AttackSystem();
            }
            Invoke("AttackRangeCheckSystem", 0.5f);                                                 //계속 체크
        }
    }

    public void AttackSystem()
    {
        if (!isAttacking)                                                   //이미 공격 중이 아닐 때 공격
        {
            //----------------------------각각 공격 애니메이션 실행----------------------------
            isAttacking = true;
            myMonsterRigid.velocity = new Vector2(0, myMonsterRigid.velocity.y);

            AttackAnimation(attackType);

            //----------------------------각각 공격 작용----------------------------
            if (myMonsterCode == MonsterCode.BM301)                             //습지의 여왕.
            {
                if (attackType == 1)                                            //일반공격 : 채찍 휘두르기
                {
                }
                else if (attackType == 2)                                       //타겟팅 공격 (적당한 프리팹이 없음..)
                {
                    bossAttackPrefabList[0].transform.position = pPosXY;
                    Instantiate(bossAttackPrefabList[0]);

                }
                else if (attackType == 3)                                       //Boss위치에 몬스터 소환(걷는 꽃)
                {
                    bossAttackPrefabList[1].transform.position = mPosXY;
                    Instantiate(bossAttackPrefabList[1]);
                }
            }
            else if (myMonsterCode == MonsterCode.BM302)                        //타오르는 피닉스
            {
                if (attackType == 1)                                            //일반공격 : 부리찍기!!!(애니메이션)
                {
                }
                else if (attackType == 2)                                       //깃털을 던져서 공격!
                {
                    GameObject summonedThrowWeapon = Instantiate(bossAttackPrefabList[0]);
                    summonedThrowWeapon.transform.position = this.transform.position;
                    MonstersThrowWeapon throwWeapon = summonedThrowWeapon.GetComponent<MonstersThrowWeapon>();
                    throwWeapon.gameObject.SetActive(true);
                    throwWeapon.StartGoToPlayer(myMonsterCode);
                }
                else if (attackType == 3)                                       //타겟팅 공격 (적당한 프리팹이 없음..)
                {
                    bossAttackPrefabList[1].transform.position = pPosXY;
                    Instantiate(bossAttackPrefabList[1]);
                }
            }
            else if (myMonsterCode == MonsterCode.BM303)                        //얼음 내시
            {
                if (attackType == 1)                                            //파도 공격!
                {
                    GameObject summonedThrowWeapon = Instantiate(bossAttackPrefabList[0]);
                    summonedThrowWeapon.transform.position = this.transform.position;
                    MonstersThrowWeapon throwWeapon = summonedThrowWeapon.GetComponent<MonstersThrowWeapon>();
                    throwWeapon.gameObject.SetActive(true);
                    throwWeapon.StartGoToPlayer(myMonsterCode, attackType, isLRM);
                }
                else if (attackType == 2)                                       //눈송이 쫓아가기 공격!
                {
                    GameObject summonedThrowWeapon = Instantiate(bossAttackPrefabList[1]);
                    summonedThrowWeapon.transform.position = this.transform.position;
                    MonstersThrowWeapon throwWeapon = summonedThrowWeapon.GetComponent<MonstersThrowWeapon>();
                    throwWeapon.gameObject.SetActive(true);
                    throwWeapon.StartGoToPlayer(myMonsterCode, attackType);
                }
                else if (attackType == 3)                                       //아이스 스피어 소환 공격!
                {
                    int count = 5;
                    List<GameObject> summonedThrowWeaponList = new List<GameObject>();
                    for (int i = 0; i < count; i++) //0,1,2,3,4
                    {
                        summonedThrowWeaponList.Add(Instantiate(bossAttackPrefabList[2]));
                        summonedThrowWeaponList[i].transform.position = new Vector3(transform.position.x, transform.position.y + i * 3, transform.position.z);
                        MonstersThrowWeapon throwWeapon = summonedThrowWeaponList[i].GetComponent<MonstersThrowWeapon>();
                        throwWeapon.gameObject.SetActive(true);
                        throwWeapon.StartGoToPlayer(myMonsterCode, attackType);
                    }
                }
            }
            else if (myMonsterCode == MonsterCode.BM304)                             //해바라기 사자
            {
                if (attackType == 1)                                            //일반공격 : 할퀴기
                {
                }
                else if (attackType == 2)                                       //꽃잎들 발사!
                {
                    MonstersThrowWeapon throwWeaponScript = Instantiate(transform.GetChild(0).gameObject).GetComponent<MonstersThrowWeapon>(); //꽃을 가져옴.
                    throwWeaponScript.gameObject.SetActive(true);
                    throwWeaponScript.StartGoToPlayer(myMonsterCode, attackType, isLRM);
                }
                else if (attackType == 3)                                       //울부짖기 (디버프)
                {
                }
            }
        }
    }

    public void AttackAnimation(int aniType)
    {
        if (aniType != 0)  //공격 안함.
        {
            RuntimeAnimatorController ac = myMonsterAnimator.runtimeAnimatorController;
            for (int i = 0; i < ac.animationClips.Length; i++)
            {
                string name1 = ac.animationClips[i].name.ToUpper();
                string name2 = (myMonsterCode.ToString() + "_AttackAnimation" + aniType).ToUpper();

                if (name1.Equals(name2))
                {
                    attackingRunTime = ac.animationClips[i].length;
                }
            }
            // myMonsterAnimator.SetBool("IsAttacking", isAttacking);          //공격 애니메이션 실행
            AnimationStateSet(MonsterState.ATTACK);
            myMonsterAnimator.SetInteger("AttackType", aniType);          //공격 애니메이션 타입 설정
            Invoke("ResetIsAttacking", attackingRunTime);
        }
    }

    public void ResetIsAttacking()
    {
        isAttacking = false;                                                        //공격 애니메이션 끝남
        attackType = 0;
        AnimationStateSet(MonsterState.IDLE);
        myMonsterAnimator.SetInteger("AttackType", attackType);
        //Debug.Log("공격 끝남");
    }

    #endregion

    public override void DropItem() //Only Boss!
    {
        DropItemObject.GetComponent<DroppedItem>().dropItemCode = myMonsterInfo.monsterDropItemCode;

        //-----------------------------------아이템 드랍-----------------------------------
        DroppedItem item = Instantiate(DropItemObject).GetComponent<DroppedItem>();

        SpawnCode mDropItemCode = myMonsterInfo.monsterDropItemCode;
        item.name = myMonsterInfo.monsterName + " 드롭 아이템:" + mDropItemCode.ToString();

        int ranX = Random.Range(-100, 101);     //min ~ max-1
        int ranY = Random.Range(100, 201);      //min ~ max-1
        item.transform.position = GetComponent<Transform>().position;
        item.GetComponent<Rigidbody2D>().AddForce(new Vector3(ranX, ranY, 0));              //위 방향으로 랜덤 발사
    }
}
