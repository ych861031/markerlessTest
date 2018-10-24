using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class generate : MonoBehaviour {

    public GameObject myPrefab;

    //public string[] gpsList = { "24.179208,120.649689", "24.178677,120.648887","24.178386, 120.649811","24.178265, 120.649083","24.178327, 120.648258",
    //"24.178646, 120.647696","24.178562, 120.647040","24.179203, 120.647018","24.179524, 120.646769", "24.179749, 120.647013",
    //"24.179342, 120.647871","24.181600, 120.648770", "24.179696, 120.648638","24.179797, 120.649315","24.179824, 120.649825",
    //"24.179761, 120.647720","24.180241, 120.646962","24.181001, 120.647711","24.181039, 120.646876","24.181662, 120.646718"};
    string[] gpsList = { "24.179208,120.649689", "24.178680, 120.649088", "24.178386, 120.649811" };
    string[] buildingList = { "資訊電機館", "圖書館", "商學大樓" };
    //public string[] buildingList = {"資訊電機館","圖書館","商學大樓","科學與航太館","紀念館",
    //"行政二館","行政大樓","忠勤樓","建築館","語文大樓",
    //"工學館","體育館", "人言大樓","人文社會館","電子通訊館",
    //"第一招待所","育樂館","理學大樓","土木水利館","學思樓"};

    public int[] lists = {-5, 5, 10,20};

    string[] location = "24.178851, 120.649673".Split(',');

    string[] imgList = {"IEEE","library","business"};

    string[] textList = { "本院目前的組織包括有電機與通訊工程博士學位學程、資訊工程學系(大學部、碩士班、博士班)、電機工程學系(大學部、碩士班)、電子工程學系(大學部、碩士班)、自動控制工程學系(大學部、碩士班)、通訊工程學系(大學部、碩士班)、資電榮譽班(大學部)",
        "開館及服務時間:\n週一至週五 08：30 - 22：00\n週六及週日 10：00 - 17：00\n科航館自修室  週一至週日 08：00 - 23：00",
        "前大學部計有會計學系、企業管理學系、國際貿易學系、財稅學系、合作經濟學系、統計學系、經濟學系、行銷學系等八個學系、一個國際企業管理學士學位學程及一個商學進修學士班" };
    // Use this for initialization
    void Start () {

        StartCoroutine("GetGps");

        for (int i = 0; i < gpsList.Length; i++){
            string[] word = gpsList[i].Split(',');
            //gps緯度是x經度y，unity裡左右改x、前後改z
            print(System.Math.Round(double.Parse(word[1])-double.Parse(location[1]),6)*100000);
            print(System.Math.Round(double.Parse(word[0]) - double.Parse(location[0]) , 6) * 100000);
            var x = 0 + (float)System.Math.Round(double.Parse(word[1]) - double.Parse(location[1]), 6) * 100000;
            var z = -25 + (float)System.Math.Round(double.Parse(word[0]) - double.Parse(location[0]), 6) * 100000;

            Vector3 move = new Vector3(x, float.Parse("-5"), z);
            //Vector3 rotation = new Vector3(-90, 90, 0);
            GameObject newObj = Instantiate(myPrefab,move,Quaternion.Euler(-90,90,0));
            newObj.name = "bilboard" + i.ToString();
            newObj.GetComponentInChildren<TextMesh>().text = buildingList[i];
            newObj.transform.localScale = new Vector3(2,2,2);
            GameObject cube = newObj.transform.GetChild(2).gameObject;
            cube.gameObject.name = "cube_" + i;//buildingList[i];
            GameObject canvas = newObj.transform.GetChild(3).gameObject;
            canvas.gameObject.name = "canvas" + i;
            GameObject title = canvas.transform.GetChild(1).gameObject;
            title.GetComponent<Text>().text = buildingList[i]; 
            GameObject image = canvas.transform.GetChild(2).gameObject;
            image.GetComponent<Image>().sprite = Resources.Load(imgList[i],typeof(Sprite)) as Sprite;

            GameObject textContent = canvas.transform.GetChild(3).gameObject;
            textContent.GetComponent<Text>().text = textList[i];
             
        }
    }
    float x = 0;
    float y = 0;
    bool gpsGetCheck = false;
	// Update is called once per frame
	void Update () {
        if( x!=0 && y!=0){
            print("x" + x);
            print("y" + y);
            gpsGetCheck = true;
        }
       
    }

    IEnumerator GetGps(){
        print("run");
        // 检查位置服务是否可用
        if (!Input.location.isEnabledByUser)
        {
            print("位置不可用");
            yield break;
        }
        Input.location.Start();

        // 等待初始化
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            print(Input.location.status.ToString() + ">>>" + maxWait.ToString());
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // 超時
        if (maxWait < 1)
        {
            print("服務初始化超時");
            yield break;
        }

        // 失敗
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("無法確定位置");
            yield break;
        }
        else
        {
            print(//"Location: \r\n" +
            "緯度：" + Input.location.lastData.latitude + "\r\n" +
                  "經度：" + Input.location.lastData.longitude + "\r\n");
            x = Input.location.lastData.latitude;
            y = Input.location.lastData.longitude;

            //最後面修改成你的陣列
            //rrrr = relationGPS(Input.location.lastData.latitude, Input.location.lastData.longitude, arrayList.test);

        }
        Input.location.Stop();
    }

    public ArrayList relationGPS(float a, float b, string[] arr)
    {
        float c;
        c = 0;//計算相對距離

        ArrayList ttts = new ArrayList();
        //存放陣列 i 值用
        int i;
        for (i = 0; i < arr.Length; i++)
        {
            string[] tmp = arr[i].Split(',');

            c = Mathf.Pow((a - Convert.ToSingle(tmp[0])), 2) + Mathf.Pow((b - Convert.ToSingle(tmp[1])), 2);
            c = Mathf.Sqrt(c);
            c *= 100;//km
            c *= 1000;//m
            print(c);

            if (c < 100)
            {
                ttts.Add(i);
            }
        }
        return ttts;
    }
}
