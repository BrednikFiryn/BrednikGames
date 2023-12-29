using System.Collections;
using UnityEngine;

public class Thorns : MonoBehaviour
{
    public Animator anim;
    public AudioSource Fire;


    public float FireTime;

    [SerializeField] private bool FireOn;

    private void Start()
    {
        FireOn = true;
    }

    private void Update()
    {
        CheckActiveFire();
    }

    /// <summary>
    /// �������� ��������� ����
    /// </summary>
    private void CheckActiveFire()
    {
        if (FireOn == true)
        {
            StartCoroutine(FireRoutine());
        }
    }

    /// <summary>
    /// ������ ��������� �������
    /// </summary>
    /// <returns></returns>
    private IEnumerator FireRoutine()
    {
        while (true)
        {
            FireOn = false;
            anim.SetTrigger("Fire");
            Fire.Play();
            yield return new WaitForSeconds(FireTime);
            OnFire();
        }
    }

    /// <summary>
    /// ��������� ����
    /// </summary>
    private void OnFire()
    {
        FireOn = true;
    }
}
