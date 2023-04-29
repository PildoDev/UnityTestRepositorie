using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollition : MonoBehaviour
{   
	//public GameObject UIHandler;
	
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	
	/*CODIGO PARA REPRODUCIR SONIDO PERO DESDE EXTERNO*/
	//Hay que agregar los sonidos en el script del jugador
	public AudioClip keySound; 
	public AudioClip gunSound;
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "key")
		{
			Debug.Log("Collision with key");
			AudioSource.PlayClipAtPoint (keySound, transform.position); //Reproduce el sonido
			Destroy(other.gameObject); //Elimina el objeto
			//this.UIHandler.GetComponent<FirstScript>(); //Aumenta el contador de llaves
		}

		if (other.tag == "pistol3")
		{
			Debug.Log("Collision with pistol3");
			AudioSource.PlayClipAtPoint (gunSound, transform.position); //Reproduce el sonido
			Destroy(other.gameObject); //Elimina el objeto
			//this.UIHandler.GetComponent<FirstScript>(); //Aumenta el contador de llaves
		}
	}

	/*CODIGO PARA REPRODUCIR SONIDO Y ESPERAR PARA ELIMINAR
	private void OnTriggerEnter(Collider key)
	{
		if (key.tag == "key")
		{
			Debug.Log("Collision with key");
			key.GetComponent<AudioSource>().Play(); //Hay que agregar el sonido al objeto key
		}
	}

	private void OnTriggerStay(Collider key) {
		if (key.GetComponent<AudioSource>().isPlaying){
			print("Reproduciendo");
		}else{
			print("No Reproduciendo");
			Destroy(key.gameObject);//Elimina el objeto
		}
	}
	*/
}
