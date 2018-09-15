using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MinecraftTextureStudio
{
    public class TextureChange
    {
        public int index;
        public Bitmap bitmap;

        public TextureChange(int index, Bitmap bitmap)
        {
            this.index = index;
            this.bitmap = bitmap;
        }
    }
}
