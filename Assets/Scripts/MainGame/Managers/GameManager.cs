using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public PlayerCharacterController playerCharacterController;
    [SerializeField] private FireHazardScriptableObject[] fireHazardScriptableObjects;
    [SerializeField] private FireHazard[] fireHazards;

    private void Start()
    {
        foreach (FireHazard fireHazard in fireHazards)
        {
            fireHazard.SetScriptableData(
                fireHazardScriptableObjects[Random.Range(0, fireHazardScriptableObjects.Length)]
            );
            fireHazard.onCharacterEnteredAction += HandleCharacterEnteredFire;
        }
    }

    public void HandleCharacterEnteredFire(FireEnteredEventArgs args)
    {
        args.targetCharacterController.TakeDamage(args.damageDealt);
    }
}
