using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Baloons/SettingsInstaller")]
public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
{
    public Settings settings;
    
    public override void InstallBindings()
    {
        Container.BindInstance(settings);
    }
}