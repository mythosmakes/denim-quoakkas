using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
      public GameObject pausedMenu;
      public static bool isPaused;
      public AudioSource audioSource;

      void Start()
      {
            pausedMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
      }
      
      void Update()
      {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("P");

                if (isPaused)
                {
                Debug.Log("Unpausing");
                    ResumeGame();
                }

                else
                {
                    Debug.Log("Pausing");
                    PauseGame();
                }
            }
      }

      public void PauseGame()
      {
        Debug.Log("Paused");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pausedMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
      
        PlayerMove controller = GetComponent<PlayerMove>();
        audioSource.Pause();
      }

      public void ResumeGame()
      {
        Debug.Log("Unpaused");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
            pausedMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;

            audioSource.Play(0);
      }
      
      public void GoToMainMenu()
      {
            SceneManager.LoadScene("MainMenu");
            isPaused = false;
      }

      public void QuitGame()
      {
            Application.Quit();
      }
}
