using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
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

    /* 改变方向计时器*/
    private float changeDirTimeVal = 4f;

    /*每隔多久改变方向*/
    private const float changeDirTime = 4f;

    private void Awake()
    {
        moveSpeed = 3;
    }


    private void FixedUpdate()
    {
        Move();
        Attack();
    }


    private void Attack()
    {
        bulletCoolTime += Time.deltaTime;

        if (bulletCoolTime >= 3f)
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
//    private void Die()
//    {
//  
//        Destroy(gameObject);
//
//        var go = Resources.Load<GameObject>(GameConst.ExplodePrefab);
//        Instantiate(go, transform.position, transform.rotation);
//
//
//        var tank = Resources.Load<GameObject>(GameConst.PlayerPrefab);
//        Instantiate(tank, bornVector3, transform.rotation);
//        isProtected = true;
//        protectTimeVal = 2f;
//        tank.transform.Find("Shield").gameObject.SetActive(true);
//
//        var relive = Resources.Load<GameObject>(GameConst.ShieldPrefab);
//        Instantiate(relive, bornVector3, transform.rotation);
//    }
    private void Move()
    {
        // 转向
        if (changeDirTimeVal >= changeDirTime)
        {
            int num = Random.Range(0, 8);
            if (num > 5)
            {
                v = -1;
                h = 0;
            }
            else if (num == 0)
            {
                v = 1;
                h = 0;
            }
            else if (num > 0 && num <= 3)
            {
                h = -1;
                v = 0;
            }
            else if (num > 3 && num <= 5)
            {
                h = 1;
                v = 0;
            }
            changeDirTimeVal = 0;
            Debug.Log("敌人改变方向");
        }
        else
        {
            changeDirTimeVal += Time.fixedDeltaTime;
        }


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