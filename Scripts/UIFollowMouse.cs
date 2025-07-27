using UnityEngine;

public class UIFollowMouse : MonoBehaviour
{

    [SerializeField] private PlayerInput _input;

    void Update()
    {
        gameObject.GetComponent<RectTransform>().position = _input.GetMousePos();
    }
}
