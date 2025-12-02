using UnityEngine;
using UnityEngine.UI;

public class ChangeHealthBar : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] Scrollbar _scrollHelath;

    private void Update()
    {
        _scrollHelath.size = _health.health;
    }

}
