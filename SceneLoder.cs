using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoder : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] Text objectivs;
    [SerializeField] AudioSource backGroundMusic;
    [SerializeField] AudioSource backGroundMusic02;
    float objectivsTime = 3;

     void Start()
    {
        backGroundMusic.Play();
        backGroundMusic02.Play();
        PauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine(objectivsText());
    }
    private void Update()
    {
        pauseGame();
    }
    public void RelodeGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void pauseGame()
    {
        if(Input.GetKey(KeyCode.Escape)) 
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
            
            FindObjectOfType<WeaponSwich>().enabled = false;
            FindObjectOfType<FirstPersonController>().enabled = false;
            FindObjectOfType<WapenScrpt>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
       

    }
    public void resume()
    {
        PauseMenu.SetActive(false );
        Time.timeScale = 1;
        
        FindObjectOfType<WeaponSwich>().enabled = true;
        FindObjectOfType<FirstPersonController>().enabled = true ;
        FindObjectOfType<WapenScrpt>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    IEnumerator objectivsText()
    {
        objectivs.enabled = true;
        yield return new WaitForSeconds(objectivsTime);
        objectivs.enabled = false;
    }
    public void playBackgroundMusic()
    {
        backGroundMusic.Stop();
        backGroundMusic02.Stop();
    }




}
