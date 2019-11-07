using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCClick : MonoBehaviour
{
    public int clicknpccode;
    public Canvas npcCanvas;

    //커밋용 주석
    // Start is called before the first frame update
    private void Start()
    {
        npcCanvas.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void NpcClick()
    {
        npcCanvas.enabled = true;
        npcCanvas.GetComponent<NPCMenuUI>().npcCode = clicknpccode;
    }

}
