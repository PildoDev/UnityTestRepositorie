using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCollection : MonoBehaviour
{   
    public GameObject leftHandNormal;
    public GameObject leftHandCruz;
    public GameObject rightHandNormal;
    public GameObject rightHandPistola;
    [SerializeField] UIHandler uiHandler;
    // Start is called before the first frame update
    void Start()
    {
        leftHandNormal.SetActive(true);
        leftHandCruz.SetActive(false);
        rightHandNormal.SetActive(true);
        rightHandPistola.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "key")
		{
			leftHandNormal.SetActive(false);
            leftHandCruz.SetActive(true);
            uiHandler.KeyCollected();
		}

        if (other.tag == "pistol3")
		{
            rightHandNormal.SetActive(false);
            rightHandPistola.SetActive(true);
		}
	}
}
