using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Lefthand : MonoBehaviour
{
    internal struct InteractionState
    {
        /// <summary>This field is true if it is is currently on.</summary>
        public bool active;
        /// <summary>This field is true if the interaction state was activated this frame.</summary>
        public bool activatedThisFrame;
        /// <summary>This field is true if the interaction state was de-activated this frame.</summary>
        public bool deActivatedThisFrame;
    }
    InteractionState m_UIPressInteractionState;
    private XRController leftHandController;
    private void Start()
    {
        leftHandController = GetComponent<XRController>();
        if(leftHandController == null)
        {
            Debug.Log("왼쪽 컨트롤러가 없습니다.");
        }
    }
    // Update is called once per frame
    void Update()
    {
        MenuTrigger(m_UIPressInteractionState);
        Debug.Log(m_UIPressInteractionState.active);
    }
    void UpdateInput()
    {
        m_UIPressInteractionState.activatedThisFrame = m_UIPressInteractionState.deActivatedThisFrame = false;
    }
    void MenuTrigger(InteractionState interactionState)
    {
        bool ispressed = false;
        leftHandController.inputDevice.IsPressed(InputHelpers.Button.SecondaryButton, out ispressed, -1f);

        if(ispressed)
        {
            if (!interactionState.active)
            {
                interactionState.activatedThisFrame = true;
                interactionState.active = true;
                Debug.Log("작동!");
            }
        }
        else
        {
            if (interactionState.active)
            {
                interactionState.activatedThisFrame = true;
                interactionState.active = false;
                
            }
        }
    }
}
