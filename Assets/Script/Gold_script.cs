﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold_script : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 1f, 0) * transform.rotation;
    }
}
