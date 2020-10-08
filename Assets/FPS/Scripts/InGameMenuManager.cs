using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InGameMenuManager : MonoBehaviour
{
    [Tooltip("Root GameObject of the menu used to toggle its activation")]
    public GameObject menuRoot;

    PlayerInputHandler m_PlayerInputsHandler;

    void Start()
    {
        m_PlayerInputsHandler = FindObjectOfType<PlayerInputHandler>();
        DebugUtility.HandleErrorIfNullFindObject<PlayerInputHandler, InGameMenuManager>(m_PlayerInputsHandler, this);

        menuRoot.SetActive(false);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetButtonDown(GameConstants.k_ButtonNamePauseMenu)
            || (menuRoot.activeSelf && Input.GetButtonDown(GameConstants.k_ButtonNameCancel))) {
            SetPauseMenuActivation(!menuRoot.activeSelf);
        }

        if (menuRoot.activeSelf) {
            // draw sqaure over player?
        }
    }

    public void ClosePauseMenu()
    {
        SetPauseMenuActivation(false);
    }

    void SetPauseMenuActivation(bool active)
    {
        menuRoot.SetActive(active);

        if (!menuRoot.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
