using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollition : MonoBehaviour
{   
    public AudioClip keySound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider key)
    {
        if (key.gameObject.tag == "key")
        {
            Debug.Log("Collition with key");
            AudioSource.PlayClipAtPoint (keySound, transform.position);
            Destroy(key.gameObject);
        }
    }
}
