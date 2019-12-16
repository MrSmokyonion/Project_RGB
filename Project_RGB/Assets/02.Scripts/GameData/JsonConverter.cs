using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;           // JSON의 직렬화를 사용하기 위한 dll 파일

/**************************************************************************************************
 * *** Unity에서 JSON 사용
 * 
 * Newtonsoft.json와 유니티의 JsonUtility 혼용 사용
 * 
 * *** Newtonsoft
 * 
 * - Monobehaviour를 상속한 클래스를 Serialize 및 Deserialize에 에러를 발생시킨다.
 * - Unity 내부 데이터 타입 사용 시 불필요한 데이터 발생
 * 
 * *** Unity에 내장된 JsonUtility
 * 
 * - Dictionary에 대한 Serialize 및 Deserialize를 지원하지 않는다.
 * - Unity 고유 데이터 타입(vector 등)을 간단히 표현할 수 있다.
 * - Self reference loop 문제를 발생시키지 않는다.
 * - 게임 오브젝트를 불러오는 것이 아니라 GetComponent 등으로 클래스를 가져와 Serialize 해야한다.
 * 
 **************************************************************************************************/

public class JsonConverter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // 문자열로 만든 JSON 데이터를 파일로 저장
    protected void CreateJsonFile(string createPath, string fileName, string jsonData)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, fileName), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    // 저장된 JSON 파일을 읽어들여 오브젝트로 변환
    protected T LoadJsonFile<T>(string loadPath, string fileName)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonData = Encoding.UTF8.GetString(data);

        return JsonConvert.DeserializeObject<T>(jsonData);
    }
}
