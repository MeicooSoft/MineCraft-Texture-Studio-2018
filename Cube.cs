using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftTextureStudio
{
    public class Cube
    {
        public bool front;
        public bool back;
        public bool left;
        public bool right;
        public bool top;
        public bool bottom;
        public Vector3 position;

        public Cube(Vector3 position)
        {
            this.position = position;
            this.front = true;
            this.back = true;
            this.left = true;
            this.right = true;
            this.top = true;
            this.bottom = true;
        }

        public Cube(float x, float y, float z)
        {
            this.position = new Vector3(x, y, z);
            this.front = true;
            this.back = true;
            this.left = true;
            this.right = true;
            this.top = true;
            this.bottom = true;
        }

        //right  left   front  back   top   bottom
        public Cube(Vector3 position, bool front, bool back, bool left, bool right, 
            bool top, bool bottom)
        {
            this.position = position;
            this.front = front;
            this.back = back;
            this.left = left;
            this.right = right;
            this.top = top;
            this.bottom = bottom;
        }

        public float x
        {
            get
            {
                return this.position.x;
            }

            set
            {
                this.position.x = value;
            }
        }

        public float y
        {
            get
            {
                return this.position.y;
            }

            set
            {
                this.position.y = value;
            }
        }

        public float z
        {
            get
            {
                return this.position.z;
            }

            set
            {
                this.position.z = value;
            }
        }

        public override string ToString()
        {
            return "X = " + position.x + ", Y = " + position.y + ", Z = " + position.z;
        }
    }
}
