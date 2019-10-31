using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class MonsterWalk : MonsterParent
{
    public override void MyStart()
    {
        Debug.Log("MyStart");

        Invoke("AttackRangeCheckSystem", 0.2f);

        if (myMonsterCode == MonsterCode.WM112)  //따로 대기 애니메이션. (배경인척 테두리가 없지만 뭔가 흔들리고 있음.)
        {
            //눈사람, 꽃 구름, 신전 기사는 Animator의 대기 했다가 따로 시작 애니메이션 존재.
            //범위 안에 들어오면 자식개체(목)에게 떨어지라고(스프라이트 변경) 명령하고, 떨어지는 시간 만큼 기다렸다가 움직이기 시작함.
        }
        else
        {
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
                    AttackSystem();
                }
            }
            Invoke("AttackRangeCheckSystem", 0.2f);                                                 //계속 체크
        }
    }

    public void AttackSystem()
    {
        if (!isAttacking)                                                   //이미 공격 중이 아닐 때 공격
        {
            //----------------------------각각 공격 애니메이션 실행----------------------------
            isAttacking = true;
            myMonsterRigid.velocity = new Vector2(0, myMonsterRigid.velocity.y);

            AttackAnimation();

            //----------------------------각각 공격 작용----------------------------
            if (myMonsterCode == MonsterCode.WM101)
            {
            }
            else if (myMonsterCode == MonsterCode.WM102 || myMonsterCode == MonsterCode.WM104)                    //뛰는 돌, 불타는 돌. 걸어오다가 일정거리 이하일 때 돌진
            {
                //돌진 공격
                if (isLRM == 1)
                    myMonsterRigid.velocity = new Vector2(-myMonsterInfo.monsterSpeed - 8, myMonsterRigid.velocity.y);
                if (isLRM == 2 || isLRM == 3)
                    myMonsterRigid.velocity = new Vector2(myMonsterInfo.monsterSpeed + 8, myMonsterRigid.velocity.y);

            }
            else if (myMonsterCode == MonsterCode.WM103)                        //서있는 나무. 범위에 들어오면 공격.
            {
            }
            else if (myMonsterCode == MonsterCode.WM106 || myMonsterCode == MonsterCode.WM108)    //원거리 공격. 불타는 주술사, 얼음 펭귄, 무지개 장미, 무지개 새
            {
                int childNum = 0;

                GameObject throwthing = transform.GetChild(childNum).gameObject;
                GameObject summonedThrowWeapon = Instantiate(throwthing);
                summonedThrowWeapon.transform.position = new Vector3(transform.position.x + 4, transform.position.y + 2, 0f);
                MonstersThrowWeapon throwWeapon = summonedThrowWeapon.GetComponent<MonstersThrowWeapon>();
                throwWeapon.gameObject.SetActive(true);
                throwWeapon.StartGoToPlayer(myMonsterCode);
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
        myMonsterAnimator.SetBool("IsAttacking", isAttacking);          //공격 애니메이션 실행
        Invoke("ResetIsAttacking", attackingRunTime);
    }

    public void ResetIsAttacking()
    {
        isAttacking = false;                                                        //공격 애니메이션 끝남
        myMonsterAnimator.SetBool("IsAttacking", isAttacking);
        //Debug.Log("공격 끝남");
    }

    #endregion
}
