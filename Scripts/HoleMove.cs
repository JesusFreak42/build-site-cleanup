using UnityEngine;

public class HoleMove : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float mobileMoveModifier = 0.01f;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Vector2 worldMoveBounds;
    [SerializeField] private UIHandler uiHandler;

    private void Update()
    {
        if (uiHandler.MenuOpen()) return;

        if (!Application.isMobilePlatform)
        { //On PC, move the hole based on mouse position
            Vector2 mousePos = new Vector2(
                Mathf.Clamp(_input.GetMousePos().x / Screen.width - 0.5f, -0.5f, 0.5f),
                Mathf.Clamp(_input.GetMousePos().y / Screen.height - 0.5f, -0.5f, 0.5f)
            ); //mouse position relative to screen size - where the middle of the screen is 0,0 and the values are clamped between -0.5 and 0.5

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x + mousePos.x * moveSpeed * Time.deltaTime, -worldMoveBounds.x, worldMoveBounds.x),
                transform.position.y,
                Mathf.Clamp(transform.position.z + mousePos.y * moveSpeed * Time.deltaTime, -worldMoveBounds.y, worldMoveBounds.y)
            );
        }
        else if (Application.isMobilePlatform)
        { //On mobile, move the hole based on mouse movement (mouse delta)
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x + _input.GetMouseDelta().x * moveSpeed * mobileMoveModifier * Time.deltaTime, -worldMoveBounds.x, worldMoveBounds.x),
                transform.position.y,
                Mathf.Clamp(transform.position.z + _input.GetMouseDelta().y * moveSpeed * mobileMoveModifier * Time.deltaTime, -worldMoveBounds.y, worldMoveBounds.y)
            );
        }

    }

}
