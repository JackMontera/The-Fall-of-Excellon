using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Invoke("DestroyMe", 3f);

    }

    void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
