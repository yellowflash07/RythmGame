using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public float displacement;
    int index = 0;
    public bool spin;
    public GameObject follow;

    private Vector3 followPos;

    private static WaveController _instance;
    public static WaveController instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        followPos = follow.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
       // follow.transform.localPosition = followPos;
        if (spin)
        {
            transform.Rotate(transform.forward * 50 * Time.deltaTime); 
        }
        transform.Translate(Vector3.forward * displacement * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.A))
            index = 1;
        if (Input.GetKeyDown(KeyCode.D))
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
