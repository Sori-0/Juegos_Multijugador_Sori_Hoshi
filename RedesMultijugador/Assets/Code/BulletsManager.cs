using Unity.Netcode;
using UnityEngine;

public class BulletsManager : NetworkBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float lifeTime = 10f;
    Vector3 dir = Vector3.forward;
    float elapsedTime;
    //[SerializeField] Health _health;
    //[SerializeField] HealthBar _healthBar;

    public void Initialize(Vector3 direction)
    {
        dir = direction;
    }

    private void Update()
    {
        if (!IsServer) return;

        transform.position += dir * speed * Time.deltaTime;
        elapsedTime = Time.deltaTime;

        if(elapsedTime >= lifeTime)
        {
            if(NetworkObject != null && NetworkObject.IsSpawned)
            {
                NetworkObject.Despawn();
            }
        }

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(!IsServer) return;
    //    if (other.CompareTag("Legion"))
    //    {

    //    }
    //    else if (other.CompareTag("Titan"))
    //    {
    //        Debug.Log("Choque");
    //        other.GetComponent<HealthBar>();
    //        _healthBar.SendDamage_ServerRPC(_health.health, 0.5f);
    //    }
    //}
}
