using System.Globalization;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : NetworkBehaviour {
    [SerializeField] Slider Healthbar;
    [SerializeField] NetworkObject networkObject;


    public void UpdateHealthBar() {

    }


    [ServerRpc]
    public void SendDamage_ServerRPC(float health) {

    }

    [ClientRpc]
    public void ApplyDamage_ClientRPC(float health) {

    }
}
