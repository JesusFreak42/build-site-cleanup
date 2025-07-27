using UnityEngine;

public class UIFollowMouse : MonoBehaviour
{

    [SerializeField] private PlayerInput _input;

    void Update()
    {
        //every frame, this UI element matches the mouse position
        gameObject.GetComponent<RectTransform>().position = _input.GetMousePos();
    }
}
