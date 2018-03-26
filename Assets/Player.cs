using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        print(CrossPlatformInputManager.GetAxis("Horizontal"));
        print(CrossPlatformInputManager.GetAxis("Vertical"));

    }
}
