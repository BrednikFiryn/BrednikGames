using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    [HideInInspector]public float vInput;
    [HideInInspector]public float hInput;

    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
    }
}
