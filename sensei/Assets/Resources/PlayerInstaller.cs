using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{

    public override void InstallBindings()
    {
        this.installInputBindings();

    }

    private void installInputBindings() {
        
    }

}
