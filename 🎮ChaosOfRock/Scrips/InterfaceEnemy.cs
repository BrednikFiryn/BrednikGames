using UnityEngine.UI;
using UnityEngine;

public class InterfaceEnemy : MonoBehaviour
{

    public float HealthEnemy, Exp, Armor;
    public bool agr, isLifeEnemy;

    public Animator anim;
    public Image imgHealth;
    public Rigidbody2D Player;


    private void Awake()
    {
        isLifeEnemy = true;
    }
    
    void FixedUpdate()
    {
        HealthInf();
        HealthCount();
    }

    /// <summary>
    /// Информация о количестве жизни на индикаторе
    /// </summary>
    void HealthInf()
    {
        imgHealth.fillAmount = HealthEnemy;
    }

    /// <summary>
    /// Проверка остатка жизни 
    /// </summary>
    void HealthCount()
    {
        if (HealthEnemy <= 0)
        {
            ExpCount(Exp);
            anim.SetBool("Death", true);
            Destroy(GetComponent<Collider2D>());
            Destroy(GetComponent<Rigidbody2D>());
            isLifeEnemy = false;
            Destroy(gameObject, 2f);
            if (gameObject.GetComponent<EnemyBoom>() != null) GetComponent<EnemyBoom>().SoundBoomRemove();
            else return;
        }
    }

    /// <summary>
    /// Получение урона 
    /// </summary>
    /// <param name="DamageEnemy"></param>
    /// <returns></returns>
    public float TakeDamage(float Damage)
    {
        agr = true;
        return HealthEnemy -= Damage * Armor;
    }

    /// <summary>
    ///  передача опыта игроку
    /// </summary>
    /// <param name="Exp"></param>
    /// <returns></returns>
    public float ExpCount(float Exp)
    {
        return FindObjectOfType<InterfaceController>().Explvl += Exp - 0.01f * Exp;
    }
}
