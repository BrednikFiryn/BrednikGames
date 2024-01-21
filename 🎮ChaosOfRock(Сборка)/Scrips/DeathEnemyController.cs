using UnityEngine;

public class DeathEnemyController : MonoBehaviour
{
    public AudioSource DeathEnemy;

    /// <summary>
    /// �������� ����� �� ���������
    /// </summary>
    public void SoundDeathRemove()
    {
        FindObjectOfType<SoundController>().Sounds.Remove(DeathEnemy);
    }
}
