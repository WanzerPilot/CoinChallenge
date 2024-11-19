using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{

    [SerializeField] Transform a, b;
    [SerializeField] float speed = 1f;
    [SerializeField] Rigidbody rb;
    [SerializeField] bool loop = false;
    Vector3 pos;

    [SerializeField] bool playOnAwake = true;

    // Start is called before the first frame update
    void Start()
    {

        if (playOnAwake)
        StartCoroutine(MoveCorout());
    }

    private void FixedUpdate()
    {
        rb.MovePosition(pos);
    }

    public IEnumerator MoveCorout()
    {
        Vector3 startPos = new Vector3(rb.transform.position.x, a.position.y, rb.transform.position.z);
        Vector3 targetPos = new Vector3(rb.transform.position.x, b.position.y, rb.transform.position.z);

        do
        {
            float t = 0;
            while (t < 1.1f)
            {
                t += Time.deltaTime * speed;
                pos = Vector3.Lerp(startPos, targetPos, t);
                yield return null;
            }
        }
        while (loop);



    }

}
