using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBoss : MonsterParent
{
    int attackType = 0; //공격아님0, 기본 1, 특수 2, 특수 3 ... 
    public GameObject bossSummonAttackPrefab;
    public GameObject bossSummonMonsterPrefab;

    private void Start()
    {
        Invoke("AttackRangeCheckSystem", 0.5f); //0.5초에 한번씩 범위 및 공격 체크.
        Invoke("PosAndMoveSystem", 0.1f);
    }

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

            Invoke("PosAndMoveSystem", 0.1f);
        }
    }

    public void MoveSystem()
    {
        //----------------------------이동----------------------------
        if (!isAttacking)                                                           //공격 중에는 move,rotate하면 안됨
        {
            //----------------------------좌우----------------------------
            if (isLRM == 1)                                                         //왼쪽에 플레이어가 있음
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                myMonsterRigid.velocity = new Vector2(-myMonsterInfo.monsterSpeed, myMonsterRigid.velocity.y);
            }
            else if (isLRM == 2)                                                    //오른쪽에 플레이어가 있음
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                myMonsterRigid.velocity = new Vector2(myMonsterInfo.monsterSpeed, myMonsterRigid.velocity.y);
            }
            else
            {
                myMonsterRigid.velocity = new Vector2(0, myMonsterRigid.velocity.y);
            }

        }
    }

    public void AttackSystem()
    {

        //----------------------------공격----------------------------
        if (myMonsterCode == MonsterCode.BOSS_1)                                    //숲의 여왕. 다가왔을 때 일반공격, 타겟팅 공격, 몬스터 소환
        {
            if (attackOrder == true)                                                //공격 명령을 받음
            {
                attackOrder = false;
                if (!isAttacking)                                                   //이미 공격 중이 아닐 때 공격
                {
                    isAttacking = true;
                    myMonsterRigid.velocity = new Vector2(0, myMonsterRigid.velocity.y);

                    if (attackType == 1)                                            //일반공격
                    {
                    }
                    else if (attackType == 2)                                       //타겟팅 공격 (적당한 프리팹이 없어서 플레이어 위치에 꽃 소환.)
                    {
                        bossSummonAttackPrefab.transform.position = pPosXY;
                        Destroy(Instantiate(bossSummonAttackPrefab), 2f);           //이 자체에서 소환 되고나서 2초 뒤 AddComponent로 Trigger 콜라이더 On해서 공격 후 혼자 Destory.
                    }
                    else if (attackType == 3)                                       //Boss위치에 몬스터 소환(걷는 꽃)
                    {
                        bossSummonMonsterPrefab.transform.position = mPosXY;
                        Instantiate(bossSummonMonsterPrefab);
                    }
                    AttackAnimation(attackType);

                    Invoke("ResetIsAttacking", attackingRunTime);
                }
            }
        }
    }

    public void AttackAnimation(int aniType)
    {

        RuntimeAnimatorController ac = myMonsterAnimator.runtimeAnimatorController;
        for (int i = 0; i < ac.animationClips.Length; i++)
        {
            string name1 = ac.animationClips[i].name.ToUpper();
            string name2 = (myMonsterCode.ToString() + "_AttackAnimation" + aniType).ToUpper();

            //Debug.Log("name1:" + name1);
            //Debug.Log("name2:" + name2);
            if (name1.Equals(name2))
            {
                attackingRunTime = ac.animationClips[i].length;
            }
        }
        myMonsterAnimator.SetBool("IsAttacking", isAttacking);          //공격 애니메이션 실행
        myMonsterAnimator.SetInteger("AttackType", attackType);          //공격 애니메이션 타입 설정
    }

    public void AttackRangeCheckSystem()
    {
        if (myMonsterInfo.monsterState != MonsterState.DEAD)
        {
            if (!isAttacking)
            {
                //--------------------------범위 체크--------------------------
                List<RaycastHit2D> hitList = new List<RaycastHit2D>();
                if (isLRM == 1)
                {
                    hitList.AddRange(Physics2D.RaycastAll(transform.position, Vector2.left, myMonsterInfo.monsterAttackRange));
                    Debug.DrawRay(transform.position, Vector2.left * myMonsterInfo.monsterAttackRange, Color.red, 0.2f);
                }
                else if (isLRM == 2 || isLRM == 3)
                {
                    //Debug.Log("isLRM" + isLRM);
                    hitList.AddRange(Physics2D.RaycastAll(transform.position, Vector2.right, myMonsterInfo.monsterAttackRange));
                    Debug.DrawRay(transform.position, Vector2.right * myMonsterInfo.monsterAttackRange, Color.red, 0.2f);
                }

                //if(hideFlags)
                foreach (RaycastHit2D h in hitList)
                {
                    //Debug.Log("RayCast 리스트!" + h.transform.tag);
                    if (h.transform.tag == "Player")
                    {
                        attackType = 1; //일반공격1
                        break;
                    }
                    attackType = Random.Range(2, 4); //특수공격2,3
                }
                attackOrder = true;
                AttackSystem();
            }
            Invoke("AttackRangeCheckSystem", 0.5f);                                                 //계속 체크
        }
    }

    public void ResetIsAttacking()
    {
        isAttacking = false;                                                        //공격 애니메이션 끝남
        attackType = 0;
        myMonsterAnimator.SetBool("IsAttacking", isAttacking);
        myMonsterAnimator.SetInteger("AttackType", attackType);
        //Debug.Log("공격 끝남");
    }
}
