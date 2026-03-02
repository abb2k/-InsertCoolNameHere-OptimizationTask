using UnityEngine;
using UnityEngine.Events;

public class FireHazard : MonoBehaviour
{
    private const string PLAYER_TAG = "PlayerCharacter";
    public event UnityAction<FireEnteredEventArgs> onCharacterEnteredAction;
    
    [HideInInspector] public FireHazardScriptableObject fireHazardData;

    [SerializeField] private UnityEvent<FireEnteredEventArgs> onCharacterEntered;

    public void SetScriptableData(FireHazardScriptableObject fireHazardScriptableObject)
    {
        fireHazardData = fireHazardScriptableObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(PLAYER_TAG)) return;

        FireEnteredEventArgs fireEnteredEventArgs = new FireEnteredEventArgs
        {
            damageDealt = fireHazardData.GetRandomFireDamage(),
            targetCharacterController = other.GetComponent<PlayerCharacterController>()
        };
        onCharacterEntered?.Invoke(fireEnteredEventArgs);
        onCharacterEnteredAction.Invoke(fireEnteredEventArgs);
    }
}

public class FireEnteredEventArgs
{
    public int damageDealt;
    public PlayerCharacterController targetCharacterController;
}
