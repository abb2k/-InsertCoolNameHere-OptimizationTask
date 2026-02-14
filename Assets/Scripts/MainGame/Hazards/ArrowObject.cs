using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ArrowObject : MonoBehaviour
{
    public float speed;
    public float damage;
    private bool canMove;
    private Coroutine currentMovementTimer = null;

    public event UnityAction<ArrowObject> OnMovementEnded;

    public void StartMovement(float time)
    {
        canMove = true;

        if (currentMovementTimer != null) StopCoroutine(currentMovementTimer);
        currentMovementTimer = StartCoroutine(MovementTimer(time));
    }

    private void Update()
    {
        if (!canMove) return;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private IEnumerator MovementTimer(float time)
    {
        yield return new WaitForSeconds(time);

        canMove = false;
        OnMovementEnded?.Invoke(this);

        currentMovementTimer = null;
    }
}
