using System.Collections;
using UnityEngine;

public class Reload : MonoBehaviour
{
    private GameManager Manager;

    // ����� �������� � �����������
    public float reloadTime;

    // ���� � ��������
    public int MagazinBullet;

    // ��������
    public bool isReload;

    // �������� �� ����������� ����������� 
    public bool CanReload => MagazinBullet < MagazinCapacity && isReload == false;

    // ������� �������� 
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
    /// ������ ����������� 
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
    /// ������ �����������
    /// </summary>
    /// <returns></returns>
    private IEnumerator ReloadRoutine()
    {
        isReload = true;
        yield return new WaitForSeconds(reloadTime);
        OnReload();
    }

    /// <summary>
    /// �����������
    /// </summary>
    void OnReload()
    {
        ReloadSound.Play();
        MagazinBullet = MagazinCapacity;
        isReload = false;
    }
}
