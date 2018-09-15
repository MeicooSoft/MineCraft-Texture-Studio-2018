using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;
using System.Threading;
using System.IO;
using System.Collections;

namespace MinecraftTextureStudio
{
    public partial class FrmProcessChanges : Form
    {
        public bool done;
        public static FrmMain frmMain;

        public FrmProcessChanges(FrmMain frmMain)
        {
            InitializeComponent();
            FrmProcessChanges.frmMain = frmMain;
            done = false;

            Thread thread = new Thread(processChanges);
            thread.Start();
        }

        public void processChanges()
        {
            OrganiseResourcePack.selectedTextures = new List<string>();

            foreach (TreeNode node in FrmMain.treeView.Nodes)
            {
                if (node.Text == "Blocks")
                {
                    OrganiseResourcePack.checkBlockNode(node);
                }
            }

            OrganiseResourcePack.textures = new List<string>();
            OrganiseResourcePack.textures.Add("Gold Ore");
            OrganiseResourcePack.textures.Add("Iron Ore");
            OrganiseResourcePack.textures.Add("Coal Ore");
            OrganiseResourcePack.textures.Add("Diamond Ore");
            OrganiseResourcePack.textures.Add("Lapis Lazuli Ore");
            OrganiseResourcePack.textures.Add("Emerald Ore");
            OrganiseResourcePack.textures.Add("Nether Quartz Ore");
            OrganiseResourcePack.textures.Add("Coal Block");
            OrganiseResourcePack.textures.Add("Iron Block");
            OrganiseResourcePack.textures.Add("Gold Block");
            OrganiseResourcePack.textures.Add("Diamond Block");
            OrganiseResourcePack.textures.Add("Redstone Block");
            OrganiseResourcePack.textures.Add("Clay Block");
            OrganiseResourcePack.textures.Add("Quartz Block");
            OrganiseResourcePack.textures.Add("Hay Block");
            OrganiseResourcePack.textures.Add("Emerald Block");
            OrganiseResourcePack.textures.Add("Lapis Lazuli Block");
            OrganiseResourcePack.textures.Add("Snow (block)");
            OrganiseResourcePack.textures.Add("Packed Ice");
            OrganiseResourcePack.textures.Add("Chest");
            OrganiseResourcePack.textures.Add("Double Chest");
            OrganiseResourcePack.textures.Add("Trapped Chest");
            OrganiseResourcePack.textures.Add("Double Trapped Chest");
            OrganiseResourcePack.textures.Add("Ender Chest");
            OrganiseResourcePack.textures.Add("Double Stone Slab");
            OrganiseResourcePack.textures.Add("Stone Slab");
            OrganiseResourcePack.textures.Add("Sandstone Slab");
            OrganiseResourcePack.textures.Add("Cobblestone Slab");
            OrganiseResourcePack.textures.Add("Bricks Slab");
            OrganiseResourcePack.textures.Add("Stone Bricks Slab");
            OrganiseResourcePack.textures.Add("Nether Brick Slab");
            OrganiseResourcePack.textures.Add("Quartz Slab");
            OrganiseResourcePack.textures.Add("Oak Wood Slab");
            OrganiseResourcePack.textures.Add("Spruce Wood Slab");
            OrganiseResourcePack.textures.Add("Birch Wood Slab");
            OrganiseResourcePack.textures.Add("Jungle Wood Slab");
            OrganiseResourcePack.textures.Add("Acacia Wood Slab");
            OrganiseResourcePack.textures.Add("Dark Oak Wood Slab");
            OrganiseResourcePack.textures.Add("Oak Wood Stairs");
            OrganiseResourcePack.textures.Add("Stone Stairs");
            OrganiseResourcePack.textures.Add("Brick Stairs");
            OrganiseResourcePack.textures.Add("Stone Brick Stairs");
            OrganiseResourcePack.textures.Add("Sandstone Stairs");
            OrganiseResourcePack.textures.Add("Nether Brick Stairs");
            OrganiseResourcePack.textures.Add("Spruce Wood Stairs");
            OrganiseResourcePack.textures.Add("Birch Wood Stairs");
            OrganiseResourcePack.textures.Add("Jungle Wood Stairs");
            OrganiseResourcePack.textures.Add("Acacia Wood Stairs");
            OrganiseResourcePack.textures.Add("Dark Oak Wood Stairs");
            OrganiseResourcePack.textures.Add("Quartz Stairs");
            OrganiseResourcePack.textures.Add("Stone");
            OrganiseResourcePack.textures.Add("Grass Block");
            OrganiseResourcePack.textures.Add("Dirt");
            OrganiseResourcePack.textures.Add("Cobblestone");
            OrganiseResourcePack.textures.Add("Bedrock");
            OrganiseResourcePack.textures.Add("Sand");
            OrganiseResourcePack.textures.Add("Gravel");
            OrganiseResourcePack.textures.Add("Sandstone");
            OrganiseResourcePack.textures.Add("Smooth Sandstone");
            OrganiseResourcePack.textures.Add("Carved Sandstone");
            OrganiseResourcePack.textures.Add("Farmland Dry");
            OrganiseResourcePack.textures.Add("Farmland Wet");
            OrganiseResourcePack.textures.Add("Moss Stone");
            OrganiseResourcePack.textures.Add("Snow");
            OrganiseResourcePack.textures.Add("Ice");
            OrganiseResourcePack.textures.Add("Mycelium");
            OrganiseResourcePack.textures.Add("Obsidian");
            OrganiseResourcePack.textures.Add("Cobweb");
            OrganiseResourcePack.textures.Add("Netherrack");
            OrganiseResourcePack.textures.Add("Soul Sand");
            OrganiseResourcePack.textures.Add("Glowstone");
            OrganiseResourcePack.textures.Add("Wooden Door");
            OrganiseResourcePack.textures.Add("Iron Door");
            OrganiseResourcePack.textures.Add("Oak Plank");
            OrganiseResourcePack.textures.Add("Birch Plank");
            OrganiseResourcePack.textures.Add("Jungle Wood Plank");
            OrganiseResourcePack.textures.Add("Spruce Plank");
            OrganiseResourcePack.textures.Add("Acacia Plank");
            OrganiseResourcePack.textures.Add("Dark Oak Plank");
            OrganiseResourcePack.textures.Add("Acacia Sapling");
            OrganiseResourcePack.textures.Add("Birch Sapling");
            OrganiseResourcePack.textures.Add("Jungle Sapling");
            OrganiseResourcePack.textures.Add("Oak Sapling");
            OrganiseResourcePack.textures.Add("Dark Oak Sapling");
            OrganiseResourcePack.textures.Add("Spruce Sapling");
            OrganiseResourcePack.textures.Add("Water Still");
            OrganiseResourcePack.textures.Add("Water Flowing");
            OrganiseResourcePack.textures.Add("Lava Still");
            OrganiseResourcePack.textures.Add("Lava Flowing");
            OrganiseResourcePack.textures.Add("Fire");
            OrganiseResourcePack.textures.Add("Portal");
            OrganiseResourcePack.textures.Add("Oak");
            OrganiseResourcePack.textures.Add("Birch");
            OrganiseResourcePack.textures.Add("Jungle Wood");
            OrganiseResourcePack.textures.Add("Spruce");
            OrganiseResourcePack.textures.Add("Acacia");
            OrganiseResourcePack.textures.Add("Big Oak");
            OrganiseResourcePack.textures.Add("Leaves Acacia");
            OrganiseResourcePack.textures.Add("Leaves Acacia Opaque");
            OrganiseResourcePack.textures.Add("Leaves Big Oak");
            OrganiseResourcePack.textures.Add("Leaves Big Oak Opaque");
            OrganiseResourcePack.textures.Add("Leaves Birch");
            OrganiseResourcePack.textures.Add("Leaves Birch Opaque");
            OrganiseResourcePack.textures.Add("Leaves Jungle");
            OrganiseResourcePack.textures.Add("Leaves Jungle Opaque");
            OrganiseResourcePack.textures.Add("Leaves Oak");
            OrganiseResourcePack.textures.Add("Leaves Oak Opaque");
            OrganiseResourcePack.textures.Add("Leaves Spruce");
            OrganiseResourcePack.textures.Add("Leaves Spruce Opaque");
            OrganiseResourcePack.textures.Add("Glass");
            OrganiseResourcePack.textures.Add("White Stained Glass");
            OrganiseResourcePack.textures.Add("Orange Stained Glass");
            OrganiseResourcePack.textures.Add("Magenta Stained Glass");
            OrganiseResourcePack.textures.Add("Light Blue Stained Glass");
            OrganiseResourcePack.textures.Add("Yellow Stained Glass");
            OrganiseResourcePack.textures.Add("Lime Stained Glass");
            OrganiseResourcePack.textures.Add("Pink Stained Glass");
            OrganiseResourcePack.textures.Add("Gray Stained Glass");
            OrganiseResourcePack.textures.Add("Light Gray Stained Glass");
            OrganiseResourcePack.textures.Add("Cyan Stained Glass");
            OrganiseResourcePack.textures.Add("Purple Stained Glass");
            OrganiseResourcePack.textures.Add("Blue Stained Glass");
            OrganiseResourcePack.textures.Add("Brown Stained Glass");
            OrganiseResourcePack.textures.Add("Green Stained Glass");
            OrganiseResourcePack.textures.Add("Red Stained Glass");
            OrganiseResourcePack.textures.Add("Black Stained Glass");
            OrganiseResourcePack.textures.Add("Glass Pane");
            OrganiseResourcePack.textures.Add("White Stained Pane");
            OrganiseResourcePack.textures.Add("Orange Stained Pane");
            OrganiseResourcePack.textures.Add("Magenta Stained Pane");
            OrganiseResourcePack.textures.Add("Light Blue Stained Pane");
            OrganiseResourcePack.textures.Add("Yellow Stained Pane");
            OrganiseResourcePack.textures.Add("Lime Stained Pane");
            OrganiseResourcePack.textures.Add("Pink Stained Pane");
            OrganiseResourcePack.textures.Add("Gray Stained Pane");
            OrganiseResourcePack.textures.Add("Light Gray Stained Pane");
            OrganiseResourcePack.textures.Add("Cyan Stained Pane");
            OrganiseResourcePack.textures.Add("Purple Stained Pane");
            OrganiseResourcePack.textures.Add("Blue Stained Pane");
            OrganiseResourcePack.textures.Add("Brown Stained Pane");
            OrganiseResourcePack.textures.Add("Green Stained Pane");
            OrganiseResourcePack.textures.Add("Red Stained Pane");
            OrganiseResourcePack.textures.Add("Black Stained Pane");
            OrganiseResourcePack.textures.Add("Redstone Ore");
            OrganiseResourcePack.textures.Add("Redstone Cross");
            OrganiseResourcePack.textures.Add("Redstone Line");
            OrganiseResourcePack.textures.Add("Redstone Torch Off");
            OrganiseResourcePack.textures.Add("Redstone Torch On");
            OrganiseResourcePack.textures.Add("Redstone Repeater Off");
            OrganiseResourcePack.textures.Add("Redstone Repeater On");
            OrganiseResourcePack.textures.Add("Redstone Lamp Off");
            OrganiseResourcePack.textures.Add("Redstone Lamp On");
            OrganiseResourcePack.textures.Add("Redstone Comparator Off");
            OrganiseResourcePack.textures.Add("Redstone Comparator On");
            OrganiseResourcePack.textures.Add("Dropper Horizontal");
            OrganiseResourcePack.textures.Add("Dropper Vertical");
            OrganiseResourcePack.textures.Add("Dispenser Horizontal");
            OrganiseResourcePack.textures.Add("Dispenser Vertical");
            OrganiseResourcePack.textures.Add("Piston");
            OrganiseResourcePack.textures.Add("Piston Extended");
            OrganiseResourcePack.textures.Add("Sticky Piston");
            OrganiseResourcePack.textures.Add("Button");
            OrganiseResourcePack.textures.Add("Wooden Button");
            OrganiseResourcePack.textures.Add("Lever");
            OrganiseResourcePack.textures.Add("Daylight Sensor");
            OrganiseResourcePack.textures.Add("Skeleton Skull");
            OrganiseResourcePack.textures.Add("Wither Skeleton Skull");
            OrganiseResourcePack.textures.Add("Zombie Head");
            OrganiseResourcePack.textures.Add("Head");
            OrganiseResourcePack.textures.Add("Creeper Head");
            OrganiseResourcePack.textures.Add("Golden Rail");
            OrganiseResourcePack.textures.Add("Detector Rail");
            OrganiseResourcePack.textures.Add("Rail");
            OrganiseResourcePack.textures.Add("Rail Turned");
            OrganiseResourcePack.textures.Add("Activator Rail");
            OrganiseResourcePack.textures.Add("Stone Pressure Plate");
            OrganiseResourcePack.textures.Add("Wooden Pressure Plate");
            OrganiseResourcePack.textures.Add("Weighted Pressure Plate (Light)");
            OrganiseResourcePack.textures.Add("Weighted Pressure Plate (Heavy)");
            OrganiseResourcePack.textures.Add("Grass");
            OrganiseResourcePack.textures.Add("Dead Bush");
            OrganiseResourcePack.textures.Add("Tall Grass");
            OrganiseResourcePack.textures.Add("Large Fern");
            OrganiseResourcePack.textures.Add("Vines");
            OrganiseResourcePack.textures.Add("Lily Pad");
            OrganiseResourcePack.textures.Add("Dandelion");
            OrganiseResourcePack.textures.Add("Poppy");
            OrganiseResourcePack.textures.Add("Blue Orchid");
            OrganiseResourcePack.textures.Add("Allium");
            OrganiseResourcePack.textures.Add("Azure Bluet");
            OrganiseResourcePack.textures.Add("Red Tulip");
            OrganiseResourcePack.textures.Add("Orange Tulip");
            OrganiseResourcePack.textures.Add("White Tulip");
            OrganiseResourcePack.textures.Add("Pink Tulip");
            OrganiseResourcePack.textures.Add("Oxeye Daisy");
            OrganiseResourcePack.textures.Add("Sunflower");
            OrganiseResourcePack.textures.Add("Lilac");
            OrganiseResourcePack.textures.Add("Rose Bush");
            OrganiseResourcePack.textures.Add("Peony");
            OrganiseResourcePack.textures.Add("Cactus");
            OrganiseResourcePack.textures.Add("Melon");
            OrganiseResourcePack.textures.Add("Sugar Cane");
            OrganiseResourcePack.textures.Add("Brown Mushroom");
            OrganiseResourcePack.textures.Add("Red Mushroom");
            OrganiseResourcePack.textures.Add("Huge Brown Mushroom");
            OrganiseResourcePack.textures.Add("Huge Red Mushroom");
            OrganiseResourcePack.textures.Add("Pumpkin On");
            OrganiseResourcePack.textures.Add("Pumpkin Off");
            OrganiseResourcePack.textures.Add("Pumpkin Stem Connected");
            OrganiseResourcePack.textures.Add("Pumpkin Stem Disconnected");
            OrganiseResourcePack.textures.Add("Melon Stem Connected");
            OrganiseResourcePack.textures.Add("Melon Stem Disconnected");
            OrganiseResourcePack.textures.Add("Nether Wart Stage 0");
            OrganiseResourcePack.textures.Add("Nether Wart Stage 1");
            OrganiseResourcePack.textures.Add("Nether Wart Stage 2");
            OrganiseResourcePack.textures.Add("Carrots Stage 0");
            OrganiseResourcePack.textures.Add("Carrots Stage 1");
            OrganiseResourcePack.textures.Add("Carrots Stage 2");
            OrganiseResourcePack.textures.Add("Carrots Stage 3");
            OrganiseResourcePack.textures.Add("Potatoes Stage 0");
            OrganiseResourcePack.textures.Add("Potatoes Stage 1");
            OrganiseResourcePack.textures.Add("Potatoes Stage 2");
            OrganiseResourcePack.textures.Add("Potatoes Stage 3");
            OrganiseResourcePack.textures.Add("Cocoa Stage 0");
            OrganiseResourcePack.textures.Add("Cocoa Stage 1");
            OrganiseResourcePack.textures.Add("Cocoa Stage 2");
            OrganiseResourcePack.textures.Add("Wheat Stage 0");
            OrganiseResourcePack.textures.Add("Wheat Stage 1");
            OrganiseResourcePack.textures.Add("Wheat Stage 2");
            OrganiseResourcePack.textures.Add("Wheat Stage 3");
            OrganiseResourcePack.textures.Add("Wheat Stage 4");
            OrganiseResourcePack.textures.Add("Wheat Stage 5");
            OrganiseResourcePack.textures.Add("Wheat Stage 6");
            OrganiseResourcePack.textures.Add("Wheat Stage 7");
            OrganiseResourcePack.textures.Add("Wool");
            OrganiseResourcePack.textures.Add("Orange Wool");
            OrganiseResourcePack.textures.Add("Magenta Wool");
            OrganiseResourcePack.textures.Add("Light Blue Wool");
            OrganiseResourcePack.textures.Add("Yellow Wool");
            OrganiseResourcePack.textures.Add("Lime Wool");
            OrganiseResourcePack.textures.Add("Pink Wool");
            OrganiseResourcePack.textures.Add("Gray Wool");
            OrganiseResourcePack.textures.Add("Light Gray Wool");
            OrganiseResourcePack.textures.Add("Cyan Wool");
            OrganiseResourcePack.textures.Add("Blue Wool");
            OrganiseResourcePack.textures.Add("Brown Wool");
            OrganiseResourcePack.textures.Add("Green Wool");
            OrganiseResourcePack.textures.Add("Red Wool");
            OrganiseResourcePack.textures.Add("Black Wool");
            OrganiseResourcePack.textures.Add("Hardened Clay");
            OrganiseResourcePack.textures.Add("Black Hardened Clay");
            OrganiseResourcePack.textures.Add("Blue Hardened Clay");
            OrganiseResourcePack.textures.Add("Brown Hardened Clay");
            OrganiseResourcePack.textures.Add("Cyan Hardened Clay");
            OrganiseResourcePack.textures.Add("Gray Hardened Clay");
            OrganiseResourcePack.textures.Add("Green Hardened Clay");
            OrganiseResourcePack.textures.Add("Light Blue Hardened Clay");
            OrganiseResourcePack.textures.Add("Lime Hardened Clay");
            OrganiseResourcePack.textures.Add("Magenta Hardened Clay");
            OrganiseResourcePack.textures.Add("Orange Hardened Clay");
            OrganiseResourcePack.textures.Add("Pink Hardened Clay");
            OrganiseResourcePack.textures.Add("Purple Hardened Clay");
            OrganiseResourcePack.textures.Add("Red Hardened Clay");
            OrganiseResourcePack.textures.Add("Silver Hardened Clay");
            OrganiseResourcePack.textures.Add("White Hardened Clay");
            OrganiseResourcePack.textures.Add("Yellow Hardened Clay");
            OrganiseResourcePack.textures.Add("Carpet");
            OrganiseResourcePack.textures.Add("Orange Carpet");
            OrganiseResourcePack.textures.Add("Magenta Carpet");
            OrganiseResourcePack.textures.Add("Light Blue Carpet");
            OrganiseResourcePack.textures.Add("Yellow Carpet");
            OrganiseResourcePack.textures.Add("Lime Carpet");
            OrganiseResourcePack.textures.Add("Pink Carpet");
            OrganiseResourcePack.textures.Add("Gray Carpet");
            OrganiseResourcePack.textures.Add("Light Gray Carpet");
            OrganiseResourcePack.textures.Add("Cyan Carpet");
            OrganiseResourcePack.textures.Add("Purple Carpet");
            OrganiseResourcePack.textures.Add("Blue Carpet");
            OrganiseResourcePack.textures.Add("Brown Carpet");
            OrganiseResourcePack.textures.Add("Green Carpet");
            OrganiseResourcePack.textures.Add("Red Carpet");
            OrganiseResourcePack.textures.Add("Black Carpet");
            OrganiseResourcePack.textures.Add("Crafting Table");
            OrganiseResourcePack.textures.Add("Enchantment Table");
            OrganiseResourcePack.textures.Add("Brewing Stand Empty");
            OrganiseResourcePack.textures.Add("Brewing Stand Potion");
            OrganiseResourcePack.textures.Add("Cauldron");
            OrganiseResourcePack.textures.Add("Hopper");
            OrganiseResourcePack.textures.Add("Anvil");
            OrganiseResourcePack.textures.Add("Furnace Off");
            OrganiseResourcePack.textures.Add("Furnace On");
            OrganiseResourcePack.textures.Add("End Portal Block");
            OrganiseResourcePack.textures.Add("End Stone");
            OrganiseResourcePack.textures.Add("Dragon Egg");
            OrganiseResourcePack.textures.Add("Bricks");
            OrganiseResourcePack.textures.Add("Stone Bricks");
            OrganiseResourcePack.textures.Add("Nether Brick");
            OrganiseResourcePack.textures.Add("Wall Sign");
            OrganiseResourcePack.textures.Add("Standing Sign");
            OrganiseResourcePack.textures.Add("Noteblock");
            OrganiseResourcePack.textures.Add("Jukebox");
            OrganiseResourcePack.textures.Add("Sponge");
            OrganiseResourcePack.textures.Add("Bed");
            OrganiseResourcePack.textures.Add("TNT");
            OrganiseResourcePack.textures.Add("Bookshelf");
            OrganiseResourcePack.textures.Add("Torch");
            OrganiseResourcePack.textures.Add("Monster Spawner");
            OrganiseResourcePack.textures.Add("Ladders");
            OrganiseResourcePack.textures.Add("Fence");
            OrganiseResourcePack.textures.Add("Fence Gate");
            OrganiseResourcePack.textures.Add("Cake");
            OrganiseResourcePack.textures.Add("Trapdoor");
            OrganiseResourcePack.textures.Add("Iron Bars");
            OrganiseResourcePack.textures.Add("Nether Brick Fence");
            OrganiseResourcePack.textures.Add("Tripwire Hook");
            OrganiseResourcePack.textures.Add("Tripwire");
            OrganiseResourcePack.textures.Add("Command Block");
            OrganiseResourcePack.textures.Add("Beacon");
            OrganiseResourcePack.textures.Add("Cobblestone Wall");
            OrganiseResourcePack.textures.Add("Flower Pot");

            //populate list of textures
            Hashtable textureCount = new Hashtable();

            foreach (string textureName in OrganiseResourcePack.textures)
            {
                List<string> textures = Blocks.getTextures(textureName);

                foreach (string path in textures)
                {
                    if (!textureCount.Contains(path))
                    {
                        textureCount.Add(path, 0);
                    }
                }
            }

            //get texture count
            foreach (string textureName in OrganiseResourcePack.selectedTextures)
            {
                List<string> textures = Blocks.getTextures(textureName);

                foreach (string path in textures)
                {
                    if (!textureCount.Contains(path))
                    {
                        textureCount.Add(path, 1);
                    }
                    else
                    {
                        int count = (int)textureCount[path];
                        count++;
                        textureCount[path] = count;
                    }
                }
            }

            //get list of textures to delete
            List<string> texturesToDelete = new List<string>();

            foreach (DictionaryEntry entry in textureCount)
            {
                string path = (string)entry.Key;
                int count = (int)entry.Value;

                if (count == 0)
                {
                    texturesToDelete.Add(path);
                }
            }

            foreach (string path in texturesToDelete)
            {
                try
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Exception occured deleting " + path + ": " + exception.Message);
                }
            }

