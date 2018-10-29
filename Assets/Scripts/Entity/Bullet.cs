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

    private int BulletLevel { get; set; }

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
            // 打到墙则打破墙
            case GameConst.WallTag:
                Destroy(gameObject);
                Destroy(other.gameObject);
                break;
            case GameConst.BarrierTag:
                // 玩家子弹打到砖播放声音
                if (BulletLevel > 1)
                {
                    // 子弹大于1级可以打破砖
                    Destroy(other.gameObject);
                }

                if (isPlayerBullet)
                {
                    other.SendMessage("PlayerAudio");
                }

                Destroy(gameObject);
                break;
            case GameConst.TankTag:
                if (!isPlayerBullet)
                {
                    // 敌人子弹打玩家
                    other.SendMessage("Die");
                    Destroy(gameObject);
                }

                break;
            case GameConst.EnemyTag:
                if (isPlayerBullet)
                {
                    // 玩家子弹打敌人
                    other.SendMessage("Die");
                    Destroy(gameObject);
                }

                break;
            case GameConst.HomeTag:
                // 子弹打到老家游戏结束
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