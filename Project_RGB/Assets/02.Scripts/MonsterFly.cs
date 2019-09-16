using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFly : MonsterParent
{
    private void Start()
    {
        myMonsterRigid.gravityScale = 0f;
    }

    void Update()
    {
        if (myMonsterCode == MonsterCode.FLY_MONSTER_1)    //과일 박쥐. 범위에 들어오면 따라다님.
        {

        }
    }
}
