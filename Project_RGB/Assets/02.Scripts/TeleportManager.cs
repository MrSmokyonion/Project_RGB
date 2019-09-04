/* ********************************************************* *
 *                          DevDong                          *
 * ********************************************************* */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // 오브젝트 이동 (로컬좌표)
    public void TeleportTarget(GameObject target, Vector3 movePos)
    {
        if (target == null) { Debug.LogWarning("Target is null."); return; }

        target.transform.localPosition = movePos;
    }

    // 오브젝트 검색 후 이동 (로컬좌표)
    public void TeleportFindTarget(string targetName, Vector3 movePos)
    {
        GameObject target = null;
        if ((target = GameObject.Find(targetName)) != null)
        {
            target.transform.localPosition = movePos;
        }
        else
        {
            Debug.LogWarning(targetName + " doesn't find.");
            return;
        }
    }
}
