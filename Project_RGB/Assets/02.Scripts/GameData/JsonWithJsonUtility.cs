using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JsonWithJsonUtility : JsonConverter
{
    // Start is called before the first frame update
    void Start()
    {
        #region JsonUtility 테스팅

        //                                              1. ObjectToJson 테스트 ---> 1#
        //JsonUtilityTestClass jtc = new JsonUtilityTestClass(true);
        //string jsonData = ObjectToJsonWithJsonUtility(jtc);
        //Debug.Log(jsonData);

        //                                              2. JsonToOject 테스트 ---> 2#
        //var jtc2 = JsonToOjectWithJsonUtility<JsonUtilityTestClass>(jsonData);
        //jtc2.Print();

        //                                              3. CreateJsonFile 테스트 ---> 1#
        //JsonUtilityTestClass jtc = new JsonUtilityTestClass(true);
        //string jsonData = ObjectToJson(jtc);
        //CreateJsonFile(Application.dataPath, "JsonUtilityTestClass", jsonData);

        //                                              4. CreateJsonFile 테스트 ---> 2#
        //var jtc2 = LoadJsonFileWithJsonUtility<JsonUtilityTestClass>(Application.dataPath, "JTestClass");
        //jtc2.Print();

        //                                              JsonUtility로 MonoBehaviour를 상속받은 클래스의 오브젝트를 Serialize
        //GameObject obj = new GameObject();
        //obj.name = "TestMono 01";
        //var jd = JsonUtility.ToJson(obj.GetComponent<TestMono>());
        //Debug.Log(jd);

        //                                              MonoBehaviour를 상속받은 클래스의 오브젝트를 Deserialize 할 때,
        //                                              FromJson 메서드 대신 FromJsonOverwrite 메서드 사용.
        //                                              이 함수는 JSON 데이터를 오브젝트로 변환할 때, 새로운 오브젝트를 만들지 않고 기존에 있는 오브젝트에 클래스의 변수 값을 덮어씌우는 처리를 한다.
        //GameObject obj = new GameObject();
        //obj.name = "TestMono 01";
        //var t = obj.AddComponent<TestMono>();
        //t.i = 333;
        //t.pos = new Vector3(-939, -33, -22);
        //var jd = JsonUtility.ToJson(obj.GetComponent<TestMono>());
        //Debug.Log(jd);

        //GameObject obj2 = new GameObject();
        //obj2.name = "TestMono 02";
        //var t2 = obj2.AddComponent<TestMono>();
        //JsonUtility.FromJsonOverwrite(jd, t2);
        #endregion
    }

    /* Object ---> JSON 문자열 */
    public string ObjectToJsonWithJsonUtility(object obj)
    {
        return JsonUtility.ToJson(obj);
    }

    /* 문자열 JSON ---> 템플릿 객체 */
    public T JsonToOjectWithJsonUtility<T>(string jsonData)
    {
        return JsonUtility.FromJson<T>(jsonData);
    }
}
