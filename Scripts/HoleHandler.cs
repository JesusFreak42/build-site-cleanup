using UnityEngine;

public class HoleHandler : MonoBehaviour
{

    [SerializeField] private int stableLayer, fallingLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == stableLayer)
        {
            other.gameObject.layer = fallingLayer;

            if (other.gameObject.GetComponent<Rigidbody>() && other.gameObject.GetComponent<Rigidbody>().isKinematic)
            {
                other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }

            if (other.gameObject.GetComponent<DestroyAfterSeconds>())
            {
                other.gameObject.GetComponent<DestroyAfterSeconds>().enabled = true;
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == fallingLayer)
        {
            other.gameObject.layer = stableLayer;
        }
    }

}
