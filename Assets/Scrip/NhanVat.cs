using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class NhanVat : MonoBehaviour
{
    public Animator ani;
    public Rigidbody2D rb;
    public bool isRight = true;
    public bool nen;
    private int tongdiem = 0;
    public AudioSource MainSoud;
    public AudioSource DeadSoud;
    public GameObject pannel,button,text,bung_xu;
    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        tinhDiem(0);
        MainSoud.Play();
        DeadSoud.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) {
            isRight = true;
            ani.SetBool("isRunning",true);
            transform.Translate(Time.deltaTime * 5,0,0);
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            transform.localScale = scale; }
        
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            isRight = false;
            ani.SetBool("isRunning",true);
            transform.Translate(-Time.deltaTime * 5,0,0);
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? -1 : 1;
            transform.localScale = scale; }
        
        else { ani.SetBool("isRunning",false); }

        if (Input.GetKey(KeyCode.UpArrow)) {
            if (isRight) {
                transform.Translate(0, Time.deltaTime* 7,0);
                Vector2 scale = transform.localScale;
                scale.x *= scale.x > 0 ? 1 : -1;
                transform.localScale = scale; }
            
            else {
                transform.Translate(-0, Time.deltaTime* 7,0);
                Vector2 scale = transform.localScale;
                scale.x *= scale.x > 0 ? -1 : 1;
                transform.localScale = scale; }
        }

        if (nen) {
            if (Input.GetKey(KeyCode.Space)) {
                        if(isRight) {
                            rb.AddForce(new Vector2(0,500));
                            Vector2 scale = transform.localScale;
                            scale.x *= scale.x > 0 ? 1 : -1;
                            transform.localScale = scale; }
                        
                        else {
                            rb.AddForce(new Vector2(0,500));
                            Vector2 scale = transform.localScale;
                            scale.x *= scale.x > 0 ? -1 : 1;
                            transform.localScale = scale; }

                        nen = false; }
        }
    }
    void tinhDiem(int diem)
    {
        tongdiem += diem;
        score.text = ": " + tongdiem;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("nen_dat"))
        {
            nen = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {   //ăn nấm
        if (other.gameObject.tag == "tren") {
            var name = other.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
            tinhDiem(3);
        }
        
        if (other.gameObject.tag == "trai" || other.gameObject.tag == "phai") {
            Time.timeScale = 0;
            pannel.SetActive(true);//show panel
            button.SetActive(true);
            text.SetActive(true); }
        
        if (other.CompareTag("coin")) {
             Destroy(other.gameObject);
             tinhDiem(1);
             DeadSoud.Play(); 
             DeadSoud.Play(); }
        
        if (other.CompareTag("bung_xu")) {
            Destroy(other.gameObject);
            Instantiate(bung_xu,
                other.gameObject.transform.position,
                other.gameObject.transform.localRotation);
            tinhDiem(5);
            DeadSoud.Play(); }
    }
}
