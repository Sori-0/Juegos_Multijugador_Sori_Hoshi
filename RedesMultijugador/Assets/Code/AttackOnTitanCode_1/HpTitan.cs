using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class HpTitan : MonoBehaviour
{
    [SerializeField] Slider _hpTitan;
    float Hp = 100;
    float damage = 1;
    bool IsDamage = false;

    private void Start()
    {
        _hpTitan.maxValue = Hp;
    }

}
