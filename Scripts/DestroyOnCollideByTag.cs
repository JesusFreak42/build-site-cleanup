using UnityEngine;

public class DestroyOnCollideByTag : MonoBehaviour
{

    [SerializeField] private string[] destroyTag;

    private void OnTriggerEnter(Collider other)
    {
        foreach (string t in destroyTag) {
            if (other.gameObject.tag == t)
            {
                Destroy(other.gameObject);
            }
        }
    }

}
