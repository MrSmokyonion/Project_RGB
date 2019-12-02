using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOutManager : MonoBehaviour
{
    public void FadeInPlay()
    {
        GetComponent<Animator>().SetBool("IsFadeIn",true);
    }
    public void FadeOutPlay()
    {
        GetComponent<Animator>().SetBool("IsFadeIn", false);
    }
}
