// * ToolTipUtility.cs
// * AUTHOR: Rica Feng
// * DESCRIPTION:
// *    Contains general information about the display of all tooltips
// * REQUIREMENTS:
// *    Attach to Tooltips UI Object.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToolTipUtility : Singleton<ToolTipUtility>
{
    private Dictionary<string, GameObject> _AllTooltips = new Dictionary<string, GameObject>();
    public Dictionary<string, GameObject> AllTooltips
    {
        get { return _AllTooltips; }
        private set { _AllTooltips = value; }
    }

    /// <summary>
    /// How far away tooltip corner is from the mouse cursor
    /// </summary>
    public float TooltipOffset = 50;

    private Vector3 LastToolTipPosition;

    void Awake()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            Transform tool_tip = transform.GetChild(i);
            AllTooltips.Add(tool_tip.name, tool_tip.gameObject);
            tool_tip.gameObject.SetActive(false);
        }
    }


    /// <summary>
    /// Hide all tooltips
    /// </summary>
    public void HideAllToolTips()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Hide a specific tool tip
    /// </summary>
    public void HideToolTip(string tooltip_name)
    {
        AllTooltips[tooltip_name].SetActive(false);
        LastToolTipPosition = Vector3.zero;
    }

    /// <summary>
    /// Show tooltip and pass in information
    /// </summary>
    public void ShowToolTip(CelestialBody celest_body)
    {
        Celest data = celest_body.GetCelest();
        Text[] list = AllTooltips["Celest"].transform.GetComponentsInChildren<Text>();

        foreach (Text element in list)
        {
            switch (element.gameObject.name)
            {
                case "Title":
                    element.text = data.name;
                    break;
                case "Type":
                    element.text = data.GetType().ToString();
                    break;
                case "Description":
                    element.text = data.GetDescription();
                    break;
                case "Purchase Cost":
                    element.text = data.purchaseCost.ToString();
                    break;
                case "Use Cost":
                    element.text = data.playCost.ToString();
                    break;
                case "Usage":
                    if ((celest_body is CometBody || celest_body is AsteroidBody) && celest_body.isLocked)
                        element.text = "[Left Click to launch projectile]";
                    else if (celest_body is CometBody || celest_body is PlanetBody && !celest_body.isLocked && celest_body.owner != null)
                        element.text = "[Drag to your Galaxy to place this Celestial]";
                    else if (celest_body is SpecialBody || celest_body is DustBody)
                        element.text = "[Left Click to gain effect]";
                    else if (celest_body is PlanetBody && celest_body.owner != null)
                        element.text = "[Locked]";
                    else if (celest_body.owner == null)
                        element.text = "[Left Click to Purchase]";
                    break;
                default:
                    throw new System.Exception("Could not find usage text.");
                    
            }
        }
        AllTooltips["Celest"].SetActive(true);
        StartCoroutine("MoveToolTip", AllTooltips["Celest"]);
    }

    /// <summary>
    /// Show tooltip and pass in information
    /// </summary>
    public void ShowGeneralToolTip(string info)
    {
        Text[] list = AllTooltips["General"].transform.GetComponentsInChildren<Text>();

        foreach (Text element in list)
        {
            switch (element.gameObject.name)
            {
                case "Info":
                    element.text = info;
                    break;
            }
        }
        AllTooltips["General"].SetActive(true);
        StartCoroutine("MoveToolTip", AllTooltips["General"]);
    }


    /// <summary>
    /// Move ToolTip
    /// </summary>
    /// <returns></returns>
    public IEnumerator MoveToolTip(GameObject active_tooltip)
    {
        RectTransform tooltip_rect = active_tooltip.GetComponent<RectTransform>();

        while(active_tooltip.activeInHierarchy)
        {
            if (Input.mousePosition != LastToolTipPosition)
            {
                //Change position of tooltip, depending on location of mouse
                if (Input.mousePosition.y < Screen.height / 2)
                {
                    if (Input.mousePosition.x < Screen.width / 2)
                    {
                        tooltip_rect.position =
                            new Vector2(Input.mousePosition.x + tooltip_rect.rect.width / 2 + TooltipOffset,
                            Input.mousePosition.y + tooltip_rect.rect.height / 2 + TooltipOffset);
                    }
                    else
                    {
                        tooltip_rect.position =
                            new Vector2(Input.mousePosition.x - tooltip_rect.rect.width / 2 - TooltipOffset,
                            Input.mousePosition.y + tooltip_rect.rect.height / 2 + TooltipOffset);
                    }

                }
                else
                {
                    if (Input.mousePosition.x < Screen.width / 2)
                    {
                        tooltip_rect.position =
                            new Vector2(Input.mousePosition.x + tooltip_rect.rect.width / 2 + TooltipOffset,
                            Input.mousePosition.y - tooltip_rect.rect.height / 2 - TooltipOffset);
                    }
                    else
                    {
                        tooltip_rect.position =
                            new Vector2(Input.mousePosition.x - tooltip_rect.rect.width / 2 - TooltipOffset,
                            Input.mousePosition.y - tooltip_rect.rect.height / 2 - TooltipOffset);
                    }
                }
                LastToolTipPosition = Input.mousePosition;
            }
            yield return null;
        }
        
    }
}