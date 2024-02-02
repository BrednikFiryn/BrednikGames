using UnityEngine;

public class ZonePosition : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [HideInInspector] public GameObject target;

    void Update()
    {
        PositionCheck();
    }


    private void PositionCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.GetComponent<EnemyTarget>() != null)
                {
                    target = hit.collider.gameObject;
                }
            }
        }

        if (gameObject.GetComponent<EnemyTarget>() == null)
        {
            gameObject.transform.position =  new Vector3(0, -50, 0);
        }

        gameObject.transform.position = target.transform.position;
    }
}
