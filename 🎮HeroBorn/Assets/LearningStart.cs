using System.Collections.Generic;
using UnityEngine;

public class LearningStart : MonoBehaviour
{

    //public int amountCoin;
    //public bool pureOfHeart;
    //public bool hasSecretIncantation;
    //public string rarelyItem;
    //public string characterAction;
    //public int playerHealth;

    public GameObject directionLight;
    private Transform lightTransform;
    private Transform camTransform;

    public string namePaladin;

    void Start()
    {
        camTransform = GetComponent<Transform>();
        lightTransform = GameObject.Find("Directional Light").GetComponent<Transform>();

        Debug.Log(camTransform.localPosition);
        Debug.Log(lightTransform.localPosition);
        CharacterInfo();
    }


    /// <summary>
    /// Информация о персонаже
    /// </summary>
    private void CharacterInfo()
    {
        Weapon HintingBow = new Weapon("HintingBow", 150);
        Paladin knight = new Paladin(namePaladin, HintingBow);
        knight.PrintStatsInfo();
    }

    ///// <summary>
    ///// Тавеерна
    ///// </summary>
    //private void MagicTeam()
    //{
    //    List<string> guestPartyMemebers = new List<string>() { "Warrior", "Archer", "Berserk" };
    //    guestPartyMemebers.Add("Necromancer");
    //    guestPartyMemebers.Insert(2, "Soldier");
    //    guestPartyMemebers.RemoveAt(0);
    //    Debug.Log($"The robbers killed Warrior");

    //    Debug.LogFormat("In the tavern of {0} heroes", guestPartyMemebers.Count);
    //   for (int i = 0; i < guestPartyMemebers.Count; i++)
    //    {
    //        Debug.LogFormat("The hero of the tavern {0} - {1}", i, guestPartyMemebers[i]);

    //        if (guestPartyMemebers[i] == "Necromancer")
    //        {
    //            Debug.LogFormat("{0} raises a squad of skeletons", guestPartyMemebers[i]);
    //        }
    //    }

    //   while(playerHealth > 0)
    //    {
    //        Debug.Log("You drink a glass of dragon's breath");
    //        playerHealth--;
    //    }

    //   if (playerHealth <= 0)
    //    {
    //        Debug.Log("You passed out");
    //    }
    //}
        
    ///// <summary>
    ///// Ищем сокровища
    ///// </summary>
    //private void OpenTreasureChamber()
    //{

    //    if (pureOfHeart && rarelyItem == "goldKey")
    //    {
    //        if (!hasSecretIncantation)
    //            Debug.Log("The chest is closed!!!");

    //        else
    //            Debug.Log("The chest is open");
    //    }

    //    else
    //        Debug.Log("The chest is closed!!!");
    //}

    ///// <summary>
    ///// Состояние персонажа
    ///// </summary>
    ///// <param name="characterAction"></param>
    //private void CharacterAction()
    //{
    //    switch (characterAction)
    //    {
    //        case "Attack":
    //            Debug.Log("Attack!!");
    //            break;
    //        case "Heal":
    //            Debug.Log("Heal!!");
    //            break;
    //        default:
    //            Debug.Log("Idle");
    //            break;
    //    }
    //}

    ///// <summary>
    ///// Предметы в инвентаре
    ///// </summary>
    //private void ItemInventory()
    //{
    //    Dictionary<string, int> itemInventory = new Dictionary<string, int>()
    //    {
    //        {"Sword", 1},
    //        {"Shield", 7},
    //        {"Stick", 5}
    //    };

    //    itemInventory.Add("Armor", 11);
    //    itemInventory["Antidote"] = 22;
    //    itemInventory["Shield"] = 10;

    //    if (itemInventory.ContainsKey("Aspirin"))
    //    {
    //        itemInventory.Remove("Aspirin");
    //        Debug.Log("We use medicine");
    //    }

    //    else
    //    {
    //        itemInventory["Aspirin"] = 30;
    //        Debug.Log("We produce medicine");
    //    }

    //    Debug.LogFormat("There are {0} items in the shop", itemInventory.Count);

    //    foreach (KeyValuePair<string, int> kvp in itemInventory)
    //    {
    //        Debug.LogFormat("There are {0} coins left", amountCoin);
    //        Debug.LogFormat("The item {0} costs {1}g", kvp.Key, kvp.Value);

    //        if (amountCoin >= kvp.Value)
    //        {
    //            amountCoin -= kvp.Value;
    //            Debug.LogFormat("We bought {0}", kvp.Key);
    //        }

    //        else if (amountCoin < kvp.Value) 
    //        {
    //            Debug.LogFormat("We don't have enough money to buy this item {0}", kvp.Key);
    //        }
            
    //    }
    //}
}
