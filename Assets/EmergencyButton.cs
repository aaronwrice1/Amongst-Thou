using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyButton : Interactable
{

    override public void Interact() {
        // isInteracting = true;
        Debug.Log("Emergency Button Pressed");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (isInteracting) {
        //     // user left mouse click on object
        //     if (Input.GetMouseButtonDown(0)) {
        //         Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        //         RaycastHit hit;

        //         if (Physics.Raycast(ray, out hit, 3f)) {
        //             if (hit.transform.name == "Emergency Button") {
        //                 Debug.Log( "Tapping Emergency button");
        //             }
        //         }
        //     }
        // }
    }
}
