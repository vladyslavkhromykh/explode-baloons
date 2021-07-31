using ExplodeBalloons.Common;
using UnityEngine;
using Zenject;

namespace ExplodeBalloons.Installers
{
    [CreateAssetMenu(menuName = "Baloons/SettingsInstaller")]
    public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
    {
        public Settings settings;

        public override void InstallBindings()
        {
            Container.BindInstance(settings);
        }
    }
}