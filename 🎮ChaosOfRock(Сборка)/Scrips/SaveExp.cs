using UnityEngine.UI;
using UnityEngine;

public class SaveExp : MonoBehaviour
{
    private float Score;

    void Start()
    {
        ExpCount();
    }

    private void ExpCount()
    {
        Score = PlayerPrefs.GetFloat("Explvl");
        GetComponent<Text>().text = "" + (int)Score;
    }

    public void ExpNull()
    {
        PlayerPrefs.DeleteKey("Explvl");
    }
}
