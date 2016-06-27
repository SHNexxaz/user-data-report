using UnityEngine;
using System.Collections;

public class CustomSerialization : MonoBehaviour {
    public float health = 100;

private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            health -= 10;
    }

private void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        if(stream.isWriting)
        {
            stream.Serialize(ref health);
        }
        else
        {
            Debug.Log("reading!");
        }
    }
}
