using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSwitch : MonoBehaviour
{
    private PlayerController player;
    private cameraControl cam;
    public Transform repairBot;
    public Transform buildBot;

    void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        cam = GameObject.FindObjectOfType<cameraControl>();


    }

    public void SwitchToRepair()
    {
        
        player.ToSwitch("Repair Bot");
        cam.CameraPositon(repairBot);

    }

    public void SwitchToBuild()
    {

        player.ToSwitch("Build Bot");
        cam.CameraPositon(buildBot);

    }
}
