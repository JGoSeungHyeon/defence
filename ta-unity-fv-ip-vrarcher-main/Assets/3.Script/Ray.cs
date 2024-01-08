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
    struct InteractionState
    {
        /// <summary>This field is true if it is is currently on.</summary>
        public bool active;
        /// <summary>This field is true if the interaction state was activated this frame.</summary>
        public bool activatedThisFrame;
        /// <summary>This field is true if the interaction state was de-activated this frame.</summary>
        public bool deActivatedThisFrame;
    }
    InteractionState m_UIPressInteractionState = new InteractionState();
    private XRController rightHandController;
    private new void Start()
    {
        rightHandController = GetComponent<XRController>();
        if (rightHandController == null)
        {
            Debug.Log("오른쪽 컨트롤러가 없습니다.");
        }
    }
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
                        UpdateInput();
                    }
                }
            }
        }
        if (GameManager.instance.playerStatus == PlayerStatus.UI)
        {
            RaycastHit raycasthit;
            if (GetCurrentRaycastHit(out raycasthit))
            {
                Debug.Log(raycasthit);
            }
        }
    }
    void UpdateInput()
    {
        m_UIPressInteractionState.activatedThisFrame = m_UIPressInteractionState.deActivatedThisFrame = false;
        SelectArea(ref m_UIPressInteractionState);
    }
    void SelectArea(ref InteractionState interactionState)
    {
        bool ispressed = false;
        rightHandController.inputDevice.IsPressed(InputHelpers.Button.Trigger, out ispressed, 0.1f);

        if (ispressed)
        {
            if (!interactionState.active)
            {
                interactionState.activatedThisFrame = true;
                interactionState.active = true;
            }
        }
        else
        {
            if (interactionState.active)
            {
                interactionState.deActivatedThisFrame = true;
                interactionState.active = false;
                SetBlockSelect();
            }
        }
    }
    void SetBlockSelect()
    {
        SelectArea selectArea = CurrentObject.GetComponent<SelectArea>();
        selectArea.SetStatusSelect();
        GameManager.instance.playerStatus = PlayerStatus.Select;
    }
}
