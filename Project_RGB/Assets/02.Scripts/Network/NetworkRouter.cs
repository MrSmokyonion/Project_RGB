using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Networking;

/**************************************************************************************************   
 *      1.  캐릭터 생성 ---> 유저코드 발급
 *      2-1. 캐릭터 데이터 불러오기
 *      2-2. 캐릭터 퀘스트 데이터 불러오기
 *      3.  캐릭터 무기 변경 *
 *      4.  캐릭터 무기 내구도 변경 *
 *      5.  캐릭터 무기 해금 *
 *      6.  캐릭터 부적 변경 *
 *      7.  캐릭터 부적 내구도 변경 *
 *      8.  캐릭터 부적 해금 *
 *      9.  캐릭터 스톤 변경 *
 *      10. 캐릭터 스톤 내구도 변경 *
 *      11. 캐릭터 스톤 해금 *
 *      12. 캐릭터 스킬 변경 *
 *      13. 캐릭터 스킬 해금 *
 *      14. 캐릭터 골드 변경 및 조회
 *      15. 캐릭터 쿠폰 변경 및 조회
 *      16. 퀘스트 상태 변경 *
 *      17. 퀘스트 아이템 수집 *
 *      18. 던전 상태 변경
 *      19. 캐릭터 삭제 요청
 **************************************************************************************************/

public enum PostType
{
    PLAYER_CHARACTER_CREATE,
    PLAYER_CHARACTER_GET_CHARDATA,
    PLAYER_CHARACTER_GET_QUESTDATA,
    PLAYER_WEAPON_CHANGE,
    PLAYER_WEAPON_DURATION,
    PLAYER_WEAPON_UNLOCK,
    PLAYER_AMULET_CHANGE,
    PLAYER_AMULET_DURATION,
    PLAYER_AMULET_UNLOCK,
    PLAYER_STONE_CHANGE,
    PLAYER_STONE_DURATION,
    PLAYER_STONE_UNLOCK,
    PLAYER_SKILL_CHANGE,
    PLAYER_SKILL_UNLOCK,
    PLAYER_GOLD_UPDATE,
    PLAYER_COUPON_UPDATE,
    PLAYER_QUEST_STATE_UPDATE,
    PLAYER_QUEST_ITEM_UPDATE,
    PLAYER_DUNGEON_STATE_UPDATE,
    PLAYER_CHARACTER_REMOVE
}

/// <summary>
/// HTTP 웹서버에 통신하는 클래스입니다.
/// </summary>
public class NetworkRouter : MonoBehaviour
{
    // Scripts
    public Quest quest = null;                      // 퀘스트 참조
    public UnlockClass unlock = null;               // 언락클래스 참조
    public PlayerStatus player = null;              // 플레이어 참조

 
    private const int questAmount = 22;             // 퀘스트 개수(22개)
    private const int playerAmount = 9;             // 플레이어 데이터 개수



    private const string ip = "172.16.16.138";      // IP : 61.81.99.35 (외부)
    private const int port = 3000;                  // Port
    private string url;                             // Uniform Resource Locator
                                                    // uri : Uniform Resource Identifier


    private void Awake()
    {
        url = "http://" + ip + ":" + port + "/";
    }


