using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int power = 0;
    public float destroyDelay = 2f;
    public string spritePath;
    public Transform arrow;
    private void Start()
    {
        //Invoke("KineticToDynamic", 0.25f);
        Invoke("DestroyBullet", destroyDelay);
    }
    private void Update()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(arrow.position, arrow.right, 0.5f);
        if (raycastHit2D.collider != null)
        {
            if (raycastHit2D.collider.tag == "Monster")
            {
                raycastHit2D.transform.GetComponent<MonsterParent>().MonsterHitWeapon(power);
                FindObjectOfType<SoundManager>().Play("bow_hit");
                FindObjectOfType<ParticleSupplier>().SetParticle(raycastHit2D.transform.position, "enemy_hit");
                Debug.Log(raycastHit2D.transform.name + "명중");
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