            //sounds
            OrganiseResourcePack.selectedSounds = new List<string>();
            OrganiseResourcePack.unselectedSounds = new List<string>();

            foreach (TreeNode node in FrmMain.treeView.Nodes)
            {
                if (node.Text == "Sounds")
                {
                    OrganiseResourcePack.checkSoundNode(node);
                }
            }

            if (OrganiseResourcePack.selectedSounds.Count > 0)
            {
                FrmAddSounds.addSounds();
                
                foreach (string soundName in OrganiseResourcePack.unselectedSounds)
                {
                    string filename = Sounds.getSounds(soundName);

                    try
                    {
                        if (File.Exists(filename))
                        {
                            File.Delete(filename);
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Exception occured deleting " + filename + ": " + exception.Message);
                    }
                }
            }

            //items
            OrganiseResourcePack.selectedItems = new List<string>();
            OrganiseResourcePack.unselectedItems = new List<string>();

            foreach (TreeNode node in FrmMain.treeView.Nodes)
            {
                if (node.Text == "Items")
                {
                    OrganiseResourcePack.checkItemNode(node);
                }
            }

            List<string> itemsToDelete = new List<string>();

            foreach (string itemName in OrganiseResourcePack.unselectedItems)
            {
                List<string> textures = Items.getTextures(itemName);

                foreach (string path in textures)
                {
                    itemsToDelete.Add(path);
                }
            }

            foreach (string path in itemsToDelete)
            {
                try
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Exception occured deleting " + path + ": " + exception.Message);
                }
            }

            FrmMain.loadResourcePack(frmMain);
            done = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (done)
            {
                this.Close();
            }

            if (progressBar.Value + 5 <= progressBar.Maximum)
            {
                progressBar.Value = progressBar.Value + 5;
            }
            else
            {
                progressBar.Value = 0;
            }
        }
    }
}
