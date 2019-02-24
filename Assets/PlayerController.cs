using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(playerMotor))]
public class PlayerController : MonoBehaviour
{
    public Interactable focus;

    public LayerMask movementMask;
    public static string robotname;



    Camera cam;
    playerMotor motor;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<playerMotor>();

    }

    public void ToSwitch(string buttonName)
    {
        robotname = buttonName;
    }

    // Update is called once per frame
    void Update()
    {
        if (robotname == gameObject.name)
        {

            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100, movementMask))
                {
                    motor.MoveToPoint(hit.point);

                    RemoveFocus();

                }

            }

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable != null)
                    {
                        SetFocus(interactable);
                    }
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        focus = newFocus;
        motor.MoveToPoint(newFocus.transform.position);
    }

    void RemoveFocus()
    {
        focus = null;

    }
}

