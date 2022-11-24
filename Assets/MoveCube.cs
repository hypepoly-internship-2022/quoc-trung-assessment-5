using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public Rigidbody cube1;
    public float speed = 10f;
    Camera mainCamera;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    void Start()
    {
       
    }

    void FixedUpdate()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButton(0))
        {
            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider.gameObject.tag == "TargetCube")
                {
                    Vector3 targetPosition = (hit.collider.transform.position - cube1.transform.position).normalized;
                    cube1.velocity = targetPosition * speed;
                }
            }
        }
        else
        {
            cube1.velocity = Vector3.zero;
        }
    }
}
