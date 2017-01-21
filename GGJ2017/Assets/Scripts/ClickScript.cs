using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour {

    public Vector3 lastGoodPoint { get; set; }
    public Vector3 clickedLocation { get; set; }
    public GameObject clickedObject { get; set;  }
    public List<string> limitToLayerNamed;

    private bool valid = false;
    public bool validClicable { get { return valid; } }

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit infoOut;

        var layerMaskNum = 0;
        var layerMask = 0;
        foreach(var layername in limitToLayerNamed)
        {
            layerMaskNum = LayerMask.NameToLayer(layername);
            layerMask |= 1 << layerMaskNum;

            // layerMask |= 1 << LayerMask.NameToLayer(layername);

            // Bit shift the 1 to the left (<<) by the number of bits equal to the value of layerMaskNum,
            // then do an inclusive OR with layerMask (|=) to find all the layers actually included.
        }

        if (Physics.Raycast(ray, out infoOut, 500, layerMask))
        {
            lastGoodPoint = infoOut.point;
            clickedObject = infoOut.collider.gameObject;
            clickedLocation = infoOut.point;
            valid = true;
        }
        else
        {
            valid = false;
        }
	}
}
