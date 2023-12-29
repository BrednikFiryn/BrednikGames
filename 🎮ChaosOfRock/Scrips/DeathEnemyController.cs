using UnityEngine;

public class DeathEnemyController : MonoBehaviour
{
    public AudioSource DeathEnemy;

    /// <summary>
    /// Удаление звука из коллекции
    /// </summary>
    public void SoundDeathRemove()
    {
        FindObjectOfType<SoundController>().Sounds.Remove(DeathEnemy);
    }
}
