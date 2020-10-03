using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// more of the tasklist
public class HUD : MonoBehaviour {

    [Tooltip("Root GameObject to be shown")]
    public GameObject menuRoot;
    
    public Text taskText;
    public List<Task> taskList = new List<Task>();

    // Start is called before the first frame update
    void Start() {
        // give player random tasks
        taskList.Add(new Task(1, false, "Take out trash yo"));
        taskList.Add(new Task(2, false, "Do other thingy"));
    }

    // Update is called once per frame
    void Update() {
         DisplayCurrentTasks();      
    }

    void DisplayCurrentTasks() {
        taskText.text = "";

        foreach (Task t in taskList) {
            string s = t.description;

            if (t.isComplete) {
                s += " - DONE";
            }

            s += "\n";
            taskText.text += s;
        }
    }

    public void completeTask(int id) {
        Debug.LogError("completeTask called!");
        Debug.LogError("real id: " + id);

        foreach (Task t in taskList) {
            if (t.id == id) {
                Debug.LogError("set to true");
                t.isComplete = true;
                return;
            }
        }
    }
}
