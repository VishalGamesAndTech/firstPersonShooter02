using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMainDoor : MonoBehaviour
{
    [SerializeField] float openRange = 5f;
    [SerializeField] Animator anim;
    [SerializeField] Transform Player;
    [SerializeField] Transform door;
    [SerializeField] GameObject PressE;
    [SerializeField] GameObject DoorClosed;
    [SerializeField] GameObject youWinCanvas;
    [SerializeField] AudioSource audioSource;


    float WaitForWin = 1.5f;
    bool endGame = false;
    public GameObject player;
    private void Start()
    {
        PressE.SetActive(false);
        DoorClosed.SetActive(false);
        youWinCanvas.SetActive(false);
    }
    private void Update()
    {

        OpenDoor();
       


    }   

    private void OpenDoor()
    {
        float Distance = Vector3.Distance(Player.transform.position, door.transform.position);
        if (player.GetComponent<PlayerHealth>().hasKey >= 1)
        {
            if (Distance <= openRange)
            {
                PressE.SetActive(true);
            }
            if (Distance >= openRange)
            {
                PressE.SetActive(false);
            }

        }
        if (player.GetComponent<PlayerHealth>().hasKey < 1)
        {
            if (Distance <= openRange)
            {
                DoorClosed.SetActive(true);
            }
            if (Distance >= openRange)
            {
                DoorClosed.SetActive(false);
            }
        }




        if (player.GetComponent<PlayerHealth>().hasKey >= 1 && Input.GetKey(KeyCode.E))
        {
            if (Distance <= openRange)
            {

                anim.SetBool("Near", true);
                audioSource.Play();
                endGame = true;
                StartCoroutine(waitForWIn());
            }


        }
        if (endGame == true)
        {
            PressE.SetActive(false);
        }
    }
    IEnumerator waitForWIn()
    {
        yield return new WaitForSeconds(WaitForWin);
        youWinCanvas.SetActive(true);
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwich>().enabled = false;
        FindObjectOfType<FirstPersonController>().enabled = false;
        FindObjectOfType<WapenScrpt>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FindObjectOfType<SceneLoder>().playBackgroundMusic();
    }
}
