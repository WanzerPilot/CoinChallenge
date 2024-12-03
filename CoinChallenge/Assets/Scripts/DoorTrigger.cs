using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animation anim;

    public static DoorTrigger instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockTheDoor();
        }
    }*/
    public void UnlockTheDoor()
    {
        anim.Play();
    }
}
