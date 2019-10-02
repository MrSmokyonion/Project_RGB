using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int power = 0;
    public Transform arrow;
    private void Start()
    {
        Invoke("DestroyBullet", 2f);
    }
    private void Update()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(arrow.position, arrow.right, 0.5f);
        if(raycastHit2D.collider != null)
        {
            if (raycastHit2D.collider.tag == "Monster")
            {
                Debug.Log("명중");
                DestroyBullet();
            }
        }
        arrow.right = GetComponent<Rigidbody2D>().velocity;
        //arrow.Translate(arrow.right * speed * Time.deltaTime, Space.World);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(arrow.position, arrow.position + (arrow.right * 0.5f));
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}