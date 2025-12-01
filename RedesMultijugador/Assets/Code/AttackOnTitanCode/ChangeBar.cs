using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeBar : NetworkBehaviour
{
    

    [ServerRpc]
    void SendDamage_ServerRPC(float health, float damage, bool damagesetter)
    {
        ApplyDamage_ClientRPC(health, damage, damagesetter);
    }

    [ClientRpc]
    void ApplyDamage_ClientRPC(float health, float damage, bool damagesetter)
    {
        
    }
}
