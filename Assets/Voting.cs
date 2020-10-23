using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Voting : NetworkBehaviour
{
    [SyncVar]
    public int test = 0;
    
    public GameObject votingScreen;

    // Start is called before the first frame update
    void Start() {
        // generate buttons based on how many people are connected
        // allow buttons to 
    }

    // Update is called once per frame
    void Update() {
        
    }

    [Command]
    public void CmdIncrementButton() {
        test += 1;
        Debug.LogError("test: " + test);
    }

    [Command]
    public void CmdDisplayVotingScreen() {
        // add correct number of players to the voting screen here
        GameObject screen = Instantiate(votingScreen, new Vector3(0, 0, 0), Quaternion.identity);
        NetworkServer.Spawn(screen);

        RpcStartMeeting();
    }

    [ClientRpc]
    public void RpcStartMeeting() {
        
        // teleport player to cafe here (will teleport all plyaers since this rpc is ran on all clients)


        // lock everyone's screen
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
