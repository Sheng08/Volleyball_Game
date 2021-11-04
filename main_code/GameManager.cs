using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject loginPanel;
    // Start is called before the first frame update
    void Start()
    {
        loginPanel.SetActive(true);
    }

    public void btnONclick()
    {
        loginPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