    /**************************************************************************************************
     * Purpose: Communicate with HTTP Server                                                          *
     * Parameters:                                                                                    *
     * Returns: boolean                                                                               *
     **************************************************************************************************/
    public bool PostRouter(PostType type, object target = null)
    {
        try
        {
            switch (type)
            {
                case PostType.PLAYER_CHARACTER_CREATE:
                    StartCoroutine(WWWCreateCharacter(100, 10, 5, 100, 1));
                    break;
                case PostType.PLAYER_CHARACTER_GET_CHARDATA:
                    StartCoroutine(WWWGetCharacterData());
                    break;
                case PostType.PLAYER_CHARACTER_GET_QUESTDATA:
                    StartCoroutine(WWWGetCharacterQuestData());
                    break;
                case PostType.PLAYER_WEAPON_CHANGE:
                    StartCoroutine(WWWChangeWeapon(((SpawnCode)target).ToString()));
                    break;
                case PostType.PLAYER_WEAPON_DURATION:
                    StartCoroutine(WWWUpdateWeaponDuration("w101", 66));
                    break;
                case PostType.PLAYER_WEAPON_UNLOCK:
                    StartCoroutine(WWWUnlockWeapon(((SpawnCode)target).ToString()));
                    break;
                case PostType.PLAYER_AMULET_CHANGE:
                    StartCoroutine(WWWChangeAmulet(((SpawnCode)target).ToString()));
                    break;
                case PostType.PLAYER_AMULET_DURATION:
                    StartCoroutine(WWWUpdateAmuletDuration("a003", 56));
                    break;
                case PostType.PLAYER_AMULET_UNLOCK:
                    StartCoroutine(WWWUnlockAmulet(((SpawnCode)target).ToString()));
                    break;
                case PostType.PLAYER_STONE_CHANGE:
                    StartCoroutine(WWWChangeStone(((SpawnCode)target).ToString()));
                    break;
                case PostType.PLAYER_STONE_DURATION:
                    StartCoroutine(WWWUpdateStoneDuration("s001", 100));
                    break;
                case PostType.PLAYER_STONE_UNLOCK:
                    StartCoroutine(WWWUnlockStone(((SpawnCode)target).ToString()));
                    break;
                case PostType.PLAYER_SKILL_CHANGE:
                    {
                        string str = ((SpawnCode)target).ToString();
                        StartCoroutine(WWWChangeSkill(str.Substring(0, 1).ToLower(), str));
                        break;
                    }
                case PostType.PLAYER_SKILL_UNLOCK:
                    {
                        string str = ((SpawnCode)target).ToString();
                        StartCoroutine(WWWUnlockSkill(str.Substring(0, 1).ToLower(), str));
                        break;
                    }
                case PostType.PLAYER_GOLD_UPDATE:
                    StartCoroutine(WWWUpdateAndGetGold(1000));
                    break;
                case PostType.PLAYER_COUPON_UPDATE:
                    StartCoroutine(WWWUpdateAndGetCoupon(1000));
                    break;
                case PostType.PLAYER_QUEST_STATE_UPDATE:
                    QuestInfo info16 = (QuestInfo)target;
                    StartCoroutine(WWWUpdateQuestState(info16.quest_code_str, info16.quest_state.ToString()));
                    break;
                case PostType.PLAYER_QUEST_ITEM_UPDATE:
                    QuestInfo info17 = (QuestInfo)target;
                    StartCoroutine(WWWUpdateQuestItem(info17.quest_code_str, info17.questItemCur));
                    break;
                case PostType.PLAYER_DUNGEON_STATE_UPDATE:
                    StartCoroutine(WWWUpdateChapterState(((SceneType)target).ToString()));
                    break;
                case PostType.PLAYER_CHARACTER_REMOVE:
                    StartCoroutine(WWWRemoveCaharacter("#9a1f002b"));
                    break;
            }
            return true;
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
            return false;
        }
    }



