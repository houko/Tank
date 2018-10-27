using UnityEngine;

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

    /*是否有护盾*/
    private bool isProtected;

    private void Awake()
    {
        moveSpeed = 5;
    }

    private void FixedUpdate()
    {
        Move();
        Attack();
    }

    private void Move()
    {
        bulletEulerAngles = transform.position;
    }


    private void Attack()
    {
        bulletCoolTime += Time.deltaTime;

        if (bulletCoolTime >= 0.5f)
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
        Destroy(gameObject);

        var go = Resources.Load<GameObject>(GameConst.ExplodePrefab);
        Instantiate(go, transform.position, transform.rotation);
    }
}