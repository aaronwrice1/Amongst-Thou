using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;

// more of the tasklist
public class HUD : NetworkBehaviour {

    [Tooltip("Root GameObject to be shown")]
    public GameObject menuRoot;
    
    public Text taskText;
    public List<Task> taskList = new List<Task>();

    void Awake() {
        createRandomTasks();
    }

    private void createRandomTasks() {
        // give player random tasks
        int numberOfTasks = 5;
        GameObject[] allTasks = GameObject.FindGameObjectsWithTag("Task");

        List<int> taskNumbers = new List<int>();
        
        // ensure no repeated tasks
        for (int i = 0; i < numberOfTasks; i++) {
            int n = Random.Range(0, allTasks.Length);
            while (taskNumbers.Contains(n)) {
                n = Random.Range(0, allTasks.Length);
            }

            taskNumbers.Add(n);
        }

        // add selected tasks to list, and make them highlighted
        for (int i = 0; i < numberOfTasks; i++) {
            GameObject g = allTasks[taskNumbers[i]];
            Task t = g.GetComponent<Task>();
            t.minimapView.SetActive(true);
            t.GetComponent<Renderer>().material.color = Color.yellow;
            taskList.Add(t);
        }
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
         DisplayCurrentTasks();      
    }

    void DisplayCurrentTasks() {
        taskText.text = "";
        string fullText = "";
        foreach (Task t in taskList) {
            string s = t.description;
            if (t.isComplete) {
                s += " - DONE";
            }
            s += "\n";
            fullText = fullText + s;
        }
        taskText.text = fullText;
    }

    public void completeTask(int id) {
        foreach (Task t in taskList) {
            if (t.id == id) {
                t.isComplete = true;
                return;
            }
        }
    }
}
