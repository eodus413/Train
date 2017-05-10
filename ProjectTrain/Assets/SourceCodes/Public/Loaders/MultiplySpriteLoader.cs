using UnityEngine;
using System.Collections.Generic;

namespace Loaders
{
    public class MultiplySpriteLoader
    {
        public MultiplySpriteLoader(string filePath)
        {
            int count = 1;
            Sprite newSprite;

            bool loading = true;
            while (loading)
            {
                newSprite = Resources.Load<Sprite>(filePath + '_' + count);      //스프라이트 로드
                if (newSprite == null) loading = false;        //만약 스프라이트가 없다면 반복문 탈출
                else
                {
                    ++count;
                    sprites.Add(newSprite);
                }
            }
        }
        List<Sprite> sprites = new List<Sprite>();

        public List<Sprite> Sprites
        {
            get { return sprites; }
        }
        public int Lenght
        {
            get { return sprites.Count; }
        }
    }

}

namespace Loaders
{
    public enum InGameUISprite
    {

    }
}