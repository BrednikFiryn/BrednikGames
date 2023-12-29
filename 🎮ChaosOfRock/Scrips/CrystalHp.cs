
using UnityEngine;

public class CrystalHp : MonoBehaviour
{
    public float Hp;
    public GameObject Crystal, SoundKit;
    public AudioSource Kit;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Legs"))
        {
            FindObjectOfType<SoundController>().Sounds.Remove(Kit);
            FindObjectOfType<HealthBar>().HpCount(Hp);
            Crystal.SetActive(false);
            SoundKit.SetActive(true);
            Destroy(GetComponent<Collider2D>());
            Destroy(gameObject, 1f);
        }
    }

}
