using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    int delay = 0;
    GameObject a, b;
    public GameObject bullet, explosion;
    Rigidbody2D rb;
    public float speed;
    int health = 3;

    void Awake(){
        rb=GetComponent<Rigidbody2D>();
        a=transform.Find("a").gameObject;
        b=transform.Find("b").gameObject;
    }
 
    void Start() {
        PlayerPrefs.SetInt("Health", health);
    }
    // управление кораблем + при нажатии "space" вызвать метод "стрельба".
    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal")*speed,0));
        rb.AddForce(new Vector2(0,Input.GetAxis("Vertical")*speed));

        if (Input.GetKey(KeyCode.Space) &&  delay > 15)
            Shoot();

        delay++;
    }
    // метод описывает действия при столкновении с снарядом врага "получение урона".
    public void Damage(){
        health--;
        PlayerPrefs.SetInt("Health", health);
        StartCoroutine(Blink());
        if (health == 0) {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.1f);
        }
    }
    // обновление спрайта здоровья.
    IEnumerator Blink() {
        GetComponent<SpriteRenderer>().color=new Color(1,0,0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color=new Color(1,1,1);
    }
    // метод спавна пуль "выстрелы".
    void Shoot(){
        delay=0;
        Instantiate(bullet,a.transform.position, Quaternion.identity);
        Instantiate(bullet,b.transform.position, Quaternion.identity);
    }
    // метод получение здоровья при подборе "аптечек".
    public void AddHealth() {
        health++;
        PlayerPrefs.SetInt("Health", health);
    }
}
