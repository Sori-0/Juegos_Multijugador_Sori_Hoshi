using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit");
        }
    }
}
