using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;           // JSON의 직렬화를 사용하기 위한 dll 파일


public class JsonWithNewtonsoft : JsonConverter
{
    // Start is called before the first frame update
    void Start()
    {
        #region Newtonsoft 테스팅

        //                                                  1. 시리얼라이즈 테스트
        //NewtonsoftTestClass jtc = new NewtonsoftTestClass(true); 
        //string jsonData = ObjectToJsonWithNewtonsoft(jtc);
        //Debug.Log(jsonData);

        //                                                  2. 디시리얼라이즈 테스트
        //var jtc2 = JsonToOjectWithNewtonsoft<NewtonsoftTestClass>(jsonData);
        //jtc2.Print();

        //                                                  3. 파일화테스트
        //NewtonsoftTestClass jtc = new NewtonsoftTestClass(true);
        //string jsonData = ObjectToJsonWithNewtonsoft(jtc);
        //CreateJsonFile(Application.dataPath, "JTestClass", jsonData);

        //                                                  4. 파일 로드
        //var jtc2 = LoadJsonFile<NewtonsoftTestClass>(Application.dataPath, "JTestClass");
        //jtc2.Print();

        #endregion
    }

    // 오브젝트를 문자열로 된 JSON 데이터로 변환처리
    public string ObjectToJsonWithNewtonsoft(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    // 문자열로 된 JSON 데이터를 받아서 원하는 타입의 객체(템플릿)으로 반환처리
    public T JsonToOjectWithNewtonsoft<T>(string jsonData)
    {
        return JsonConvert.DeserializeObject<T>(jsonData);
    }
}
