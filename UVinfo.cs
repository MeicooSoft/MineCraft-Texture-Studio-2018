using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinecraftTextureStudio
{
    public class UV
    {
        public float startU;
        public float endU;
        public float startV;
        public float endV;
        public bool flipU;
        public bool flipV;
        public bool rotateRight;
        public int textureIndex;

        public UV(float u1, float v1, float u2, float v2, float width, float height)
        {
            init(u1, v1, u2, v2, 0, width, height);
        }

        public UV(float u1, float v1, float u2, float v2, int textureIndex, float width, float height)
        {
            init(u1, v1, u2, v2, textureIndex, width, height);
        }

        public void init(float u1, float v1, float u2, float v2, int textureIndex, float width, float height)
        {
            this.startU = u1 / width;
            this.endU = (u2 + 1) / width;

            this.startV = 1 - (v2 + 1) / height;
            this.endV = 1 - v1 / height;

            this.flipU = false;
            this.flipV = false;
            this.textureIndex = textureIndex;
        }

        public UV(float u1, float v1, float u2, float v2, float width, float height, bool flipU, bool flipV)
        {
            init(u1, v1, u2, v2, 0, width, height, flipU, flipV);
        }

        public UV(float u1, float v1, float u2, float v2, int textureIndex, float width, float height, bool flipU, bool flipV)
        {
            init(u1, v1, u2, v2, textureIndex, width, height, flipU, flipV);
        }

        public void init(float u1, float v1, float u2, float v2, int textureIndex, float width, float height, bool flipU, bool flipV)
        {
            this.startU = u1 / width;
            this.endU = (u2 + 1) / width;

            this.startV = 1 - (v2 + 1) / height;
            this.endV = 1 - v1 / height;

            this.flipU = flipU;
            this.flipV = flipV;
            this.textureIndex = textureIndex;
        }

        public UV(float u1, float v1, float u2, float v2, float width, float height, bool rotateRight)
        {
            init(u1, v1, u2, v2, 0, width, height, rotateRight);
        }

        public UV(float u1, float v1, float u2, float v2, int textureIndex, float width, float height, bool rotateRight)
        {
            init(u1, v1, u2, v2, textureIndex, width, height, rotateRight);
        }

        public void init(float u1, float v1, float u2, float v2, int textureIndex, float width, float height, bool rotateRight)
        {
            if (rotateRight)
            {
                float saveU1 = u1;
                float saveV1 = v1;

                float saveU2 = u2;
                float saveV2 = v2;

                u1 = height - 1 - saveV2;
                v1 = width - 1 - saveU2;

                u2 = height - 1 - saveV1;
                v2 = width - 1 - saveU1;
            }
            
            this.startU = u1 / width;
            this.endU = (u2 + 1) / width;

            this.startV = 1 - (v2 + 1) / height;
            this.endV = 1 - v1 / height;

            this.rotateRight = rotateRight;
            this.textureIndex = textureIndex;
        }

        public UV(float u1, float v1, float u2, float v2, int textureIndex, float width, float height, bool rotateRight, bool flipU, bool flipV)
        {
            if (rotateRight)
            {
                float saveU1 = u1;
                float saveV1 = v1;

                float saveU2 = u2;
                float saveV2 = v2;

                u1 = height - 1 - saveV2;
                v1 = width - 1 - saveU2;

                u2 = height - 1 - saveV1;
                v2 = width - 1 - saveU1;
            }

            this.startU = u1 / width;
            this.endU = (u2 + 1) / width;

            this.startV = 1 - (v2 + 1) / height;
            this.endV = 1 - v1 / height;

            this.flipU = flipU;
            this.flipV = flipV;
            this.rotateRight = rotateRight;
            this.textureIndex = textureIndex;
        }

        public UV(float startU, float endU, float startV, float endV)
        {
            this.startU = startU;
            this.endU = endU;

            this.startV = startV;
            this.endV = endV;

            this.textureIndex = 0;
        }

        public UV()
        {
            this.startU = 0.0f;
            this.endU = 1.0f;

            this.startV = 0.0f;
            this.endV = 1.0f;

            this.textureIndex = 0;
        }
    }

    public class UVinfo
    {
        public UV front;
        public UV back;
        public UV left;
        public UV right;
        public UV top;
        public UV bottom;

        public UVinfo(UV front, UV back, UV left, UV right, UV top, UV bottom)
        {
            this.front = front;
            this.back = back;
            this.left = left;
            this.right = right;
            this.top = top;
            this.bottom = bottom;
        }

        public UVinfo()
        {
            this.front = new UV();
            this.back = new UV();
            this.left = new UV();
            this.right = new UV();
            this.top = new UV();
            this.bottom = new UV();
        }        

        public void setTextureIndex(int textureIndex)
        {
            this.front.textureIndex = textureIndex;
            this.back.textureIndex = textureIndex;
            this.left.textureIndex = textureIndex;
            this.right.textureIndex = textureIndex;
            this.top.textureIndex = textureIndex;
            this.bottom.textureIndex = textureIndex;
        }
    }
}
