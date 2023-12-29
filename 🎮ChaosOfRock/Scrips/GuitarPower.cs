using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarPower : MonoBehaviour
{
    private ClassController _ClassController;
    public int TakePower;
    public bool isGuitarPlay;

    // Счетчик

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
    /// Проверка на возможность играть
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
    //        // Отнимает энергию в Interface с учетом TakePower
    //        _ClassController._Interface.power -= Time.deltaTime * TakePower;
    //        _ClassController._Interface.imgPower.fillAmount -= 1f / _ClassController._Interface.MaxPower * TakePower * Time.deltaTime;
    //    }     

    //    if (isGuitarPlay == false)
    //    {
    //        // Отнимает энергию в Interface с учетом TakePower
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

