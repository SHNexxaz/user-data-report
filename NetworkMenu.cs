using UnityEngine;
using System.Collections;

public class NetworkMenu : MonoBehaviour {

    public string connectionIP = "127.0.0.1"; //local host
    public int portNumber = 8632;             //a ridiculous port number so won't have confliction 

    private bool connected = false;
    public static bool Connected { get; private set;}

    private void OnConnectedToServer()
    {
        connected = true;
    }

    private void OnServerInitialized()
    {
        connected = true;
    }

    private void OnDisconnectedFromServer()
    {
        connected = false;
    }

    private void OnGUI()
    {
        if (!connected)
        {
            connectionIP = GUILayout.TextField(connectionIP);
            int.TryParse(GUILayout.TextField(portNumber.ToString()), out portNumber);


            if (GUILayout.Button("connect"))
                Network.Connect(connectionIP, portNumber);

            if (GUILayout.Button("host"))
                Network.InitializeServer(8, portNumber, true); //8 is how many users can join the server at same time
            //user nat punch through
        }

        else
        {
            GUILayout.Label("Connections: " + Network.connections.Length.ToString());
        }

    }
}


