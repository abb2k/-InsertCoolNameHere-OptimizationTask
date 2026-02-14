using System.Collections;
using UnityEngine;

public class ArrowHazard : MonoBehaviour
{
    public GameObject arrowPrefab;
    [SerializeField] private float shootInterval;

    private void Start()
    {
        StartCoroutine(ShootTimer());
    }

    private IEnumerator ShootTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);

            Instantiate(arrowPrefab, transform.position, Quaternion.Euler(0, 180, 0));
        }
    }
}
