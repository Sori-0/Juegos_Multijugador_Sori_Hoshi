using UnityEngine;
using Unity.Netcode;

public class LegionProjectile : NetworkBehaviour
{
    [SerializeField] NetworkObject _bullet;
    void CreateBullets()
    {
        NetworkObject.Instantiate( _bullet );
    }

    private void Update()
    {
        if (!IsOwner) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Disparo");
            CreateBullets();
        }
    }
}
