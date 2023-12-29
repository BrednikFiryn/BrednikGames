using System.Collections;
using UnityEngine;

public class Reload : MonoBehaviour
{
    private GameManager Manager;

    // Время стрельбы и перезарядки
    public float reloadTime;

    // Пули в магазине
    public int MagazinBullet;

    // Проверка
    public bool isReload;

    // Проверка на возможность перезарядки 
    public bool CanReload => MagazinBullet < MagazinCapacity && isReload == false;

    // Емкость магазина 
    public int MagazinCapacity;

    public AudioSource ReloadSound;

    private void Start()
    {
        Manager = FindObjectOfType<GameManager>();
        MagazinBullet = MagazinCapacity;
    }

    void Update()
    {
            ReloadLogic();
    }

    /// <summary>
    /// Логика перезарядки 
    /// </summary>
    void ReloadLogic()
    {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (CanReload == false) return;
                Manager.R.SetActive(false);
                StartCoroutine(ReloadRoutine());
            }
    }

    /// <summary>
    /// Таймер перезарядки
    /// </summary>
    /// <returns></returns>
    private IEnumerator ReloadRoutine()
    {
        isReload = true;
        yield return new WaitForSeconds(reloadTime);
        OnReload();
    }

    /// <summary>
    /// Перезарядка
    /// </summary>
    void OnReload()
    {
        ReloadSound.Play();
        MagazinBullet = MagazinCapacity;
        isReload = false;
    }
}
