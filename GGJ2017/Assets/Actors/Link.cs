﻿using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Link : MonoBehaviour
{
    public Person personA;
    public Person personB;
    public bool Visible = true;










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

        personB = b;


    public bool contains(Person person)
    {
        return (personA == person || personB == person);
    }

    // Update is called once per frame
    void Update()
    {





















            for (int i = 0; i < transform.childCount; i++)
            {
                temp.gameObject.SetActive(true);
        }
        if (!Visible && wasVisible)











}