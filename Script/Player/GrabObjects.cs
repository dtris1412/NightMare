using System.Collections;
using System.Collections.Generic;
/*using TreeEditor;*/
using Unity.VisualScripting;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance;

    private GameObject grabbedObject;
    private int layerIndex;
    private void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
    }
    private void Update()
    {
        RaycastHit2D hintInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);
        if (hintInfo.collider != null && hintInfo.collider.gameObject.layer == layerIndex)
        {
            //grabObject
            if (Input.GetKeyDown(KeyCode.Space) && grabbedObject == null)
            {
                grabbedObject = hintInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
            }

        }
        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
    }

}
