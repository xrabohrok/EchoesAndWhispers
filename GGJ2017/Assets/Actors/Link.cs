using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Link : MonoBehaviour
{
    public Lead leadA;
    public Lead leadB;
    public bool Visible = true;
    public GameObject drawLinkPiece;
    public float baseScale = 1f;

    public int numPieces = 10;

    private bool mouseLinked;
    private float LinkWidth = .5f;

    private bool wasVisible = true;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < numPieces; i++)

        {

            var temp = GameObject.Instantiate(drawLinkPiece);


            temp.transform.position = transform.position;

            temp.transform.localPosition = new Vector3(LinkWidth, 0) * i;

            temp.transform.parent = this.gameObject.transform;

            temp.SetActive(Visible);
        }
        wasVisible = Visible;
    }

    public void recieveTargets(Lead a, Lead b)
    {        leadA = a;
        leadB = b;
    }

    public void recieveTargets(Lead a)
    {
        leadA = a;
        mouseLinked = true;        Visible = true;
    }

    public void passToPersonTarget(Lead b)
    {
        leadB = b;
        mouseLinked = false;    }

    public bool contains(Lead lead)
    {
        return (leadA == lead || leadB == lead);
    }

    // Update is called once per frame
    void Update()
    {        if (leadA != null && (leadB != null || mouseLinked))
        {
            var placea = leadA.transform.position;
            Vector3 placeb;
            if(!mouseLinked)
            {
                 placeb = leadB.transform.position;
            }
            else
            {
                placeb = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            this.transform.position = placea;
            var dist = placeb - placea;


            for (int i = 0; i < transform.childCount; i++)

            {
                var temp = transform.GetChild(i);
                temp.transform.localPosition = new Vector3(dist.magnitude/numPieces, 0)*i;
            }

            dist.Normalize();
            float rot_z = Mathf.Atan2(dist.y, dist.x)*Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(rot_z, Vector3.forward);

        }
        if (Visible != wasVisible)        {
            for (int i = 0; i < transform.childCount; i++)
            {                var temp = transform.GetChild(i);
                temp.gameObject.SetActive(Visible);            }
        }

        wasVisible = Visible;

    }
}