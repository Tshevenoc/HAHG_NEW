using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour {

    public GameObject Explode;
    public GameObject Burn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {

        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "Pineapple_Grenade")
        {
            Instantiate(Explode, col.gameObject.transform.position, col.gameObject.transform.rotation);
            Instantiate(Burn, col.gameObject.transform.position, col.gameObject.transform.rotation);
            Debug.Log("GRENADE THROWN ON GROUND AHHHHHHHHHHHH!");
            
        }
    }
}
