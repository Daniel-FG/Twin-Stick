using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour
{
    private Rigidbody rigidBody;

    private const int bufferFrames = 1000;
    private int currentBuffer;
    private MyKeyFrame[] keyFrame = new MyKeyFrame[bufferFrames];
    private MyGameManager gameManager;
	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<MyGameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameManager.recording == true)
        {
            Record();
        }
        else
        {
            PlayBack();
        }
	}
    public void PlayBack()
    {
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        transform.position = keyFrame[frame].framePosition;
        transform.rotation = keyFrame[frame].frameRotation;
        Debug.Log("Playing frame " + frame);
    }
    public void Record()
    {
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
        keyFrame[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
        Debug.Log("Writing frame " + frame);
        
    }
}

/// <summary>
/// 哈
/// </summary>
public struct MyKeyFrame
{
    public float frameTime;
    public Vector3 framePosition;
    public Quaternion frameRotation;
    public MyKeyFrame(float time, Vector3 position, Quaternion rotation)
    {
        frameTime = time;
        framePosition = position;
        frameRotation = rotation;
    }

}
