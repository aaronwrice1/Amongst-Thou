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

    public GameObject minimapView;

    public GameObject display;

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
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

    }

    public void setTaskComplete(int id) {

        GetComponent<Renderer>().material.color = Color.red;
        minimapView.SetActive(false);

        HUD hud = GameObject.Find("TaskList").GetComponent<HUD>();
        hud.completeTask(id);
    }

    public virtual void resetTask() {
        // implemented in subclasses
    }

    public void showCursor() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void hideCursor() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    public void CloseTask() {
        hideCursor();
        Destroy(display);
    }
}
