using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmerTextUpdater : MonoBehaviour {

    public Text textFeild;
    public GameObject player;
    public Vector3 offset;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        FarmersBag bag = (FarmersBag)player.GetComponent(typeof(FarmersBag));
        textFeild.text = "Money:" + bag.money;
        transform.position = player.transform.position + offset; 

    }
}
