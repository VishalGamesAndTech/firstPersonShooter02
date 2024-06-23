using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WapenZoom : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float ZoomOut = 60f;
    [SerializeField] float ZoomIn = 20f;
    bool ClickButton = false;

    FirstPersonController FPController;
    [SerializeField] float ZoomInSensitiviy = 0.5f;
    [SerializeField] float ZoomOutSensitiviy = 1f;
    [SerializeField] GameObject PlayerCapsule;
    [SerializeField] GameObject ShotGun;
    [SerializeField] int afterZoomMovingSpeed = 2;
    [SerializeField] int befourZoomMovingSpeed = 4;

    // Start is called before the first frame update
    void Start()
    {
        FPController = PlayerCapsule.GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(ClickButton == false)
            {
                zoomIn();
            }
            else
            {
                zomOut();
            }
        }
    }

    

    private void zoomIn()
    {
        ShotGun.GetComponent<MeshRenderer>().enabled = false;
       
        ClickButton = true;
        FPCamera.fieldOfView = ZoomIn;
        FPController.RotationSpeed = ZoomInSensitiviy;
        PlayerCapsule.GetComponent<FirstPersonController>().MoveSpeed = afterZoomMovingSpeed;
    }

    private void zomOut()
    {
        ShotGun.GetComponent<MeshRenderer>().enabled = true;
        ClickButton = false;
        FPCamera.fieldOfView = ZoomOut;
        FPController.RotationSpeed = ZoomOutSensitiviy;
        PlayerCapsule.GetComponent<FirstPersonController>().MoveSpeed = befourZoomMovingSpeed;
    }

    private void OnDisable()
    {
        zomOut();
    }
}
