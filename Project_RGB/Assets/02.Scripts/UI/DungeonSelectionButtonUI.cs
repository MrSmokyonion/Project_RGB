using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSelectionButtonUI : MonoBehaviour
{
    public DungeonSelectionImageUI dungeonSelectionImageUI_Script;
    // Start is called before the first frame update
    public void DungeonSlotUpButton()
    {
        dungeonSelectionImageUI_Script.DungeonSlotUpButton();

    }

    public void DungeonSlotDownButton()
    {
        dungeonSelectionImageUI_Script.DungeonSlotDownButton();
    }
}
