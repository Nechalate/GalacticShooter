using UnityEngine;

public class Battery : MonoBehaviour
{
    // если врезался обьект с тегом "игрок" выполнить метод "добавить здоровье" и уничтожится.
    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag=="Player") {
            col.gameObject.GetComponent<Move>().AddHealth();
            Destroy(gameObject);
        }
    }
}
