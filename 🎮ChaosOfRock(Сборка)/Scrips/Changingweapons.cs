using System.Collections.Generic;
using UnityEngine;

public class Changingweapons : MonoBehaviour
{
    public List<GameObject> states;
    public bool WeaponCheck_;

    private void Start()
    {
        WeaponCheck_ = false;
    }

    void Update()
    {
        WeaponCheck();
        WeaponChange();
    }

    /// <summary>
    /// Проверка переключения оружия
    /// </summary>
    private void WeaponCheck()
    {

        foreach  (var i in states)
         {

            if (WeaponCheck_ == true)
            {
                states[0].SetActive(true);
                states[2].SetActive(true);
                states[1].SetActive(false);
                states[3].SetActive(false);
            }

            if (WeaponCheck_ == false)
            {
                states[0].SetActive(false);
                states[2].SetActive(false);
                states[1].SetActive(true);
                states[3].SetActive(true);
            }
        }

    }

    /// <summary>
    /// Логика смены оружия
    /// </summary>
    private void WeaponChange()
    {
        if (Input.GetKeyDown(KeyCode.Q) && WeaponCheck_ == true)
        {
            WeaponCheck();

            WeaponCheck_ = false;
        }

        else if (Input.GetKeyDown(KeyCode.Q) && WeaponCheck_ == false)
        {
            WeaponCheck();
            WeaponCheck_ = true;
        }
    }
}
