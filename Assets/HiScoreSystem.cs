using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiScoreSystem : MonoBehaviour
{
    public static float SCORE;
    public float HiSCORE;
    // Start is called before the first frame update
    void Start()
    {
        HiSCORE = PlayerPrefs.GetFloat("HiSCORE", 0);
        this.GetComponent<Text>().text = "HiScore:" + HiSCORE;
    }

    // Update is called once per frame
    void Update()
    {

        if (SCORE > HiSCORE)
        {

            HiSCORE = SCORE;
            //ハイスコア更新

            PlayerPrefs.SetFloat("HiSCORE", HiSCORE);
            //ハイスコアを保存

            this.GetComponent<Text>().text = "HiScore:" + HiSCORE;
            //ハイスコアを表示
        }
    }
}
