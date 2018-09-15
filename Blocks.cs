using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace MinecraftTextureStudio
{
    public class Blocks
    {
        public static void loadBlocks()
        {
            FrmMain.blockList = new List<string>();
            FrmMain.blocks = new Hashtable();
            addBlock("Destroy", 0);
            addBlock("Stone", 1);
            addBlock("Grass Block", 2);
            addBlock("Dirt", 3);
            addBlock("Cobblestone", 4);
            addBlock("Oak Plank", 5);
            addBlock("Birch Plank", 5);
            addBlock("Jungle Wood Plank", 5);
            addBlock("Spruce Plank", 5);
            addBlock("Acacia Plank", 5);
            addBlock("Dark Oak Plank", 5);
            addBlock("Acacia Sapling", 6);
            addBlock("Birch Sapling", 6);
            addBlock("Jungle Sapling", 6);
            addBlock("Oak Sapling", 6);
            addBlock("Dark Oak Sapling", 6);
            addBlock("Spruce Sapling", 6);
            addBlock("Bedrock", 7);
            addBlock("Water Still", 8);
            addBlock("Water Flowing", 9);
            addBlock("Lava Still", 10);
            addBlock("Lava Flowing", 11);
            addBlock("Sand", 12);
            addBlock("Gravel", 13);
            addBlock("Gold Ore", 14);
            addBlock("Iron Ore", 15);
            addBlock("Coal Ore", 16);
            addBlock("Oak", 17);
            addBlock("Birch", 17);
            addBlock("Jungle Wood", 17);
            addBlock("Spruce", 17);
            addBlock("Acacia", 17);
            addBlock("Big Oak", 17);
            addBlock("Leaves Acacia", 18);
            addBlock("Leaves Acacia Opaque", 18);
            addBlock("Leaves Big Oak", 18);
            addBlock("Leaves Big Oak Opaque", 18);
            addBlock("Leaves Birch", 18);
            addBlock("Leaves Birch Opaque", 18);
            addBlock("Leaves Jungle", 18);
            addBlock("Leaves Jungle Opaque", 18);
            addBlock("Leaves Oak", 18);
            addBlock("Leaves Oak Opaque", 18);
            addBlock("Leaves Spruce", 18);
            addBlock("Leaves Spruce Opaque", 18);
            addBlock("Sponge", 19);
            addBlock("Glass", 20);
            addBlock("White Stained Glass", 20);
            addBlock("Orange Stained Glass", 20);
            addBlock("Magenta Stained Glass", 20);
            addBlock("Light Blue Stained Glass", 20);
            addBlock("Yellow Stained Glass", 20);
            addBlock("Lime Stained Glass", 20);
            addBlock("Pink Stained Glass", 20);
            addBlock("Gray Stained Glass", 20);
            addBlock("Light Gray Stained Glass", 20);
            addBlock("Cyan Stained Glass", 20);
            addBlock("Purple Stained Glass", 20);
            addBlock("Blue Stained Glass", 20);
            addBlock("Brown Stained Glass", 20);
            addBlock("Green Stained Glass", 20);
            addBlock("Red Stained Glass", 20);
            addBlock("Black Stained Glass", 20);
            addBlock("Lapis Lazuli Ore", 21);
            addBlock("Lapis Lazuli Block", 22);
            addBlock("Dispenser Horizontal", 23);
            addBlock("Dispenser Vertical", 23);
            addBlock("Sandstone", 24);
            addBlock("Smooth Sandstone", 24);
            addBlock("Carved Sandstone", 24);
            addBlock("Noteblock", 25);
            addBlock("Bed", 26);
            addBlock("Golden Rail", 27);
            addBlock("Detector Rail", 28);
            addBlock("Sticky Piston", 29);
            addBlock("Cobweb", 30);
            addBlock("Grass", 31);
            addBlock("Dead Bush", 32);
            addBlock("Piston", 33);
            addBlock("Piston Extended", 34);
            addBlock("Wool", 35);
            addBlock("Orange Wool", 35);
            addBlock("Magenta Wool", 35);
            addBlock("Light Blue Wool", 35);
            addBlock("Yellow Wool", 35);
            addBlock("Lime Wool", 35);
            addBlock("Pink Wool", 35);
            addBlock("Gray Wool", 35);
            addBlock("Light Gray Wool", 35);
            addBlock("Cyan Wool", 35);
            addBlock("Blue Wool", 35);
            addBlock("Brown Wool", 35);
            addBlock("Green Wool", 35);
            addBlock("Red Wool", 35);
            addBlock("Black Wool", 35);
            //36 has no visual component
            addBlock("Dandelion", 37);
            addBlock("Poppy", 38);
            addBlock("Blue Orchid", 38);
            addBlock("Allium", 38);
            addBlock("Azure Bluet", 38);
            addBlock("Red Tulip", 38);
            addBlock("Orange Tulip", 38);
            addBlock("White Tulip", 38);
            addBlock("Pink Tulip", 38);
            addBlock("Oxeye Daisy", 38);
            addBlock("Brown Mushroom", 39);
            addBlock("Red Mushroom", 40);
            addBlock("Gold Block", 41);
            addBlock("Iron Block", 42);
            addBlock("Double Stone Slab", 43);
            addBlock("Stone Slab", 44);
            addBlock("Sandstone Slab", 44);
            addBlock("Cobblestone Slab", 44);
            addBlock("Bricks Slab", 44);
            addBlock("Stone Bricks Slab", 44);
            addBlock("Nether Brick Slab", 44);
            addBlock("Quartz Slab", 44);
            addBlock("Bricks", 45);
            addBlock("TNT", 46);
            addBlock("Bookshelf", 47);
            addBlock("Moss Stone", 48);
            addBlock("Obsidian", 49);
            addBlock("Torch", 50);
            addBlock("Fire", 51);
            addBlock("Monster Spawner", 52);
            addBlock("Oak Wood Stairs", 53);
            addBlock("Chest", 54);
            addBlock("Double Chest", 54);
            addBlock("Redstone Cross", 55);
            addBlock("Redstone Line", 55);
            addBlock("Diamond Ore", 56);
            addBlock("Diamond Block", 57);
            addBlock("Crafting Table", 58);
            addBlock("Wheat Stage 0", 59);
            addBlock("Wheat Stage 1", 59);
            addBlock("Wheat Stage 2", 59);
            addBlock("Wheat Stage 3", 59);
            addBlock("Wheat Stage 4", 59);
            addBlock("Wheat Stage 5", 59);
            addBlock("Wheat Stage 6", 59);
            addBlock("Wheat Stage 7", 59);
            addBlock("Farmland Dry", 60);
            addBlock("Farmland Wet", 60);
            addBlock("Furnace Off", 61);
            addBlock("Furnace On", 62);
            addBlock("Standing Sign", 63);
            addBlock("Wooden Door", 64);
            addBlock("Ladders", 65);
            addBlock("Rail", 66);
            addBlock("Rail Turned", 66);
            addBlock("Stone Stairs", 67);
            addBlock("Wall Sign", 68);
            addBlock("Lever", 69);
            addBlock("Stone Pressure Plate", 70);
            addBlock("Iron Door", 71);
            addBlock("Wooden Pressure Plate", 72);
            addBlock("Redstone Ore", 73);
            //74 is lit redstone
            addBlock("Redstone Torch Off", 75);
            addBlock("Redstone Torch On", 76);
            addBlock("Button", 77);
            addBlock("Snow", 78);
            addBlock("Dirt (Snow)", 78);
            addBlock("Ice", 79);
            addBlock("Snow (block)", 80);
            addBlock("Cactus", 81);
            addBlock("Clay Block", 82);
            addBlock("Sugar Cane", 83);
            addBlock("Jukebox", 84);
            addBlock("Fence", 85);
            addBlock("Pumpkin Off", 86);
            addBlock("Netherrack", 87);
            addBlock("Soul Sand", 88);
            addBlock("Glowstone", 89);
            addBlock("Portal", 90);
            addBlock("Pumpkin On", 91);
            addBlock("Cake", 92);
            addBlock("Redstone Repeater Off", 93);
            addBlock("Redstone Repeater On", 94);
            //95 is stained glass
            addBlock("Trapdoor", 96);
            //97 is monster egg, same texture as cobblestone
            addBlock("Stone Bricks", 98);
            addBlock("Huge Brown Mushroom", 99);
            addBlock("Huge Red Mushroom", 100);
            addBlock("Iron Bars", 101);
            addBlock("Glass Pane", 102);
            addBlock("Melon", 103);
            addBlock("Pumpkin Stem Connected", 104);
            addBlock("Pumpkin Stem Disconnected", 104);
            addBlock("Melon Stem Connected", 105);
            addBlock("Melon Stem Disconnected", 105);
            addBlock("Vines", 106);
            addBlock("Fence Gate", 107);
            addBlock("Brick Stairs", 108);
            addBlock("Stone Brick Stairs", 109);
            addBlock("Mycelium", 110);
            addBlock("Lily Pad", 111);
            addBlock("Nether Brick", 112);
            addBlock("Nether Brick Fence", 113);
            addBlock("Nether Brick Stairs", 114);
            addBlock("Nether Wart Stage 0", 115);
            addBlock("Nether Wart Stage 1", 115);
            addBlock("Nether Wart Stage 2", 115);
            addBlock("Enchantment Table", 116);
            addBlock("Brewing Stand Empty", 117);
            addBlock("Brewing Stand Potion", 117);
            addBlock("Cauldron", 118);
            //119 is end portal
            addBlock("End Portal Block", 120);
            addBlock("End Stone", 121);
            addBlock("Dragon Egg", 122);
            addBlock("Redstone Lamp Off", 123);
            addBlock("Redstone Lamp On", 123);
            //125 is a double wooden slab
            addBlock("Oak Wood Slab", 126);
            addBlock("Spruce Wood Slab", 126);
            addBlock("Birch Wood Slab", 126);
            addBlock("Jungle Wood Slab", 126);
            addBlock("Acacia Wood Slab", 126);
            addBlock("Dark Oak Wood Slab", 126);
            addBlock("Cocoa Stage 0", 127);
            addBlock("Cocoa Stage 1", 127);
            addBlock("Cocoa Stage 2", 127);
            addBlock("Sandstone Stairs", 128);
            addBlock("Emerald Ore", 129);
            addBlock("Ender Chest", 130);
            addBlock("Tripwire Hook", 131);
            addBlock("Tripwire", 132);
            addBlock("Emerald Block", 133);
            addBlock("Spruce Wood Stairs", 134);
            addBlock("Birch Wood Stairs", 135);
            addBlock("Jungle Wood Stairs", 136);
            addBlock("Command Block", 137);
            addBlock("Beacon", 138);
            addBlock("Cobblestone Wall", 139);
            addBlock("Flower Pot", 140);
            addBlock("Carrots Stage 0", 141);
            addBlock("Carrots Stage 1", 141);
            addBlock("Carrots Stage 2", 141);
            addBlock("Carrots Stage 3", 141);
            addBlock("Potatoes Stage 0", 142);
            addBlock("Potatoes Stage 1", 142);
            addBlock("Potatoes Stage 2", 142);
            addBlock("Potatoes Stage 3", 142);
            addBlock("Wooden Button", 143);
            addBlock("Skeleton Skull", 144);
            addBlock("Wither Skeleton Skull", 144);
            addBlock("Zombie Head", 144);
            addBlock("Head", 144);
            addBlock("Creeper Head", 144);
            addBlock("Anvil", 145);
            addBlock("Trapped Chest", 146);
            addBlock("Double Trapped Chest", 146);
            addBlock("Weighted Pressure Plate (Light)", 147);
            addBlock("Weighted Pressure Plate (Heavy)", 148);
            addBlock("Redstone Comparator Off", 149);
            addBlock("Redstone Comparator On", 150);
            addBlock("Daylight Sensor", 151);
            addBlock("Redstone Block", 152);
            addBlock("Nether Quartz Ore", 153);
            addBlock("Hopper", 154);
            addBlock("Quartz Block", 155);
            addBlock("Quartz Stairs", 156);
            addBlock("Activator Rail", 157);
            addBlock("Dropper Horizontal", 158);
            addBlock("Dropper Vertical", 158);
            addBlock("Black Hardened Clay", 159);
            addBlock("Blue Hardened Clay", 159);
            addBlock("Brown Hardened Clay", 159);
            addBlock("Cyan Hardened Clay", 159);
            addBlock("Gray Hardened Clay", 159);
            addBlock("Green Hardened Clay", 159);
            addBlock("Light Blue Hardened Clay", 159);
            addBlock("Lime Hardened Clay", 159);
            addBlock("Magenta Hardened Clay", 159);
            addBlock("Orange Hardened Clay", 159);
            addBlock("Pink Hardened Clay", 159);
            addBlock("Purple Hardened Clay", 159);
            addBlock("Red Hardened Clay", 159);
            addBlock("Silver Hardened Clay", 159);
            addBlock("White Hardened Clay", 159);
            addBlock("Yellow Hardened Clay", 159);
            addBlock("White Stained Glass Pane", 160);
            addBlock("Orange Stained Glass Pane", 160);
            addBlock("Magenta Stained Glass Pane", 160);
            addBlock("Light Blue Stained Glass Pane", 160);
            addBlock("Yellow Stained Glass Pane", 160);
            addBlock("Lime Stained Glass Pane", 160);
            addBlock("Pink Stained Glass Pane", 160);
            addBlock("Gray Stained Glass Pane", 160);
            addBlock("Light Gray Stained Glass Pane", 160);
            addBlock("Cyan Stained Glass Pane", 160);
            addBlock("Purple Stained Glass Pane", 160);
            addBlock("Blue Stained Glass Pane", 160);
            addBlock("Brown Stained Glass Pane", 160);
            addBlock("Green Stained Glass Pane", 160);
            addBlock("Red Stained Glass Pane", 160);
            addBlock("Black Stained Glass Pane", 160);
            //161 is another leaves block type
            //162 is another logs block type
            addBlock("Acacia Wood Stairs", 163);
            addBlock("Dark Oak Wood Stairs", 164);
            //165 is slime block
            //166 is barrier
            //167 is iron trapdoor
            //168 is unused
            //169 is unused
            addBlock("Hay Block", 170);
            addBlock("Carpet", 171);
            addBlock("Orange Carpet", 171);
            addBlock("Magenta Carpet", 171);
            addBlock("Light Blue Carpet", 171);
            addBlock("Yellow Carpet", 171);
            addBlock("Lime Carpet", 171);
            addBlock("Pink Carpet", 171);
            addBlock("Gray Carpet", 171);
            addBlock("Light Gray Carpet", 171);
            addBlock("Cyan Carpet", 171);
            addBlock("Purple Carpet", 171);
            addBlock("Blue Carpet", 171);
            addBlock("Brown Carpet", 171);
            addBlock("Green Carpet", 171);
            addBlock("Red Carpet", 171);
            addBlock("Black Carpet", 171);
            addBlock("Hardened Clay", 172);
            addBlock("Coal Block", 173);
            addBlock("Packed Ice", 174);
            addBlock("Sunflower", 175);
            addBlock("Lilac", 175);
            addBlock("Rose Bush", 175);
            addBlock("Peony", 175);
            addBlock("Tall Grass", 175);
            addBlock("Large Fern", 175);
            addBlock("Inverted Daylight Sensor", 178);
            addBlock("Red Sandstone", 179);
            addBlock("Red Sandstone Stairs", 180);
            //addBlock("Double Red Sandstone Slab", 181);
            addBlock("Red Sandstone Slab", 182);
            addBlock("Spruce Fence Gate", 183);
            addBlock("Birch Fence Gate", 184);
            addBlock("Jungle Fence Gate", 185);
            addBlock("Dark Oak Fence Gate", 186);
            addBlock("Acacia Fence Gate", 187);
            addBlock("Spruce Fence", 188);
            addBlock("Birch Fence", 189);
            addBlock("Jungle Fence", 190);
            addBlock("Dark Oak Fence", 191);
            addBlock("Acacia Fence", 192);
            addBlock("Spruce Door", 193);
            addBlock("Birch Door", 194);
            addBlock("Jungle Door", 195);
            addBlock("Acacia Door", 196);
            addBlock("Dark Oak Door", 197);
        }

        public static void addBlock(string name, int index)
        {
            List<string> textures = Blocks.getTextures(name);

            bool allFound = true;
            foreach (string texture in textures)
            {
                if (!File.Exists(texture))
                {
                    allFound = false;
                    Console.WriteLine(texture + " not found");
                }
            }

            if (allFound)
            {
                FrmMain.blocks.Add(name, index);
                FrmMain.blockList.Add(name);
            }
        }

        public static List<string> getTextures(string blockName)
        {
            List<string> textures = new List<string>();

            if (blockName == "Stone")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\stone.png");
            }
            else if (blockName == "Grass Block")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\grass_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\grass_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\dirt.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\grass_side_overlay.png");
            }
            else if (blockName == "Cobblestone")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\cobblestone.png");
            }
            else if (blockName == "Oak Plank")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_oak.png");
            }
            else if (blockName == "Birch Plank")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_birch.png");
            }
            else if (blockName == "Jungle Wood Plank")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_jungle.png");
            }
            else if (blockName == "Spruce Plank")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_spruce.png");
            }
            else if (blockName == "Acacia Plank")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_acacia.png");
            }
            else if (blockName == "Dark Oak Plank")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_big_oak.png");
            }
            else if (blockName == "Acacia Sapling")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sapling_acacia.png");
            }
            else if (blockName == "Birch Sapling")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sapling_birch.png");
            }
            else if (blockName == "Jungle Sapling")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sapling_jungle.png");
            }
            else if (blockName == "Oak Sapling")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sapling_oak.png");
            }
            else if (blockName == "Dark Oak Sapling")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sapling_roofed_oak.png");
            }
            else if (blockName == "Spruce Sapling")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sapling_spruce.png");
            }
            else if (blockName == "Dirt")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\dirt.png");
            }
            else if (blockName == "Bedrock")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\bedrock.png");
            }
            else if (blockName == "Water Still")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\water_still.png");
            }
            else if (blockName == "Water Flowing")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\water_flow.png");
            }
            else if (blockName == "Lava Still")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\lava_still.png");
            }
            else if (blockName == "Lava Flowing")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\lava_flow.png");
            }
            else if (blockName == "Sand")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sand.png");
            }
            else if (blockName == "Gravel")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\gravel.png");
            }
            else if (blockName == "Gold Ore")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\gold_ore.png");
            }
            else if (blockName == "Iron Ore")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\iron_ore.png");
            }
            else if (blockName == "Coal Ore")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\coal_ore.png");
            }
            else if (blockName == "Oak")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\log_oak.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\log_oak_top.png");
            }
            else if (blockName == "Birch")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\log_birch.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\log_birch_top.png");
            }
            else if (blockName == "Jungle Wood")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\log_jungle.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\log_jungle_top.png");
            }
            else if (blockName == "Spruce")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\log_spruce.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\log_spruce_top.png");
            }
            else if (blockName == "Acacia")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\log_acacia.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\log_acacia_top.png");
            }
            else if (blockName == "Big Oak")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\log_big_oak.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\log_big_oak_top.png");
            }
            else if (blockName == "Leaves Acacia")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\leaves_acacia.png");
            }
            else if (blockName == "Leaves Acacia Opaque")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\leaves_acacia_opaque.png");
            }
            else if (blockName == "Leaves Big Oak")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\leaves_big_oak.png");
            }
            else if (blockName == "Leaves Big Oak Opaque")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\leaves_big_oak_opaque.png");
            }
            else if (blockName == "Leaves Birch")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\leaves_birch.png");
            }
            else if (blockName == "Leaves Birch Opaque")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\leaves_birch_opaque.png");
            }
            else if (blockName == "Leaves Jungle")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\leaves_jungle.png");
            }
            else if (blockName == "Leaves Jungle Opaque")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\leaves_jungle_opaque.png");
            }
            else if (blockName == "Leaves Oak")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\leaves_oak.png");
            }
            else if (blockName == "Leaves Oak Opaque")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\leaves_oak_opaque.png");
            }
            else if (blockName == "Leaves Spruce")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\leaves_spruce.png");
            }
            else if (blockName == "Leaves Spruce Opaque")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\leaves_spruce_opaque.png");
            }
            else if (blockName == "Lapis Lazuli Ore")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\lapis_ore.png");
            }
            else if (blockName == "Lapis Lazuli Block")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\lapis_block.png");
            }
            else if (blockName == "Sponge")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sponge.png");
            }
            else if (blockName == "Glass")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass.png");
            }
            else if (blockName == "White Stained Glass")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_white.png");
            }
            else if (blockName == "Orange Stained Glass")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_orange.png");
            }
            else if (blockName == "Magenta Stained Glass")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_magenta.png");
            }
            else if (blockName == "Light Blue Stained Glass")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_light_blue.png");
            }
            else if (blockName == "Yellow Stained Glass")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_yellow.png");
            }
            else if (blockName == "Lime Stained Glass")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_lime.png");
            }
            else if (blockName == "Pink Stained Glass")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_pink.png");
            }
            else if (blockName == "Gray Stained Glass")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_gray.png");
            }
            else if (blockName == "Light Gray Stained Glass")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_silver.png");
            }
            else if (blockName == "Cyan Stained Glass")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_cyan.png");
            }
            else if (blockName == "Purple Stained Glass")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_purple.png");
            }
            else if (blockName == "Blue Stained Glass")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_blue.png");
            }
            else if (blockName == "Brown Stained Glass")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_brown.png");
            }
            else if (blockName == "Green Stained Glass")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_green.png");
            }
            else if (blockName == "Red Stained Glass")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_red.png");
            }
            else if (blockName == "Black Stained Glass")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_black.png");
            }
            else if (blockName == "Dispenser Horizontal")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\furnace_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\furnace_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\dispenser_front_horizontal.png");
            }
            else if (blockName == "Dispenser Vertical")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\furnace_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\dispenser_front_vertical.png");
            }
            else if (blockName == "Sandstone")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sandstone_normal.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sandstone_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sandstone_bottom.png");
            }
            else if (blockName == "Smooth Sandstone")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sandstone_smooth.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sandstone_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sandstone_bottom.png");
            }
            else if (blockName == "Carved Sandstone")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sandstone_carved.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sandstone_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sandstone_bottom.png");
            }
            else if (blockName == "Sticky Piston")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\piston_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\piston_top_sticky.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\furnace_top.png");
            }
            else if (blockName == "Noteblock")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\noteblock.png");
            }
            else if (blockName == "Bed")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\bed_head_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\bed_head_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_oak.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\bed_head_end.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\bed_feet_end.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\bed_feet_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\bed_feet_top.png");
            }
            else if (blockName == "Golden Rail")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\rail_golden.png");
            }
            else if (blockName == "Detector Rail")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\rail_detector.png");
            }
            else if (blockName == "Grass")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\tallgrass.png");
            }
            else if (blockName == "Cobweb")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\web.png");
            }
            else if (blockName == "Dead Bush")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\deadbush.png");
            }
            else if (blockName == "Piston")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\piston_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\piston_top_normal.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\furnace_top.png");
            }
            else if (blockName == "Piston Extended")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\piston_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\piston_top_normal.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\piston_bottom.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\piston_inner.png");
            }
            else if (blockName == "Wool")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_white.png");
            }
            else if (blockName == "Orange Wool")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_orange.png");
            }
            else if (blockName == "Magenta Wool")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_magenta.png");
            }
            else if (blockName == "Light Blue Wool")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_light_blue.png");
            }
            else if (blockName == "Yellow Wool")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_yellow.png");
            }
            else if (blockName == "Lime Wool")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_lime.png");
            }
            else if (blockName == "Pink Wool")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_pink.png");
            }
            else if (blockName == "Gray Wool")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_gray.png");
            }
            else if (blockName == "Light Gray Wool")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_silver.png");
            }
            else if (blockName == "Cyan Wool")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_cyan.png");
            }
            else if (blockName == "Blue Wool")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_blue.png");
            }
            else if (blockName == "Brown Wool")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_brown.png");
            }
            else if (blockName == "Green Wool")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_green.png");
            }
            else if (blockName == "Red Wool")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_red.png");
            }
            else if (blockName == "Black Wool")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_black.png");
            }
            else if (blockName == "Dandelion")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\flower_dandelion.png");
            }
            else if (blockName == "Poppy")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\flower_rose.png");
            }
            else if (blockName == "Blue Orchid")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\flower_blue_orchid.png");
            }
            else if (blockName == "Allium")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\flower_allium.png");
            }
            else if (blockName == "Azure Bluet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\flower_houstonia.png");
            }
            else if (blockName == "Red Tulip")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\flower_tulip_red.png");
            }
            else if (blockName == "Orange Tulip")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\flower_tulip_orange.png");
            }
            else if (blockName == "White Tulip")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\flower_tulip_white.png");
            }
            else if (blockName == "Pink Tulip")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\flower_tulip_pink.png");
            }
            else if (blockName == "Oxeye Daisy")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\flower_oxeye_daisy.png");
            }
            else if (blockName == "Brown Mushroom")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\mushroom_brown.png");
            }
            else if (blockName == "Red Mushroom")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\mushroom_red.png");
            }
            else if (blockName == "Gold Block")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\gold_block.png");
            }
            else if (blockName == "Iron Block")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\iron_block.png");
            }
            else if (blockName == "Double Stone Slab")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\stone_slab_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\stone_slab_top.png");
            }
            else if (blockName == "Stone Slab")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\stone_slab_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\stone_slab_top.png");
            }
            else if (blockName == "Sandstone Slab")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sandstone_normal.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sandstone_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sandstone_bottom.png");
            }
            else if (blockName == "Cobblestone Slab")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\cobblestone.png");
            }
            else if (blockName == "Bricks Slab")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\brick.png");
            }
            else if (blockName == "Stone Bricks Slab")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\stonebrick.png");
            }
            else if (blockName == "Nether Brick Slab")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\nether_brick.png");
            }
            else if (blockName == "Quartz Slab")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\quartz_block_top.png");
            }
            else if (blockName == "Oak Wood Slab")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_oak.png");
            }
            else if (blockName == "Spruce Wood Slab")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_spruce.png");
            }
            else if (blockName == "Birch Wood Slab")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_birch.png");
            }
            else if (blockName == "Jungle Wood Slab")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_jungle.png");
            }
            else if (blockName == "Acacia Wood Slab")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_acacia.png");
            }
            else if (blockName == "Dark Oak Wood Slab")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_big_oak.png");
            }
            else if (blockName == "Bricks")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\brick.png");
            }
            else if (blockName == "TNT")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\tnt_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\tnt_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\tnt_bottom.png");
            }
            else if (blockName == "Bookshelf")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\bookshelf.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_oak.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_oak.png");
            }
            else if (blockName == "Moss Stone")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\cobblestone_mossy.png");
            }
            else if (blockName == "Obsidian")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\obsidian.png");
            }
            else if (blockName == "Torch")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\torch_on.png");
            }
            else if (blockName == "Fire")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\fire_layer_0.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\fire_layer_1.png");
            }
            else if (blockName == "Monster Spawner")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\mob_spawner.png");
            }
            else if (blockName == "Oak Wood Stairs")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_oak.png");
            }
            else if (blockName == "Stone Stairs")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\cobblestone.png");
            }
            else if (blockName == "Sandstone Stairs")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sandstone_normal.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sandstone_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\sandstone_bottom.png");
            }
            else if (blockName == "Spruce Wood Stairs")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_spruce.png");
            }
            else if (blockName == "Birch Wood Stairs")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_birch.png");
            }
            else if (blockName == "Jungle Wood Stairs")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_jungle.png");
            }
            else if (blockName == "Wooden Button")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_oak.png");
            }
            else if (blockName == "Skeleton Skull")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\entity\\skeleton\\skeleton.png");
            }
            else if (blockName == "Wither Skeleton Skull")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\entity\\skeleton\\wither_skeleton.png");
            }
            else if (blockName == "Zombie Head")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\entity\\zombie\\zombie.png");
            }
            else if (blockName == "Head")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\entity\\steve.png");
            }
            else if (blockName == "Creeper Head")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\entity\\creeper\\creeper.png");
            }
            else if (blockName == "Anvil")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\anvil_base.png");
            }
            else if (blockName == "Trapped Chest")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\entity\\chest\\trapped.png");
            }
            else if (blockName == "Double Trapped Chest")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\entity\\chest\\trapped_double.png");
            }
            else if (blockName == "Weighted Pressure Plate (Light)")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\gold_block.png");
            }
            else if (blockName == "Weighted Pressure Plate (Heavy)")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\iron_block.png");
            }
            else if (blockName == "Redstone Comparator Off")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\comparator_off.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\redstone_torch_off.png");
            }
            else if (blockName == "Redstone Comparator On")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\comparator_on.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\redstone_torch_off.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\redstone_torch_on.png");
            }
            else if (blockName == "Acacia Wood Stairs")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_acacia.png");
            }
            else if (blockName == "Dark Oak Wood Stairs")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_big_oak.png");
            }
            else if (blockName == "Quartz Stairs")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\quartz_block_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\quartz_block_top.png");
            }
            else if (blockName == "Chest")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\entity\\chest\\normal.png");
            }
            else if (blockName == "Double Chest")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\entity\\chest\\normal_double.png");
            }
            else if (blockName == "Redstone Cross")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\redstone_dust_cross.png");
            }
            else if (blockName == "Redstone Line")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\redstone_dust_line.png");
            }
            else if (blockName == "Diamond Ore")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\diamond_ore.png");
            }
            else if (blockName == "Diamond Block")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\diamond_block.png");
            }
            else if (blockName == "Crafting Table")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\crafting_table_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\crafting_table_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_oak.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\crafting_table_front.png");
            }
            else if (blockName == "Wheat Stage 0")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wheat_stage_0.png");
            }
            else if (blockName == "Wheat Stage 1")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wheat_stage_1.png");
            }
            else if (blockName == "Wheat Stage 2")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wheat_stage_2.png");
            }
            else if (blockName == "Wheat Stage 3")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wheat_stage_3.png");
            }
            else if (blockName == "Wheat Stage 4")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wheat_stage_4.png");
            }
            else if (blockName == "Wheat Stage 5")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wheat_stage_5.png");
            }
            else if (blockName == "Wheat Stage 6")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wheat_stage_6.png");
            }
            else if (blockName == "Wheat Stage 7")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wheat_stage_7.png");
            }
            else if (blockName == "Farmland Dry")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\dirt.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\farmland_dry.png");
            }
            else if (blockName == "Farmland Wet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\dirt.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\farmland_wet.png");
            }
            else if (blockName == "Furnace Off")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\furnace_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\furnace_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\furnace_front_off.png");
            }
            else if (blockName == "Furnace On")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\furnace_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\furnace_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\furnace_front_on.png");
            }
            else if (blockName == "Standing Sign")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\entity\\sign.png");
            }
            else if (blockName == "Wall Sign")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\entity\\sign.png");
            }
            else if (blockName == "Lever")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\cobblestone.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\lever.png");
            }
            else if (blockName == "Stone Pressure Plate")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\stone.png");
            }
            else if (blockName == "Wooden Pressure Plate")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_oak.png");
            }
            else if (blockName == "Wooden Door")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\door_wood_upper.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\door_wood_lower.png");
            }
            else if (blockName == "Iron Door")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\door_iron_upper.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\door_iron_lower.png");
            }
            else if (blockName == "Ladders")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\ladder.png");
            }
            else if (blockName == "Rail")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\rail_normal.png");
            }
            else if (blockName == "Rail Turned")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\rail_normal_turned.png");
            }
            else if (blockName == "Redstone Ore")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\redstone_ore.png");
            }
            else if (blockName == "Redstone Torch Off")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\redstone_torch_off.png");
            }
            else if (blockName == "Redstone Torch On")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\redstone_torch_on.png");
            }
            else if (blockName == "Button")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\stone.png");
            }
            else if (blockName == "Snow")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\snow.png");
            }
            else if (blockName == "Dirt (Snow)")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\grass_side_snowed.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\snow.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\dirt.png");
            }
            else if (blockName == "Ice")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\ice.png");
            }
            else if (blockName == "Snow (block)")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\snow.png");
            }
            else if (blockName == "Cactus")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\cactus_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\cactus_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\cactus_bottom.png");
            }
            else if (blockName == "Clay Block")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\clay.png");
            }
            else if (blockName == "Sugar Cane")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\reeds.png");
            }
            else if (blockName == "Jukebox")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\jukebox_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\jukebox_top.png");
            }
            else if (blockName == "Fence")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_oak.png");
            }
            else if (blockName == "Pumpkin Off")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\pumpkin_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\pumpkin_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\pumpkin_face_off.png");
            }
            else if (blockName == "Netherrack")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\netherrack.png");
            }
            else if (blockName == "Soul Sand")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\soul_sand.png");
            }
            else if (blockName == "Glowstone")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glowstone.png");
            }
            else if (blockName == "Portal")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\portal.png");
            }
            else if (blockName == "Pumpkin On")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\pumpkin_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\pumpkin_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\pumpkin_face_on.png");
            }
            else if (blockName == "Cake")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\cake_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\cake_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\cake_bottom.png");
            }
            else if (blockName == "Redstone Repeater Off")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\repeater_off.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\redstone_torch_off.png");
            }
            else if (blockName == "Redstone Repeater On")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\repeater_on.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\redstone_torch_on.png");
            }
            else if (blockName == "Trapdoor")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\trapdoor.png");
            }
            else if (blockName == "Huge Brown Mushroom")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\mushroom_block_skin_brown.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\mushroom_block_inside.png");
            }
            else if (blockName == "Stone Bricks")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\stonebrick.png");
            }
            else if (blockName == "Huge Red Mushroom")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\mushroom_block_skin_red.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\mushroom_block_inside.png");
            }
            else if (blockName == "Iron Bars")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\iron_bars.png");
            }
            else if (blockName == "Glass Pane")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_pane_top.png");
            }
            else if (blockName == "Melon")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\melon_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\melon_top.png");
            }
            else if (blockName == "Pumpkin Stem Connected")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\pumpkin_stem_connected.png");
            }
            else if (blockName == "Pumpkin Stem Disconnected")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\pumpkin_stem_disconnected.png");
            }
            else if (blockName == "Melon Stem Connected")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\melon_stem_connected.png");
            }
            else if (blockName == "Melon Stem Disconnected")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\melon_stem_disconnected.png");
            }
            else if (blockName == "Vines")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\vine.png");
            }
            else if (blockName == "Fence Gate")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_oak.png");
            }
            else if (blockName == "Brick Stairs")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\brick.png");
            }
            else if (blockName == "Stone Brick Stairs")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\stonebrick.png");
            }
            else if (blockName == "Mycelium")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\mycelium_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\mycelium_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\dirt.png");
            }
            else if (blockName == "Lily Pad")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\waterlily.png");
            }
            else if (blockName == "Nether Brick")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\nether_brick.png");
            }
            else if (blockName == "Nether Brick Fence")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\nether_brick.png");
            }
            else if (blockName == "Nether Brick Stairs")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\nether_brick.png");
            }
            else if (blockName == "Nether Wart Stage 0")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\nether_wart_stage_0.png");
            }
            else if (blockName == "Nether Wart Stage 1")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\nether_wart_stage_1.png");
            }
            else if (blockName == "Nether Wart Stage 2")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\nether_wart_stage_2.png");
            }
            else if (blockName == "Enchantment Table")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\enchanting_table_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\enchanting_table_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\enchanting_table_bottom.png");
            }
            else if (blockName == "Brewing Stand Empty")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\brewing_stand.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\brewing_stand_base.png");
            }
            else if (blockName == "Brewing Stand Potion")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\brewing_stand.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\brewing_stand_base.png");
            }
            else if (blockName == "Cauldron")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\cauldron_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\cauldron_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\cauldron_inner.png");
            }
            else if (blockName == "End Portal Block")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\endframe_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\endframe_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\end_stone.png");
            }
            else if (blockName == "End Stone")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\end_stone.png");
            }
            else if (blockName == "Dragon Egg")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\dragon_egg.png");
            }
            else if (blockName == "Redstone Lamp Off")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\redstone_lamp_off.png");
            }
            else if (blockName == "Redstone Lamp On")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\redstone_lamp_on.png");
            }
            else if (blockName == "Cocoa Stage 0")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\cocoa_stage_0.png");
            }
            else if (blockName == "Cocoa Stage 1")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\cocoa_stage_1.png");
            }
            else if (blockName == "Cocoa Stage 2")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\cocoa_stage_2.png");
            }
            else if (blockName == "Emerald Ore")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\emerald_ore.png");
            }
            else if (blockName == "Ender Chest")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\entity\\chest\\ender.png");
            }
            else if (blockName == "Tripwire Hook")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_oak.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\trip_wire_source.png");
            }
            else if (blockName == "Tripwire")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\trip_wire.png");
            }
            else if (blockName == "Emerald Block")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\emerald_block.png");
            }
            else if (blockName == "Command Block")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\command_block.png");
            }
            else if (blockName == "Beacon")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\beacon.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\obsidian.png");
            }
            else if (blockName == "Cobblestone Wall")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\cobblestone.png");
            }
            else if (blockName == "Flower Pot")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\flower_pot.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\dirt.png");
            }
            else if (blockName == "Carrots Stage 0")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\carrots_stage_0.png");
            }
            else if (blockName == "Carrots Stage 1")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\carrots_stage_1.png");
            }
            else if (blockName == "Carrots Stage 2")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\carrots_stage_2.png");
            }
            else if (blockName == "Carrots Stage 3")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\carrots_stage_3.png");
            }
            else if (blockName == "Potatoes Stage 0")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\potatoes_stage_0.png");
            }
            else if (blockName == "Potatoes Stage 1")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\potatoes_stage_1.png");
            }
            else if (blockName == "Potatoes Stage 2")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\potatoes_stage_2.png");
            }
            else if (blockName == "Potatoes Stage 3")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\potatoes_stage_3.png");
            }
            else if (blockName == "Redstone Block")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\redstone_block.png");
            }
            else if (blockName == "Daylight Sensor")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\daylight_detector_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\daylight_detector_top.png");
            }
            else if (blockName == "Nether Quartz Ore")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\quartz_ore.png");
            }
            else if (blockName == "Hopper")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hopper_outside.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hopper_inside.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hopper_top.png");
            }
            else if (blockName == "Quartz Block")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\quartz_block_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\quartz_block_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\quartz_block_bottom.png");
            }
            else if (blockName == "Activator Rail")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\rail_activator.png");
            }
            else if (blockName == "Dropper Horizontal")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\furnace_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\furnace_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\dropper_front_horizontal.png");
            }
            else if (blockName == "Dropper Vertical")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\furnace_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\dropper_front_vertical.png");
            }
            else if (blockName == "Hay Block")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hay_block_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hay_block_top.png");
            }
            else if (blockName == "Carpet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_white.png");
            }
            else if (blockName == "Orange Carpet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_orange.png");
            }
            else if (blockName == "Magenta Carpet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_magenta.png");
            }
            else if (blockName == "Light Blue Carpet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_light_blue.png");
            }
            else if (blockName == "Yellow Carpet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_yellow.png");
            }
            else if (blockName == "Lime Carpet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_lime.png");
            }
            else if (blockName == "Pink Carpet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_pink.png");
            }
            else if (blockName == "Gray Carpet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_gray.png");
            }
            else if (blockName == "Light Gray Carpet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_silver.png");
            }
            else if (blockName == "Cyan Carpet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_cyan.png");
            }
            else if (blockName == "Purple Carpet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_purple.png");
            }
            else if (blockName == "Blue Carpet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_blue.png");
            }
            else if (blockName == "Brown Carpet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_brown.png");
            }
            else if (blockName == "Green Carpet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_green.png");
            }
            else if (blockName == "Red Carpet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_red.png");
            }
            else if (blockName == "Black Carpet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\wool_colored_black.png");
            }
            else if (blockName == "Hardened Clay")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hardened_clay.png");
            }
            else if (blockName == "Black Hardened Clay")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hardened_clay_stained_black.png");
            }
            else if (blockName == "Blue Hardened Clay")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hardened_clay_stained_blue.png");
            }
            else if (blockName == "Brown Hardened Clay")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hardened_clay_stained_brown.png");
            }
            else if (blockName == "Cyan Hardened Clay")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hardened_clay_stained_cyan.png");
            }
            else if (blockName == "Gray Hardened Clay")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hardened_clay_stained_gray.png");
            }
            else if (blockName == "Green Hardened Clay")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hardened_clay_stained_green.png");
            }
            else if (blockName == "Light Blue Hardened Clay")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hardened_clay_stained_light_blue.png");
            }
            else if (blockName == "Lime Hardened Clay")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hardened_clay_stained_lime.png");
            }
            else if (blockName == "Magenta Hardened Clay")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hardened_clay_stained_magenta.png");
            }
            else if (blockName == "Orange Hardened Clay")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hardened_clay_stained_orange.png");
            }
            else if (blockName == "Pink Hardened Clay")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hardened_clay_stained_pink.png");
            }
            else if (blockName == "Purple Hardened Clay")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hardened_clay_stained_purple.png");
            }
            else if (blockName == "Red Hardened Clay")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hardened_clay_stained_red.png");
            }
            else if (blockName == "Silver Hardened Clay")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hardened_clay_stained_silver.png");
            }
            else if (blockName == "White Hardened Clay")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hardened_clay_stained_white.png");
            }
            else if (blockName == "Yellow Hardened Clay")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\hardened_clay_stained_yellow.png");
            }
            else if (blockName == "White Stained Glass Pane")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_white.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_pane_top_white.png");
            }
            else if (blockName == "Orange Stained Glass Pane")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_orange.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_pane_top_orange.png");
            }
            else if (blockName == "Magenta Stained Glass Pane")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_magenta.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_pane_top_magenta.png");
            }
            else if (blockName == "Light Blue Stained Glass Pane")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_light_blue.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_pane_top_light_blue.png");
            }
            else if (blockName == "Yellow Stained Glass Pane")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_yellow.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_pane_top_yellow.png");
            }
            else if (blockName == "Lime Stained Glass Pane")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_lime.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_pane_top_lime.png");
            }
            else if (blockName == "Pink Stained Glass Pane")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_pink.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_pane_top_pink.png");
            }
            else if (blockName == "Gray Stained Glass Pane")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_gray.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_pane_top_gray.png");
            }
            else if (blockName == "Light Gray Stained Glass Pane")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_silver.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_pane_top_silver.png");
            }
            else if (blockName == "Cyan Stained Glass Pane")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_cyan.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_pane_top_cyan.png");
            }
            else if (blockName == "Purple Stained Glass Pane")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_purple.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_pane_top_purple.png");
            }
            else if (blockName == "Blue Stained Glass Pane")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_blue.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_pane_top_blue.png");
            }
            else if (blockName == "Brown Stained Glass Pane")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_brown.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_pane_top_brown.png");
            }
            else if (blockName == "Green Stained Glass Pane")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_green.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_pane_top_green.png");
            }
            else if (blockName == "Red Stained Glass Pane")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_red.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_pane_top_red.png");
            }
            else if (blockName == "Black Stained Glass Pane")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_black.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\glass_pane_top_black.png");
            }
            else if (blockName == "Coal Block")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\coal_block.png");
            }
            else if (blockName == "Packed Ice")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\ice_packed.png");
            }
            else if (blockName == "Sunflower")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\double_plant_sunflower_bottom.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\double_plant_sunflower_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\double_plant_sunflower_front.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\double_plant_sunflower_back.png");
            }
            else if (blockName == "Lilac")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\double_plant_syringa_bottom.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\double_plant_syringa_top.png");
            }
            else if (blockName == "Rose Bush")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\double_plant_rose_bottom.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\double_plant_rose_top.png");
            }
            else if (blockName == "Peony")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\double_plant_paeonia_bottom.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\double_plant_paeonia_top.png");
            }
            else if (blockName == "Tall Grass")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\double_plant_grass_bottom.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\double_plant_grass_top.png");
            }
            else if (blockName == "Large Fern")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\double_plant_fern_bottom.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\double_plant_fern_top.png");
            }
            else if (blockName == "Destroy")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\destroy_stage_0.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\destroy_stage_1.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\destroy_stage_2.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\destroy_stage_3.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\destroy_stage_4.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\destroy_stage_5.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\destroy_stage_6.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\destroy_stage_7.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\destroy_stage_8.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\destroy_stage_9.png");
            }
            else if (blockName == "Inverted Daylight Sensor")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\daylight_detector_side.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\daylight_detector_inverted_top.png");
            }
            else if (blockName == "Red Sandstone")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\red_sandstone_normal.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\red_sandstone_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\red_sandstone_bottom.png");
            }
            else if (blockName == "Red Sandstone Stairs")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\red_sandstone_normal.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\red_sandstone_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\red_sandstone_bottom.png");
            }
            else if (blockName == "Red Sandstone Slab")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\red_sandstone_normal.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\red_sandstone_top.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\red_sandstone_bottom.png");
            }
            else if (blockName == "Spruce Fence Gate")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_spruce.png");
            }
            else if (blockName == "Birch Fence Gate")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_birch.png");
            }
            else if (blockName == "Jungle Fence Gate")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_jungle.png");
            }
            else if (blockName == "Dark Oak Fence Gate")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_big_oak.png");
            }
            else if (blockName == "Acacia Fence Gate")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_acacia.png");
            }
            else if (blockName == "Spruce Fence")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_spruce.png");
            }
            else if (blockName == "Birch Fence")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_birch.png");
            }
            else if (blockName == "Jungle Fence")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_jungle.png");
            }
            else if (blockName == "Dark Oak Fence")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_big_oak.png");
            }
            else if (blockName == "Acacia Fence")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\planks_acacia.png");
            }
            else if (blockName == "Spruce Door")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\door_spruce_upper.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\door_spruce_lower.png");
            }
            else if (blockName == "Birch Door")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\door_birch_upper.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\door_birch_lower.png");
            }
            else if (blockName == "Jungle Door")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\door_jungle_upper.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\door_jungle_lower.png");
            }
            else if (blockName == "Acacia Door")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\door_acacia_upper.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\door_acacia_lower.png");
            }
            else if (blockName == "Dark Oak Door")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\door_dark_oak_upper.png");
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\door_dark_oak_lower.png");
            }
            
            return textures;
        }
    }
}
