using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**************************************************************************************************
 *      로컬 데이터 저장 항목
 *      
 *      - 유저코드 (string) - init
 *      - 소리 음소거 여부 (int) - init, option
 *      - 소리 볼륨값 (int) - init, option
 *      - 위치 장소 (string) - repeat
 *      - 위치값 (vector) - repeat
 *      - 최초 로그인 시간 (string) - init
 *      - 최근 로그인 시간 (string) - repeat
 *      
 **************************************************************************************************/

public class LocalDataStorage : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SavePlayerLocalData", 1.0f, 1.0f); // TEST
        PrintLocalData();                                   // TEST
    }

    // 주기적인 저장
    private void SavePlayerLocalData(Vector3 pos) // 플레이어에서 해당 스크립트로 요청하기로 함. (동현-태현)
    {
        PlayerPrefs.SetString("RECENT_TIME", System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
        PlayerPrefs.SetString("POSITION", "No Data");
        PlayerPrefs.SetFloat("X", pos.x);
        PlayerPrefs.SetFloat("Y", pos.y);
        PlayerPrefs.SetFloat("Z", pos.z);
    }

    // 캐릭터 생성
    public void InitPlayerLocalData(string userCode)
    {
        PlayerPrefs.SetString("USERCODE", userCode); // #00000000
        PlayerPrefs.SetString("START_TIME", System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
        PlayerPrefs.SetInt("MUTE", 1); // true : 1
        PlayerPrefs.SetInt("VOLUME", 50); // 1 ~ 100
    }

    // 다른 계정으로 로그인
    public void ChangePlayerCharater(string userCode)
    {
        PlayerPrefs.SetString("USERCODE", userCode);
    }

    // 캐릭터 제거
    public void RemovePlayerCharacter(string removeUserCode)
    {
        if (PlayerPrefs.GetString("USERCODE") == removeUserCode)
        {
            PlayerPrefs.DeleteKey("USERCODE");
        }
    }

    // 옵션 설정
    public void SetOptionLocalData(int mute, int volume)
    {
        PlayerPrefs.SetInt("MUTE", mute);
        PlayerPrefs.SetInt("VOLUME", volume);
    }

    // 던전 선택 데이터 저장
    public void SaveSelectedDungeonNum(int dungeonNum /* 0:Tutorial, 1:Chapter1, 2:Chapter2 ... */ )
    {
        PlayerPrefs.SetInt("DUNGEON_NUM", dungeonNum);
    }

    // 로컬 데이터 출력
    public void PrintLocalData()
    {
        Debug.Log(""
            + "유저코드: " + PlayerPrefs.GetString("USERCODE") + "\n"
            + "음소거(0/1): " + PlayerPrefs.GetInt("MUTE") + "\n"
            + "볼륨: " + PlayerPrefs.GetInt("VOLUME") + "\n"
            + "최종위치: " + PlayerPrefs.GetString("POSITION") + "\n"
            + "최종좌표: " + PlayerPrefs.GetFloat("X") + "," + PlayerPrefs.GetFloat("Y") + "," + PlayerPrefs.GetFloat("Z") + "\n"
            + "최초시간: " + PlayerPrefs.GetString("START_TIME") + "\n"
            + "최근시간: " + PlayerPrefs.GetString("RECENT_TIME") + "\n"
            + "선택던전번호: " + PlayerPrefs.GetInt("DUNGEON_NUM")
            );
    }
}