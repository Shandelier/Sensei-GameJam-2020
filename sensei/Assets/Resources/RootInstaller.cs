using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RootInstaller : MonoInstaller
{

    public override void InstallBindings()
    {
        this.installInputBindings();

    }

    private void installInputBindings() {
        Container.BindInterfacesAndSelfTo<GameLoop>().AsSingle();
    }

}
