using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/*
 * HTTP 웹서버에 통신하는 클래스입니다.
 */

public enum DataType
{
    PLAYER_ALL_DATA
}

//public class Player
//{
//    public int power;
//    public float health;
//}

public class NetworkRouter : MonoBehaviour
{

    private const string ip = "172.16.36.188";      // IP
    private const int port = 3000;                  // Port
    private string url;                             // Uniform Resource Locator
    private string uri;                             // Uniform Resource Identifier

    //public Player UserCharacter = new Player();


    // Start is called before the first frame update
    void Start()
    {
        url = "http://" + ip + ":" + port + "/";
        uri = FindPlayerUri();

        //TEST
        //DataRouter(UserCharacter, DataType.PLAYER_ALL_DATA);
    }

    private string FindPlayerUri()
    {
        // TODO : 각 플레이어의 고유 ID를 구하는 로직이 들어갑니다.

        return "#000001";
    }

    // "DataType"에 따라 전송패킷을 분기
    public bool DataRouter(object target, DataType type)
    {
        switch (type)
        {
            case DataType.PLAYER_ALL_DATA:
                StartCoroutine(RequestPlayerAllData(target));
                break;
        }
        return true;
    }

    // "PLAYER_ALL_DATA"에 해당되는 분기 메서드
    private IEnumerator RequestPlayerAllData(object target)
    {
        // Player player = (Player)target;
        string sUrl = url + "PlayerAllData"; // "http://172.16.36.188:3000/PlayerAllData";

        // 1. 요청 데이터 구성
        WWWForm form = new WWWForm();
        form.AddField("PlayerCode", uri);

        // 2. 연결
        UnityWebRequest www = UnityWebRequest.Post(sUrl, form);
        www.chunkedTransfer = false;

        // 3. 요청
        yield return www.SendWebRequest();

        // 4. 응답
        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else if (www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string[] datas = www.downloadHandler.text.Split('@');
            foreach (string document in datas)
            {
                string[] doc = document.Split(':'); // Certainly 2-size

                switch (doc[0])
                {
                    case "Attack": /*player.power = int.Parse(doc[1]);*/ break;
                    case "Health": /*player.health = int.Parse(doc[1]);*/ break;
                }
            }
            //Debug.Log(player.power);
            //Debug.Log(player.health);

            //target = player;

            //Debug.Log(UserCharacter.power);
            //Debug.Log(UserCharacter.health);
        }
    }
}
