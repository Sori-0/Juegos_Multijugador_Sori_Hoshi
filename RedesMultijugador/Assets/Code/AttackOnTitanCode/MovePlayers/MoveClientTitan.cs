using System.Globalization;
using Unity.Netcode;
using UnityEngine;

public class MoveClientTitan : NetworkBehaviour
{
    public Transform[] hostTitan;
    public Transform[] clientTitan;

    TransformData1[] transformData;

    private void Start()
    {
        transformData = new TransformData1[hostTitan.Length];
    }

    private void Update()
    {
        if (!IsOwner) return;

        transformData[0].Position = hostTitan[0].position;
        transformData[0].Rotation = hostTitan[0].rotation;        
        SendTransformClientTitan_ServerRPC(transformData);
    }


    [ServerRpc]
    void SendTransformClientTitan_ServerRPC(TransformData1[] data)
    {
        ApplayTranformClientTitanArrayToAll_ClientRPC(data);
    }

    [ClientRpc]
    void ApplayTranformClientTitanArrayToAll_ClientRPC(TransformData1[] data)
    {
        clientTitan[0].position = data[0].Position;
        clientTitan[0].rotation = data[0].Rotation;
    }

}
