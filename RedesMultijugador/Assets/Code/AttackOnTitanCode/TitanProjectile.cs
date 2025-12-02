using Unity.Netcode;
using UnityEngine;

public class TitanProjectile : NetworkBehaviour
{
    [SerializeField] NetworkObject _bullet;
    void CreateBullets()
    {
        NetworkObject.Instantiate(_bullet);
    }

    private void Update()
    {
        if (!IsOwner) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Disparo");
            for(int i = 0; i <= 3; i++)
            {
                CreateBullets();
            }
        }
    }
}
