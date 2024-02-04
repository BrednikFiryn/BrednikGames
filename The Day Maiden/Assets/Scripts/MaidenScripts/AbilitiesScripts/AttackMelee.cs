using UnityEngine;

public class AttackMelee : MonoBehaviour
{

    [SerializeField] private float attackDistantDelay;

    private Animator anim;
    private Collider collider;
    private float attackTime = float.MinValue;



    private void Awake()
    {
        collider = GetComponent<Collider>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        AttackMeleeCheck();
    }

    /// <summary>
    /// Ѕлижн€€ атака по нажатию кнопки(1)
    /// </summary>
    private void AttackMeleeCheck()
    {
        if (Time.time < attackTime + attackDistantDelay) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetTrigger("Attack");
            collider.enabled = true;
            attackTime = Time.time;
        }

        else
            collider.enabled = false;
    }
}
