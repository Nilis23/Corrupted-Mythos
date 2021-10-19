using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera cam;

    CinemachineBasicMultiChannelPerlin perlin;
    float timer;
    float tTimer;
    float strength;
    bool strengthen = false;

    private void Awake()
    {
        if (cam == null)
        {
            cam = GetComponent<CinemachineVirtualCamera>();
        }
        perlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void shakeCam(float intensity, float time, bool inverse = false)
    {   
        strength = intensity;
        timer = time;
        tTimer = time;
        strengthen = inverse;
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;

            if (!strengthen)
            {
                perlin.m_AmplitudeGain = Mathf.Lerp(strength, 0f, (1 - (timer / tTimer)));
            }
            else
            {
                perlin.m_AmplitudeGain = Mathf.Lerp(0f, strength, (1 - (timer / tTimer)));
                
                if(timer <= 0)
                {
                    perlin.m_AmplitudeGain = 0;
                    strengthen = false;
                }
            }
        }
    }
}
