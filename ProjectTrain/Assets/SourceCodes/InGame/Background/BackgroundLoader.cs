using UnityEngine;
using Loaders;

namespace Background
{
    public class BackgroundLoader
    {
        public BackgroundLoader(Transform parent)
        {
            this.parent = parent;
        }
        
        Transform parent;
        public int backgroundCount { get; private set; }


        GameObjectLoader gameObjectLoader;
        MultiplySpriteLoader resourceLoader;

        public Transform[] CreateBackgrounds(Stages stage,string loadName)
        {
            resourceLoader = new MultiplySpriteLoader("Sprites/Backgrounds/" + stage.ToString() + '/' + loadName);
            gameObjectLoader = new GameObjectLoader(loadName, resourceLoader.Lenght, parent);

            Transform[] backgrounds = new Transform[resourceLoader.Lenght];
            backgrounds = gameObjectLoader.transforms;
            backgroundCount = backgrounds.Length;

            SpriteRenderer renderer;
            for (int i = 0; i < backgroundCount; ++i)
            {
                renderer = backgrounds[i].gameObject.AddComponent<SpriteRenderer>();
                renderer.sprite = resourceLoader.Sprites[i];
                renderer.sortingOrder = i * -1;
                renderer.sortingLayerName = loadName;
            }
            
            return backgrounds;
        }
    }
}