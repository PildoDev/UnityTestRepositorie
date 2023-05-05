using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Scrollbar vida;
    public TMP_Text llavesTXT;
    public TMP_Text timerTXT;
    private float bVida = 1;
    private float speed = 1;
    private int llaves = 0;
    private int llavesTotales = 0;
    public bool backwards;
    public GameObject gameOver;
    [SerializeField] MenuScript menuScript;
    [Tooltip("if it's backwards set the timer here")] public float time;
    private int minutes, seconds, cents;

    void Start()
    {
        this.bVida = 1;
        this.llaves = 0;
        this.llavesTotales = GameObject.FindGameObjectsWithTag("key").Length;
        this.vida.GetComponent<Scrollbar>().size = bVida;
        llavesTXT.text="Llaves : " + llaves + "/" + llavesTotales;
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*Funcion para el tiempo*/
        if(backwards ==true){
            time -= Time.deltaTime;
            if(time < 0) time=0;

        }else{
            time += Time.deltaTime;
        }

        minutes =(int)(time/60f);
        seconds =(int)(time - minutes *60f);
        //cents =(int)((time- (int)time) *100f);
        
        timerTXT.text = "Tiempo: "+string.Format("{0:00}:{1:00}",minutes, seconds);
        /* /--Funcion para el tiempo--/ */

        this.bVida -= 0.00005f;
        this.vida.GetComponent<Scrollbar>().size = bVida;
        if(bVida <= 0){
            this.gameOver.SetActive(true);
            //yield return new WaitForSeconds(5);
            menuScript.Menu();
        }

    }

    private void OnTriggerEnter(Collider other) {
        //speed = speed + 1;
        if(other.name=="Zombie3"){
            this.bVida = this.bVida - 0.1f;
            this.vida.GetComponent<Scrollbar>().size = bVida;
        }
        if (other.tag == "key"){
            llaves++;
            llavesTXT.text="Llaves : " + llaves + "/" + llavesTotales;
        }
    }

    public void KeyCollected(){
        llaves++;
        llavesTXT.text="Llaves : " + llaves + "/" + llavesTotales;
    }
}
