using UnityEngine;
using Unity.Netcode;
public class MasterAvatarManager : NetworkBehaviour
{
    NetworkObject networkObject;
    public GameObject HostTitan, ClientTitan;
    public GameObject HostLegion, ClientLegion;

    public Transform xrHead, xrLeftHand, xrRightHand;


    private void Start()
    {
        networkObject = GetComponent<NetworkObject>();
        if(networkObject != null)
        {
            bool isOwner = networkObject.IsOwner;
            if(networkObject.OwnerClientId == 0)
            {
                if (isOwner) HostTitan.SetActive(true);
                else ClientTitan.SetActive(false);
            }
            else
            {
                if (isOwner) ClientLegion.SetActive(true);
                else HostLegion.SetActive(false);
            }
        }
    }
}
