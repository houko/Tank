using System;
using UnityEngine;

/**
 * 1. 攻击
 * 2. 移动
 * 3. 死亡
 * 4. 攻击
 */
public class Player : MonoBehaviour
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

    /*是否有护盾*/
    private bool isProtected;

    /*护盾时间*/
    private float protectTimeVal = 3;

    private GameObject player;

    /*玩家血量*/
    public static int hp = 3;

    private void Update()
    {
        Attack();
        CheckShield();
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void CheckShield()
    {
        if (isProtected)
        {
            protectTimeVal -= Time.deltaTime;
            if (protectTimeVal <= 0)
            {
                isProtected = false;
                player.transform.Find("Shield").gameObject.SetActive(false);
            }
        }
    }


    private void Attack()
    {
        bulletCoolTime += Time.deltaTime;

        if ((Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.J)) && bulletCoolTime >= 0.5f)
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
        if (isProtected)
        {
            return;
        }

        Destroy(gameObject);

        // 爆炸
        var go = Resources.Load<GameObject>(GameConst.ExplodePrefab);
        Instantiate(go, transform.position, transform.rotation);
        hp -= 1;
        Debug.Log("hp is " + hp);

        if (hp == 0)
        {
            Debug.Log("game over");
        }

        // 重生
        player = Resources.Load<GameObject>(GameConst.PlayerPrefab);
        Instantiate(player, GameConst.PlayerBornVector3, transform.rotation);
        isProtected = true;
        protectTimeVal = 3f;

        // 魔法盾标识
        player.transform.Find("Shield").gameObject.SetActive(true);
    }

    private void Move()
    {
        // 垂直方向
        h = Input.GetAxis("Horizontal");

        // 水平方向
        v = Input.GetAxis("Vertical");

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