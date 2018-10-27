using DefaultNamespace;
using UnityEngine;

/**
 * 子弹
 * 1. 移动
 * 2. 碰到物体的碰撞操作
 */
public class Bullet : MonoBehaviour
{
    private const float moveSpeed = 10f;

    public bool isPlayerBullet;

    private void Update()
    {
        transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
    }


    /// <summary>
    /// 子弹和其他物体碰撞了
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case GameObjectTag.Wall:
                Destroy(gameObject);
                Destroy(other.gameObject);
                break;
            case GameObjectTag.Barrier:
                if (isPlayerBullet)
                {
                    other.SendMessage("PlayerAudio");
                }

                Destroy(gameObject);
                break;
            case GameObjectTag.Tank:
                if (!isPlayerBullet)
                {
                    // 敌人打玩家
                    other.SendMessage("Die");
                    Destroy(gameObject);
                }

                break;
            case GameObjectTag.Enemy:
                if (isPlayerBullet)
                {
                    // 玩家打敌人
                    other.SendMessage("Die");
                    Destroy(gameObject);
                }

                break;
            case GameObjectTag.Home:
                Destroy(gameObject);
                Destroy(other.gameObject);
                var home = Resources.Load<GameObject>(GameConst.DieHomePrefab);
                Instantiate(home, other.transform.position, Quaternion.identity);

                var explode = Resources.Load<GameObject>(GameConst.ExplodePrefab);
                Instantiate(explode, other.transform.position, Quaternion.identity);
                GameContext.isGameOver = true;
                break;
        }
    }
}