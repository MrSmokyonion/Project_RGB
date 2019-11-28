using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCClick : MonoBehaviour
{
    public int clicknpccode;
    public Canvas npcCanvas;

    // Start is called before the first frame update
    private void Start()
    {
        npcCanvas.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NpcClick()
    {
        npcCanvas.enabled = true;
        npcCanvas.GetComponent<NPCMenuUI>().npcCode = clicknpccode;
    }

}
