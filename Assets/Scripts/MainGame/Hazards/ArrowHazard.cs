using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class ArrowHazard : MonoBehaviour
{
    public GameObject arrowPrefab;
    [SerializeField] private float shootInterval;
    private ObjectPool<ArrowObject> arrowsPool;
    [SerializeField] private float poolArrowAfter;
    [SerializeField] private int maxArrowPoolSize;

    void Awake()
    {
        arrowsPool = new ObjectPool<ArrowObject>(
            createFunc: CreateArrow,
            actionOnGet: OnTakeArrowFromPool,
            actionOnRelease: OnReturnArrowToPool,
            actionOnDestroy: DestroyArrow,
            defaultCapacity: maxArrowPoolSize,
            maxSize: maxArrowPoolSize
        );
    }

    private ArrowObject CreateArrow()
    {
        var newArrow = Instantiate(arrowPrefab, transform.position, Quaternion.Euler(0, 180, 0)).GetComponent<ArrowObject>();
        newArrow.gameObject.SetActive(false);
        newArrow.OnMovementEnded += OnArrowStoppedMovement;
        return newArrow;
    }

    private void OnTakeArrowFromPool(ArrowObject arrow)
    {
        arrow.transform.position = transform.position;
        arrow.transform.rotation = Quaternion.Euler(0, 180, 0);
        arrow.gameObject.SetActive(true);
    }

    private void DestroyArrow(ArrowObject arrow)
    {
        Destroy(arrow.gameObject);
    }

    private void OnReturnArrowToPool(ArrowObject arrow)
    {
        arrow.gameObject.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(ShootTimer());
    }

    private IEnumerator ShootTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);

            var arrow = arrowsPool.Get();
            arrow.StartMovement(poolArrowAfter);
        }
    }

    private void OnArrowStoppedMovement(ArrowObject arrow)
    {
        arrowsPool.Release(arrow);
    }
}
