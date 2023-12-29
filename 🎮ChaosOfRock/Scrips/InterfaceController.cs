using UnityEngine.UI;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
    private ClassController _ClassController;
    public VoiceOverControll voiceOverControll;

    // Счетчик патронов
    [SerializeField] private Text BulletInMagazin, HealthBar, TextExp;
    public float BulletCount, Explvl;
    public bool EnemyNull, HpAllert;

    //  Индикатор здоровья
    public Image imgHealth;

    // Индикатор Уровня
    public ExpBar _ExpBar;

    private void Start()
    {
        _ClassController = FindObjectOfType<ClassController>();
        _ClassController._HealthBar.health = 1f;
    }

    void Update()
    {
        EnemyCheck();
        BulletInf();
        CountInf();
        ExpInf();
    }

    /// <summary>
    /// инофрмация о количестве патронов
    /// </summary>
    void BulletInf()
    {
        BulletInMagazin.text = "" + BulletCount;
        BulletCount = _ClassController._Reload.MagazinBullet;
    }

    /// <summary>
    /// Счетчик жизни 
    /// </summary>
    private void CountInf()
    {
        HealthBar.text = "" + (int)(_ClassController._HealthBar.health * 100);
        imgHealth.fillAmount = _ClassController._HealthBar.health;

        if (_ClassController._HealthBar.health <= 0.5f && HpAllert == false)
        {
            voiceOverControll.HpMonolog();
            HpAllert = true;
        }
        
        else if (_ClassController._HealthBar.health > 1f && HpAllert == true) HpAllert = false;
    }

        /// <summary>
        /// Счетчик опыта
        /// </summary>
        public void ExpInf()
    {
        TextExp.text = "" + (int)Explvl;
        PlayerPrefs.SetFloat("Explvl", Explvl);
        PlayerPrefs.Save();
    }

    /// <summary>
    ///  накопление опыта 
    /// </summary>
    /// <param name="Exp"></param>
    /// <returns></returns>
    public float ExpCount(float Exp)
    {
        return Explvl += Exp;
    }

    /// <summary>
    /// Если врагов на сцене нет = null
    /// о/summary>
    private void EnemyCheck()
    {
        if (FindObjectOfType<InterfaceEnemy>() == null) EnemyNull = true;
    }

}
