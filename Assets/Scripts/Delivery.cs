using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);

    SpriteRenderer sR;

    bool hasPackage; //Default false
    [SerializeField] float destroyDelay = 0.5f;

    private void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
            if(the thing we trigger is the package)
                then print "package picked up" to the console.         
         */

        if (collision.tag == "Package" && !hasPackage){

            Debug.Log("Package picked up!");
            hasPackage = true;
            sR.color = hasPackageColor;
            Destroy(collision.gameObject, destroyDelay);
        }

        if(collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered package!");
            hasPackage = false;
            sR.color = noPackageColor;
        }
    }
}
