using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, trailDist;
    public GameObject trail,target;
    int index = 0;

    //public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        Debug.Log(Vector3.Distance(trail.transform.position, transform.position));
        if (Vector3.Distance(trail.transform.position, transform.position) > trailDist)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            // transform.Translate(Vector3.forward * speed * Time.deltaTime);

        }
        transform.Translate(Vector3.up * Input.GetAxis("Vertical") * 10* Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Q))
            index = 1;
        if (Input.GetKeyDown(KeyCode.E))
            index = 0;
    }

    Vector3 GetRandomVector()
    {
        switch (index)
        {
            case 0:
                return Vector3.right;
            case 1:
                return -Vector3.forward;
            default:
                return Vector3.right;
        }
    }
}
