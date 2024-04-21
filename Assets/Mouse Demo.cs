using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move the camera left or right based on arrow key input
        transform.Translate(new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0));
    }
}