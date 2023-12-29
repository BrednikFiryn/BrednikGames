using UnityEngine;
using System.Collections.Generic;

public class ItemControll : MonoBehaviour
{
    public List<GameObject> TextItems;
    public InterfaceController _InterfaceController;
    public VoiceOverControll voiceOverControll;
    public GameObject Item;
    public float ExpLife;
    public float ExpSoul;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Legs"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();

            gameManager.E.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                voiceOverControll.StopMonolog();
                MenuManager menuManager = FindObjectOfType<MenuManager>();


                if (gameObject.name == "CrystalLife")
                {
                    TextItems[0].SetActive(true);
                    _InterfaceController.ExpCount(ExpLife);
                    gameManager.RedCrystal = true;
                }
                else if (gameObject.name == "Pedestal(Soul)")
                {
                    TextItems[0].SetActive(true);
                    _InterfaceController.ExpCount(ExpSoul);
                    gameManager.SoulCrystal = true;
                    Destroy(GetComponent<Collider2D>());
                }
                else if (gameObject.name == "ItemScul")
                {
                    if (gameManager.SculText2)
                        TextItems[1].SetActive(true);
                    else
                        TextItems[0].SetActive(true);

                    gameManager.Scul = true;
                }

                gameManager.PauseMonolog();
                gameManager.E.SetActive(false);
                menuManager.ItemEguipt();
                Destroy(Item);
            }
        }
    }
        

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Legs"))
        {
            FindObjectOfType<GameManager>().E.SetActive(false);
        }
    }
}