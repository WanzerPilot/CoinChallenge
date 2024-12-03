using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LightCtrl : MonoBehaviour
{
    [SerializeField] List<Light> lights = new List<Light>();
    [SerializeField] ElevatorController elevator;
    public GameObject directionalLight;

    public UnityEvent onEndLevel;


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
        Timer.instance.StopTimer();
        directionalLight.gameObject.SetActive(false);
        foreach (Light light in lights)
        {
            light.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        elevator.StartCoroutine(elevator.MoveCorout());
        onEndLevel.Invoke();

        yield return ScreenFadeController.instance.Fade(true);
        
        SceneManager.LoadSceneAsync("ResultScene");
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!other.CompareTag("Player")) return;
        other.transform.SetParent(transform);
        StartCoroutine(StartEvent());
    }


}

