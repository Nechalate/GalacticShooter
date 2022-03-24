using UnityEngine;

public class KillZone : MonoBehaviour
{
    // вражеские снаряды при столкновении с коллизией за границами сцены уничтожаются чтобы повысить производительность игры.
    void OnTriggerEnter2D(Collider2D col) {
        Destroy(col.gameObject);
    }
}