    /**************************************************************************************************
     * Purpose: 1. 캐릭터 생성 ---> 유저코드 발급                                                     *
     * Parameters:                                                                                    *
     * Returns: an IEnumerator                                                                        *
     **************************************************************************************************/
    private IEnumerator WWWCreateCharacter(int health, int power, int defense, int gold, int coupon)
    {

        // 0. 요청 주소 생성
        string sUrl = url + "character/create";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("userDeviceMacID", GetMacAddress()); // ex : "F8:E6:1A:BE:CF:10"
        form.AddField("userHealth", health);
        form.AddField("userPower", power);
        form.AddField("userDefense", defense);
        form.AddField("userGold", gold);
        form.AddField("userCoupon", coupon);

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError) Debug.Log("isNetworkError : " + www.error);
        else if (www.isHttpError) Debug.Log("isHttpError : " + www.error);
        else
        {
            // 유저코드 생성(획득)
            GameObject.FindObjectOfType<LocalDataStorage>().InitPlayerLocalData(www.downloadHandler.text);
            Debug.Log("[라우터] 캐릭터 생성 완료!\n" + www.downloadHandler.text + "\n" + www.responseCode);
        }
    }



    public string myMacAddress = string.Empty;
    public string GetMacAddress()
    {
        try
        {
            string macAddress = "";
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in nics)
            {
                PhysicalAddress address = adapter.GetPhysicalAddress();
                if (address.ToString() != "")
                {
                    macAddress = address.ToString();
                    myMacAddress = macAddress;

                    return macAddress;
                }
            }
            return "error lectura mac address";
        }
        catch (Exception ex)
        {
            return "" + ex;
        }
    }



    /**************************************************************************************************
     * Purpose: 2-1. 캐릭터 데이터 불러오기                                                             *
     * Parameters:                                                                                    *
     * Returns: an IEnumerator                                                                        *
     **************************************************************************************************/
    private IEnumerator WWWGetCharacterData()
    {
        string[] questData = new string[questAmount];
        string[] playerData = new string[playerAmount];


        // 0. 요청 주소 생성
        string sUrl = url + "character/chardata";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("userCode", PlayerPrefs.GetString("USERCODE"));

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError) Debug.Log("isNetworkError : " + www.error);
        else if (www.isHttpError) Debug.Log("isHttpError : " + www.error);
        else
        {
            string[] datas = www.downloadHandler.text.Split('@');
            foreach (string document in datas)
            {
                string[] doc = document.Split(':'); // Certainly 2-size

                switch (doc[0])
                {
                    case "Health":  playerData[0] = doc[1]; break;
                    case "Power":   playerData[1] = doc[1]; break;
                    case "Defense": playerData[2] = doc[1]; break;

                    case "Skill_R": playerData[3] = doc[1]; break;
                    case "Skill_G": playerData[4] = doc[1]; break;
                    case "Skill_B": playerData[5] = doc[1]; break;

                    case "Weapon":  playerData[6] = doc[1]; break;
                    case "Amulet":  playerData[7] = doc[1]; break;
                    case "Stone":   playerData[8] = doc[1]; break;
                }
            }
            
            player.Init_AllData(playerData);
            Debug.Log("[라우터] 캐릭터 불러오기 완료!\n" + datas);
        }
    }



    /**************************************************************************************************
     * Purpose: 2-2. 캐릭터 퀘스트 데이터 불러오기                                                      *
     * Parameters:                                                                                    *
     * Returns: an IEnumerator                                                                        *
     **************************************************************************************************/
    private IEnumerator WWWGetCharacterQuestData()
    {
        string[] questData = new string[questAmount];


        // 0. 요청 주소 생성
        string sUrl = url + "character/questdata";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("userCode", PlayerPrefs.GetString("USERCODE"));

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError) Debug.Log("isNetworkError : " + www.error);
        else if (www.isHttpError) Debug.Log("isHttpError : " + www.error);
        else
        {
            string[] datas = www.downloadHandler.text.Split('@');
            foreach (string document in datas)
            {
                string[] doc = document.Split(':'); // Certainly 2-size

                switch (doc[0])
                {
                    case "quest001": questData[0] = doc[1]; break;
                    case "quest002": questData[1] = doc[1]; break;
                    case "quest003": questData[2] = doc[1]; break;
                    case "quest004": questData[3] = doc[1]; break;
                    case "quest005": questData[4] = doc[1]; break;
                    case "quest006": questData[5] = doc[1]; break;
                    case "quest007": questData[6] = doc[1]; break;
                    case "quest008": questData[7] = doc[1]; break;
                    case "quest009": questData[8] = doc[1]; break;
                    case "quest010": questData[9] = doc[1]; break;
                    case "quest011": questData[10] = doc[1]; break;
                    case "quest012": questData[11] = doc[1]; break;
                    case "quest013": questData[12] = doc[1]; break;
                    case "quest014": questData[13] = doc[1]; break;
                    case "quest015": questData[14] = doc[1]; break;
                    case "quest016": questData[15] = doc[1]; break;
                    case "quest017": questData[16] = doc[1]; break;
                    case "quest018": questData[17] = doc[1]; break;
                    case "quest019": questData[18] = doc[1]; break;
                    case "quest020": questData[19] = doc[1]; break;
                    case "quest021": questData[20] = doc[1]; break;
                    case "quest022": questData[21] = doc[1]; break;
                }
            }

            quest.LoadQuestData(questData);                                 // Quest Information
            Debug.Log("[라우터] 캐릭터 퀘스트 데이터 불러오기 완료!\n" + datas);
        }
    }



    /**************************************************************************************************
     * Purpose: 3. 캐릭터 무기 변경                                              *
     * Parameters:                                                                                     *
     * Returns: an IEnumerator                                                                         *
     **************************************************************************************************/
    private IEnumerator WWWChangeWeapon(string weaponModel /* 무기 모델 */)
    {

        // 0. 요청 주소 생성
        string sUrl = url + "weapon/change";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("userCode", PlayerPrefs.GetString("USERCODE"));
        form.AddField("userWeaponModel", weaponModel);

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError) Debug.Log("isNetworkError : " + www.error);
        else if (www.isHttpError) Debug.Log("isHttpError : " + www.error);
        else
        {
            Debug.Log("[라우터] 캐릭터 무기 변경 완료!\n" + weaponModel);
        }
    }



    /**************************************************************************************************
     * Purpose: 4. 캐릭터 무기 내구도 변경                                                              *
     * Parameters:                                                                                    *
     * Returns: an IEnumerator                                                                        *
     **************************************************************************************************/
    private IEnumerator WWWUpdateWeaponDuration(string weaponModel /* 무기 모델 */, int duration /* 지정 내구도 */)
    {
        // 0. 요청 주소 생성
        string sUrl = url + "weapon/duration";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("userCode", PlayerPrefs.GetString("USERCODE"));
        form.AddField("userWeaponModel", weaponModel);
        form.AddField("userDuration", duration);

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError) Debug.Log("isNetworkError : " + www.error);
        else if (www.isHttpError) Debug.Log("isHttpError : " + www.error);
        else
        {
            Debug.Log("[라우터] 캐릭터 무기 내구도 변경 완료!\n" + weaponModel + "(" + duration + "/100)");
        }
    }



    /**************************************************************************************************
     * Purpose: 5. 캐릭터 무기 해금                                                                    *
     * Parameters:                                                                                    *
     * Returns: an IEnumerator                                                                        *
     **************************************************************************************************/
    private IEnumerator WWWUnlockWeapon(string weaponModel /* 무기 모델 */)
    {

        // 0. 요청 주소 생성
        string sUrl = url + "weapon/unlock";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("userCode", PlayerPrefs.GetString("USERCODE"));
        form.AddField("userWeaponModel", weaponModel);

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError) Debug.Log("isNetworkError : " + www.error);
        else if (www.isHttpError) Debug.Log("isHttpError : " + www.error);
        else
        {
            Debug.Log("[라우터] 캐릭터 무기 해금 완료!\n" + weaponModel);
        }
    }



    /**************************************************************************************************
     * Purpose: 6. 캐릭터 부적 변경                                                                    *
     * Parameters:                                                                                    *
     * Returns: an IEnumerator                                                                        *
     **************************************************************************************************/
    private IEnumerator WWWChangeAmulet(string amuletModel /* 부적 모델 */)
    {

        // 0. 요청 주소 생성
        string sUrl = url + "amulet/change";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("userCode", PlayerPrefs.GetString("USERCODE"));
        form.AddField("userAmuletModel", amuletModel);

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError) Debug.Log("isNetworkError : " + www.error);
        else if (www.isHttpError) Debug.Log("isHttpError : " + www.error);
        else
        {
            Debug.Log("[라우터] 캐릭터 부적 변경 완료!\n" + amuletModel);
        }
    }



    /**************************************************************************************************
     * Purpose: 7. 캐릭터 부적 내구도 변경                                                              *
     * Parameters:                                                                                    *
     * Returns: an IEnumerator                                                                        *
     **************************************************************************************************/
    private IEnumerator WWWUpdateAmuletDuration(string amuletModel /* 부적 모델 */, int duration /* 지정 내구도 */)
    {

        // 0. 요청 주소 생성
        string sUrl = url + "amulet/duration";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("userCode", PlayerPrefs.GetString("USERCODE"));
        form.AddField("userAmuletModel", amuletModel);
        form.AddField("userDuration", duration);

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError) Debug.Log("isNetworkError : " + www.error);
        else if (www.isHttpError) Debug.Log("isHttpError : " + www.error);
        else
        {
            Debug.Log("[라우터] 캐릭터 부적 내구도 변경 완료!\n" + amuletModel + "(" + duration + "/100)");
        }
    }



    /**************************************************************************************************
     * Purpose: 8. 캐릭터 부적 해금                                                                    *
     * Parameters:                                                                                    *
     * Returns: an IEnumerator                                                                        *
     **************************************************************************************************/
    private IEnumerator WWWUnlockAmulet(string amuletModel /* 부적 모델 */)
    {

        // 0. 요청 주소 생성
        string sUrl = url + "amulet/unlock";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("userCode", PlayerPrefs.GetString("USERCODE"));
        form.AddField("userAmuletModel", amuletModel);

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError) Debug.Log("isNetworkError : " + www.error);
        else if (www.isHttpError) Debug.Log("isHttpError : " + www.error);
        else
        {
            Debug.Log("[라우터] 캐릭터 부적 해금 완료!\n" + amuletModel);
        }
    }



    /**************************************************************************************************
     * Purpose: 9. 캐릭터 스톤 변경                                                                    *
     * Parameters:                                                                                    *
     * Returns: an IEnumerator                                                                        *
     **************************************************************************************************/
    private IEnumerator WWWChangeStone(string stoneModel /* 스톤 모델 */)
    {

        // 0. 요청 주소 생성
        string sUrl = url + "stone/change";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("userCode", PlayerPrefs.GetString("USERCODE"));
        form.AddField("userStoneModel", stoneModel);

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError) Debug.Log("isNetworkError : " + www.error);
        else if (www.isHttpError) Debug.Log("isHttpError : " + www.error);
        else
        {

        }
    }



    /**************************************************************************************************
     * Purpose: 10. 캐릭터 스톤 내구도 변경                                                             *
     * Parameters:                                                                                    *
     * Returns: an IEnumerator                                                                        *
     **************************************************************************************************/
    private IEnumerator WWWUpdateStoneDuration(string stoneModel /* 스톤 모델 */, int duration /* 지정 내구도 */)
    {
        // 0. 요청 주소 생성
        string sUrl = url + "stone/duration";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("userCode", PlayerPrefs.GetString("USERCODE"));
        form.AddField("userStoneModel", stoneModel);
        form.AddField("userDuration", duration);

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError) Debug.Log("isNetworkError : " + www.error);
        else if (www.isHttpError) Debug.Log("isHttpError : " + www.error);
        else
        {

        }
    }



    /**************************************************************************************************
     * Purpose: 11. 캐릭터 스톤 해금                                                                   *
     * Parameters:                                                                                    *
     * Returns: an IEnumerator                                                                        *
     **************************************************************************************************/
    private IEnumerator WWWUnlockStone(string stoneModel /* 스톤 모델 */)
    {

        // 0. 요청 주소 생성
        string sUrl = url + "stone/unlock";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("userCode", PlayerPrefs.GetString("USERCODE"));
        form.AddField("userStoneModel", stoneModel);

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError) Debug.Log("isNetworkError : " + www.error);
        else if (www.isHttpError) Debug.Log("isHttpError : " + www.error);
        else
        {

        }
    }



    /**************************************************************************************************
     * Purpose: 12. 캐릭터 스킬 변경                                                                   *
     * Parameters:                                                                                    *
     * Returns: an IEnumerator                                                                        *
     **************************************************************************************************/
    private IEnumerator WWWChangeSkill(string skillType /* 스킬 타입 rgb */, string skillModel /* 스킬 모델 */)
    {

        // 0. 요청 주소 생성
        string sUrl = url + "skill/change";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("userCode", PlayerPrefs.GetString("USERCODE"));
        form.AddField("userSkillType", skillType);
        form.AddField("userSkillModel", skillModel);

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError) Debug.Log("isNetworkError : " + www.error);
        else if (www.isHttpError) Debug.Log("isHttpError : " + www.error);
        else
        {

        }
    }



    /**************************************************************************************************
     * Purpose: 13. 캐릭터 스킬 해금                                                                   *
     * Parameters:                                                                                    *
     * Returns: an IEnumerator                                                                        *
     **************************************************************************************************/
    private IEnumerator WWWUnlockSkill(string skillType /* 스킬 타입 rgb */, string skillModel /* 스킬 모델 */)
    {

        // 0. 요청 주소 생성
        string sUrl = url + "skill/unlock";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("userCode", PlayerPrefs.GetString("USERCODE"));
        form.AddField("userSkillType", skillType);
        form.AddField("userSkillModel", skillModel);

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError) Debug.Log("isNetworkError : " + www.error);
        else if (www.isHttpError) Debug.Log("isHttpError : " + www.error);
        else
        {

        }
    }



    /**************************************************************************************************
     * Purpose: 14. 캐릭터 골드 변경 및 조회                                                            *
     * Parameters:                                                                                    *
     * Returns: an IEnumerator                                                                        *
     **************************************************************************************************/
    private IEnumerator WWWUpdateAndGetGold(int gold /* 변경할 골드 총량 */)
    {
        // 0. 요청 주소 생성
        string sUrl = url + "character/gold";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("userCode", PlayerPrefs.GetString("USERCODE"));
        form.AddField("userGold", gold);

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError) Debug.Log("isNetworkError : " + www.error);
        else if (www.isHttpError) Debug.Log("isHttpError : " + www.error);
        else
        {
            /* 플레이어 골드 = www.downloadHandler.text;*/
        }
    }



    /**************************************************************************************************
     * Purpose: 15. 캐릭터 쿠폰 변경 및 조회                                                            *
     * Parameters:                                                                                    *
     * Returns: an IEnumerator                                                                        *
     **************************************************************************************************/
    private IEnumerator WWWUpdateAndGetCoupon(int coupon /* 변경할 쿠폰 총량 */)
    {
        // 0. 요청 주소 생성
        string sUrl = url + "character/coupon";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("userCode", PlayerPrefs.GetString("USERCODE"));
        form.AddField("userGold", coupon);

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError) Debug.Log("isNetworkError : " + www.error);
        else if (www.isHttpError) Debug.Log("isHttpError : " + www.error);
        else
        {
            /* 플레이어 쿠폰 = www.downloadHandler.text;*/
        }
    }



    /**************************************************************************************************
     * Purpose: 16. 퀘스트 상태 변경                                                                   *
     * Parameters:                                                                                    *
     * Returns: an IEnumerator                                                                        *
     **************************************************************************************************/
    private IEnumerator WWWUpdateQuestState(string questModel /* 퀘스트 모델 */, string state /* 변경할 상태 enable/able/accept/success */)
    {

        // 0. 요청 주소 생성
        string sUrl = url + "quest/state";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("userCode", PlayerPrefs.GetString("USERCODE"));
        form.AddField("userQuestModel", questModel);
        form.AddField("userQuestState", state);

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError) Debug.Log("isNetworkError : " + www.error);
        else if (www.isHttpError) Debug.Log("isHttpError : " + www.error);
        else
        {

        }
    }



    /**************************************************************************************************
     * Purpose: 17. 퀘스트 아이템 수집                                                                 *
     * Parameters:                                                                                    *
     * Returns: an IEnumerator                                                                        *
     **************************************************************************************************/
    private IEnumerator WWWUpdateQuestItem(string questModel /* 퀘스트 모델 */, int questItemAmount /* 변경할 아이템 수량 */)
    {
        // 0. 요청 주소 생성
        string sUrl = url + "quest/item";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("userCode", PlayerPrefs.GetString("USERCODE"));
        form.AddField("userQuestModel", questModel);
        form.AddField("userQuestItemAmount", questItemAmount);

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError) Debug.Log("isNetworkError : " + www.error);
        else if (www.isHttpError) Debug.Log("isHttpError : " + www.error);
        else
        {

        }
    }



    /**************************************************************************************************
     * Purpose: 18. 던전 클리어 상태로 변경                                                             *
     * Parameters:                                                                                    *
     * Returns: an IEnumerator                                                                        *
     **************************************************************************************************/
    private IEnumerator WWWUpdateChapterState(string chapterName /* 챕터 키워드 */)
    {
        // 0. 요청 주소 생성
        string sUrl = url + "chapter/state";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("userCode", PlayerPrefs.GetString("USERCODE"));
        form.AddField("userChapterName", chapterName);

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError) Debug.Log("isNetworkError : " + www.error);
        else if (www.isHttpError) Debug.Log("isHttpError : " + www.error);
        else
        {

        }
    }



    /**************************************************************************************************
     * Purpose: 19. 캐릭터 삭제 요경                                                                   *
     * Parameters:                                                                                    *
     * Returns: an IEnumerator                                                                        *
     **************************************************************************************************/
    private IEnumerator WWWRemoveCaharacter(string removeUserCode)
    {
        // 0. 요청 주소 생성
        string sUrl = url + "character/remove";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("userCode", removeUserCode);

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError) Debug.Log("isNetworkError : " + www.error);
        else if (www.isHttpError) Debug.Log("isHttpError : " + www.error);
        else
        {
            GameObject.FindObjectOfType<LocalDataStorage>().RemovePlayerCharacter(removeUserCode);

            // TODO: 재접속 요청
        }
    }
}