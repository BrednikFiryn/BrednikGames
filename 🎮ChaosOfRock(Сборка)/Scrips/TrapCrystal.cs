using UnityEngine;
using System.Collections.Generic;

public class TrapCrystal : MonoBehaviour
{

    [SerializeField] private GameManager Manager;
    public List<GameObject> Objects;

    public InterfaceController _InterfaceController;

    public GameObject AlertTrap, Trap;
    public float ExpFilth;
    public bool TrapOff;

    void Start()
    { 
        Manager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Legs"))
        {
            Manager.E.SetActive(true);
            CheckTrap();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Legs"))
        {
            Manager.E.SetActive(false);
        }
    }

    /// <summary>
    /// Взаимодействие с ловушкой
    /// </summary>
    private void CheckTrap()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Manager.Scul == false)
            {
                Manager.SculText2 = true;
                AlertTrap.SetActive(true);
                FindObjectOfType<GameManager>().PauseMonolog();
            }
            
            else if (Manager.Scul == true)
            {
                TrapOff = false;
                Manager.Scul = false;

                foreach (var i in Objects)
                {
                    Objects[0].SetActive(true);

                    if (Objects[1].name == "CrystalFilth")
                    {
                        FindObjectOfType<MenuManager>().ItemEguipt();
                        Manager.FilthCrystal = true;
                        _InterfaceController.ExpCount(ExpFilth);
                        Destroy(Objects[1]);
                        Destroy(GetComponent<Collider2D>());
                    }
                }
            }
        }
    }

    /// <summary>
    /// Активация ловушки
    /// </summary>
    public void TrapActive()
    {
        if (Manager.Scul == false)
        {
            Trap.SetActive(true);
            Destroy(GetComponent<Collider2D>());
        }
    }

}
