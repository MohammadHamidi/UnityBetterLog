using System.Collections;
using System.Collections.Generic;
using Core.Application.Logging;
using UnityEngine;
using Zenject;

public class LoggerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IDebugLogger>().To<DebugLogger>().AsSingle().NonLazy();
    }
}
