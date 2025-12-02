using UnityEngine;
using Unity.Netcode;
public class MasterAvatarManager2 : NetworkBehaviour
{
    NetworkObject networkObject;
    public GameObject HostTitan, ClientTitan;
    public GameObject HostLegion, ClientLegion;

    public Transform xrHead, xrLeftHand, xrRightHand;
    bool isOwnerByServer;

    HealthBar healthBar;
    [SerializeField] Health _heath;

    private void Start()
    {
        networkObject = GetComponent<NetworkObject>();
        healthBar = GetComponent<HealthBar>();
        if(networkObject != null)
        {
            bool isOwner = networkObject.IsOwner;
            isOwnerByServer = networkObject.IsOwnedByServer;
            if(networkObject.OwnerClientId == 0)
            {
                if (isOwner) HostTitan.SetActive(true);
                else ClientTitan.SetActive(true);
            }
            else
            {
                if (isOwner) ClientLegion.SetActive(true);
                else HostLegion.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bala") && isOwnerByServer)
        {
            healthBar.SendDamage_ServerRPC(_heath.health, 0.5f);
        }
        if (other.CompareTag("BalaTitan"))
        {
            
        }
    }

}
