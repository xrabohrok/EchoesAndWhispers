using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public void focusPerson(Transform coordinates)
{
    //TODO:Move network to person, center left person
    coordinates.position= coordinates.position + new Vector3(20.0f, 0.0f, 0.0f);
    Camera.main.transform.LookAt(coordinates);
    //TODO:Set zoom
    
}

public void showNetwork()
{
    //TODO: Zoom out, character on left investigators on right

    Vector3 center = new Vector3();
    Camera.main.ScreenToWorldPoint(center);
    Camera.main.orthographicSize = fullMapOut;
}

public void cameraDrag()
{
    //TODO: Pan and move the camera


}

public void cameraZoom(object input)
{
//TODO: Take in object then zoom in or out

}

public void focusDual(Transform one, Transform two)
{
    //TODO: Implement zooming on two targets


}