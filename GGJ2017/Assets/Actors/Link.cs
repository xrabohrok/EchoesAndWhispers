using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Link : MonoBehaviour
{
    public Person personA;
    public Person personB;
    public bool Visible = true;

    public GameObject drawLinkPiece;

    public float baseScale = 1f;
    public int numPieces = 10;
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

        }
    }

    public void recieveTargets(Person a, Person b)

    {
        personA = a;
        personB = b;
    }

    // Update is called once per frame
    void Update()
    {

        if (personA != null && personB != null)
        {
            var placea = personA.transform.position;
            var placeb = personB.transform.position;

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

        if (Visible && !wasVisible)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var temp = transform.GetChild(i);
                temp.gameObject.SetActive(true);
            }
        }
        if (!Visible && wasVisible)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var temp = transform.GetChild(i);
                temp.gameObject.SetActive(false);
            }
        }

        wasVisible = Visible;

    }
}