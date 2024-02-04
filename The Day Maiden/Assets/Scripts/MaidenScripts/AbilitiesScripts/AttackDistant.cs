using UnityEngine;

public class AttackDistant : MonoBehaviour
{

    [SerializeField] private float attackDistantDelay;
    [SerializeField] private GameObject fireBall;
    [SerializeField] private ParticleSystem particleSystem;

    private AttackDistantTarget attackDistantTarget;

    private float attackTime = float.MinValue;

    private void Start()
    {
        attackDistantTarget = FindObjectOfType<AttackDistantTarget>();
    }

    void Update()
    {
        AttackCheck();
    }

    /// <summary>
    /// Атака по выбраному противнику.
    /// </summary>
    private void AttackCheck()
    {
        if (Time.time < attackTime + attackDistantDelay) return;

        fireBall.transform.position = gameObject.GetComponent<AttackDistant>().transform.position;

        if (Input.GetKeyDown(KeyCode.Mouse2) && attackDistantTarget.target != null)
        {
            fireBall.transform.position = attackDistantTarget.target.transform.position;
            particleSystem.Play();

            attackTime = Time.time;
        }

        else if (attackDistantTarget.target == false)
        {
            fireBall.transform.position = gameObject.transform.position;
        }
    }
}
