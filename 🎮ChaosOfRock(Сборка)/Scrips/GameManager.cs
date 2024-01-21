using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Objects, PlayerObjects, PatrollZone;
    public GameObject PauseMenu, Player, E, R, Notification, SpawnPoint, CollectionEnemy, ContinueDeath, LoadAnim;
    public HealthBar _HealthBar;
    public FireTick fireTick;
    public SoundController soundController;

    [SerializeField] public bool RedCrystal, SoulCrystal, FilthCrystal, Scul, SculText2, PauseBlock, loadScene;

    public float ArmorSoul;
    public int index;

    private void Start()
    {
        soundController = FindObjectOfType<SoundController>();
        CursorTime();
        PauseBlock = true;
    }

    void Update()
    {
        ContinueDeathActive();
        TrueObject();
        FalseObject();
        Pause();
    }

    /// <summary>
    /// ��������������� � �����
    /// </summary>
    public void DeathFireActive()
    {
        FindObjectOfType<FireTick>().fireDamage.Play();
        fireTick.fireTime = fireTick.fireTimeMax;
    }

    /// <summary>
    /// �������� ���������� �����
    /// </summary>
    public void CheckPauseBlock()
    {
        PauseBlock = false;
    }

    /// <summary>
    /// �����
    /// </summary>
    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PauseBlock == false && _HealthBar.isAlive == true)
        {
            soundController.AllAudioPause();
            PauseMenu.SetActive(true);
            PauseBlock = true;
            CursorTime();
        }
    }

    /// <summary>
    /// ����� � ��������
    /// </summary>
    public void PauseMonolog()
    {
        soundController.AllAudioPause();
        PauseBlock = true;
        CursorTime();
    }

    /// <summary>
    /// ������ ���������� � ������� � ��������� �������.
    /// </summary>
    public void CursorTime()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
    }

    /// <summary>
    /// ������ �������
    /// </summary>
    public void StartTime()
    {
        Time.timeScale = 1f;
    }

    /// <summary>
    /// ���������� ������� � ������ �������.
    /// </summary>
   public void Cursorlock()
    {
        PauseBlock = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    /// <summary>
    /// ������ ���������� � �������.
    /// </summary>
   public void CursorConfined()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    /// <summary>
    /// �����.
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }

    /// <summary>
    /// ������ ������.
    /// </summary>
    public void Repeat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    /// <summary>
    /// ������� ��������.
    /// </summary>
    private void TrueObject()
    {
        foreach (var i in Objects)
        {
            if (RedCrystal == true) Objects[0].SetActive(true);

            if (SoulCrystal == true) Objects[1].SetActive(true);

            if (FilthCrystal == true) Objects[2].SetActive(true);

            if (Scul == true) Objects[3].SetActive(true);
        }
    }

    /// <summary>
    /// �������� ��������.
    /// </summary>
    private void FalseObject()
    {
        foreach (var i in Objects)
        {
            if (RedCrystal == false) Objects[0].SetActive(false);

            if (SoulCrystal == false) Objects[1].SetActive(false);

            if (FilthCrystal == false) Objects[2].SetActive(false);

            if (Scul == false) Objects[3].SetActive(false);
        }
    }

    /// <summary>
    /// ��������������.
    /// </summary>
    public void NotificationAlert() 
    {
        Notification.SetActive(true);
        CursorTime();
    }

    /// <summary>
    /// ���������� �������� ������ � ������ ������.
    /// </summary>
    public void PlayerObjectsOff()
    {
        foreach (var i in PlayerObjects)
        {
            i.SetActive(false);
        }

        CollectionEnemy.SetActive(false);
    }

    /// <summary>
    /// ����� �������� �������.
    /// </summary>
    public void OnButtonTrapOnClick()
    {
        SculText2 = true;
    }

    /// <summary>
    /// ����� ������
    /// </summary>
    public void OnButtonSpawnPoint()
    {
        Player.transform.position = SpawnPoint.transform.position;
    }

    /// <summary>
    /// ��������� ������ �������� ������ � ������ ������.
    /// </summary> 
    public void ActiveEnemy()
    {
        foreach (var i in PlayerObjects)
        {
            i.SetActive(true);
        }

        CollectionEnemy.SetActive(true);
    }

    /// <summary>
    /// ������ �������� �� ����� ���������
    /// </summary>
    private void ContinueDeathActive()
    {
        if (!_HealthBar.isAlive && !loadScene)
        {
            Cursor.lockState = CursorLockMode.Confined;
            ContinueDeath.SetActive(true);
        }

        if (!_HealthBar.isAlive && loadScene) ContinueDeath.SetActive(false);
    }

    /// <summary>
    /// ��������� ��� ��������� ������
    /// </summary>
    public void DeathPlayer()
    {
        ContinueDeath.SetActive(true);
    }
    

    /// <summary>
    /// �������� 
    /// </summary>
    public void Load()
    {
        GetComponent<GameManager>().loadScene = true;
        LoadAnim.SetActive(true);
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);

        while (!asyncLoad.isDone) yield return null;
    }

}
