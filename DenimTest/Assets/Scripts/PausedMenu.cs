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
                  if (isPaused)
                  {
                        ResumeGame();
                  }
                  else
                  {
                        PauseGame();
                 }
            }
      }

      public void PauseGame()
      {
            pausedMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
      
            PlayerMove controller = GetComponent<PlayerMove>();
            audioSource.Pause();
      }

      public void ResumeGame()
      {
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
