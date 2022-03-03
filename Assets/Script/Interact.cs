using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(playermotor))]
public class Interact : MonoBehaviour
{
    public LayerMask movementMask;
    Camera cam;
    playermotor motor;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<playermotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray =  cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, movementMask))
        {
                motor.MoveToPoint(hit.point);
            }
        }

        
    }
}
