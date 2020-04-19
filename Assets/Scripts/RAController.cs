using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject nextButton, previusButton;
    public GameObject[] cars;
    
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (index==0)
        {
            previusButton.SetActivate(false);
        }
        else if (index==cars.Length-1)
        {
            nextButton.SetActivate(false);
        }
        else{
            previusButton.SetActivate(true);
            nextButton.SetActivate(true);
        }
    }
}
