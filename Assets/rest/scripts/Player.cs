using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour
{
    [Tooltip("In m/s")] [SerializeField] float xSpeed = 10f;
    [Tooltip("In m/s")] [SerializeField] float xRange = 5f;
    [Tooltip("In m/s")] [SerializeField] float yRange = 3f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;
    [SerializeField] GameObject gun1,gun2;
    float xThrow, yThrow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        Fire();
        int count=FindObjectsOfType<AudioSource>().Length;
        if(count>1)
        {
            FindObjectsOfType<AudioSource>()[0].Stop();
        }
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffsetThisFrame = xThrow * xSpeed * Time.deltaTime;
        float yOffsetThisFrame = yThrow * xSpeed * Time.deltaTime;

        float xrawNewPos = transform.localPosition.x + xOffsetThisFrame;
        float xPos = Mathf.Clamp(xrawNewPos, -xRange, xRange);

        float yrawNewPos = transform.localPosition.y + yOffsetThisFrame;
        float yPos = Mathf.Clamp(yrawNewPos, -yRange, yRange);

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }

    void onPlayerDeath()
    {
        print("Die");
    }

    private void Fire(){
        if(Input.GetButton("Fire")){
            gun1.SetActive(true);
            gun2.SetActive(true);
        }
        else if(!Input.GetButton("Fire")){
            gun1.SetActive(false);
            gun2.SetActive(false);
        }
    }
}