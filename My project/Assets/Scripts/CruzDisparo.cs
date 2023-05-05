using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruzDisparo : MonoBehaviour
{
    public GameObject Modelo;// modelo de la cruz
	public GameObject Coordenadas;// el punto de origen o salida
	GameObject Cruz;//  el objeto a diparar

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update(){
        if( Input.GetMouseButton(0))
            dispararMagia();
    }
    public void dispararMagia()
    {
      if(Cruz==null){
            Cruz = Instantiate(Modelo, Coordenadas.transform.position, Quaternion.identity)as GameObject;
            //Cruz.transform.SetParent(Coordenadas.transform.parent);
            //Cruz.transform.rotation=Coordenadas.transform.rotation;
            Cruz.GetComponent<Rigidbody>().velocity=Coordenadas.transform.right*10f;
            Destroy(Cruz,2f);
       }      
    }    
}
