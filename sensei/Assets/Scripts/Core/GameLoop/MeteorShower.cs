using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MeteorShower : IInitializable
{
    GameObject player = null;

    public void Initialize() {
        this.player = GameObject.FindGameObjectsWithTag("PlayerTag")[0];     
    }

    
}
