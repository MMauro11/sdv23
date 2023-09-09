using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed;
    public float mouseNavigationMargin;
    public Vector2 currentPosition;
    public Vector2 panLimit;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the current position of the camera.
        Vector2 currentPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Pan();
    }

    // Calculates the movement direction based on keyboard or mouse input.
    void Pan()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.mousePosition.y >= Screen.height - mouseNavigationMargin)
        {
            currentPosition.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.mousePosition.y <= mouseNavigationMargin)
        {
            currentPosition.y += -panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x <= mouseNavigationMargin)
        {
            currentPosition.x += -panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x >= Screen.width - mouseNavigationMargin)
        {
            currentPosition.x += panSpeed * Time.deltaTime;
        }

        // Ensures the camera is constrained within the map.
        currentPosition.x = Mathf.Clamp(currentPosition.x, -panLimit.x, panLimit.x);
        currentPosition.y = Mathf.Clamp(currentPosition.y, -panLimit.y, panLimit.y);

        // Updates the current position of the camera.
        transform.position = currentPosition;
    }
}
