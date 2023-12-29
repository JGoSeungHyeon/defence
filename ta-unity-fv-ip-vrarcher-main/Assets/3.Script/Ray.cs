using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine.XR.Interaction.Toolkit.UI;
using UnityEngine.XR;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;

public class Ray : XRRayInteractor
{
    GameObject CurrentObject;
    private void Update()
    {
        if (GameManager.instance.playerStatus == PlayerStatus.Search)
        {
            RaycastHit raycasthit;
            if (GetCurrentRaycastHit(out raycasthit))
            {
                if (CurrentObject != null && CurrentObject != raycasthit.collider.gameObject)
                {
                    SelectArea selectArea = CurrentObject.GetComponent<SelectArea>();
                    if (selectArea != null)
                    {
                        selectArea.SetStatusNone();
                    }
                    CurrentObject = raycasthit.collider.gameObject;
                }
                if (raycasthit.collider.gameObject.layer == 14)
                {
                    CurrentObject = raycasthit.collider.gameObject;
                    SelectArea selectArea = CurrentObject.GetComponent<SelectArea>();
                    if (selectArea != null)
                    {
                        selectArea.SetStatusOutline();
                    }
                }
            }
        }

    }
}
