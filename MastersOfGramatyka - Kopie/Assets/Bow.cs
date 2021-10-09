using UnityEngine;
using Cinemachine;

public class Bow : MonoBehaviour
{
    public int damage = 10;
    //private float range = 100f;
    public CinemachineFreeLook freeLookCam;
    public CinemachineVirtualCamera vCam;
    public LayerMask ignoreTag;
    public Camera cam;
    public GameObject arrow;
    public Transform target;
    private float shootForce = 65f;
   // private float forceBoost = 40f;
    public Animator bowAnim;
    private Vector3 targetPos;
    private int arrowsCount;
    //private float startTime, endTime;
    public float arrowRate = 1.15f;
    private float nextArrow;
    public bool reload;

    private void Start()
    {
  
        arrowsCount = GameObject.FindGameObjectsWithTag("Arrow").Length;
        
    }

    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            startTime = Time.time;
        }
        if (Input.GetMouseButtonUp(0))
        {
            endTime = Time.time;
        }

        if (endTime - startTime > 0.5f)
        {
            print(endTime - startTime);
            startTime = 0f;
            endTime = 0f;
        }*/

        //need to be zoomed in and pressing the shoot button to shoot
        if (Input.GetMouseButtonDown(0) && vCam.Priority > freeLookCam.Priority && Time.time > nextArrow)
        {
            nextArrow = Time.time + arrowRate;
            bowAnim.SetTrigger("Active");
            Shoot();
            reload = false;
        }
        else if (Input.GetMouseButtonUp(0) && vCam.Priority > freeLookCam.Priority)
        {
            reload = true;
            bowAnim.SetTrigger("NotActive");
        }

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


        if (vCam.Priority > freeLookCam.Priority)
        {
            bowAnim.SetBool("isFiring", true);
        }
        else if (vCam.Priority < freeLookCam.Priority)
        {
            bowAnim.SetBool("isFiring", false);
        }
    }

    void Shoot()
    {

        GameObject currentArrow = Instantiate(arrow, target.transform.position, transform.rotation);  //cloning the arrows
        currentArrow.GetComponent<Rigidbody>().velocity = target.transform.forward * shootForce; //AddForce(cam.transform.forward * shootForce, ForceMode.Impulse); //force added to the arrows so they can fly

        //Destroy(currentArrow, 10f);

    }

}

