using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarPower : MonoBehaviour
{
    private ClassController _ClassController;
    public int TakePower;
    public bool isGuitarPlay;

    // �������

    private void Start()
    {
        _ClassController = FindObjectOfType<ClassController>();
        isGuitarPlay = false;
    }

    private void Update()
    {
        //PowerFill();
        PlayCheck();
        //PowerIndex();
        //_ClassController._Interface.powerInf();
    }

    /// <summary>
    /// �������� �� ����������� ������
    /// </summary>
    void PlayCheck()
    {
        if (Input.GetButtonDown("Fire1") && !isGuitarPlay)
        {
            isGuitarPlay = true;
        }

        else if (Input.GetButtonDown("Fire1") && isGuitarPlay)
        {
            isGuitarPlay = false;
        }
    }

    //void PowerFill()
    //{
    //    if (isGuitarPlay == true)
    //    {
    //        // �������� ������� � Interface � ������ TakePower
    //        _ClassController._Interface.power -= Time.deltaTime * TakePower;
    //        _ClassController._Interface.imgPower.fillAmount -= 1f / _ClassController._Interface.MaxPower * TakePower * Time.deltaTime;
    //    }     

    //    if (isGuitarPlay == false)
    //    {
    //        // �������� ������� � Interface � ������ TakePower
    //        _ClassController._Interface.power += Time.deltaTime * TakePower;
    //        _ClassController._Interface.imgPower.fillAmount += 1f / _ClassController._Interface.MaxPower * TakePower * Time.deltaTime;
    //    }
      
    //}


    //public void PowerIndex()
    //{
    //    if (isGuitarPlay) TakePower = 5;
    //    if (!isGuitarPlay) TakePower = 10;
    //}
}

