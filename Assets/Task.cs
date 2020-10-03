using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : Interactable
{
    [SerializeField]
    public int id;
    public bool isComplete = false;
    public string description = "default";

    [Tooltip("Root GameObject of the Task used to interact with Task")]
    public GameObject menuRoot;

    PlayerInputHandler m_PlayerInputsHandler;

    public Task(int id, bool isComplete) {
        this.id = id;
        this.isComplete = isComplete;
    }

    public Task(int id, bool isComplete, string description) {
        this.id = id;
        this.isComplete = isComplete;
        this.description = description;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerInputsHandler = FindObjectOfType<PlayerInputHandler>();
        DebugUtility.HandleErrorIfNullFindObject<PlayerInputHandler, ThreeButtonTask>(m_PlayerInputsHandler, this);

        menuRoot.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void setTaskComplete(int id) {
        HUD hud = GameObject.Find("HUD").GetComponent<HUD>();
        hud.completeTask(id);
    }

    override public void Interact() {
        Debug.LogError("Interacting with: " + id);
        SetDisplayMenu(!menuRoot.activeSelf);
    }

    void SetDisplayMenu(bool active) {
        menuRoot.SetActive(active);

        if (menuRoot.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            // Time.timeScale = 0f;

            // EventSystem.current.SetSelectedGameObject(null);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            // Time.timeScale = 1f;
            // AudioUtility.SetMasterVolume(1);
        }

    }

    public virtual void resetTask() {
        // implemented in subclasses
    }

    public void CloseTask()
    {
        resetTask();
        SetDisplayMenu(false);
    }
}
