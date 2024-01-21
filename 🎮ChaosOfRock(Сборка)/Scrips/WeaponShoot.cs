using System.Collections;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    private ClassController _ClassController;
    private GameManager Manager;

    public AudioSource Shoot, Reload, NeedReload;

    [SerializeField] GameObject Bullet;
    [SerializeField] Transform shootPoint;


    // �������� �� ����������� ��������
    private bool CanShoot => _ClassController._Reload.MagazinBullet > 0 & _ClassController._Reload.isReload == false;

    private void Start()
    {
        Manager = FindObjectOfType<GameManager>();
        _ClassController = FindObjectOfType<ClassController>();
    }

    private void Update()
    {
            ShootLogic();
    }

    /// <summary>
    /// ������ c������� 
    /// </summary>
    void ShootLogic()
    {
        if (Input.GetButtonDown("Fire1") && FindObjectOfType<GameManager>().PauseBlock == false)
        {
            if (CanShoot == false)
            {
                if (_ClassController._Reload.CanReload == true)
                {
                    Reload.Play();
                    NeedReload.Play();
                   Manager.R.SetActive(true);
                }
                return;
            }
            OnAttack();
        }
    }

    /// <summary>
    /// ����� ����
    /// </summary>
    void OnAttack()
    {
        Shoot.Play();
        Instantiate(Bullet, shootPoint.position, transform.rotation);
        _ClassController._Reload.MagazinBullet--;
    }

}

