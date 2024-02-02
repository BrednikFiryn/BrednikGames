using UnityEngine;

public class AttackDistant : MonoBehaviour
{

    [SerializeField] private ParticleSystem attackRay;
    [SerializeField] private float attackDelay;
    [SerializeField] private GameObject damageZone;
    [SerializeField] private GameObject ray;

    private ZonePosition zonePosition;
    private float attackTime = float.MinValue;

    private void Start()
    {
        zonePosition = FindObjectOfType<ZonePosition>();
    }

    void Update()
    {
        AttackCheck();
    }

    private void AttackCheck()
    {
        if (Time.time < attackTime + attackDelay) return;

        damageZone.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            ray.transform.position = zonePosition.target.transform.position;
            damageZone.SetActive(true);
            attackTime = Time.time;
            attackRay.Play();
        }
    }
}
