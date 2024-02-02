using UnityEngine;

public class EnemyTarget : MonoBehaviour
{

    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }


    private void OnMouseEnter()
    {
        renderer.material.color = Color.red;
    }

    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}
