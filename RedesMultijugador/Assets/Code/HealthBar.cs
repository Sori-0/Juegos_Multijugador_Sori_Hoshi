using TMPro;
using Unity.Netcode;
using UnityEngine;

public class HealthBar : MonoBehaviour {
    [SerializeField, Range(0f, 100f)] NetworkVariable<float> m_health;
    [SerializeField] TextMeshProUGUI m_textMeshPro;

    private void Update() {

    }

    [ServerRpc]
    void SendDamage_ServerRPC(float health, TextMeshProUGUI text, bool damagesetter) {
        
    }

    [ClientRpc]
    void ApplyDamage_ClientRPC(float health, TextMeshProUGUI text, bool damagesetter) {
        if (damagesetter) {
            health--;
        } else if (!damagesetter) {
            health++;
        }
    }
}
