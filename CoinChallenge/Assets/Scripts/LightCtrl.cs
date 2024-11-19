using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCtrl : MonoBehaviour
{
    [SerializeField] List<Light> lights = new List<Light>();
    [SerializeField] ElevatorController elevator;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Light light in lights)
        {
            light.gameObject.SetActive(false);
        }
    }

    IEnumerator StartEvent()
    {
        foreach (Light light in lights)
        {
            light.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        elevator.StartCoroutine(elevator.MoveCorout());
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (!other.CompareTag("Player")) return;
        StartCoroutine(StartEvent());
    }
}

