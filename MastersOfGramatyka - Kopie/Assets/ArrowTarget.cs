using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ArrowTarget : MonoBehaviour
{

    public Camera cam;
    public CinemachineVirtualCamera vCam;
    public CinemachineFreeLook freeLookCam;
    private Vector3 targetPos;

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); //a ray to the center of the screen

        if (vCam.Priority > freeLookCam.Priority)
        {

            if (Physics.Raycast(ray))
            {
                targetPos = ray.GetPoint(25);
            }
            else
            {
                targetPos = ray.GetPoint(25);
            }
            transform.LookAt(targetPos); //bow looks at center of screen, where he will also shoot

        }
    }
}
