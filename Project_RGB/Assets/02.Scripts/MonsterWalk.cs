using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class MonsterWalk : MonsterParent
{
    private void Start()
    {
        Invoke("AttackRangeCheckSystem", 0.2f);
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
        if (myMonsterCode == MonsterCode.WALK_MONSTER_1)                            //걷는 꽃. 플레이어에게 그냥 걸어감
        {
        }
        else if (myMonsterCode == MonsterCode.WALK_MONSTER_2 ||                     //뛰는 돌. 걸어오다가 일정거리 이하일 때 돌진
                myMonsterCode == MonsterCode.WALK_MONSTER_3)                        //서있는 나무. 범위에 들어오면 공격.
        {
            if (attackOrder == true)                                                //공격 명령을 받음
            {
                attackOrder = false;
                if (!isAttacking)                                                   //이미 공격 중이 아닐 때 공격
                {
                    isAttacking = true;
                    myMonsterRigid.velocity = new Vector2(0, myMonsterRigid.velocity.y);
                    if (myMonsterCode == MonsterCode.WALK_MONSTER_2)                //돌진 공격
                    {
                        if (isLRM == 1)
                            myMonsterRigid.velocity = new Vector2(-myMonsterInfo.monsterSpeed - 8, myMonsterRigid.velocity.y);
                        if (isLRM == 2 || isLRM == 3)
                            myMonsterRigid.velocity = new Vector2(myMonsterInfo.monsterSpeed + 8, myMonsterRigid.velocity.y);
                    }

                    RuntimeAnimatorController ac = myMonsterAnimator.runtimeAnimatorController;
                    for (int i = 0; i < ac.animationClips.Length; i++)
                    {
                        string name1 = ac.animationClips[i].name.ToUpper();
                        string name2 = (myMonsterCode.ToString() + "_AttackAnimation").ToUpper();

                        if (name1.Equals(name2))
                        {
                            attackingRunTime = ac.animationClips[i].length;
                        }
                    }
                    myMonsterAnimator.SetBool("IsAttacking", isAttacking);          //공격 애니메이션 실행
                    Invoke("ResetIsAttacking", attackingRunTime);
                }
            }
        }
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
                        attackOrder = true;
                    }
                }
                AttackSystem();
            }
            Invoke("AttackRangeCheckSystem", 0.2f);                                                 //계속 체크
        }
    }

    public void ResetIsAttacking()
    {
        isAttacking = false;                                                        //공격 애니메이션 끝남
        myMonsterAnimator.SetBool("IsAttacking", isAttacking);
        //Debug.Log("공격 끝남");
    }
}
