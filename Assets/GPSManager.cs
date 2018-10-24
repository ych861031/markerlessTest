using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GPSManager : MonoBehaviour
{

    public Text txt;
    public ArrayList rrrr;//接relationGPS的回傳值

    public void GetGPS()
    {
        StartCoroutine(StartGPS());
        
    }

    IEnumerator StartGPS()
    {
        txt.text = "開始獲取GPS訊息";

        // 检查位置服务是否可用
        if (!Input.location.isEnabledByUser)
        {
            txt.text = "位置不可用";
            yield break;
        }

        // 查詢之前先開啟
        txt.text = "開啟";
        Input.location.Start();

        // 等待初始化
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            txt.text = Input.location.status.ToString() + ">>>" + maxWait.ToString();
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // 超時
        if (maxWait < 1)
        {
            txt.text = "服務初始化超時";
            yield break;
        }

        // 失敗
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            txt.text = "無法確定位置";
            yield break;
        }
        else
        {
            txt.text = //"Location: \r\n" +
            "緯度：" + Input.location.lastData.latitude + "\r\n" +
            "經度：" + Input.location.lastData.longitude + "\r\n";

            
            //最後面修改成你的陣列
            //rrrr = relationGPS(Input.location.lastData.latitude, Input.location.lastData.longitude, arrayList.test);
            
        }

        // 停止，如果沒有要繼續更新位置
        Input.location.Stop();
    }

    public ArrayList relationGPS(float a,float b,string[] arr)
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
