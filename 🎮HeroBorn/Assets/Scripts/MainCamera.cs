using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    public Vector3 camOffset = new Vector3(0f, 1.2f, -2.6f);
    private Transform target;
    
    void Start()
    {
        target = GameObject.Find("Warrior(Red)").transform;
    }

    void LateUpdate()
    {
        LookTargetPlayer();
    }

    private void LookTargetPlayer()
    {
        this.transform.position = target.TransformPoint(camOffset);
        this.transform.LookAt(target);
    }
}
