using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDoor : MonoBehaviour
{
    public bool teleport = false;
    public GameObject partnerDoor;    //이 문과 연결 되어있는 문.

    public void PlayerGoToNextStage(GameObject player)    //제대로 될지 모르겠다..
    {
        if (teleport)
        {
            //화면 페이드 아웃

            player.transform.position = partnerDoor.transform.position;

            //화면 페이드 인
        }
    }

    #region 일용할 양식
    /*
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
    */
    #endregion
}
