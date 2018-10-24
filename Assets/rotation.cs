using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {


    GameObject cam;
    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    // Update is called once per frame
    void Update () {
        //print(cam.transform.rotation);
        //var pos = this.transform.position;
        //var rot = (pos.x - cam.transform.rotation.y);
        //var x = cam.transform.rotation.y * 180;
        //print("x" + x);
        //this.transform.rotation = Quaternion.Euler(-90, x + 80, 0);
        //transform.LookAt(cam.transform);
        var angle = GetAngle(this.transform.position, cam.transform.position);
        //print("angle" + angle);
        this.transform.rotation = Quaternion.Euler(-90, angle -90, 0);

    }

    private float GetAngle(Vector3 a, Vector3 b)
    {
        b.x -= a.x;
        b.z -= a.z;

        float deltaAngle = 0;
        if (b.x == 0 && b.z == 0)
        {
            return 0;
        }
        else if (b.x > 0 && b.z > 0)
        {
            deltaAngle = 0;
        }
        else if (b.x > 0 && b.z == 0)
        {
            return 90;
        }
        else if (b.x > 0 && b.z < 0)
        {
            deltaAngle = 180;
        }
        else if (b.x == 0 && b.z < 0)
        {
            return 180;
        }
        else if (b.x < 0 && b.z < 0)
        {
            deltaAngle = -180;
        }
        else if (b.x < 0 && b.z == 0)
        {
            return -90;
        }
        else if (b.x < 0 && b.z > 0)
        {
            deltaAngle = 0;
        }

        float angle = Mathf.Atan(b.x / b.z) * Mathf.Rad2Deg + deltaAngle;
        return angle;
    }
}
