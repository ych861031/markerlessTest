using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchSreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(mouseDown.click){
            print("in");
            DesktopInput();
        }
       

	}


    void DesktopInput(){
        if(Input.GetMouseButton(0)){
            print("Click");
            try{
                GameObject.Find("Canvas").GetComponent < Canvas > ().enabled = false;
            }catch{
                print("maybe is closed");
            }
        }
    }


}
