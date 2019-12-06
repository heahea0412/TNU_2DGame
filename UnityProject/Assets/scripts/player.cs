using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    #region 欄位區域
    
    //定義欄位 Field
    //欄位類型 欄位名稱(指定 值) 結尾
    //預設 private 私人
    //public 公開
    [Header("速度"), Range(0f, 100f)]
    public float speed = 3.5f;      //浮點數
    [Header("跳躍"), Range(100, 2000)]
    public int jump = 300;          //整數
    [Header("是否在地板"), Tooltip("用來判定角色是否在地板上")]
    public bool isGround = false;   //布林值
    [Header("角色名稱")]
    public string _name = "HEAHEA";    //字串
    [Header("元件")]
    public Rigidbody2D r2d;
    public Animator ani;
    [Header("音效區域")]
    public AudioSource aud;
    public AudioClip soundcherry;
    [Header("櫻桃區域")]
    public int cherryCurrent;
    public int cherryTotal;
    public Text textCherry;




    #endregion

    //定義方法
    //語法
    //修飾詞 傳回類型 方法名稱(){}
    //void無傳回

    private void Move()
    {
        float h =  Input.GetAxisRaw("Horizontal");   //輸入.取得軸向("水平")左右與AD
        r2d.AddForce(new Vector2(speed*h, 0));
        ani.SetBool("跑步開關", h != 0);    //動畫元件.設定布林值

        if(Input.GetKeyDown(KeyCode.A)) transform.eulerAngles = new Vector3(0, 180, 0);
        else if (Input.GetKeyDown(KeyCode.D)) transform.eulerAngles = new Vector3(0, 0, 0);
      
    }
    private void Jump()
    {
        //如果按下空白鍵 並且 在地板上等於勾選
        if (Input.GetKeyDown(KeyCode.Space)&& isGround == true)
        {
            isGround = false;   //在地板上 = 取消
            r2d.AddForce(new Vector2(0,jump));  //剛體.推力(往上)
            ani.SetTrigger("跳躍觸發");    //動畫元件.設定觸發器
        }
    }
    private void Dead()
    {

    }

    private void Start()
    {
        cherryTotal=GameObject.FindGameObjectsWithTag("櫻桃").Length;
        textCherry.text = "櫻桃:0/" + cherryTotal;
    }

    //事件:在特定時間點以指定次數執行
    //更新事件
    private void Update()
    {
        Move();
        Jump();
    }

    //碰撞事件:2D物件碰撞時執行一次
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name=="地板")
        {
            isGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "櫻桃")
        {
            aud.PlayOneShot(soundcherry, 1.5f);
            Destroy(collision.gameObject);   //刪除碰撞物件
            cherryCurrent++;
            textCherry.text = "櫻桃:" + cherryCurrent + "/" + cherryTotal;
        }
    }
}