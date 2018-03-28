using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetButton : MonoBehaviour {
    GameObject horseshoe;
    // Use this for initialization
    void Start () {
        //horseshoe = GetComponent<GameObject>();
        //defPos = horseshoe.transform.position;
        //defRot = horseshoe.transform.localRotation;
        //defScale = horseshoe.transform.localScale;
    }
	
	// Update is called once per frame
	void onTriggerEnter (Collider other)
    {
        horseshoe = GetComponent<GameObject>();
        horseshoe.transform.position = new Vector3(5.9954e-09f, 0.014821f, 3.1607e-08f);
        Debug.Log("triggered");
    }
}
