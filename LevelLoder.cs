using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoder : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void loadLevel()
    {
        SceneManager.LoadScene("level01");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
