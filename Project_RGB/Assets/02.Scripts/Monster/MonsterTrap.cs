using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTrap : MonsterParent
{
    public override void MyStart()
    {
        if (myMonsterCode != MonsterCode.TM503)
        {
            Invoke("AttackRangeCheckSystem", 0.2f);

            Invoke("PosAndMoveSystem", 0.1f);
        }

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
               ((pPosXY.x > mPosXY.x) ? 2 : 3);                                     //Player가 Left 1, Right 2, Midle 3 에 있음

            MoveSystem();

            Invoke("PosAndMoveSystem", 0.1f);
        }
    }

    public void MoveSystem()
    {
        //----------------------------이동 안함----------------------------
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
                pPosXY = new Vector2(PlayerObject.transform.position.x, PlayerObject.transform.position.y);
                mPosXY = new Vector2(this.transform.position.x, this.transform.position.y);

                //--------------------------범위 체크--------------------------
                if (Mathf.Sqrt(((pPosXY.x - mPosXY.x) * (pPosXY.x - mPosXY.x)) + ((pPosXY.y - mPosXY.y) * (pPosXY.y - mPosXY.y))) < myMonsterInfo.monsterAttackRange)
                {
                    AttackSystem();
                }
            }
            Invoke("AttackRangeCheckSystem", 0.2f);                                 //계속 체크
        }
    }

    public void AttackSystem()
    {
        if (!isAttacking)                                                           //이미 공격 중이 아닐 때 공격
        {
            //----------------------------각각 공격 애니메이션 실행----------------------------
            isAttacking = true;
            myMonsterRigid.velocity = new Vector2(0, myMonsterRigid.velocity.y);

            AttackAnimation();

            //----------------------------각각 공격 작용----------------------------
            if (myMonsterCode == MonsterCode.TM501)
            {
            }
            else if (myMonsterCode == MonsterCode.TM502)
            {
            }
            else if (myMonsterCode == MonsterCode.TM503)
            {
            }
            else if (myMonsterCode == MonsterCode.TM506)//고드름 낙하!
            {
                //그냥 애니메이션으로 만들기로 함.
            }
        }
    }

    public void AttackAnimation()
    {
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
        myMonsterAnimator.SetBool("IsAttacking", isAttacking);                      //공격 애니메이션 실행
        Invoke("ResetIsAttacking", attackingRunTime);
    }

    public void ResetIsAttacking()
    {
        isAttacking = false;                                                        //공격 애니메이션 끝남
        myMonsterAnimator.SetBool("IsAttacking", isAttacking);
        //Debug.Log("공격 끝남");
    }



    public  void MonsterHitWeapon(Collider2D col) //KTH: override 붙여져 있었는데 컴파일 에러땜시 잠깐 땜.
    {
        //Trap은 DeadCheck를 해줄 필요가 없습니다.
        quest.QuestMonsterCheck(myMonsterCode);                                 //Trap을 때리면 무기를 확인해서 신호를 보내줌!
    }



    #endregion
}