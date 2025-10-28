using UnityEngine;
using Unity.Netcode;

public class BoneSync : NetworkBehaviour
{
    public Transform[] bones;
    public Transform[] targets;

    public TransformData[] transformDataArray;


    private void Start()
    {
        transformDataArray = new TransformData[bones.Length];
    }

    private void Update()
    {
        if (!IsOwner) return;

        for (int i = 0; i < bones.Length; i++)
        {
            transformDataArray[i].Position = bones[i].position;
            transformDataArray[i].Rotation = bones[i].rotation;
        }
        SendBoneArray_ServerRPC(transformDataArray);
    }

    

    [ServerRpc]
    void SendBoneArray_ServerRPC(TransformData[] data)
    {
        ApplayTranformArrayToAll_ClientRPC(data);
    }

    [ClientRpc]
    void ApplayTranformArrayToAll_ClientRPC(TransformData[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            targets[i].position = data[i].Position;
            targets[i].rotation = data[i].Rotation;
        }
    }

}
