using System.Globalization;
using Unity.Netcode;
using UnityEngine;

public class MoveHostLegion : NetworkBehaviour
{
    public Transform[] hostLegion;
    public Transform[] clientLegion;
    [SerializeField] Transform spawner;

    TransformData1[] transformData;

    private void Start()
    {
        transformData = new TransformData1[hostLegion.Length];
        spawner = GameObject.FindGameObjectWithTag("Spawner").transform;
    }

    private void Update()
    {
        if (!IsOwner) return;

        transformData[0].Position = hostLegion[0].position;
        transformData[0].Rotation = hostLegion[0].rotation;
        SendTransformClientLegion_ServerRPC(transformData);
        
    }

    public void TPLegion() => transform.position = spawner.position;

    [ServerRpc]
    void SendTransformClientLegion_ServerRPC(TransformData1[] data)
    {
        ApplayTranformClientLegionArrayToAll_ClientRPC(data);
    }

    [ClientRpc]
    void ApplayTranformClientLegionArrayToAll_ClientRPC(TransformData1[] data)
    {
        clientLegion[0].position = data[0].Position;
        clientLegion[0].rotation = data[0].Rotation;
    }

}
