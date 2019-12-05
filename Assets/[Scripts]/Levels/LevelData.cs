using EditorTools;
using UnityEngine;

namespace Levels
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Levels/Level Data")]

    public class LevelData : ScriptableObject
    {
        public string id;
        [SceneSelector]
        public string sceneName;
    }
}
