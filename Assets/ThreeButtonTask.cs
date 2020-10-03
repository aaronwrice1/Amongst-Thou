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
        menuRoot.SetActive(false);
    }

    private void Update() {
        
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
            Debug.LogError("Task Completed!");
            Debug.LogError("things id: " + id);
            setTaskComplete(id);
            CloseTask();
        }
    }

    override public void resetTask() {
        button1Pressed = false;
        button2Pressed = false;
        button3Pressed = false;
    }
}
