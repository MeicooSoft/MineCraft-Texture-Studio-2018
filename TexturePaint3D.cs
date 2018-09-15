using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftTextureStudio
{
    public class TexturePaint3D
    {
        public static TextureUpdate updateTexture(int faceIndex, ModelType modelType, Cube cubePosition)
        {
            if (modelType == ModelType.Block)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, cubePosition.z), 0);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 15 - cubePosition.y), 0);
                }
            }
            else if (modelType == ModelType.BlockFrontTopAndBottom)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, cubePosition.z), 1);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 1);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 15 - cubePosition.y), 2);
                }
            }
            else if (modelType == ModelType.BlockSameTopAndBottom)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, cubePosition.z), 1);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 1);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 15 - cubePosition.y), 0);
                }
            }
            else if (modelType == ModelType.BlockTop)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, cubePosition.z), 0);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 1);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 15 - cubePosition.y), 0);
                }
            }
            else if (modelType == ModelType.BlockDiffTopAndBottom)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, cubePosition.z), 2);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 1);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 15 - cubePosition.y), 0);
                }
            }
            else if (modelType == ModelType.Stairs)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, cubePosition.x), 0);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, cubePosition.x), 0);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 15 - cubePosition.y), 0);
                }
            }
            else if (modelType == ModelType.PistonExtended)
            {
                if (cubePosition.x == 19 && faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 15 - cubePosition.y), 1);
                }
                else if (cubePosition.x == 16 && faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 1);
                }
                else if (cubePosition.x == -12 && faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 2);
                }
                else if (cubePosition.x == -1 && faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 15 - cubePosition.y), 3);
                }
                //piston pusher
                else if (cubePosition.z == 15 && faceIndex == 5 &&
                    (cubePosition.x >= 16 && cubePosition.x <= 19))
                {
                    int newX = (int)(cubePosition.x - 4);
                    return new TextureUpdate(new Vector2(15 - cubePosition.y, 15 - newX), 0);
                }
                else if (cubePosition.z == 0 && faceIndex == 4 &&
                (cubePosition.x >= 16 && cubePosition.x <= 19))
                {
                    int newX = (int)(cubePosition.x - 4);
                    return new TextureUpdate(new Vector2(15 - cubePosition.y, 15 - newX), 0);
                }
                else if (cubePosition.y == 15 && faceIndex == 3 &&
                    (cubePosition.x >= 16 && cubePosition.x <= 19))
                {
                    int newX = (int)(cubePosition.x - 4);
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - newX), 0);
                }
                else if (cubePosition.y == 0 && faceIndex == 2 &&
                    (cubePosition.x >= 16 && cubePosition.x <= 19))
                {
                    int newX = (int)(cubePosition.x - 4);
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - newX), 0);
                }
                //piston shaft
                else if (faceIndex == 5 && cubePosition.x >= 0 && cubePosition.x <= 15)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 15 - (cubePosition.y + 6)), 0);
                }
                else if (faceIndex == 4 && cubePosition.x >= 0 && cubePosition.x <= 15)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 15 - (cubePosition.y + 6)), 0);
                }
                else if (faceIndex == 3 && cubePosition.x >= 0 && cubePosition.x <= 15)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z - 6), 0);
                }
                else if (faceIndex == 2 && cubePosition.x >= 0 && cubePosition.x <= 15)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 15 - (cubePosition.z + 6)), 0);
                }
                //base sides
                else if (faceIndex == 5 && cubePosition.x >= -12 && cubePosition.x <= -1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.y, 3 - cubePosition.x), 0);
                }
                else if (faceIndex == 4 && cubePosition.x >= -12 && cubePosition.x <= -1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.y, 3 - cubePosition.x), 0);
                }
                else if (faceIndex == 3 && cubePosition.x >= -12 && cubePosition.x <= -1)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 3 - cubePosition.x), 0);
                }
                else if (faceIndex == 2 && cubePosition.x >= -12 && cubePosition.x <= -1)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 3 - cubePosition.x), 0);
                }
            }
            else if (modelType == ModelType.StandingSign)
            {
                if (faceIndex == 0)
                {
                    if (cubePosition.y >= 6 && cubePosition.y <= 17 &&
                        cubePosition.z >= 7 && cubePosition.z <= 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.z - 7, 11 - (cubePosition.y - 8)), 0);
                    }
                    else if (cubePosition.y >= -8 && cubePosition.y <= 5 &&
                             cubePosition.z >= 7 && cubePosition.z <= 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.z - 7, 28 - (cubePosition.y + 7)), 0);
                    }
                }
                else if (faceIndex == 1)
                {
                    if (cubePosition.y >= 6 && cubePosition.y <= 17 &&
                        cubePosition.z >= 7 && cubePosition.z <= 8)
                    {
                        return new TextureUpdate(new Vector2(34 - cubePosition.z, 11 - (cubePosition.y - 8)), 0);
                    }
                    else if (cubePosition.y >= -8 && cubePosition.y <= 5 &&
                             cubePosition.z >= 7 && cubePosition.z <= 8)
                    {
                        return new TextureUpdate(new Vector2(4 - (cubePosition.z - 8), 28 - (cubePosition.y + 7)), 0);
                    }
                }
                else if (faceIndex == 2)
                {
                    if (cubePosition.y == -7)
                    {
                        if (cubePosition.x == 8 && cubePosition.y == -7 && cubePosition.z == 7)
                        {
                            return new TextureUpdate(new Vector2(4, 14), 0);
                        }
                        else if (cubePosition.x == 7 && cubePosition.y == -7 && cubePosition.z == 7) //X = 7, Y = -7, Z = 7)
                        {
                            return new TextureUpdate(new Vector2(5, 14), 0);
                        }
                        else if (cubePosition.x == 8 && cubePosition.y == -7 && cubePosition.z == 8)
                        {
                            return new TextureUpdate(new Vector2(4, 15), 0);
                        }
                        else if (cubePosition.x == 7 && cubePosition.y == -7 && cubePosition.z == 8)
                        {
                            return new TextureUpdate(new Vector2(5, 15), 0);
                        }
                    }
                    else if (cubePosition.x >= -4 && cubePosition.x <= 19 &&
                             cubePosition.z >= 7 && cubePosition.z <= 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 30, cubePosition.z - 7), 0);
                    }
                }
                else if (faceIndex == 3)
                {
                    if (cubePosition.x >= -4 && cubePosition.x <= 19 &&
                        cubePosition.z >= 7 && cubePosition.z <= 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 6, cubePosition.z - 7), 0);
                    }
                }
                if (faceIndex == 4)
                {
                    if (cubePosition.x >= -4 && cubePosition.x <= 19 &&
                        cubePosition.y >= 6 && cubePosition.y <= 17)
                    {
                        return new TextureUpdate(new Vector2(23 - (cubePosition.x + 6) + 30, 19 - cubePosition.y), 0);
                    }
                    else if (cubePosition.x >= 7 && cubePosition.x <= 8 &&
                             cubePosition.y >= -8 && cubePosition.y <= 5)
                    {
                        return new TextureUpdate(new Vector2(7 - (cubePosition.x - 7), 28 - (cubePosition.y + 7)), 0);
                    }
                }
                else if (faceIndex == 5)
                {
                    if (cubePosition.x >= -4 && cubePosition.x <= 19 &&
                        cubePosition.y >= 6 && cubePosition.y <= 17)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 6, 19 - cubePosition.y), 0);
                    }
                    else if (cubePosition.x >= 7 && cubePosition.x <= 8 &&
                             cubePosition.y >= -8 && cubePosition.y <= 5)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x - 5, 28 - (cubePosition.y + 7)), 0);
                    }
                }
            }
            else if (modelType == ModelType.WallSign)
            {
                if (faceIndex == 0)
                {
                    if (cubePosition.y >= 2 && cubePosition.y <= 13 &&
                        cubePosition.z >= 7 && cubePosition.z <= 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.z - 7, 7 - (cubePosition.y - 8)), 0);
                    }
                }
                else if (faceIndex == 1)
                {
                    if (cubePosition.y >= 2 && cubePosition.y <= 13 &&
                        cubePosition.z >= 7 && cubePosition.z <= 8)
                    {
                        return new TextureUpdate(new Vector2(34 - cubePosition.z, 7 - (cubePosition.y - 8)), 0);
                    }
                }
                else if (faceIndex == 2)
                {
                    if (cubePosition.x >= -4 && cubePosition.x <= 19 &&
                             cubePosition.z >= 7 && cubePosition.z <= 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 30, cubePosition.z - 7), 0);
                    }
                }
                else if (faceIndex == 3)
                {
                    if (cubePosition.x >= -4 && cubePosition.x <= 19 &&
                        cubePosition.z >= 7 && cubePosition.z <= 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 6, cubePosition.z - 7), 0);
                    }
                }
                if (faceIndex == 4)
                {
                    if (cubePosition.x >= -4 && cubePosition.x <= 19 &&
                        cubePosition.y >= 2 && cubePosition.y <= 13)
                    {
                        return new TextureUpdate(new Vector2(23 - (cubePosition.x + 6) + 30, 15 - cubePosition.y), 0);
                    }
                }
                else if (faceIndex == 5)
                {
                    if (cubePosition.x >= -4 && cubePosition.x <= 19 &&
                        cubePosition.y >= 2 && cubePosition.y <= 13)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 6, 15 - cubePosition.y), 0);
                    }
                }
            }
            else if (modelType == ModelType.FenceGate)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x - 1, cubePosition.z), 0);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x - 1, cubePosition.z), 0);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x - 1, 15 - cubePosition.y), 0);
                }
                if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x - 1, 15 - cubePosition.y), 0);
                }
            }
            else if (modelType == ModelType.DaylightSensor)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 10 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 10 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 1);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, 10 - cubePosition.y), 0);
                }
                if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 10 - cubePosition.y), 0);
                }
            }
            else if (modelType == ModelType.DragonEgg)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, 15 - cubePosition.y), 0);
                }
                if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 15 - cubePosition.y), 0);
                }
            }
            else if (modelType == ModelType.Cake)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, cubePosition.z), 2);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 1);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, 15 - cubePosition.y), 0);
                }
                if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 15 - cubePosition.y), 0);
                }
            }
            else if (modelType == ModelType.Button)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z - 7, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(8 - cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z - 7), 0);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z - 7), 0);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 15 - cubePosition.y), 0);
                }
                if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 15 - cubePosition.y), 0);
                }
            }
            else if (modelType == ModelType.Trapdoor)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 22 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 22 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 22 - cubePosition.y), 0);
                }
                if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 22 - cubePosition.y), 0);
                }
            }
            else if (modelType == ModelType.CraftingTable)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 3);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, cubePosition.z), 2);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 1);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, 15 - cubePosition.y), 3);
                }
                else if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 15 - cubePosition.y), 0);
                }
            }
            else if (modelType == ModelType.GrassBlock)
            {
                List<string> textures = Blocks.getTextures("Grass Block");
                TextureUpdate textureUpdate = null;

                if (faceIndex == 0)
                {
                    textureUpdate = new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    textureUpdate = new TextureUpdate(new Vector2(15 - cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    textureUpdate = new TextureUpdate(new Vector2(15 - cubePosition.x, cubePosition.z), 2);
                }
                else if (faceIndex == 3)
                {
                    textureUpdate = new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 1);
                }
                else if (faceIndex == 4)
                {
                    textureUpdate = new TextureUpdate(new Vector2(15 - cubePosition.x, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 5)
                {
                    textureUpdate = new TextureUpdate(new Vector2(cubePosition.x, 15 - cubePosition.y), 0);
                }

                if (faceIndex == 0 || faceIndex == 1 || faceIndex == 4 || faceIndex == 5)
                {
                    try
                    {
                        Bitmap copyTexture2 = null;
                        Bitmap copyTexture4 = null;

                        lock (FrmMain.texture2)
                        {
                            copyTexture2 = new Bitmap(FrmMain.texture2);
                        }

                        lock (FrmMain.texture4)
                        {
                            copyTexture4 = new Bitmap(FrmMain.texture4);
                        }

                        if (copyTexture2 != null && copyTexture4 != null)
                        {
                            //check if there is a pixel at the selected position
                            Color colour = copyTexture4.GetPixel((int)textureUpdate.uv.x, (int)textureUpdate.uv.y);

                            if (colour.R == 0 && colour.G == 0 && colour.B == 0 && colour.A == 0)
                            {
                                textureUpdate.textureIndex = 0;
                            }
                            else
                            {
                                textureUpdate.textureIndex = 3;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        textureUpdate = null;
                    }
                }

                if (textureUpdate != null)
                {
                    return textureUpdate;
                }
            }
            else if (modelType == ModelType.Fence)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    if (cubePosition.x >= 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x - 8, cubePosition.z), 0);
                    }
                    else if (cubePosition.x < 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 8, cubePosition.z), 0);
                    }
                }
                else if (faceIndex == 3)
                {
                    if (cubePosition.x >= 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x - 8, cubePosition.z), 0);
                    }
                    else if (cubePosition.x < 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 8, cubePosition.z), 0);
                    }
                }
                else if (faceIndex == 4)
                {
                    if (cubePosition.x >= 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x - 8, 15 - cubePosition.y), 0);
                    }
                    else if (cubePosition.x < 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 8, 15 - cubePosition.y), 0);
                    }
                }
                else if (faceIndex == 5)
                {
                    if (cubePosition.x < 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 8, 15 - cubePosition.y), 0);
                    }
                    else
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x - 8, 15 - cubePosition.y), 0);
                    }
                }
            }
            else if (modelType == ModelType.Snow)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - (cubePosition.y - 8)), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 15 - (cubePosition.y - 8)), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 15 - (cubePosition.y - 8)), 0);
                }
                else if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 15 - (cubePosition.y - 8)), 0);
                }
            }
            else if (modelType == ModelType.EnchantmentTable)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, cubePosition.z), 2);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 1);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 15 - cubePosition.y), 0);
                }
            }
            else if (modelType == ModelType.Anvil)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 14 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 14 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 14 - cubePosition.y), 0);
                }
                else if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 14 - cubePosition.y), 0);
                }
            }
            else if (modelType == ModelType.Carpet)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 15), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 15), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 15), 0);
                }
                else if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 15), 0);
                }
            }
            else if (modelType == ModelType.Door)
            {
                if (faceIndex == 0)
                {
                    if (cubePosition.y > 7)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.z - 7, 15 - (cubePosition.y - 8)), 0);
                    }
                    else
                    {
                        return new TextureUpdate(new Vector2(cubePosition.z - 7, 15 - (cubePosition.y + 8)), 1);
                    }
                }
                else if (faceIndex == 1)
                {
                    if (cubePosition.y > 7)
                    {
                        return new TextureUpdate(new Vector2(9 - cubePosition.z, 15 - (cubePosition.y - 8)), 0);
                    }
                    else
                    {
                        return new TextureUpdate(new Vector2(9 - cubePosition.z, 15 - (cubePosition.y + 8)), 1);
                    }
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, cubePosition.z - 7), 1);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, 9 - cubePosition.z), 1);
                }
                else if (faceIndex == 4)
                {
                    if (cubePosition.y > 7)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, 15 - (cubePosition.y - 8)), 0);
                    }
                    else
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, 15 - (cubePosition.y + 8)), 1);
                    }
                }
                else if (faceIndex == 5)
                {
                    if (cubePosition.y > 7)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, 15 - (cubePosition.y - 8)), 0);
                    }
                    else
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, 15 - (cubePosition.y + 8)), 1);
                    }
                }
            }
            else if (modelType == ModelType.Wall)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    if (cubePosition.x >= 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x - 8, cubePosition.z), 0);
                    }
                    else
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 8, cubePosition.z), 0);
                    }
                }
                else if (faceIndex == 3)
                {
                    if (cubePosition.x >= 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x - 8, cubePosition.z), 0);
                    }
                    else
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 8, cubePosition.z), 0);
                    }
                }
                else if (faceIndex == 4)
                {
                    if (cubePosition.x >= 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x - 8, 15 - cubePosition.y), 0);
                    }
                    else
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 8, 15 - cubePosition.y), 0);
                    }
                }
                else if (faceIndex == 5)
                {
                    if (cubePosition.x >= 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x - 8, 15 - cubePosition.y), 0);
                    }
                    else
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 8, 15 - cubePosition.y), 0);
                    }
                }
            }
            else if (modelType == ModelType.MobHead ||
                     modelType == ModelType.ZombieHead)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z - 4, 19 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(27 - cubePosition.z, 19 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(27 - cubePosition.x, cubePosition.z - 4), 0);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x + 4, cubePosition.z - 4), 0);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(35 - cubePosition.x, 19 - cubePosition.y), 0);
                }
                else if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x + 4, 19 - cubePosition.y), 0);
                }
            }
            else if (modelType == ModelType.Hopper)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 14 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 14 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    if (cubePosition.y == 9.1f)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 1);
                    }
                    else if (cubePosition.y == 9.0f ||
                             cubePosition.y == -1 ||
                             cubePosition.y == 3)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                    }
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 2);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 14 - cubePosition.y), 0);
                }
                else if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 14 - cubePosition.y), 0);
                }
            }
            else if (modelType == ModelType.Cactus)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, cubePosition.z), 2);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 1);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, 15 - cubePosition.y), 0);
                }
                else if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 15 - cubePosition.y), 0);
                }
            }
            else if (modelType == ModelType.Bed)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 4);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 3);
                }
                else if (faceIndex == 2)
                {
                    if (cubePosition.x >= 8)
                    {
                        return new TextureUpdate(new Vector2(15 - (cubePosition.x - 8), cubePosition.z), 2);
                    }
                    else
                    {
                        return new TextureUpdate(new Vector2(15 - (cubePosition.x + 8), cubePosition.z), 2);
                    }
                }
                else if (faceIndex == 3)
                {
                    if (cubePosition.x >= 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x - 8, 15 - cubePosition.z), 0);
                    }
                    else
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 8, 15 - cubePosition.z), 6);
                    }
                }
                else if (faceIndex == 4)
                {
                    if (cubePosition.x >= 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x - 8, 15 - cubePosition.y), 1);
                    }
                    else if (cubePosition.x < 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 8, 15 - cubePosition.y), 5);
                    }
                }
                else if (faceIndex == 5)
                {
                    if (cubePosition.x >= 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x - 8, 15 - cubePosition.y), 1);
                    }
                    else if (cubePosition.x < 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 8, 15 - cubePosition.y), 5);
                    }
                }
            }
            else if (modelType == ModelType.Cauldron)
            {
                if (faceIndex == 0)
                {
                    if (cubePosition.x == 0)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 0);
                    }
                    else if (cubePosition.x == 14)
                    {
                        return new TextureUpdate(new Vector2(15 - cubePosition.z, 15 - cubePosition.y), 0);
                    }
                }
                else if (faceIndex == 1)
                {
                    if (cubePosition.x == 1)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.z, 15 - cubePosition.y), 0);
                    }
                    else if (cubePosition.x == 15)
                    {
                        return new TextureUpdate(new Vector2(15 - cubePosition.z, 15 - cubePosition.y), 0);
                    }
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, cubePosition.z), 2);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 1);
                }
                else if (faceIndex == 4)
                {
                    if (cubePosition.z == 0)
                    {
                        return new TextureUpdate(new Vector2(15 - cubePosition.x, 15 - cubePosition.y), 0);
                    }
                    else if (cubePosition.z == 14)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, 15 - cubePosition.y), 0);
                    }
                }
                else if (faceIndex == 5)
                {
                    if (cubePosition.z == 1)
                    {
                        return new TextureUpdate(new Vector2(15 - cubePosition.x, 15 - cubePosition.y), 0);
                    }
                    else if (cubePosition.z == 15)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, 15 - cubePosition.y), 0);
                    }
                }
            }
            else if (modelType == ModelType.FlowerPot)
            {
                if (faceIndex == 0)
                {
                    if (cubePosition.x == 10)
                    {
                        return new TextureUpdate(new Vector2(15 - cubePosition.z, 20 - cubePosition.y), 0);
                    }
                    else
                    {
                        return new TextureUpdate(new Vector2(cubePosition.z, 20 - cubePosition.y), 0);
                    }
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 20 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, cubePosition.z + 5), 0);
                }
                else if (faceIndex == 3)
                {
                    if (cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(15 - cubePosition.x, 15 - cubePosition.z), 1);
                    }
                    else
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                    }
                }
                else if (faceIndex == 4)
                {
                    if (cubePosition.z == 10)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, 20 - cubePosition.y), 0);
                    }
                    else
                    {
                        return new TextureUpdate(new Vector2(15 - cubePosition.x, 20 - cubePosition.y), 0);
                    }
                }
                else if (faceIndex == 5)
                {
                    if (cubePosition.z == 5)
                    {
                        return new TextureUpdate(new Vector2(15 - cubePosition.x, 20 - cubePosition.y), 0);
                    }
                    else
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, 20 - cubePosition.y), 0);
                    }
                }
            }
            else if (modelType == ModelType.RedstoneTorchOn)
            {
                if (faceIndex == 0)
                {
                    return new TextureUpdate(new Vector2(cubePosition.z, 18 - cubePosition.y), 0);
                }
                else if (faceIndex == 1)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.z, 18 - cubePosition.y), 0);
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, cubePosition.z), 0);
                }
                else if (faceIndex == 3)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                }
                else if (faceIndex == 4)
                {
                    return new TextureUpdate(new Vector2(15 - cubePosition.x, 18 - cubePosition.y), 0);
                }
                else if (faceIndex == 5)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, 18 - cubePosition.y), 0);
                }
            }
            else if (modelType == ModelType.RedstoneComparatorOff)
            {
                if (faceIndex == 0)
                {
                    if ((cubePosition.z == 11 ||
                         cubePosition.z == 12) &&
                         cubePosition.y >= 9)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.z - 4, 19 - cubePosition.y), 1);
                    } 
                    else if (cubePosition.y == 7 ||
                             cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.z, 22 - cubePosition.y), 0);
                    }
                    else if (cubePosition.y == 9 ||
                             cubePosition.y == 10)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.z + 5, 16 - cubePosition.y), 1);
                    }
                }
                else if (faceIndex == 1)
                {                    
                    if (cubePosition.y >= 9 &&
                       (cubePosition.z == 11 || cubePosition.z == 12))
                    {
                        return new TextureUpdate(new Vector2(19 - cubePosition.z, 19 - cubePosition.y), 1);
                    }
                    else if (cubePosition.y == 7 ||
                             cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(15 - cubePosition.z, 22 - cubePosition.y), 0);
                    }
                    else if (cubePosition.y == 9 ||
                             cubePosition.y == 10)
                    {
                        return new TextureUpdate(new Vector2(10 - cubePosition.z, 16 - cubePosition.y), 1);
                    }
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                }
                else if (faceIndex == 3)
                {
                    if (cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                    }
                    else if (cubePosition.y == 9 ||
                             cubePosition.y == 10)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z + 4), 1);
                    }
                    else if (cubePosition.y == 13 &&
                            (cubePosition.x == 4 || cubePosition.x == 5))
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 3, cubePosition.z - 5), 1);
                    }
                    else if (cubePosition.y == 13 &&
                            (cubePosition.x == 10 || cubePosition.x == 11))
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x - 3, cubePosition.z - 5), 1);
                    }
                }
                else if (faceIndex == 4)
                {
                    if (cubePosition.y == 7 ||
                        cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, 22 - cubePosition.y), 0);
                    }
                    else if ((cubePosition.x == 7 ||
                              cubePosition.x == 8) &&
                             (cubePosition.y == 9 ||
                              cubePosition.y == 10))
                    {
                        return new TextureUpdate(new Vector2(15 - cubePosition.x, 16 - cubePosition.y), 1);
                    }
                    else if ((cubePosition.x == 10 ||
                              cubePosition.x == 11) &&
                              cubePosition.y >= 9)
                    {
                        return new TextureUpdate(new Vector2(18 - cubePosition.x, 19 - cubePosition.y), 1);
                    }
                    else if ((cubePosition.x == 4 ||
                              cubePosition.x == 5) &&
                              cubePosition.y >= 9)
                    {
                        return new TextureUpdate(new Vector2(12 - cubePosition.x, 19 - cubePosition.y), 1);
                    }
                }
                else if (faceIndex == 5)
                {
                    if (cubePosition.y >= 9 &&
                       (cubePosition.x == 4 ||
                        cubePosition.x == 5))
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 3, 19 - cubePosition.y), 1);
                    }
                    else if (cubePosition.y >= 9 &&
                            (cubePosition.x == 10 ||
                             cubePosition.x == 11))
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x - 3, 19 - cubePosition.y), 1);
                    }
                    else if (cubePosition.y == 7 ||
                             cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, 22 - cubePosition.y), 0);
                    }
                    else if (cubePosition.y == 9 ||
                             cubePosition.y == 10)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, 16 - cubePosition.y), 1);
                    }
                }
            }
            else if (modelType == ModelType.RedstoneComparatorOn)
            {
                if (faceIndex == 0)
                {
                    if (cubePosition.y >= 9 &&
                       (cubePosition.z >= 10 &&
                        cubePosition.z <= 13))
                    {
                        return new TextureUpdate(new Vector2(cubePosition.z - 4, 19 - cubePosition.y), 2);
                    }
                    else if (cubePosition.y == 7 ||
                             cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.z, 22 - cubePosition.y), 0);
                    }
                    else if (cubePosition.y == 9 ||
                             cubePosition.y == 10)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.z + 5, 16 - cubePosition.y), 1);
                    }
                }
                else if (faceIndex == 1)
                {
                    if (cubePosition.y >= 9 &&
                       (cubePosition.z >= 10 && 
                        cubePosition.z <= 13))
                    {
                        return new TextureUpdate(new Vector2(19 - cubePosition.z, 19 - cubePosition.y), 2);
                    }
                    else if (cubePosition.y == 7 ||
                             cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(15 - cubePosition.z, 22 - cubePosition.y), 0);
                    }
                    else if (cubePosition.y == 9 ||
                             cubePosition.y == 10)
                    {
                        return new TextureUpdate(new Vector2(10 - cubePosition.z, 16 - cubePosition.y), 1);
                    }
                }
                else if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                }
                else if (faceIndex == 3)
                {
                    if (cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                    }
                    else if (cubePosition.y == 9 ||
                             cubePosition.y == 10)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z + 4), 1);
                    }
                    else if (cubePosition.y == 13 &&
                            (cubePosition.x >= 3 && cubePosition.x <= 6))
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 3, cubePosition.z - 5), 2);
                    }
                    else if (cubePosition.y == 13 &&
                            (cubePosition.x >= 9 && cubePosition.x <= 12))
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x - 3, cubePosition.z - 5), 2);
                    }
                }
                else if (faceIndex == 4)
                {
                    if (cubePosition.y == 7 ||
                        cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, 22 - cubePosition.y), 0);
                    }
                    else if ((cubePosition.x == 7 ||
                              cubePosition.x == 8) &&
                             (cubePosition.y == 9 ||
                              cubePosition.y == 10))
                    {
                        return new TextureUpdate(new Vector2(15 - cubePosition.x, 16 - cubePosition.y), 1);
                    }
                    else if (cubePosition.y >= 9 &&
                            (cubePosition.x >= 9 &&
                             cubePosition.x <= 12))
                    {
                        return new TextureUpdate(new Vector2(18 - cubePosition.x, 19 - cubePosition.y), 2);
                    }
                    else if (cubePosition.y >= 9 &&
                            (cubePosition.x >= 3 &&
                             cubePosition.x <= 6))
                    {
                        return new TextureUpdate(new Vector2(12 - cubePosition.x, 19 - cubePosition.y), 2);
                    }
                }
                else if (faceIndex == 5)
                {
                    if (cubePosition.y >= 9 &&
                       (cubePosition.x >= 3 &&
                        cubePosition.x <= 6))
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x + 3, 19 - cubePosition.y), 2);
                    }
                    else if (cubePosition.y >= 9 &&
                            (cubePosition.x >= 9 &&
                             cubePosition.x <= 12))
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x - 3, 19 - cubePosition.y), 2);
                    }
                    else if (cubePosition.y == 7 ||
                             cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, 22 - cubePosition.y), 0);
                    }
                    else if (cubePosition.y == 9 ||
                             cubePosition.y == 10)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, 16 - cubePosition.y), 1);
                    }
                }
            }
            else if (modelType == ModelType.RedstoneRepeaterOff)
            {
                if (faceIndex == 0)
                {
                    if (cubePosition.y >= 9 &&
                       (cubePosition.z == 2 ||
                        cubePosition.z == 3))
                    {
                        return new TextureUpdate(new Vector2(cubePosition.z + 5, 19 - cubePosition.y), 1);
                    }
                    else if (cubePosition.y >= 9 &&
                            (cubePosition.z == 6 ||
                             cubePosition.z == 7))
                    {
                        return new TextureUpdate(new Vector2(cubePosition.z + 1, 19 - cubePosition.y), 1);
                    }
                    else if (cubePosition.y == 7 ||
                        cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.z, 22 - cubePosition.y), 0);
                    }
                }
                else if (faceIndex == 1)
                {
                    if (cubePosition.y >= 9 &&
                       (cubePosition.z == 2 ||
                        cubePosition.z == 3))
                    {
                        return new TextureUpdate(new Vector2(10 - cubePosition.z, 19 - cubePosition.y), 1);
                    }
                    else if (cubePosition.y >= 9 &&
                            (cubePosition.z == 6 ||
                             cubePosition.z == 7))
                    {
                        return new TextureUpdate(new Vector2(14 - cubePosition.z, 19 - cubePosition.y), 1);
                    }
                    else if (cubePosition.y == 7 ||
                             cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(15 - cubePosition.z, 22 - cubePosition.y), 0);
                    }
                }
                if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                }
                else if (faceIndex == 3)
                {
                    if (cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                    }
                    else if (cubePosition.y == 13 &&
                            (cubePosition.z == 6 ||
                             cubePosition.z == 7))
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 1);
                    }
                    else if (cubePosition.y == 13 &&
                            (cubePosition.z == 2 ||
                             cubePosition.z == 3))
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z + 4), 1);
                    }
                }
                else if (faceIndex == 4)
                {
                    if (cubePosition.y >= 9 ||
                       (cubePosition.x == 7 ||
                        cubePosition.x == 8))
                    {
                        return new TextureUpdate(new Vector2(15 - cubePosition.x, 19 - cubePosition.y), 1);
                    }
                    else if (cubePosition.y == 7 ||
                             cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(15 - cubePosition.x, 22 - cubePosition.y), 0);
                    }
                }
                else if (faceIndex == 5)
                {
                    if (cubePosition.y >= 9 ||
                       (cubePosition.x == 7 ||
                        cubePosition.x == 8))
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, 19 - cubePosition.y), 1);
                    }
                    else if (cubePosition.y == 7 ||
                             cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, 22 - cubePosition.y), 0);
                    }
                }
            }
            else if (modelType == ModelType.RedstoneRepeaterOn)
            {
                if (faceIndex == 0)
                {
                    if (cubePosition.y >= 9 &&
                       (cubePosition.z >= 1 &&
                        cubePosition.z <= 4))
                    {
                        return new TextureUpdate(new Vector2(cubePosition.z + 5, 19 - cubePosition.y), 1);
                    }
                    else if (cubePosition.y >= 9 &&
                            (cubePosition.z >= 5 &&
                             cubePosition.z <= 8))
                    {
                        return new TextureUpdate(new Vector2(cubePosition.z + 1, 19 - cubePosition.y), 1);
                    }
                    else if (cubePosition.y == 7 ||
                        cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.z, 22 - cubePosition.y), 0);
                    }
                }
                else if (faceIndex == 1)
                {
                    if (cubePosition.y >= 9 &&
                       (cubePosition.z >= 1 &
                        cubePosition.z <= 4))
                    {
                        return new TextureUpdate(new Vector2(10 - cubePosition.z, 19 - cubePosition.y), 1);
                    }
                    else if (cubePosition.y >= 9 &&
                            (cubePosition.z >= 5 &&
                             cubePosition.z <= 8))
                    {
                        return new TextureUpdate(new Vector2(14 - cubePosition.z, 19 - cubePosition.y), 1);
                    }
                    else if (cubePosition.y == 7 ||
                             cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(15 - cubePosition.z, 22 - cubePosition.y), 0);
                    }
                }
                if (faceIndex == 2)
                {
                    return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                }
                else if (faceIndex == 3)
                {
                    if (cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 0);
                    }
                    else if (cubePosition.y == 13 &&
                            (cubePosition.z >= 5 &&
                             cubePosition.z <= 8))
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z), 1);
                    }
                    else if (cubePosition.y == 13 &&
                            (cubePosition.z >= 1 &&
                             cubePosition.z <= 4))
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, cubePosition.z + 4), 1);
                    }
                }
                else if (faceIndex == 4)
                {
                    if (cubePosition.y >= 9 ||
                       (cubePosition.x >= 6 &&
                        cubePosition.x <= 9))
                    {
                        return new TextureUpdate(new Vector2(15 - cubePosition.x, 19 - cubePosition.y), 1);
                    }
                    else if (cubePosition.y == 7 ||
                             cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(15 - cubePosition.x, 22 - cubePosition.y), 0);
                    }
                }
                else if (faceIndex == 5)
                {
                    if (cubePosition.y >= 9 ||
                       (cubePosition.x >= 6 &&
                        cubePosition.x <= 9))
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, 19 - cubePosition.y), 1);
                    }
                    else if (cubePosition.y == 7 ||
                             cubePosition.y == 8)
                    {
                        return new TextureUpdate(new Vector2(cubePosition.x, 22 - cubePosition.y), 0);
                    }
                }
            }

            return new TextureUpdate(new Vector2(0, 0), -1);
        }

        public static List<Cube> getCubePositions(ModelType modelType)
        {
            List<Cube> cubes = new List<Cube>();

            if (modelType == ModelType.Block ||
                modelType == ModelType.BlockSTBF ||
                modelType == ModelType.BlockTop ||
                modelType == ModelType.BlockSameTopAndBottom ||
                modelType == ModelType.BlockDiffTopAndBottom ||
                modelType == ModelType.BlockFrontTopAndBottom ||
                modelType == ModelType.DoubleStoneSlab ||
                modelType == ModelType.CraftingTable ||
                modelType == ModelType.GrassBlock)
            {
                for (int x = 0; x < 16; x++)
                {
                    for (int y = 0; y < 16; y++)
                    {
                        for (int z = 0; z < 16; z++)
                        {
                            if (x == 0 || x == 15 ||
                                y == 0 || y == 15 ||
                                z == 0 || z == 15)
                            {
                                cubes.Add(new Cube(x, y, z));
                            }
                        }
                    }
                }
            }
            else if (modelType == ModelType.EndPortalBlock)
            {
                for (int x = 0; x < 16; x++)
                {
                    for (int y = 0; y < 13; y++)
                    {
                        for (int z = 0; z < 16; z++)
                        {
                            if (x == 0 || x == 15 ||
                                y == 0 || y == 12 ||
                                z == 0 || z == 15)
                            {
                                cubes.Add(new Cube(x, y, z));
                            }
                        }
                    }
                }
            }
            else if (modelType == ModelType.CocoaStage0)
            {
                addBox(4, 5, 4, 6, 5, 6, ref cubes);
            }
            else if (modelType == ModelType.CocoaStage1)
            {
                addBox(6, 7, 6, 5, 4, 5, ref cubes);
            }
            else if (modelType == ModelType.CocoaStage2)
            {
                addBox(8, 9, 8, 4, 3, 4, ref cubes);
            }
            else if (modelType == ModelType.Chest)
            {
                for (int x = 1; x < 15; x++)
                {
                    for (int y = 0; y < 14; y++)
                    {
                        for (int z = 1; z < 15; z++)
                        {
                            if (x == 1 || x == 14 ||
                                y == 0 || y == 13 ||
                                z == 1 || z == 14)
                            {
                                cubes.Add(new Cube(x, y, z));
                            }
                        }
                    }
                }

                //latch
                for (int y = 7; y <= 10; y++)
                {
                    cubes.Add(new Cube(7, y, 15));
                    cubes.Add(new Cube(8, y, 15));
                }
            }
            else if (modelType == ModelType.DoubleChest)
            {
                addBox(30, 13, 14, -7, 0, 1, ref cubes);

                //latch
                for (int y = 6; y <= 9; y++)
                {
                    cubes.Add(new Cube(7, y, 15));
                    cubes.Add(new Cube(8, y, 15));
                }
            }
            else if (modelType == ModelType.Torch)
            {
                addBox(2, 10, 2, 7, 3, 7, ref cubes);
            }
            else if (modelType == ModelType.RedstoneTorchOn)
            {
                addBox(2, 10, 2, 7, 3, 7, ref cubes);
                addTorchPlanes(new Vector3(7, 11, 6), ref cubes);
            }
            else if (modelType == ModelType.StoneSlab ||
                     modelType == ModelType.Slab)
            {
                addBox(16, 8, 16, 0, 4, 0, ref cubes);
            }
            else if (modelType == ModelType.Stairs || 
                     modelType == ModelType.MultiTextureStairs)
            {
                for (int x = 0; x < 16; x++)
                {
                    for (int y = 0; y < 16; y++)
                    {
                        for (int z = 0; z < 16; z++)
                        {
                            if (x < 8 || y < 8)
                            {
                                if (x == 0 || x == 7 || x == 15 ||
                                    y == 0 || y == 7 || y == 15 ||
                                    z == 0 || z == 15)
                                {
                                    cubes.Add(new Cube(x, y, z));
                                }
                            }
                        }
                    }
                }
            }
            else if (modelType == ModelType.PressurePlate ||
                modelType == ModelType.WeightedPressurePlateLight ||
                modelType == ModelType.WeightedPressurePlateHeavy)
            {
                addBox(14, 1, 14, 1, 8, 1, ref cubes);
            }
            else if (modelType == ModelType.FenceGate)
            {
                //left and right vertical posts
                addBox(2, 11, 2, 1, 5, 7, ref cubes);
                addBox(2, 11, 2, 15, 5, 7, ref cubes);

                //top and bottom horizontal posts
                addBox(12, 3, 2, 3, 12, 7, ref cubes);
                addBox(12, 3, 2, 3, 6, 7, ref cubes);

                //middle
                addBox(4, 3, 2, 7, 9, 7, ref cubes);
            }
            else if (modelType == ModelType.PistonExtended)
            {
                addBox(12, 16, 16, -12, 0, 0, ref cubes);
                addBox(16, 4, 4, 0, 6, 6, ref cubes);
                addBox(4, 16, 16, 16, 0, 0, ref cubes);
            }
            else if (modelType == ModelType.StandingSign)
            {
                addBox(24, 12, 2, -4, 6, 7, ref cubes);
                addBox(2, 14, 2, 7, -8, 7, ref cubes);
            }
            else if (modelType == ModelType.WallSign)
            {
                addBox(24, 12, 2, -4, 2, 7, ref cubes);
            }
            else if (modelType == ModelType.Door)
            {
                addBox(16, 32, 3, 0, -8, 7, ref cubes);
            }
            else if (modelType == ModelType.DaylightSensor)
            {
                addBox(16, 6, 16, 0, 5, 0, ref cubes);
            }
            else if (modelType == ModelType.DragonEgg)
            {
                addBox(4, 1, 4, 6, 15, 6, ref cubes);
                addBox(6, 1, 6, 5, 14, 5, ref cubes);
                addBox(8, 1, 8, 4, 13, 4, ref cubes);
                addBox(10, 2, 10, 3, 11, 3, ref cubes);
                addBox(12, 3, 12, 2, 8, 2, ref cubes);
                addBox(14, 5, 14, 1, 3, 1, ref cubes);
                addBox(12, 2, 12, 2, 1, 2, ref cubes);
                addBox(6, 1, 6, 5, 0, 5, ref cubes);
            }
            else if (modelType == ModelType.Cake)
            {
                addBox(14, 8, 14, 1, 0, 1, ref cubes);
            }
            else if (modelType == ModelType.Button)
            {
                addBox(6, 4, 2, 5, 6, 7, ref cubes);
            }
            else if (modelType == ModelType.Trapdoor)
            {
                addBox(16, 3, 16, 0, 7, 0, ref cubes);
            }
            else if (modelType == ModelType.Fence)
            {
                addBox(12, 3, 2, 2, 12, 7, ref cubes);

                //bottom horizontal post
                addBox(12, 3, 2, 2, 6, 7, ref cubes);

                //left post
                addBox(4, 16, 4, -2, 0, 6, ref cubes);

                //right post
                addBox(4, 16, 4, 14, 0, 6, ref cubes);
            }
            else if (modelType == ModelType.Snow)
            {
                addBox(16, 2, 16, 0, 8, 0, ref cubes);
            }
            else if (modelType == ModelType.EnchantmentTable)
            {
                addBox(16, 12, 16, 0, 0, 0, ref cubes);
            }
            else if (modelType == ModelType.Anvil)
            {
                addBox(12, 4, 12, 2, -1, 2, ref cubes);
                addBox(8, 1, 10, 4, 3, 3, ref cubes);
                addBox(4, 5, 8, 6, 4, 4, ref cubes);
                addBox(10, 6, 16, 3, 9, 0, ref cubes);
            }
            else if (modelType == ModelType.Carpet)
            {
                addBox(16, 1, 16, 0, 8, 0, ref cubes);
            }
            else if (modelType == ModelType.RedstoneRepeaterOff)
            {
                addBox(2, 5, 2, 7, 9, 2, ref cubes);
                addBox(2, 5, 2, 7, 9, 6, ref cubes);
                addBox(16, 2, 16, 0, 7, 0, ref cubes);
            }
            else if (modelType == ModelType.RedstoneRepeaterOn)
            {
                addBox(2, 5, 2, 7, 9, 2, ref cubes);
                addBox(2, 5, 2, 7, 9, 6, ref cubes);
                addBox(16, 2, 16, 0, 7, 0, ref cubes);

                addTorchPlanes(new Vector3(7, 12, 1), ref cubes);
                addTorchPlanes(new Vector3(7, 12, 5), ref cubes);
            }
            else if (modelType == ModelType.RedstoneComparatorOff)
            {
                addBox(2, 2, 2, 7, 9, 2, ref cubes);
                addBox(2, 5, 2, 4, 9, 11, ref cubes);
                addBox(2, 5, 2, 10, 9, 11, ref cubes);
                addBox(16, 2, 16, 0, 7, 0, ref cubes);
            }
            else if (modelType == ModelType.RedstoneComparatorOn)
            {
                addBox(2, 2, 2, 7, 9, 2, ref cubes);
                addBox(2, 5, 2, 4, 9, 11, ref cubes);
                addBox(2, 5, 2, 10, 9, 11, ref cubes);
                addBox(16, 2, 16, 0, 7, 0, ref cubes);

                addTorchPlanes(new Vector3(4, 12, 10), ref cubes);
                addTorchPlanes(new Vector3(10, 12, 10), ref cubes);
            }
            else if (modelType == ModelType.Hopper)
            {
                for (int y = 0; y < 6; y++)
                {
                    for (int z = 0; z < 16; z++)
                    {
                        //front and back
                        cubes.Add(new Cube(0, y + 9, z));
                        cubes.Add(new Cube(1, y + 9, z));

                        cubes.Add(new Cube(14, y + 9, z));
                        cubes.Add(new Cube(15, y + 9, z));

                        if (z >= 2 && z <= 14)
                        {
                            //left and right
                            cubes.Add(new Cube(z, y + 9, 0));
                            cubes.Add(new Cube(z, y + 9, 1));

                            cubes.Add(new Cube(z, y + 9, 14));
                            cubes.Add(new Cube(z, y + 9, 15));
                        }
                    }
                }

                addBox(8, 6, 8, 4, 3, 4, ref cubes);
                addBox(4, 4, 4, 6, -1, 6, ref cubes);

                for (int x = 2; x < 14; x++)
                {
                    for (int z = 2; z < 14; z++)
                    {
                        cubes.Add(new Cube(new Vector3(x, 9.0f, z), false, false, false, false, false, true));
                        cubes.Add(new Cube(new Vector3(x, 9.1f, z), false, false, false, false, false, true));
                    }
                }
            }
            else if (modelType == ModelType.MobHead ||
                modelType == ModelType.ZombieHead)
            {
                addBox(8, 8, 8, 4, 4, 4, ref cubes);
            }
            else if (modelType == ModelType.Wall)
            {
                addBox(8, 16, 8, -4, 0, 4, ref cubes);
                addBox(8, 13, 6, 4, 0, 5, ref cubes);
                addBox(8, 16, 8, 12, 0, 4, ref cubes);
            }
            else if (modelType == ModelType.Cactus)
            {
                addBox(14, 16, 14, 1, 0, 1, ref cubes);

                //front left
                cubes.Add(new Cube(new Vector3(1, 13, 0), true, false, false, false, false, false));
                cubes.Add(new Cube(new Vector3(1, 9, 0), true, false, false, false, false, false));
                cubes.Add(new Cube(new Vector3(1, 5, 0), true, false, false, false, false, false));
                cubes.Add(new Cube(new Vector3(1, 3, 0), true, false, false, false, false, false));

                //front right
                cubes.Add(new Cube(new Vector3(1, 13, 15), true, false, false, false, false, false));
                cubes.Add(new Cube(new Vector3(1, 9, 15), true, false, false, false, false, false));
                cubes.Add(new Cube(new Vector3(1, 5, 15), true, false, false, false, false, false));
                cubes.Add(new Cube(new Vector3(1, 3, 15), true, false, false, false, false, false));

                //back left
                cubes.Add(new Cube(new Vector3(14, 13, 0), false, true, false, false, false, false));
                cubes.Add(new Cube(new Vector3(14, 9, 0), false, true, false, false, false, false));
                cubes.Add(new Cube(new Vector3(14, 5, 0), false, true, false, false, false, false));
                cubes.Add(new Cube(new Vector3(14, 3, 0), false, true, false, false, false, false));

                //back right
                cubes.Add(new Cube(new Vector3(14, 13, 15), false, true, false, false, false, false));
                cubes.Add(new Cube(new Vector3(14, 9, 15), false, true, false, false, false, false));
                cubes.Add(new Cube(new Vector3(14, 5, 15), false, true, false, false, false, false));
                cubes.Add(new Cube(new Vector3(14, 3, 15), false, true, false, false, false, false));

                //left front
                cubes.Add(new Cube(new Vector3(0, 13, 1), false, false, true, false, false, false));
                cubes.Add(new Cube(new Vector3(0, 9, 1), false, false, true, false, false, false));
                cubes.Add(new Cube(new Vector3(0, 5, 1), false, false, true, false, false, false));
                cubes.Add(new Cube(new Vector3(0, 3, 1), false, false, true, false, false, false));

                //right front
                cubes.Add(new Cube(new Vector3(15, 13, 1), false, false, true, false, false, false));
                cubes.Add(new Cube(new Vector3(15, 9, 1), false, false, true, false, false, false));
                cubes.Add(new Cube(new Vector3(15, 5, 1), false, false, true, false, false, false));
                cubes.Add(new Cube(new Vector3(15, 3, 1), false, false, true, false, false, false));

                //left back
                cubes.Add(new Cube(new Vector3(0, 13, 14), false, false, false, true, false, false));
                cubes.Add(new Cube(new Vector3(0, 9, 14), false, false, false, true, false, false));
                cubes.Add(new Cube(new Vector3(0, 5, 14), false, false, false, true, false, false));
                cubes.Add(new Cube(new Vector3(0, 3, 14), false, false, false, true, false, false));

                //right back
                cubes.Add(new Cube(new Vector3(15, 13, 14), false, false, false, true, false, false));
                cubes.Add(new Cube(new Vector3(15, 9, 14), false, false, false, true, false, false));
                cubes.Add(new Cube(new Vector3(15, 5, 14), false, false, false, true, false, false));
                cubes.Add(new Cube(new Vector3(15, 3, 14), false, false, false, true, false, false));
            }
            else if (modelType == ModelType.Bed)
            {
                addBox(32, 6, 16, -8, 3, 0, ref cubes);

                //front and back
                for (int z = 13; z <= 15; z++)
                {
                    for (int y = 0; y <= 2; y++)
                    {
                        cubes.Add(new Cube(new Vector3(-8, y, z), true, false, false, false, false, false));
                        cubes.Add(new Cube(new Vector3(-8, y, z - 13), true, false, false, false, false, false));

                        cubes.Add(new Cube(new Vector3(23, y, z), false, true, false, false, false, false));
                        cubes.Add(new Cube(new Vector3(23, y, z - 13), false, true, false, false, false, false));
                    }
                }

                //left and right
                for (int x = -8; x <= -6; x++)
                {
                    for (int y = 0; y <= 2; y++)
                    {
                        cubes.Add(new Cube(new Vector3(x, y, 0), false, false, true, false, false, false));
                        cubes.Add(new Cube(new Vector3(x + 29, y, 0), false, false, true, false, false, false));

                        cubes.Add(new Cube(new Vector3(x, y, 15), false, false, false, true, false, false));
                        cubes.Add(new Cube(new Vector3(x + 29, y, 15), false, false, false, true, false, false));
                    }
                }
            }
            else if (modelType == ModelType.Cauldron)
            {
                for (int y = 4; y < 16; y++)
                {
                    for (int z = 0; z < 16; z++)
                    {
                        //front and back
                        cubes.Add(new Cube(0, y, z));
                        cubes.Add(new Cube(1, y, z));

                        cubes.Add(new Cube(14, y, z));
                        cubes.Add(new Cube(15, y, z));

                        if (z >= 2 && z <= 14)
                        {
                            //left and right
                            cubes.Add(new Cube(z, y, 0));
                            cubes.Add(new Cube(z, y, 1));

                            cubes.Add(new Cube(z, y, 14));
                            cubes.Add(new Cube(z, y, 15));
                        }
                    }
                }

                //legs
                for (int z = 12; z <= 15; z++)
                {
                    for (int y = 0; y <= 2; y++)
                    {
                        cubes.Add(new Cube(new Vector3(0, y, z), true, false, false, false, false, false));
                        cubes.Add(new Cube(new Vector3(0, y, z - 12), true, false, false, false, false, false));

                        cubes.Add(new Cube(new Vector3(15, y, z), false, true, false, false, false, false));
                        cubes.Add(new Cube(new Vector3(15, y, z - 12), false, true, false, false, false, false));
                    }
                }

                for (int z = 0; z <= 15; z++)
                {
                    cubes.Add(new Cube(new Vector3(0, 3, z), true, false, false, false, false, false));
                    cubes.Add(new Cube(new Vector3(15, 3, z), false, true, false, false, false, false));
                }

                for (int x = 0; x <= 3; x++)
                {
                    for (int y = 0; y <= 2; y++)
                    {
                        cubes.Add(new Cube(new Vector3(x, y, 0), false, false, true, false, false, false));
                        cubes.Add(new Cube(new Vector3(x + 12, y, 0), false, false, true, false, false, false));

                        cubes.Add(new Cube(new Vector3(x, y, 15), false, false, false, true, false, false));
                        cubes.Add(new Cube(new Vector3(x + 12, y, 15), false, false, false, true, false, false));
                    }
                }

                for (int x = 0; x <= 15; x++)
                {
                    cubes.Add(new Cube(new Vector3(x, 3, 0), false, false, true, false, false, false));
                    cubes.Add(new Cube(new Vector3(x, 3, 15), false, false, false, true, false, false));
                }

                //bottom of cauldron
                for (int x = 2; x < 14; x++)
                {
                    for (int z = 2; z < 14; z++)
                    {
                        cubes.Add(new Cube(new Vector3(x, 4.0f, z), false, false, false, false, false, true));
                    }
                }
            }
            else if (modelType == ModelType.FlowerPot)
            {
                addBox(6, 4, 6, 5, 5, 5, ref cubes);

                for (int x = 0; x < 6; x++)
                {
                    for (int z = 0; z < 6; z++)
                    {
                        if (x == 0 || x == 5 ||
                            z == 0 || z == 5)
                        {
                            cubes.Add(new Cube(x + 5, 9.0f, z + 5));
                            cubes.Add(new Cube(x + 5, 10.0f, z + 5));
                        }
                    }
                }
            }

            return cubes;
        }

        public static void addBox(int width, int height, int depth, int xOffset, int yOffset, int zOffset, ref List<Cube> cubes)
        {
            for (int x = xOffset; x < width + xOffset; x++)
            {
                for (int y = yOffset; y < height + yOffset; y++)
                {
                    for (int z = zOffset; z < depth + zOffset; z++)
                    {
                        if (x == xOffset || x == width + xOffset - 1 ||
                            y == yOffset || y == height + yOffset - 1 ||
                            z == zOffset || z == depth + zOffset - 1)
                        {
                            cubes.Add(new Cube(x, y, z));
                        }
                    }
                }
            }
        }

        public static void addTorchPlanes(Vector3 position, ref List<Cube> cubes)
        {
            //front
            cubes.Add(new Cube(new Vector3(position.x, position.y, position.z), true, false, false, false, false, false));
            cubes.Add(new Cube(new Vector3(position.x, position.y + 1, position.z), true, false, false, false, false, false));
            cubes.Add(new Cube(new Vector3(position.x, position.y, position.z + 3), true, false, false, false, false, false));
            cubes.Add(new Cube(new Vector3(position.x, position.y + 1, position.z + 3), true, false, false, false, false, false));
            cubes.Add(new Cube(new Vector3(position.x, position.y + 2, position.z + 1), true, false, false, false, false, false));
            cubes.Add(new Cube(new Vector3(position.x, position.y + 2, position.z + 2), true, false, false, false, false, false));

            //back
            cubes.Add(new Cube(new Vector3(position.x + 1, position.y, position.z), false, true, false, false, false, false));
            cubes.Add(new Cube(new Vector3(position.x + 1, position.y + 1, position.z), false, true, false, false, false, false));
            cubes.Add(new Cube(new Vector3(position.x + 1, position.y, position.z + 3), false, true, false, false, false, false));
            cubes.Add(new Cube(new Vector3(position.x + 1, position.y + 1, position.z + 3), false, true, false, false, false, false));
            cubes.Add(new Cube(new Vector3(position.x + 1, position.y + 2, position.z + 1), false, true, false, false, false, false));
            cubes.Add(new Cube(new Vector3(position.x + 1, position.y + 2, position.z + 2), false, true, false, false, false, false));

            //left
            cubes.Add(new Cube(new Vector3(position.x - 1, position.y, position.z + 1), false, false, true, false, false, false));
            cubes.Add(new Cube(new Vector3(position.x - 1, position.y + 1, position.z + 1), false, false, true, false, false, false));
            cubes.Add(new Cube(new Vector3(position.x + 2, position.y, position.z + 1), false, false, true, false, false, false));
            cubes.Add(new Cube(new Vector3(position.x + 2, position.y + 1, position.z + 1), false, false, true, false, false, false));
            cubes.Add(new Cube(new Vector3(position.x, position.y + 2, position.z + 1), false, false, true, false, false, false));
            cubes.Add(new Cube(new Vector3(position.x + 1, position.y + 2, position.z + 1), false, false, true, false, false, false));

            //right
            cubes.Add(new Cube(new Vector3(position.x - 1, position.y, position.z + 2), false, false, false, true, false, false));
            cubes.Add(new Cube(new Vector3(position.x - 1, position.y + 1, position.z + 2), false, false, false, true, false, false));
            cubes.Add(new Cube(new Vector3(position.x + 2, position.y, position.z + 2), false, false, false, true, false, false));
            cubes.Add(new Cube(new Vector3(position.x + 2, position.y + 1, position.z + 2), false, false, false, true, false, false));
            cubes.Add(new Cube(new Vector3(position.x, position.y + 2, position.z + 2), false, false, false, true, false, false));
            cubes.Add(new Cube(new Vector3(position.x + 1, position.y + 2, position.z + 2), false, false, false, true, false, false));
        }
    }
}
