using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 0f;
    public int power = 0;

    private void Start()
    {
        Invoke("DestroyBullet", 2f);
    }
    private void Update()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, transform.right, 0.5f);
        if(raycastHit2D.collider != null)
        {
            if (raycastHit2D.collider.tag == "Monster")
            {
                Debug.Log("명중");
                DestroyBullet();
            }
        }
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + (transform.right * 0.5f));
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
