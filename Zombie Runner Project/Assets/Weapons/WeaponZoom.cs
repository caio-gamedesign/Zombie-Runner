using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] float fovZoomIn = 20f;
    [SerializeField] float fovZoomOut = 60f;

    [SerializeField] float fovZoomInSensitivity = .2f;
    [SerializeField] float fovZoomOutSensitivity = 2f;

    RigidbodyFirstPersonController fpsController;

    private void Awake()
    {
        fpsController = transform.root.GetComponent<RigidbodyFirstPersonController>();
    }

    public void FOVZoomIn()
    {
        camera.fieldOfView = fovZoomIn;
        fpsController.mouseLook.XSensitivity = fpsController.mouseLook.YSensitivity = fovZoomInSensitivity;
    }

    public void FOVZoomOut()
    {
        camera.fieldOfView = fovZoomOut;
        fpsController.mouseLook.XSensitivity = fpsController.mouseLook.YSensitivity = fovZoomOutSensitivity;
    }

}
