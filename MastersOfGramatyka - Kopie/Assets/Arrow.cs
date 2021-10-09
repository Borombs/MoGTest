using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody rb;
    private int damage = 25;
    public LayerMask ignoreTag;
    public bool shot = false;
    private bool dealtDmg;
    public Collider arrowCol;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if(!rb.isKinematic)
        transform.rotation = Quaternion.LookRotation(rb.velocity);

        //Shoot();
        /*if (!hasDmgd)
        {
            Dmg = StartCoroutine(DoDmg()); ;
        }
            
        else
        {
            StopCoroutine(Dmg);
        }*/

    }



    /*public void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, range, ~ignoreTag))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            EnemyStats target = hit.transform.GetComponent<EnemyStats>(); //if we hit something we try to get the "EnemyStats" script
            if (target != null & shot) //if the target exists
            {
                target.GetDmg(damage); //the target gets damage
            }
        }
    }*/

    void OnCollisionEnter(Collision Col)
     {

        if(Col.gameObject.CompareTag("Enemy") && !dealtDmg)
        {
            dealtDmg = true;
            EnemyStats target = Col.transform.GetComponent<EnemyStats>();
            if(target != null)
            {
                target.GetDmg(damage);
            }
        }
        rb.isKinematic = true; // stop physics
        transform.parent = Col.transform; // doesn't move yet, but will move w/what it hit

    }   

}
