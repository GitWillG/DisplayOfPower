﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

namespace efe{

public class audioManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAudio(AudioSource targetAudio)
    {
        targetAudio.Play();
    }
}
}