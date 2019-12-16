using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public float barrierCnt = 3;
    public float time = 10;

    private void Start()
    {
        StartCoroutine(crt_BarrierTime());
    }

    private IEnumerator crt_BarrierTime()
    {
        yield return null;

        float curTime = 0f;
        while(true)
        {
            yield return new WaitForEndOfFrame();

            curTime += Time.deltaTime;
            if (curTime >= time)
                break;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Monster")
            return;

        barrierCnt--;

        //Monster 넉백
        GameObject obj = collision.gameObject;
        int dirt = (obj.transform.position.x - transform.parent.position.x > 0) ? 1 : -1;
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(dirt, 1) * 7, ForceMode2D.Impulse);

        if (barrierCnt <= 0)
            Destroy(gameObject);
    }
}