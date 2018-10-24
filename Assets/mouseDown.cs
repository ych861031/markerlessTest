using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDown : MonoBehaviour {

    GameObject canvas;
	// Use this for initialization
	void Start () {
        //string[] word = this.gameObject.name.Split('_');
        //canvas = GameObject.Find("canvas"+word[1]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static bool click = false;

    private void OnMouseDown()
    {
        string[] word = this.gameObject.name.Split('_');
        canvas = GameObject.Find("canvas" + word[1]);
        showMouseDownMsg();
        if (!click){
            canvas.GetComponent<Canvas>().enabled = true;
            click = true;
        }else{
            canvas.GetComponent<Canvas>().enabled = false;
            click = false;
        }


    }

    public void showMouseDownMsg(){
        Debug.Log("Object: DetechMouseDown");
        print(this.gameObject.name);
    }
}
