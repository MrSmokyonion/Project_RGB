using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(WeaponHide());
    }
    IEnumerator WeaponHide()
    {
        yield return new WaitForSeconds(0.5f);
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
