using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGeneralToolTip : MonoBehaviour
{
    [TextArea]
    public string Info = "";

    public void StartGeneralToolTip()
    {
        ToolTipUtility.Instance.ShowGeneralToolTip(Info);
    }

    public void EndGeneralToolTip()
    {
        ToolTipUtility.Instance.HideToolTip("General");
    }
}
