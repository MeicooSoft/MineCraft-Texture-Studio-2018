using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftTextureStudio
{
    public class TextureUpdate
    {
        public Vector2 uv;
        public int textureIndex;

        public TextureUpdate(Vector2 uv, int textureIndex)
        {
            this.uv = uv;
            this.textureIndex = textureIndex;
        }
    }
}
