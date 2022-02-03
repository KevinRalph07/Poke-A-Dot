using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H2P : MonoBehaviour
{
    public GameObject H2Pmenu;
    private void Awake()
    {
        H2Pmenu.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Enter()
    {
        H2Pmenu.SetActive(true);
    }

    public void Exit()
    {
        H2Pmenu.SetActive(false);
    }
}
