using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    

    public void TogglePanel(GameObject panelToToggle)
    {
        if (panelToToggle != null)
        {
            panelToToggle.SetActive(!panelToToggle.activeSelf);
        }
    }
}
