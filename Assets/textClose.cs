using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textClose : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        showMouseDownMsg();
    }

    public void showMouseDownMsg()
    {
        Debug.Log("Object: DetechMouseDown");
        print(this.gameObject.name);
    }
}
