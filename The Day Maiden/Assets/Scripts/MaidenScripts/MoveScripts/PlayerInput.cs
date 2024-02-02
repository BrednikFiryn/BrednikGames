using UnityEngine;

public class PlayerInput : MonoBehaviour
{
     [HideInInspector] public float vInput;
     [HideInInspector] public float hInput;

    private void Update()
    {
        InputCheck();
    }

    private void InputCheck()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
    }
}
