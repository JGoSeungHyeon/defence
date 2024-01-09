using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Lefthand : MonoBehaviour
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
    private XRController leftHandController;
    [SerializeField] private GameObject MenuUI;
    
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
        UpdateInput();
    }
    void UpdateInput()
    {
        m_UIPressInteractionState.activatedThisFrame = m_UIPressInteractionState.deActivatedThisFrame = false;
        MenuTrigger(ref m_UIPressInteractionState);
    }
    void MenuTrigger(ref InteractionState interactionState)
    {
        bool ispressed = false;
        leftHandController.inputDevice.IsPressed(InputHelpers.Button.SecondaryButton, out ispressed, 0.1f);

        if(ispressed)
        {
            if (!interactionState.active)
            {
                interactionState.activatedThisFrame = true;
                interactionState.active = true;
                
            }
        }
        else
        {
            if(interactionState.active)
            {
                interactionState.deActivatedThisFrame = true;
                interactionState.active = false;
                if(GameManager.instance.playerStatus != PlayerStatus.UI)
                {
                    GameManager.instance.playerStatus = PlayerStatus.UI;
                    SetMenuUI(true);
                }
                else
                {
                    GameManager.instance.playerStatus = PlayerStatus.Idle;
                    SetMenuUI(false);
                }

            }
        }
    }
    void SetMenuUI(bool onoff)
    {
        MenuUI.SetActive(onoff);
    }
}
