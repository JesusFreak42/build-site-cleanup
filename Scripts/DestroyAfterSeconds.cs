using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{

    [SerializeField] private float destroyAfterSeconds;

    void Start()
    {
        Destroy(this.gameObject, destroyAfterSeconds);
    }
}
