using UnityEngine;

public class ArrowObject : MonoBehaviour
{
    public float speed;
    public float damage;
    
    [SerializeField]
    private float killTimer;

    void Start()
    {
        Destroy(gameObject, killTimer);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
