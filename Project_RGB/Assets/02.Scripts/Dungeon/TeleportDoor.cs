using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDoor : MonoBehaviour
{
    public bool teleportOpen = false;
    public bool chapterClear = false;
    public GameObject outputDoor;                           //이 문과 연결 되어있는 나가는 문. (Chapter Clear 문은 output이 없음)
    public DungeonManager dungeonManager;                   //(Find)
    public GameObject playerObject;                         //(Find)
    public Sprite OpenDoor;                                 //(Inspector)

    private void Start()
    {
        dungeonManager = GameObject.Find("DungeonManager").GetComponent<DungeonManager>();
        playerObject = GameObject.Find("Player");
        dungeonManager.teleportDoors.Add(this);
    }

    private void Update()
    {
        if (teleportOpen || chapterClear)
            GetComponent<SpriteRenderer>().sprite = OpenDoor;
    }

    public void PlayerInteractWithDoor()
    {
        //Player가 상호작용 버튼을 눌러서 문의 이 함수에 넣어줄 시 데려왔을 시.
        Debug.Log("teleportOpen:" + teleportOpen);
        if (teleportOpen)
        {
            if (!chapterClear)
            {
                dungeonManager.BeforeGoToNextStage();
                Invoke("AfterPlayerInteractWithDoor", 2f);
            }
            else
            {
                dungeonManager.ChapterClear();
            }
        }
        else                                                            //아직 몬스터가 남아있을 시 (false)
        {
            //아직 몬스터가 남아있습니다. (안내문?이 뜸)
        }
    }

    public void AfterPlayerInteractWithDoor()
    {
        Debug.Log("텔레포트 실행");
        playerObject.transform.position = outputDoor.transform.position;
        Debug.Log("텔레포트 완료해야함.");
        dungeonManager.AfterGoToNextStage();
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
