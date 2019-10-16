using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersThrowWeapon : MonoBehaviour
{
    /*
     * 사용법
     * 
     * 사용 될 몬스터의 자식 또는 변수로 이 오브젝트를 두십시오.
     * 어떠한 방식으로든 이 오브젝트를 복사 소환하십시오. (GetChild..GameObject..)
     * 오브젝트를 복사 소환한 후, goToPlayer를 true로 바꿔주십시오.
     * 끝
     */

    public int Speed = 10;
    bool goToPlayer = false;
    GameObject PlayerObject;
    Vector2 pPosXY;
    Vector2 mPosXY;
    Rigidbody2D myRigid;

    public void StartGoToPlayer(MonsterCode monsterCode)
    {
        PlayerObject = GameObject.Find("MonsterPlayer_Sample");
        myRigid = GetComponent<Rigidbody2D>();
        Invoke("Dead", 2f);
        goToPlayer = true;

        switch (monsterCode)
        {
            case MonsterCode.WM106: //불타는 주술사
                Speed = 12; ChaseThePlayer();
                break;
            case MonsterCode.WM108: //얼음 펭귄
                Speed = 20; ParabolicExerciseToPlayer();
                break;
            case MonsterCode.BM302: //타오르는 피닉스
                Speed = 30; FireToPlayer();
                break;
        }
    }

    private void ChaseThePlayer()
    {
        if (goToPlayer == true)
        {
            pPosXY = new Vector2(PlayerObject.transform.position.x, PlayerObject.transform.position.y);
            mPosXY = new Vector2(this.transform.position.x, this.transform.position.y);

            //if (pPosXY.x < mPosXY.x)        //왼쪽으로
            //    myRigid.velocity = new Vector2(-Speed, myRigid.velocity.y);
            //else if (pPosXY.x > mPosXY.x)   //오른쪽으로
            //    myRigid.velocity = new Vector2(+Speed, myRigid.velocity.y);
            //if (pPosXY.y < mPosXY.y)        //아래로
            //    myRigid.velocity = new Vector2(myRigid.velocity.x, -Speed);
            //else if (pPosXY.y > mPosXY.y)   //위로
            //    myRigid.velocity = new Vector2(myRigid.velocity.x, +Speed);


            float a = mPosXY.x - pPosXY.x;
            if (a < 0) a *= -1;
            float b = mPosXY.y - pPosXY.y;
            if (b < 0) b *= -1;

            float sX;
            float sY;
            if (a == 0)
            {
                sX = 0;
                sY = Speed;
            }
            else if (b == 0)
            {
                sX = Speed;
                sY = 0;
            }
            else
            {
                sX = Mathf.Sqrt((Speed * Speed) / (1 + ((b * b) / (a * a))));
                sY = sX * (b / a);
            }

            //----------------------------좌우----------------------------
            Vector3 myLS = transform.localScale;

            if (pPosXY.x < mPosXY.x)                                                         //왼쪽에 플레이어가 있음
            {
                transform.localScale = new Vector3(myLS.x > 0 ? myLS.x : -myLS.x, myLS.y, myLS.z);
                myRigid.velocity = new Vector2(-sX, myRigid.velocity.y);
            }
            else if (pPosXY.x > mPosXY.x)                                                    //오른쪽에 플레이어가 있음
            {
                transform.localScale = new Vector3(myLS.x < 0 ? myLS.x : -myLS.x, myLS.y, myLS.z);
                myRigid.velocity = new Vector2(sX, myRigid.velocity.y);
            }

            //----------------------------상하----------------------------
            if (pPosXY.y > mPosXY.y)                                                         //위쪽에 플레이어가 있음
            {
                myRigid.velocity = new Vector2(myRigid.velocity.x, sY);
            }
            else if (pPosXY.y < mPosXY.y)                                                    //아래쪽에 플레이어가 있음
            {
                myRigid.velocity = new Vector2(myRigid.velocity.x, -sY);
            }

            Invoke("ChaseThePlayer", 0.1f);
        }
    }

    private void ParabolicExerciseToPlayer()
    {
        if (goToPlayer == true)
        {
            float firingAngle = 45.0f;
            float gravity = 9.8f;

            Transform target = PlayerObject.transform;
            Transform myTransform = this.transform;
            //으악 여기 고쳐야함 아직 안고침 앍ㄹ아흐ㅏㄱㄷ미ㅓ훌ㄷ미ㅏㅡㅍ딜ㅈㅁㅍ
            Transform projectile = gameObject.transform.parent.gameObject.transform;
            projectile.position = myTransform.position + new Vector3(0, 0.0f, 0);

            // Calculate distance to target
            float target_Distance = Vector3.Distance(projectile.position, target.position);

            // Calculate the velocity needed to throw the object to the target at specified angle.
            float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

            // Extract the X  Y componenent of the velocity
            float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
            float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

            // Calculate flight time.
            float flightDuration = target_Distance / Vx;

            // Rotate projectile to face the target.
            projectile.rotation = Quaternion.LookRotation(target.position - projectile.position);

            float elapse_time = 0;

            while (elapse_time < flightDuration)
            {
                projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

                elapse_time += Time.deltaTime;
            }
        }
    }

    private void FireToPlayer()
    {
        if (goToPlayer == true)
        {
            pPosXY = new Vector2(PlayerObject.transform.position.x, PlayerObject.transform.position.y);
            mPosXY = new Vector2(this.transform.position.x, this.transform.position.y);

            //--------------------그 방향을 바라봄--------------------
            float distance = Vector2.Distance(pPosXY, mPosXY);
            Vector2 offset = new Vector2(pPosXY.x - mPosXY.x, pPosXY.y - mPosXY.y); //플레이어의 좌표값을 가져와서 그 방향을 봄
            float mangle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            Quaternion mQut = Quaternion.Euler(new Vector3(0, 0, mangle));

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, mQut, 1.0f);

            //--------------------그 방향으로 전진--------------------

            float a = mPosXY.x - pPosXY.x;
            if (a < 0) a *= -1;
            float b = mPosXY.y - pPosXY.y;
            if (b < 0) b *= -1;

            float sX;
            float sY;
            if (a == 0)
            {
                sX = 0;
                sY = Speed;
            }
            else if (b == 0)
            {
                sX = Speed;
                sY = 0;
            }
            else
            {
                sX = Mathf.Sqrt((Speed * Speed) / (1 + ((b * b) / (a * a))));
                sY = sX * (b / a);
            }

            //----------------------------좌우----------------------------
            Vector3 myLS = transform.localScale;

            if (pPosXY.x < mPosXY.x)                                                         //왼쪽에 플레이어가 있음
            {
                myRigid.velocity = new Vector2(-sX, myRigid.velocity.y);
            }
            else if (pPosXY.x > mPosXY.x)                                                    //오른쪽에 플레이어가 있음
            {
                myRigid.velocity = new Vector2(sX, myRigid.velocity.y);
            }

            //----------------------------상하----------------------------
            if (pPosXY.y > mPosXY.y)                                                         //위쪽에 플레이어가 있음
            {
                myRigid.velocity = new Vector2(myRigid.velocity.x, sY);
            }
            else if (pPosXY.y < mPosXY.y)                                                    //아래쪽에 플레이어가 있음
            {
                myRigid.velocity = new Vector2(myRigid.velocity.x, -sY);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player") && (goToPlayer == true))
        {
            goToPlayer = false;
            Dead();
        }
    }

    public void Dead()
    {
        Destroy(this.gameObject, 0.1f);
    }
}
