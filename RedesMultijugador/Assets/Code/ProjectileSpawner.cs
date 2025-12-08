using Unity.Netcode;
using UnityEngine;

public class ProjectileSpawner1 : NetworkBehaviour
{
    [SerializeField] NetworkObject titanPrefab;
    [SerializeField] NetworkObject bulletPrefab; 
    NetworkObject _player;
    [SerializeField] Transform titanSpawnPoint;
    [SerializeField] Transform legionSpawnPoint;

    private void Start()
    {
        _player = GetComponent<NetworkObject>();
    }

    private void Update()
    {
        if (!IsOwner) return;
        if (Input.GetMouseButtonDown(0) && _player.OwnerClientId == 0)
        {
            Vector3 pos = titanSpawnPoint ? titanSpawnPoint.position : transform.position + transform.forward * 2f;
            Quaternion rot = titanSpawnPoint ? titanSpawnPoint.rotation : transform.rotation;
            Vector3 dir = rot * Vector3.forward;

            SpawnProjectileTitanServerRpc(pos, rot, dir);
        }
        else if(Input.GetMouseButtonDown(0) && _player.OwnerClientId == 1)
        {
            Vector3 pos = legionSpawnPoint ? legionSpawnPoint.position : transform.position + transform.forward * 2f;
            Quaternion rot = legionSpawnPoint ? legionSpawnPoint.rotation : transform.rotation;
            Vector3 dir = rot * Vector3.forward;

            SpawnProjectileLegionServerRpc(pos, rot, dir);
        }
    }

    [ServerRpc]
    void SpawnProjectileTitanServerRpc(Vector3 pos, Quaternion rot, Vector3 dir, ServerRpcParams _ = default)
    {
        var proj = Instantiate(titanPrefab, pos, rot);
        var simple = proj.GetComponent<BulletsManager1>();
        if (simple != null) simple.Initialize(dir);
        proj.Spawn();
    }
    [ServerRpc]
    void SpawnProjectileLegionServerRpc(Vector3 pos, Quaternion rot, Vector3 dir, ServerRpcParams _ = default)
    {
        var proj = Instantiate(bulletPrefab, pos, rot);
        var simple = proj.GetComponent<BulletsManager1>();
        if (simple != null) simple.Initialize(dir);
        proj.Spawn();
    }
}
