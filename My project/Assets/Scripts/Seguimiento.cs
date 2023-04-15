using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguimiento : MonoBehaviour
{
	UnityEngine.AI.NavMeshAgent  Agente;
	Vector3   PosInicial;
	public GameObject Enemigo;
	GameObject Rotacion;
	bool vista;
	Vector3 distancia;
	public LayerMask floorLayer;
	double distanciaMínima = 1.75;
	// Start is called before the first frame update
	void Start()
	{ 
		this.Agente=this.GetComponent<UnityEngine.AI.NavMeshAgent>();  
		PosInicial=this.transform.position;
		this.Rotacion=this.gameObject;
	}
	public void navegar(GameObject Objetivo)
	{
		UnityEngine.AI.NavMeshHit hit;
		this.vista=UnityEngine.AI.NavMesh.Raycast(this.transform.position,this.Enemigo.transform.position, out hit,UnityEngine.AI.NavMesh.AllAreas);
		//print(hit.distance);

		if(hit.distance<distanciaMínima)//estoy cerca
		{	
			this.Agente.SetDestination(Objetivo.transform.position);
			this.ataque();
		}
		if(hit.distance>=distanciaMínima && hit.distance<=20)//distancia media
			if(!this.vista){
				this.Agente.SetDestination(Objetivo.transform.position);
				this.caminar();
			}
			else
				this.Agente.SetDestination(PosInicial);
				rotar();
		if(hit.distance>20)
			this.Agente.SetDestination(PosInicial);
	}

	public void rotar()
	{
		float distancia=Vector3.Distance(this.transform.position,PosInicial);
		//print(distancia);
		if(distancia<1.6f )
		{
			this.transform.eulerAngles = new Vector3(0,this.Rotacion.transform.rotation.y,0);
			this.idle();
		}
	}

	public bool espalda() {
		Vector3 objetivo = Enemigo.transform.position - this.transform.position;
		RaycastHit hit;
		Physics.Raycast(new Vector3(transform.position.x, 0.5f, transform.position.z), objetivo, out hit, Mathf.Infinity);
		if (hit.collider.tag == "Espalda")
			return false;
		return true;
	}

	public void caminar(){
		this.GetComponent<Animator>().SetBool("Ver",true);
		this.GetComponent<Animator>().SetBool("Ataque",false);
	}
	
	public void idle(){
		this.GetComponent<Animator>().SetBool("Ver",false);
		this.GetComponent<Animator>().SetBool("Ataque",false);
	}

	public void ataque() {
		//this.GetComponent<Animator>().SetTrigger("Ataque");
		this.GetComponent<Animator>().SetBool("Ataque",true);
	}

	// Update is called once per frame
	void Update()
	{
		if(espalda())
			this.navegar(this.Enemigo);
	}
}