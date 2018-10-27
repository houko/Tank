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
    public float moveSpeed;

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
    private float protectTimeVal;


    private void Awake()
    {
        moveSpeed = 5;
        protectTimeVal = 2f;
    }


    private void FixedUpdate()
    {
        Move();
        Attack();
        CheckShield();
    }


    private void CheckShield()
    {
        if (isProtected)
        {
            protectTimeVal -= Time.deltaTime;
            if (protectTimeVal <= 0)
            {
                isProtected = false;
            }
        }
    }


    private void Attack()
    {
        bulletCoolTime += Time.deltaTime;

        if ((Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.J)) && bulletCoolTime >= 0.5f)
        {
            GameObject go = Resources.Load<GameObject>(GameConst.BulletPrefab);
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

        var go = Resources.Load<GameObject>(GameConst.ExplodePrefab);
        Instantiate(go, transform.position, transform.rotation);


        var tank = Resources.Load<GameObject>(GameConst.PlayerPrefab);
        Instantiate(tank, GameConst.PlayerBornVector3, transform.rotation);
        isProtected = true;
        protectTimeVal = 2f;
        tank.transform.Find("Shield").gameObject.SetActive(true);

        var relive = Resources.Load<GameObject>(GameConst.ShieldPrefab);
        Instantiate(relive, GameConst.PlayerBornVector3, transform.rotation);
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