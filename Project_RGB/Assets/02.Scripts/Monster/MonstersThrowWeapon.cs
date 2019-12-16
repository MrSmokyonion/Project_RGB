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

    public int throwThingSpeed = 10;
    public float lifeTime = 100f;
    bool goToPlayer = false;
    GameObject PlayerObject;
    Vector2 pPosXY;
    Vector2 mPosXY;
    Rigidbody2D myRigid;

    public void StartGoToPlayer(MonsterCode monsterCode, int attackType = -1, int isLRM = 0)
    {
        PlayerObject = GameObject.Find("MonsterPlayer_Sample");
        myRigid = GetComponent<Rigidbody2D>();
        goToPlayer = true;

        switch (monsterCode)
        {
            case MonsterCode.WM106: //불타는 주술사
                throwThingSpeed = 8; ChaseThePlayer(); lifeTime = 2.0f;
                break;
            case MonsterCode.WM108: //얼음 펭귄
                StartCoroutine(ParabolicExerciseToPlayer()); lifeTime = 7.0f;
                break;
            case MonsterCode.WM110: //무지개 장미
                throwThingSpeed = 30; FireToPlayer(); lifeTime = 3.0f;
                break;
            case MonsterCode.FM203: //무지개 새
                throwThingSpeed = 7; ChaseThePlayer(); lifeTime = 2.5f;
                break;
            case MonsterCode.BM302: //타오르는 피닉스
                throwThingSpeed = 30; FireToPlayer(); lifeTime = 3.0f;
                break;
            case MonsterCode.BM303: //얼음네시
                if (attackType == 1)
                {
                    throwThingSpeed = 12; lifeTime = 3.0f;
                    JustGoToFront(isLRM);
                    //파도 공격!!!
                }
                else if (attackType == 2)
                {
                    throwThingSpeed = 10; lifeTime = 8.0f;
                    ChaseThePlayer();
                    //쫓아가랏 눈송이!!!!
                }
                else if (attackType == 3)
                {
                    throwThingSpeed = 40; lifeTime = 5.0f;
                    //타켓팅 아이스 스피어 5개가 각자 다른 곳에서 생성 되었습니다!!!
                    //발싸!!!!
                    FireToPlayer();
                }
                break;
            case MonsterCode.BM304: //해바라기 사자
                if (attackType == 2)   //꽃잎 발싸! (랜덤위치, 랜덤속도, 수평으로 날아감.)
                {
                    throwThingSpeed = 10; lifeTime = 4f;
                    //ChaseThePlayer();
                    StartCoroutine(irregularStraightThrowToPlayer(isLRM));
                    //쫓아가랏 눈송이!!!!
                }
                break;
        }
        if (goToPlayer)
        {
            Invoke("Dead", lifeTime);
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
                sY = throwThingSpeed;
            }
            else if (b == 0)
            {
                sX = throwThingSpeed;
                sY = 0;
            }
            else
            {
                sX = Mathf.Sqrt((throwThingSpeed * throwThingSpeed) / (1 + ((b * b) / (a * a))));
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

    private IEnumerator ParabolicExerciseToPlayer()
    {
        if (goToPlayer == true)
        {
            //스프라이트 투명했다가 발사할 때 돌아옴.
            SpriteRenderer spRen = GetComponent<SpriteRenderer>();
            Color myColor = spRen.color;
            myColor.a = 0f;
            spRen.color = myColor;
            yield return new WaitForSeconds(1.1f);
            myColor.a = 1f;
            spRen.color = myColor;

            //여기부터 계산 시작
            float firingAngle = 45.0f;
            float gravity = 9.8f;

            Transform target = PlayerObject.transform;
            Transform projectile = transform;
            projectile.position = transform.position + new Vector3(0, 0.0f, 0); //??? 이게 대체 뭐하는거지

            // Calculate distance to target
            float target_Distance = Vector3.Distance(projectile.position, target.position);

            // Calculate the velocity needed to throw the object to the target at specified angle.
            float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

            // Extract the X  Y componenent of the velocity
            float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad) /* (target.position.x < projectile.position.x ? -1f : 1f)*/;
            float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

            // Calculate flight time.
            float flightDuration = target_Distance / Vx;

            // Rotate projectile to face the target. (We are 2D. So, Sprite little Crush...)
            projectile.rotation = Quaternion.LookRotation(target.position - projectile.position);

            //projectile.rotation = Quaternion.LookRotation(-(target.position - projectile.position));

            float elapse_time = 0;

            while (true)
            {
                //좀 더 생각해봅시다.
                projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

                elapse_time += Time.deltaTime;

                yield return null;
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
                sY = throwThingSpeed;
            }
            else if (b == 0)
            {
                sX = throwThingSpeed;
                sY = 0;
            }
            else
            {
                sX = Mathf.Sqrt((throwThingSpeed * throwThingSpeed) / (1 + ((b * b) / (a * a))));
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

    private void JustGoToFront(int isLRM)   //Player가 Left 1, Right 2, Midle 3 에 있음
    {
        if (isLRM == 1)                                                         //왼쪽에 플레이어가 있음
        {
            myRigid.velocity = new Vector2(-throwThingSpeed, myRigid.velocity.y);
        }
        else if (isLRM == 2)                                                    //오른쪽에 플레이어가 있음
        {
            myRigid.velocity = new Vector2(throwThingSpeed, myRigid.velocity.y);
        }
    }

    private IEnumerator irregularStraightThrowToPlayer(int isLRM)
    {

        List<GameObject> myClones = new List<GameObject>();
        int objectCount = Random.Range(5, 11);   //5~10개 발싸!
        for (int i = 0; i < objectCount; i++)
            myClones.Add(Instantiate(this.gameObject, transform.parent));

        foreach (GameObject clone in myClones)
        {
            clone.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + Random.Range(-5.0f, 5.0f));

            if (isLRM == 1)                                                         //왼쪽에 플레이어가 있음
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector2(-throwThingSpeed, clone.GetComponent<Rigidbody2D>().velocity.y);
            }
            else if (isLRM == 2)                                                    //오른쪽에 플레이어가 있음
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector2(throwThingSpeed, clone.GetComponent<Rigidbody2D>().velocity.y);
            }

            Destroy(clone, lifeTime);
            yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));
        }

        //foreach (GameObject c in myClones)
        //{
        //    Destroy(c, lifeTime);
        //}
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
