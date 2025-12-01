using UnityEngine;
using Unity.Netcode;
//En Unity, los RPC solo pueden usarse si el script es un NetworkBehaviour.
public class RPCBehabiourExample : NetworkBehaviour
{
    //Los RPC  (Remote Procedure Call) son funciones que se pueden
    //detonar desde el cliente o servidor, para "obligar" a otras instancias del juego
    //a ejecutar acciones especificas
    //Si quieres mandar un RPC al Cliente desde el Servidor es SERVER -> CLIENT
    //Si quieres mandar un RPC al Servidor desde el Cliente es Client -> SERVER -> CLIENT(S)

    //Para poder enviar RPC´s necesitamos user el tag [ServerRPC] a [ClientRPC]
    //Las funciones deben llevar el sufijo ClientRPC o ServerRPC según sea el caso

    //Ejemplo1: Llamada directa de server a todos los demas, con arguemntos

    public PlayerDataNet dataPlayer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SayHello_ServerRPC();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            dataPlayer.goldCount = 49;
            dataPlayer.killPosition = transform.position;
            SpawnWhenKilled_ServerRPC(dataPlayer);
        }
    }

    [ServerRpc]    
    void SayHello_ServerRPC()
    {
        Debug.Log("Hola soy el ejemplo 1");
        ApplayHello_ClientRPC();
    }

    [ClientRpc]
    void ApplayHello_ClientRPC()
    {
        Debug.Log("Hola, soy el cliente y estoy recibiendo el rpc del server");
    }

    //Ejemplo 2: ServerRPC con información serializada
    [ServerRpc] 
    void SpawnWhenKilled_ServerRPC(PlayerDataNet data)
    {
        ApplaySpawnLootWhenKilled_ClientRPC(data);
    }
    [ClientRpc] 
    void ApplaySpawnLootWhenKilled_ClientRPC(PlayerDataNet data)
    {
        Debug.Log("Spawn " + data.goldCount + " at " + data.killPosition);
    }

    [ClientRpc]
    void BroadcastDeadEvent_ClientRPC(PlayerDataNet data)
    {
        BroadcastToEveryone_ServerRPC(data);
    }

    [ServerRpc]
    void BroadcastToEveryone_ServerRPC(PlayerDataNet data)
    {
        ReceiveBroadcast_ClientRPC(data);
    }

    [ClientRpc]
    void ReceiveBroadcast_ClientRPC(PlayerDataNet data)
    {
        Debug.Log("Spawn " + data.goldCount + " at " + data.killPosition);
    }
}
