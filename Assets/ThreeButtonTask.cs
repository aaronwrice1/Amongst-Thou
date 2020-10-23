using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

// The minigame is to select all buttons
public class ThreeButtonTask : Task {

    public bool button1Pressed = false;
    public bool button2Pressed = false;
    public bool button3Pressed = false;

    public ThreeButtonTask(int id, bool isComplete) : base(id, isComplete) {
        // not needed yet
    }

    void Start() {

    }

    void Update() {

    }

    override public void Interact() {
        Debug.LogError("calling interact!!");

        // only allow interaction if user has task
        if (GetComponent<Renderer>().material.color != Color.yellow) {
            return;
        }
        
        // display ui for task
        display = Instantiate(menuRoot, new Vector3(0,0,0), Quaternion.identity);

        // setup buttons to call functions
        Button[] buttons = display.GetComponentsInChildren<Button>();
        foreach (Button b in buttons) {
            switch (b.name) {
                case "Button1":
                    b.onClick.AddListener(delegate { setButton1On(); });
                    break;
                case "Button2":
                    b.onClick.AddListener(delegate { setButton2On(); });
                    break;
                case "Button3":
                    b.onClick.AddListener(delegate { setButton3On(); });
                    break;
                case "CloseButton":
                    b.onClick.AddListener(delegate { CloseTask(); });
                    break;
                default:
                    Debug.LogError("No case to handle button called: " + b.name);
                    break;
            }
        }

        showCursor();
    }

    public void setButton1On() {
        button1Pressed = true;
        checkIfTaskIsComplete();
    }

    public void setButton2On() {
        button2Pressed = true;
        checkIfTaskIsComplete();
    }

    public void setButton3On() {
        button3Pressed = true;
        checkIfTaskIsComplete();
    }

    private void checkIfTaskIsComplete() {
        if (button1Pressed && button2Pressed && button3Pressed) {
            // task completed!
            setTaskComplete(id);

            CloseTask();
        }
    }

}
