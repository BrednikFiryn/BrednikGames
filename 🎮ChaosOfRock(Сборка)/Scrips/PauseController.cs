using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject pause;
    public bool PauseOff;

    void Start()
    {
        pause.SetActive(false);
        PauseOff = true;
    }

    void Update()
    {
        Pause();
    }

    /// <summary>
    /// Перезапустить сцену
    /// </summary>
    public void OnButtonRepead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 1;
    }

    /// <summary>
    /// Вернуться в главное меню 
    /// </summary>
    public void OnButtonBackMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    /// <summary>
    /// Пауза
    /// </summary>
    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            if (pause) PauseOff = false;

            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    /// <summary>
    /// Снять паузу 
    /// </summary>
    public void OnButtonContinue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        pause.SetActive(false);
        PauseOff = true;
    }
}

