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

        Debug.LogError("start for id: " + id);

        // if the task is in the players tasklist, display minimap icon for task
        HUD hud = GameObject.Find("HUD").GetComponent<HUD>();
        foreach (Task t in hud.taskList) {
            Debug.LogError("t.id: " + t.id);
            if (t.id == id) {
                Debug.LogError("activated minimap for: " + id);
                minimapView.SetActive(true);
            }
        }
    }

    void Update() {
        // have the task highlight itself if it's not done
        HUD hud = GameObject.Find("HUD").GetComponent<HUD>();
        foreach (Task t in hud.taskList) {
            if (t.id == id) {
                if (!t.isComplete) {
                    GetComponent<Renderer>().material.color = Color.yellow;
                } else {
                    GetComponent<Renderer>().material.color = Color.red;
                    Debug.LogError("set false for: " + id);
                    minimapView.SetActive(false);
                }
                break;
            }
        }
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
