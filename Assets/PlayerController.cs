﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject nextButton, previusButton, initPoint;
    public GameObject[] cars;
    public GameObject[] cars_clone;

    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        cars_clone = new GameObject[cars.Length];
        for (int i = 0; i < cars.Length; i++)
        {
            GameObject car = Instantiate(cars[i], new Vector3(0,0,0), Quaternion.identity);
            car.transform.parent = initPoint.transform;
            car.transform.position = new Vector3(0,0,-5);
            car.transform.localPosition = new Vector3(0,0,0);
            car.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
            car.name = i.ToString();
            car.SetActive(false);
            cars_clone[i] = car;
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cars_clone.Length; i++)
        {
         if (cars_clone[i].name == index.ToString())
         {
             cars_clone[i].SetActive(true);
         }else{
             cars_clone[i].SetActive(false);
         }   
        }

        if (index == 0)
        {
            previusButton.SetActive(false);
        }
        else if (index == cars.Length - 1)
        {
            nextButton.SetActive(false);
        }
        else
        {
            previusButton.SetActive(true);
            nextButton.SetActive(true);
        }
    }

    public void Next()
    {
        index += 1;
    }

    public void Previus()
    {
        index -= 1;
    }

    public void ChangeColor(string hex_color)
    {
        Color color = GetColorRGBA(hex_color);

        foreach (Transform child in cars_clone[index].transform)
        {
            if (child.name == "object.000" || child.name == "object.012" || child.name == "object.002")
            {
                Material mat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
                mat.SetColor("_BaseColor", color);
                child.gameObject.GetComponent<Renderer>().material=mat;
            }
        }
    }

    Color GetColorRGBA(string hex_color)
    {
        Color new_color;
        ColorUtility.TryParseHtmlString(hex_color, out new_color);
        return new_color;
    }
}


