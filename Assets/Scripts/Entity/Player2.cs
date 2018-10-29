using System;
using UnityEngine;

/**
 * 1. 攻击
 * 2. 移动
 * 3. 死亡
 * 4. 攻击
 */
public class Player2 : MonoBehaviour
{
    public float moveSpeed = 3;

    /*垂直方向*/
    public float h;

    /*水平方向*/
    public float v;

    /*枪口方向*/
    private Vector3 bulletEulerAngles;

    /*攻击冷却时间*/
    private float bulletCoolTime;

    /*护盾时间*/
    private float protectTimeVal = 3;

    private AudioSource tankAudio;


    private void Awake()
    {
        tankAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (GameContext.isGameOver)
        {
            return;
        }

        Attack();
        CheckShield();
    }

    private void FixedUpdate()
    {
        if (GameContext.isGameOver)
        {
            return;
        }

        Move();
    }


    private void CheckShield()
    {
        if (protectTimeVal > 0)
        {
            protectTimeVal -= Time.deltaTime;
            if (protectTimeVal <= 0)
            {
                transform.Find("Shield").GetComponent<Renderer>().enabled = false;
            }
        }
    }


    private void Attack()
    {
        bulletCoolTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Return) && bulletCoolTime >= 0.5f)
        {
            GameObject go = Resources.Load<GameObject>(GameConst.PlayerBulletPrefab);
            Instantiate(go, transform.position, Quaternion.Euler(bulletEulerAngles));
            bulletCoolTime = 0f;
        }
    }


    /// <summary>
    /// 死
    /// 1. 销毁
    /// 2. 爆炸效果，0
    /// 3. 在出生地重新实例化
    /// 4. 播放重生效果
    /// </summary>
    private void Die()
    {
        // 无敌状态不会死亡
        if (protectTimeVal > 0)
        {
            return;
        }

        Destroy(gameObject);

        // 爆炸
        var go = Resources.Load<GameObject>(GameConst.ExplodePrefab);
        Instantiate(go, transform.position, transform.rotation);
        GameContext.player2Hp -= 1;
        Debug.Log("hp is " + GameContext.player2Hp);

        if (GameContext.player1Hp == 0 && GameContext.player2Hp == 0)
        {
            GameContext.isGameOver = true;
            return;
        }

        Relive();
    }


    /**
     * 重生
     * 只能在玩家的死亡方法调用
     */
    private void Relive()
    {
        if (GameContext.player2Hp > 0)
        {
            // 重生
            GameObject go = Resources.Load<GameObject>(GameConst.BornPrefab2);
            Instantiate(go, GameConst.Player2BornVector3, Quaternion.identity);
        }
    }


    private void Move()
    {
        // 垂直方向
        h = Input.GetAxis("Player2Horizontal");

        // 水平方向
        v = Input.GetAxis("Player2Vertical");

        // 沿x移动
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);

        // 往右
        if (h < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
            bulletEulerAngles = new Vector3(0, 0, 90);
        }

        // 往左
        if (h > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            bulletEulerAngles = new Vector3(0, 0, -90);
        }

        if (Math.Abs(h) > 0)
        {
//            AudioClip audioClip = Resources.Load<AudioClip>(GameConst.DrivingAudio);
//            tankAudio.Stop();
//            tankAudio.clip = audioClip;
//            if (!tankAudio.isPlaying)
//            {
//                AudioSource.PlayClipAtPoint(audioClip, transform.position);
//            }

            return;
        }


        // 沿y移动
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);

        // 往下
        if (v < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
            bulletEulerAngles = new Vector3(0, 0, 180);
        }

        // 往上
        if (v > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            bulletEulerAngles = new Vector3(0, 0, 0);
        }
    }
}