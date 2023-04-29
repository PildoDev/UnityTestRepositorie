using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCollection : MonoBehaviour
{
    public GameObject manosNormales;
    public GameObject manosCruz;
    // Start is called before the first frame update
    void Start()
    {
        manosNormales.SetActive(true);
        manosCruz.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "key")
		{
			manosNormales.SetActive(false);
            manosCruz.SetActive(true);
		}
	}
}
