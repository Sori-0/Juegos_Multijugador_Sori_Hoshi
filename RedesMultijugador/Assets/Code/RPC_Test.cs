using UnityEngine;
using Unity.Netcode;

public class RPC_Test : NetworkBehaviour 
{
    private void Update()
    {
        if(!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SendMessage_ServerRPC("Hi, I am client " + OwnerClientId);
        }

    }

    [ServerRpc]
    void SendMessage_ServerRPC(string msg, ServerRpcParams rcpParams = default)
    {
        Debug.Log(msg);
        ResendMessageToAll_ClientRPC("Server is sending " + msg);
    }
    [ClientRpc]
    void ResendMessageToAll_ClientRPC(string msg, ClientRpcParams rcpParams = default)
    {
        Debug.Log("[Client]" + msg);
    }
}
