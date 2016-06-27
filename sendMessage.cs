using UnityEngine;
using System.Collections.Generic; //list

public class sendMessage : MonoBehaviour {

    public List<string> messageList = new List<string>();

    private string currentMessage = string.Empty;

    private void OnGUI()
    {
        

        GUILayout.Space(100);
        GUILayout.BeginHorizontal(GUILayout.Width(250));
        currentMessage = GUILayout.TextField(currentMessage);
        if(GUILayout.Button("Send"))
        {
            if (!string.IsNullOrEmpty(currentMessage.Trim()))
            {
                GetComponent<NetworkView>().RPC("Message", RPCMode.Server, new object[] { currentMessage });
                currentMessage = string.Empty;
            }
               
            
        }
        GUILayout.EndHorizontal();

        foreach (string str in messageList)
        {
            GUILayout.Label(str);
        }

    }

    [RPC]
    public void Message(string message)
    {
        messageList.Add(message);
    }
    
}
