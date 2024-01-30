using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
     [HideInInspector]public float vInput;
     [HideInInspector]public float hInput;

    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
    }
}
