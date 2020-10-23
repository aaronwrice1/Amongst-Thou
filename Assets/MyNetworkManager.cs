using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager {

    public GameObject killerPrefab;

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId) {

        // make all other players besides the first an imposter
        // just for testing purposes 

        Debug.LogError("num players: " + numPlayers);

        if (numPlayers > 0) {
            Debug.LogError("Killer added");
            var player = (GameObject)GameObject.Instantiate(killerPrefab, startPositions[numPlayers].position, Quaternion.identity);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        } else {
            Debug.LogError("player added");

            var player = (GameObject)GameObject.Instantiate(playerPrefab, startPositions[0].position, Quaternion.identity);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
    }
}
