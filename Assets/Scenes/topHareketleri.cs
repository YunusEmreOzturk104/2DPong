using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class topHareketleri : MonoBehaviour
{
    public Rigidbody2D top;
    public float xHizi, yHizi;
    public TextMeshProUGUI player1Yazi, player2Yazi, kazananYazisi,bitisYazisi;
    int player1Skor, player2Skor;
    public int maxSkor;
    public AudioSource skorSesi, kazanmaSesi;

    void Start()
    {
        
    }

    void Update()
    {
        player1Yazi.text = player1Skor.ToString();
        player2Yazi.text = player2Skor.ToString();
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }
    void OnCollisionEnter2D(Collision2D temas)
    {
        if (temas.gameObject.tag=="Player1")
        {
            top.velocity = new Vector2(-xHizi, Random.Range(-3f,3f));
        }
        else if (temas.gameObject.tag == "Player2")
        {
            top.velocity = new Vector2(xHizi, Random.Range(-3f, 3f));
        }
        if (temas.gameObject.tag=="UstDuvar")
        {
            top.velocity = new Vector2(top.velocity.x, -yHizi);
        }
        else if (temas.gameObject.tag=="AltDuvar")
        {
            top.velocity = new Vector2(top.velocity.x, yHizi);
        }
        if (temas.gameObject.tag == "SolDuvar")
        {
            player1Skor++;
            transform.position = new Vector2(-6.06f, 0f);
            skorSesi.Play();
        }
        else if (temas.gameObject.tag == "SagDuvar")
        {
            player2Skor++;
            transform.position = new Vector2(6.06f, 0f);
            skorSesi.Play();
        }
        if (player1Skor==maxSkor)
        {
            kazananYazisi.text = "player 1 win";
            bitisYazisi.text = "OYUN BÝTTÝ!!! \n TEKRAR OYNAMAK ÝÇÝN ENTER TUSUNA BASÝNÝZ";
            kazanmaSesi.Play();
            Time.timeScale = 0;
        }
        else if (player2Skor==maxSkor)
        {
            kazananYazisi.text ="player2 win ";
            bitisYazisi.text = "OYUN BÝTTÝ!!! \n TEKRAR OYNAMAK ÝÇÝN ENTER TUSUNA BASÝNÝZ";
            kazanmaSesi.Play();
            Time.timeScale = 0;
        }
        
    }
}

