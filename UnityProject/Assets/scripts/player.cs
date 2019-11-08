using UnityEngine;

public class player : MonoBehaviour
{
    //定義欄位 Field
    //欄位類型 欄位名稱(指定 值) 結尾
    //預設 private 私人
    //public 公開
    [Header("速度"),Range(0f,100f)]
    public float speed = 3.5f;      //浮點數
    [Header("跳躍"),Range(100,2000)]
    public int jump = 300;          //整數
    [Header("是否在地板"),Tooltip("用來判定角色是否在地板上")]
    public bool isGround = false;   //布林值
   [Header("角色名稱")]
    public string _name = "HEAHEA";    //字串




 
}
