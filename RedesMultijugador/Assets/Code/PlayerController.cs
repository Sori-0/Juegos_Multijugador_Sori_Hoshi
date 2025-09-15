using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;

public class PlayerController : NetworkBehaviour {
    public float speed = 5f;
    [SerializeField] NetworkTransform m_networkTransform;

    void Start() {
        m_networkTransform = GetComponent<NetworkTransform>();
        if (m_networkTransform == IsHost) {
            gameObject.GetComponentInChildren<Renderer>().material.color = Color.red;
        } else {
            gameObject.GetComponentInChildren<Renderer>().material.color = Color.blue;
        }
    }
    private void Update() {
        if (!IsOwner) return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(h, 0, v);

        transform.Translate(input * speed * Time.deltaTime);
    }
}
