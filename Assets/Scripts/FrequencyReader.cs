using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class FrequencyReader : MonoBehaviour
{
    public AudioSource audioSource;
    AudioClip audioClip;
    public GameObject cube, quad;
    public int index, multiplier;
    public float pathSpeed, beatThreshold;

    public PostProcessVolume processVolume;
    LensDistortion ld;
    public bool main;
    // Start is called before the first frame update
    void Start()
    {
       // audioSource = GetComponent<AudioSource>();
       // audioClip = audioSource.clip;
        InvokeRepeating("PathGen", 0, pathSpeed);
        processVolume.sharedProfile.TryGetSettings<LensDistortion>(out ld);
        // audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

        //    Debug.Log(Mathf.Log(spectrum[index]) + 10);
        //    Debug.DrawLine(new Vector3(spectrum[0] - 1, Mathf.Log(spectrum[0]) + 10, 2), new Vector3(spectrum[0], Mathf.Log(spectrum[1]) + 10, 2), Color.red);
        //    for (int i = 1; i < spectrum.Length - 1; i++)
        //    {
        //     //   Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
        //      //  Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.red);

        //        if(Mathf.Log(spectrum[i]) + 10 > 3f)
        //        {
        //           // Debug.Log("Beat");
        //        }
        //     //   Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
        //      //  Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
        //    }
        //
    }

    void PathGen()
    {
        float[] spectrum = new float[256];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        //transform.localPosition = new Vector3(transform.localPosition.x, multiplier * Mathf.Log(spectrum[0]) + 10, transform.localPosition.z);
        if(!WaveController.instance.spin)
        {
            transform.localPosition = new Vector3(0, multiplier * Mathf.Log(spectrum[0]) + 10, transform.localPosition.z);
        }
        GameObject cu = Instantiate(cube, transform.position, Quaternion.identity);
        cu.name = transform.position.x.ToString();
        Destroy(cu, 4);
        if (main)
        {
            if (cu.transform.position.y > beatThreshold)
            {
                quad.GetComponent<Renderer>().material.color = Random.ColorHSV();
                ld.intensity.value = -50;
            }
            else
            {
                ld.intensity.value = 0;
            } 
        }
    }

    
}
