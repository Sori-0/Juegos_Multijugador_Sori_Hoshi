using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class HpTitan : NetworkBehaviour
{
    [SerializeField] Slider _hpTitan;
    [SerializeField] NetworkVariable<float> titanHealth = new(1,NetworkVariableReadPermission.Everyone,NetworkVariableWritePermission.Owner);
    float Hp = 100;
    float damage = 1;

    private void Start()
    {
        _hpTitan = GameObject.FindGameObjectWithTag("SliderHealth").GetComponent<Slider>();
        _hpTitan.maxValue = Hp;
        titanHealth.Value = Hp;
    }
    public void DamageDone() {
        titanHealth.Value -= 5f;
    }
    public override void OnNetworkSpawn() {
        titanHealth.OnValueChanged += (float previousValue, float newValue) => {
            _hpTitan.value = titanHealth.Value;
        };
    }

}
