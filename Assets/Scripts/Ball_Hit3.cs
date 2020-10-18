using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball_Hit3 : MonoBehaviour
{
    public GameObject Ball;//インスタンス生成用ボールの変数
    public GameObject Ball_Clone;//インスタンス生成したボールのクローン
    public GameObject BallCamera;//ボール追従用カメラ
    public float CountTime;//SetTimeの秒数までカウントする
    public float SetTime;//この秒数でボールの飛距離が確定する
    public float DistanceX;//毎フレームX軸の距離(DistanceX)進む
    public float DistanceY;//毎フレームY軸の距離(DistanceY)進む
    public bool Hit;
    public static float Distance2;//打った位置から着地した地点の二点間の距離
    public bool Distance;
    public GameObject DistanceG;//何メートル飛んだか表示するテキストのオブジェクト
    public Text DistanceT;////何メートル飛んだか表示するテキストの中身
    public float Interval;//何メートルのテキスト表示してから何秒後にIngame1にもどるか

    // Start is called before the first frame update
    void Start()
    {
        Hit = true;
        SetTime = PlayerMove3.Time;
        DistanceX = PlayerMove3.DistanceX;
        DistanceY = PlayerMove3.DistanceY;
        Debug.Log(PlayerMove3.Time);
        Debug.Log("DistanceX = " + PlayerMove3.DistanceX);
        Debug.Log("DistanceY = " + PlayerMove3.DistanceY);
        Ball_Clone = Instantiate(Ball, new Vector3(0, -25, 0), Quaternion.identity);
        BallCamera.transform.parent = Ball_Clone.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CountTime += 1;
        if (SetTime <= CountTime)
        {
            Hit = false;
            Distance = true;
        }
        if (Hit)
        {
            Ball_Clone.transform.position += new Vector3(DistanceX, DistanceY, 0);
        }
        if (SetTime / 2 >= CountTime)
        {
            Ball_Clone.transform.localScale += new Vector3(0.01f, 0.01f, 0);

        }
        if (SetTime / 2 <= CountTime && SetTime >= CountTime)
        {
            Ball_Clone.transform.localScale += new Vector3(-0.01f, -0.01f, 0);
        }

        Distance2 = Vector2.Distance(new Vector2(0, -25), Ball_Clone.transform.position);
        if (Distance)
        {
            DistanceT.text = Mathf.Ceil(Distance2) + "m";
            DistanceG.SetActive(true);
            Interval += Time.deltaTime;
            if (Interval >= 2)
            {
                DistanceG.SetActive(false);
                Distance = false;
                Interval = 0;

                SceneManager.LoadScene("Stage3_Ingame1");
            }
        }
    }
}
