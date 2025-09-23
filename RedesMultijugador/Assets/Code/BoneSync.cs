using UnityEngine;
using Unity.Netcode;

public class BoneSync : NetworkBehaviour
{
    public Transform bone;

    private void Update()
    {
        if(!IsOwner) return;

        SendBoneTranform_ServerRPC(bone.transform.position, bone.transform.rotation);

    }

    [ServerRpc]
    void SendBoneTranform_ServerRPC(Vector3 pos, Quaternion rot)
    {
        ApplyToAll_ClientRPC(pos, rot);
    }

    [ClientRpc]
    void ApplyToAll_ClientRPC(Vector3 pos, Quaternion rot)
    {
        if (IsOwner) return;

        bone.transform.position = pos;
        bone.transform.rotation = rot;
    }

}
