using System.Globalization;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class HealthBar : NetworkBehaviour {
    [SerializeField, Range(0f, 100f)] float m_health;
    [SerializeField] Health _heath;
    NetworkObject networkObject;
    private void Awake()
    {
        networkObject = GetComponent<NetworkObject>();
        bool isOwner = networkObject.IsOwnedByServer;
    }

    private void Update() {
        if (!IsOwner) return;
        SendDamage_ServerRPC(_heath.health, 0.5f);
    }

    [ServerRpc]
    public void SendDamage_ServerRPC(float health, float damage) {
        ApplyDamage_ClientRPC(health,damage);
    }

    [ClientRpc]
    public void ApplyDamage_ClientRPC(float health, float damage ) {
        health -= damage;
    }
}
