using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventario : MonoBehaviour{
    private bool inventarioIsOpen = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
        /*
        if (Input.GetKeyDown("y"))
            SceneManager.LoadScene(3, LoadSceneMode.Additive);
        if (Input.GetKeyDown("z"))
            SceneManager.UnloadSceneAsync(3);
        */
        if (Input.GetKeyDown("e") && inventarioIsOpen==true){
            inventarioIsOpen = false;
            cerrarInventario();
        }else if(Input.GetKeyDown("e") && inventarioIsOpen==false){
            inventarioIsOpen = true;
            abrirInventario();
        }
    }

    void abrirInventario(){
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
    }

    void cerrarInventario(){
        SceneManager.UnloadSceneAsync(3);
    }
}
