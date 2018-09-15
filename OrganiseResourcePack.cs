using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace MinecraftTextureStudio
{
    public class OrganiseResourcePack
    {
        public static List<string> textures;
        public static List<string> selectedTextures;
        public static List<string> selectedSounds;
        public static List<string> unselectedSounds;
        public static List<string> selectedItems;
        public static List<string> unselectedItems;

        public static void loadOrganiseTree()
        {
            FrmMain.treeView.CheckBoxes = true;

            TreeNode blocks = new TreeNode("Blocks");
            FrmMain.treeView.Nodes.Add(blocks);

            TreeNode ores = new TreeNode("Ores");
            blocks.Nodes.Add(ores);

            ores.Nodes.Add("Gold Ore");
            ores.Nodes.Add("Iron Ore");
            ores.Nodes.Add("Coal Ore");
            ores.Nodes.Add("Diamond Ore");
            ores.Nodes.Add("Redstone Ore");
            ores.Nodes.Add("Lapis Lazuli Ore");
            ores.Nodes.Add("Emerald Ore");
            ores.Nodes.Add("Nether Quartz Ore");
            
            TreeNode materialBlocks = new TreeNode("Material Blocks");
            blocks.Nodes.Add(materialBlocks);

            materialBlocks.Nodes.Add("Coal Block");
            materialBlocks.Nodes.Add("Iron Block");
            materialBlocks.Nodes.Add("Gold Block");
            materialBlocks.Nodes.Add("Diamond Block");
            materialBlocks.Nodes.Add("Redstone Block");
            materialBlocks.Nodes.Add("Clay Block");
            materialBlocks.Nodes.Add("Quartz Block");
            materialBlocks.Nodes.Add("Hay Block");
            materialBlocks.Nodes.Add("Emerald Block");
            materialBlocks.Nodes.Add("Lapis Lazuli Block");
            materialBlocks.Nodes.Add("Snow (block)");
            materialBlocks.Nodes.Add("Packed Ice");
            
            TreeNode chests = new TreeNode("Chests");
            blocks.Nodes.Add(chests);

            chests.Nodes.Add("Chest");
            chests.Nodes.Add("Double Chest");
            chests.Nodes.Add("Trapped Chest");
            chests.Nodes.Add("Double Trapped Chest");
            chests.Nodes.Add("Ender Chest");
            
            TreeNode slabs = new TreeNode("Slabs");
            blocks.Nodes.Add(slabs);

            slabs.Nodes.Add("Double Stone Slab");
            slabs.Nodes.Add("Stone Slab");
            slabs.Nodes.Add("Sandstone Slab");
            slabs.Nodes.Add("Cobblestone Slab");
            slabs.Nodes.Add("Bricks Slab");
            slabs.Nodes.Add("Stone Bricks Slab");
            slabs.Nodes.Add("Nether Brick Slab");
            slabs.Nodes.Add("Quartz Slab");
            slabs.Nodes.Add("Oak Wood Slab");
            slabs.Nodes.Add("Spruce Wood Slab");
            slabs.Nodes.Add("Birch Wood Slab");
            slabs.Nodes.Add("Jungle Wood Slab");
            slabs.Nodes.Add("Acacia Wood Slab");
            slabs.Nodes.Add("Dark Oak Wood Slab");
            
            TreeNode stairs = new TreeNode("Stairs");
            blocks.Nodes.Add(stairs);

            stairs.Nodes.Add("Oak Wood Stairs");
            stairs.Nodes.Add("Stone Stairs");
            stairs.Nodes.Add("Brick Stairs");
            stairs.Nodes.Add("Stone Brick Stairs");
            stairs.Nodes.Add("Sandstone Stairs");
            stairs.Nodes.Add("Nether Brick Stairs");
            stairs.Nodes.Add("Spruce Wood Stairs");
            stairs.Nodes.Add("Birch Wood Stairs");
            stairs.Nodes.Add("Jungle Wood Stairs");
            stairs.Nodes.Add("Acacia Wood Stairs");
            stairs.Nodes.Add("Dark Oak Wood Stairs");
            stairs.Nodes.Add("Quartz Stairs");
            
            TreeNode naturalBlocks = new TreeNode("Natural Blocks");
            blocks.Nodes.Add(naturalBlocks);

            naturalBlocks.Nodes.Add("Stone");
            naturalBlocks.Nodes.Add("Grass Block");
            naturalBlocks.Nodes.Add("Dirt");
            naturalBlocks.Nodes.Add("Dirt (Snow)");
            naturalBlocks.Nodes.Add("Cobblestone");
            naturalBlocks.Nodes.Add("Bedrock");
            naturalBlocks.Nodes.Add("Sand");
            naturalBlocks.Nodes.Add("Gravel");
            naturalBlocks.Nodes.Add("Sandstone");
            naturalBlocks.Nodes.Add("Smooth Sandstone");
            naturalBlocks.Nodes.Add("Carved Sandstone");
            naturalBlocks.Nodes.Add("Farmland Dry");
            naturalBlocks.Nodes.Add("Farmland Wet");
            naturalBlocks.Nodes.Add("Moss Stone");
            naturalBlocks.Nodes.Add("Snow");
            naturalBlocks.Nodes.Add("Ice");
            naturalBlocks.Nodes.Add("Mycelium");
            naturalBlocks.Nodes.Add("Obsidian");
            naturalBlocks.Nodes.Add("Cobweb");
            naturalBlocks.Nodes.Add("Netherrack");
            naturalBlocks.Nodes.Add("Soul Sand");
            naturalBlocks.Nodes.Add("Glowstone");
            
            TreeNode doors = new TreeNode("Doors");
            blocks.Nodes.Add(doors);

            doors.Nodes.Add("Wooden Door");
            doors.Nodes.Add("Iron Door");
            
            TreeNode planks = new TreeNode("Planks");
            blocks.Nodes.Add(planks);

            planks.Nodes.Add("Oak Plank");
            planks.Nodes.Add("Birch Plank");
            planks.Nodes.Add("Jungle Wood Plank");
            planks.Nodes.Add("Spruce Plank");
            planks.Nodes.Add("Acacia Plank");
            planks.Nodes.Add("Dark Oak Plank");

            TreeNode saplings = new TreeNode("Saplings");
            blocks.Nodes.Add(saplings);

            saplings.Nodes.Add("Acacia Sapling");
            saplings.Nodes.Add("Birch Sapling");
            saplings.Nodes.Add("Jungle Sapling");
            saplings.Nodes.Add("Oak Sapling");
            saplings.Nodes.Add("Dark Oak Sapling");
            saplings.Nodes.Add("Spruce Sapling");

            TreeNode environmentalElements = new TreeNode("Environmental Elements");
            blocks.Nodes.Add(environmentalElements);

            environmentalElements.Nodes.Add("Water Still");
            environmentalElements.Nodes.Add("Water Flowing");
            environmentalElements.Nodes.Add("Lava Still");
            environmentalElements.Nodes.Add("Lava Flowing");
            environmentalElements.Nodes.Add("Fire");
            environmentalElements.Nodes.Add("Portal");
            
            TreeNode woods = new TreeNode("Woods");
            blocks.Nodes.Add(woods);

            woods.Nodes.Add("Oak");
            woods.Nodes.Add("Birch");
            woods.Nodes.Add("Jungle Wood");
            woods.Nodes.Add("Spruce");
            woods.Nodes.Add("Acacia");
            woods.Nodes.Add("Big Oak");

            TreeNode leaves = new TreeNode("Leaves");
            blocks.Nodes.Add(leaves);

            leaves.Nodes.Add("Leaves Acacia");
            leaves.Nodes.Add("Leaves Acacia Opaque");
            leaves.Nodes.Add("Leaves Big Oak");
            leaves.Nodes.Add("Leaves Big Oak Opaque");
            leaves.Nodes.Add("Leaves Birch");
            leaves.Nodes.Add("Leaves Birch Opaque");
            leaves.Nodes.Add("Leaves Jungle");
            leaves.Nodes.Add("Leaves Jungle Opaque");
            leaves.Nodes.Add("Leaves Oak");
            leaves.Nodes.Add("Leaves Oak Opaque");
            leaves.Nodes.Add("Leaves Spruce");
            leaves.Nodes.Add("Leaves Spruce Opaque");

            TreeNode glassTypes = new TreeNode("Glass Types");
            blocks.Nodes.Add(glassTypes);

            TreeNode glass = new TreeNode("Normal Glass");
            glassTypes.Nodes.Add(glass);

            glass.Nodes.Add("Glass");
            glass.Nodes.Add("White Stained Glass");
            glass.Nodes.Add("Orange Stained Glass");
            glass.Nodes.Add("Magenta Stained Glass");
            glass.Nodes.Add("Light Blue Stained Glass");
            glass.Nodes.Add("Yellow Stained Glass");
            glass.Nodes.Add("Lime Stained Glass");
            glass.Nodes.Add("Pink Stained Glass");
            glass.Nodes.Add("Gray Stained Glass");
            glass.Nodes.Add("Light Gray Stained Glass");
            glass.Nodes.Add("Cyan Stained Glass");
            glass.Nodes.Add("Purple Stained Glass");
            glass.Nodes.Add("Blue Stained Glass");
            glass.Nodes.Add("Brown Stained Glass");
            glass.Nodes.Add("Green Stained Glass");
            glass.Nodes.Add("Red Stained Glass");
            glass.Nodes.Add("Black Stained Glass");

            TreeNode glassPane = new TreeNode("Glass Panes");
            glassTypes.Nodes.Add(glassPane);

            glassPane.Nodes.Add("Glass Pane");
            glassPane.Nodes.Add("White Stained Glass Pane");
            glassPane.Nodes.Add("Orange Stained Glass Pane");
            glassPane.Nodes.Add("Magenta Stained Glass Pane");
            glassPane.Nodes.Add("Light Blue Stained Glass Pane");
            glassPane.Nodes.Add("Yellow Stained Glass Pane");
            glassPane.Nodes.Add("Lime Stained Glass Pane");
            glassPane.Nodes.Add("Pink Stained Glass Pane");
            glassPane.Nodes.Add("Gray Stained Glass Pane");
            glassPane.Nodes.Add("Light Gray Stained Glass Pane");
            glassPane.Nodes.Add("Cyan Stained Glass Pane");
            glassPane.Nodes.Add("Purple Stained Glass Pane");
            glassPane.Nodes.Add("Blue Stained Glass Pane");
            glassPane.Nodes.Add("Brown Stained Glass Pane");
            glassPane.Nodes.Add("Green Stained Glass Pane");
            glassPane.Nodes.Add("Red Stained Glass Pane");
            glassPane.Nodes.Add("Black Stained Glass Pane");

            TreeNode redstoneMachines = new TreeNode("Redstone & Redstone Machines");
            blocks.Nodes.Add(redstoneMachines);

            redstoneMachines.Nodes.Add("Redstone Cross");
            redstoneMachines.Nodes.Add("Redstone Line");
            redstoneMachines.Nodes.Add("Redstone Torch Off");
            redstoneMachines.Nodes.Add("Redstone Torch On");
            redstoneMachines.Nodes.Add("Redstone Repeater Off");
            redstoneMachines.Nodes.Add("Redstone Repeater On");
            redstoneMachines.Nodes.Add("Redstone Lamp Off");
            redstoneMachines.Nodes.Add("Redstone Lamp On");
            redstoneMachines.Nodes.Add("Redstone Comparator Off");
            redstoneMachines.Nodes.Add("Redstone Comparator On");
            redstoneMachines.Nodes.Add("Dropper Horizontal");
            redstoneMachines.Nodes.Add("Dropper Vertical");
            redstoneMachines.Nodes.Add("Dispenser Horizontal");
            redstoneMachines.Nodes.Add("Dispenser Vertical");
            redstoneMachines.Nodes.Add("Piston");
            redstoneMachines.Nodes.Add("Piston Extended");
            redstoneMachines.Nodes.Add("Sticky Piston");
            redstoneMachines.Nodes.Add("Button");
            redstoneMachines.Nodes.Add("Wooden Button");
            redstoneMachines.Nodes.Add("Lever");
            redstoneMachines.Nodes.Add("Daylight Sensor");

            TreeNode mobHeads = new TreeNode("Mob Heads");
            blocks.Nodes.Add(mobHeads);

            mobHeads.Nodes.Add("Skeleton Skull");
            mobHeads.Nodes.Add("Wither Skeleton Skull");
            mobHeads.Nodes.Add("Zombie Head");
            mobHeads.Nodes.Add("Head");
            mobHeads.Nodes.Add("Creeper Head");

            TreeNode rail = new TreeNode("Rail");
            blocks.Nodes.Add(rail);

            rail.Nodes.Add("Golden Rail");
            rail.Nodes.Add("Detector Rail");
            rail.Nodes.Add("Rail");
            rail.Nodes.Add("Rail Turned");
            rail.Nodes.Add("Activator Rail");

            TreeNode pressurePlates = new TreeNode("Pressure Plates");
            blocks.Nodes.Add(pressurePlates);

            pressurePlates.Nodes.Add("Stone Pressure Plate");
            pressurePlates.Nodes.Add("Wooden Pressure Plate");
            pressurePlates.Nodes.Add("Weighted Pressure Plate (Light)");
            pressurePlates.Nodes.Add("Weighted Pressure Plate (Heavy)");
            
            TreeNode plants = new TreeNode("Plants");
            blocks.Nodes.Add(plants);

            plants.Nodes.Add("Grass");
            plants.Nodes.Add("Dead Bush");
            plants.Nodes.Add("Tall Grass");
            plants.Nodes.Add("Large Fern");
            plants.Nodes.Add("Vines");
            plants.Nodes.Add("Lily Pad");
            
            TreeNode flowers = new TreeNode("Flowers");
            blocks.Nodes.Add(flowers);

            flowers.Nodes.Add("Dandelion");
            flowers.Nodes.Add("Poppy");
            flowers.Nodes.Add("Blue Orchid");
            flowers.Nodes.Add("Allium");
            flowers.Nodes.Add("Azure Bluet");
            flowers.Nodes.Add("Red Tulip");
            flowers.Nodes.Add("Orange Tulip");
            flowers.Nodes.Add("White Tulip");
            flowers.Nodes.Add("Pink Tulip");
            flowers.Nodes.Add("Oxeye Daisy");
            flowers.Nodes.Add("Sunflower");
            flowers.Nodes.Add("Lilac");
            flowers.Nodes.Add("Rose Bush");
            flowers.Nodes.Add("Peony");
            
            TreeNode growingPlants = new TreeNode("Growing Plants");
            blocks.Nodes.Add(growingPlants);

            growingPlants.Nodes.Add("Cactus");
            growingPlants.Nodes.Add("Melon");
            growingPlants.Nodes.Add("Sugar Cane");
            growingPlants.Nodes.Add("Brown Mushroom");
            growingPlants.Nodes.Add("Red Mushroom");
            growingPlants.Nodes.Add("Huge Brown Mushroom");
            growingPlants.Nodes.Add("Huge Red Mushroom");
            growingPlants.Nodes.Add("Pumpkin On");
            growingPlants.Nodes.Add("Pumpkin Off");
            growingPlants.Nodes.Add("Pumpkin Stem Connected");
            growingPlants.Nodes.Add("Pumpkin Stem Disconnected");
            growingPlants.Nodes.Add("Melon Stem Connected");
            growingPlants.Nodes.Add("Melon Stem Disconnected");
            growingPlants.Nodes.Add("Nether Wart Stage 0");
            growingPlants.Nodes.Add("Nether Wart Stage 1");
            growingPlants.Nodes.Add("Nether Wart Stage 2");
            growingPlants.Nodes.Add("Carrots Stage 0");
            growingPlants.Nodes.Add("Carrots Stage 1");
            growingPlants.Nodes.Add("Carrots Stage 2");
            growingPlants.Nodes.Add("Carrots Stage 3");
            growingPlants.Nodes.Add("Potatoes Stage 0");
            growingPlants.Nodes.Add("Potatoes Stage 1");
            growingPlants.Nodes.Add("Potatoes Stage 2");
            growingPlants.Nodes.Add("Potatoes Stage 3");
            growingPlants.Nodes.Add("Cocoa Stage 0");
            growingPlants.Nodes.Add("Cocoa Stage 1");
            growingPlants.Nodes.Add("Cocoa Stage 2");
            growingPlants.Nodes.Add("Wheat Stage 0");
            growingPlants.Nodes.Add("Wheat Stage 1");
            growingPlants.Nodes.Add("Wheat Stage 2");
            growingPlants.Nodes.Add("Wheat Stage 3");
            growingPlants.Nodes.Add("Wheat Stage 4");
            growingPlants.Nodes.Add("Wheat Stage 5");
            growingPlants.Nodes.Add("Wheat Stage 6");
            growingPlants.Nodes.Add("Wheat Stage 7");
            
            TreeNode wool = new TreeNode("Wool");
            blocks.Nodes.Add(wool);

            wool.Nodes.Add("Wool");
            wool.Nodes.Add("Orange Wool");
            wool.Nodes.Add("Magenta Wool");
            wool.Nodes.Add("Light Blue Wool");
            wool.Nodes.Add("Yellow Wool");
            wool.Nodes.Add("Lime Wool");
            wool.Nodes.Add("Pink Wool");
            wool.Nodes.Add("Gray Wool");
            wool.Nodes.Add("Light Gray Wool");
            wool.Nodes.Add("Cyan Wool");
            wool.Nodes.Add("Blue Wool");
            wool.Nodes.Add("Brown Wool");
            wool.Nodes.Add("Green Wool");
            wool.Nodes.Add("Red Wool");
            wool.Nodes.Add("Black Wool");

            TreeNode clay = new TreeNode("Clay");
            blocks.Nodes.Add(clay);

            clay.Nodes.Add("Hardened Clay");
            clay.Nodes.Add("Black Hardened Clay");
            clay.Nodes.Add("Blue Hardened Clay");
            clay.Nodes.Add("Brown Hardened Clay");
            clay.Nodes.Add("Cyan Hardened Clay");
            clay.Nodes.Add("Gray Hardened Clay");
            clay.Nodes.Add("Green Hardened Clay");
            clay.Nodes.Add("Light Blue Hardened Clay");
            clay.Nodes.Add("Lime Hardened Clay");
            clay.Nodes.Add("Magenta Hardened Clay");
            clay.Nodes.Add("Orange Hardened Clay");
            clay.Nodes.Add("Pink Hardened Clay");
            clay.Nodes.Add("Purple Hardened Clay");
            clay.Nodes.Add("Red Hardened Clay");
            clay.Nodes.Add("Silver Hardened Clay");
            clay.Nodes.Add("White Hardened Clay");
            clay.Nodes.Add("Yellow Hardened Clay");

            TreeNode carpet = new TreeNode("Carpet");
            blocks.Nodes.Add(carpet);

            carpet.Nodes.Add("Carpet");
            carpet.Nodes.Add("Orange Carpet");
            carpet.Nodes.Add("Magenta Carpet");
            carpet.Nodes.Add("Light Blue Carpet");
            carpet.Nodes.Add("Yellow Carpet");
            carpet.Nodes.Add("Lime Carpet");
            carpet.Nodes.Add("Pink Carpet");
            carpet.Nodes.Add("Gray Carpet");
            carpet.Nodes.Add("Light Gray Carpet");
            carpet.Nodes.Add("Cyan Carpet");
            carpet.Nodes.Add("Purple Carpet");
            carpet.Nodes.Add("Blue Carpet");
            carpet.Nodes.Add("Brown Carpet");
            carpet.Nodes.Add("Green Carpet");
            carpet.Nodes.Add("Red Carpet");
            carpet.Nodes.Add("Black Carpet");

            TreeNode industryAndCrafting = new TreeNode("Industry and Crafting");
            blocks.Nodes.Add(industryAndCrafting);

            industryAndCrafting.Nodes.Add("Crafting Table");
            industryAndCrafting.Nodes.Add("Enchantment Table");
            industryAndCrafting.Nodes.Add("Brewing Stand Empty");
            industryAndCrafting.Nodes.Add("Brewing Stand Potion");
            industryAndCrafting.Nodes.Add("Cauldron");
            industryAndCrafting.Nodes.Add("Hopper");
            industryAndCrafting.Nodes.Add("Anvil");
            industryAndCrafting.Nodes.Add("Furnace Off");
            industryAndCrafting.Nodes.Add("Furnace On");

            TreeNode endBlocks = new TreeNode("End Blocks");
            blocks.Nodes.Add(endBlocks);

            endBlocks.Nodes.Add("End Portal Block");
            endBlocks.Nodes.Add("End Stone");
            endBlocks.Nodes.Add("Dragon Egg");
            
            TreeNode bricks = new TreeNode("Brick Types");
            blocks.Nodes.Add(bricks);

            bricks.Nodes.Add("Bricks");
            bricks.Nodes.Add("Stone Bricks");
            bricks.Nodes.Add("Nether Brick");

            TreeNode signs = new TreeNode("Signs");
            blocks.Nodes.Add(signs);

            signs.Nodes.Add("Wall Sign");
            signs.Nodes.Add("Standing Sign");

            TreeNode blocksMusic = new TreeNode("Music");
            blocks.Nodes.Add(blocksMusic);

            blocksMusic.Nodes.Add("Noteblock");
            blocksMusic.Nodes.Add("Jukebox");
            
            TreeNode misc = new TreeNode("Miscellaneous");
            blocks.Nodes.Add(misc);

            misc.Nodes.Add("Sponge");
            misc.Nodes.Add("Bed");
            misc.Nodes.Add("TNT");
            misc.Nodes.Add("Bookshelf");
            misc.Nodes.Add("Torch");
            misc.Nodes.Add("Monster Spawner");
            misc.Nodes.Add("Ladders");
            misc.Nodes.Add("Fence");
            misc.Nodes.Add("Fence Gate");
            misc.Nodes.Add("Cake");
            misc.Nodes.Add("Trapdoor");
            misc.Nodes.Add("Iron Bars");
            misc.Nodes.Add("Nether Brick Fence");
            misc.Nodes.Add("Tripwire Hook");
            misc.Nodes.Add("Tripwire");
            misc.Nodes.Add("Command Block");
            misc.Nodes.Add("Beacon");
            misc.Nodes.Add("Cobblestone Wall");
            misc.Nodes.Add("Flower Pot");
            misc.Nodes.Add("Destroy");

            //items
            TreeNode items = new TreeNode("Items");
            FrmMain.treeView.Nodes.Add(items);

            items.Nodes.Add("Iron Shovel");
            items.Nodes.Add("Iron Pickaxe");
            items.Nodes.Add("Iron Axe");
            items.Nodes.Add("Flint and Steel");
            items.Nodes.Add("Apple");
            items.Nodes.Add("Bow Standby");
            items.Nodes.Add("Bow Pulling 0");
            items.Nodes.Add("Bow Pulling 1");
            items.Nodes.Add("Bow Pulling 2");
            items.Nodes.Add("Arrow");
            items.Nodes.Add("Coal");
            items.Nodes.Add("Diamond");
            items.Nodes.Add("Iron Ingot");
            items.Nodes.Add("Gold Ingot");
            items.Nodes.Add("Iron Sword");
            items.Nodes.Add("Wooden Sword");
            items.Nodes.Add("Wooden Shovel");
            items.Nodes.Add("Wooden Pickaxe");
            items.Nodes.Add("Wooden Axe");
            items.Nodes.Add("Stone Sword");
            items.Nodes.Add("Stone Shovel");
            items.Nodes.Add("Stone Pickaxe");
            items.Nodes.Add("Stone Axe");
            items.Nodes.Add("Diamond Sword");
            items.Nodes.Add("Diamond Shovel");
            items.Nodes.Add("Diamond Pickaxe");
            items.Nodes.Add("Diamond Axe");
            items.Nodes.Add("Stick");
            items.Nodes.Add("Bowl");
            items.Nodes.Add("Mushroom Stew");
            items.Nodes.Add("Golden Sword");
            items.Nodes.Add("Golden Shovel");
            items.Nodes.Add("Golden Pickaxe");
            items.Nodes.Add("Golden Axe");
            items.Nodes.Add("String");
            items.Nodes.Add("Feather");
            items.Nodes.Add("Gunpowder");
            items.Nodes.Add("Wooden Hoe");
            items.Nodes.Add("Stone Hoe");
            items.Nodes.Add("Iron Hoe");
            items.Nodes.Add("Diamond Hoe");
            items.Nodes.Add("Gold Hoe");
            items.Nodes.Add("Wheat Seeds");
            items.Nodes.Add("Wheat");
            items.Nodes.Add("Bread");
            items.Nodes.Add("Leather Cap");
            items.Nodes.Add("Leather Tunic");
            items.Nodes.Add("Leather Pants");
            items.Nodes.Add("Leather Boots");
            items.Nodes.Add("Chain Helmet");
            items.Nodes.Add("Chain Chestplate");
            items.Nodes.Add("Chain Leggings");
            items.Nodes.Add("Chain Boots");
            items.Nodes.Add("Iron Helmet");
            items.Nodes.Add("Iron Chestplate");
            items.Nodes.Add("Iron Leggings");
            items.Nodes.Add("Iron Boots");
            items.Nodes.Add("Diamond Helmet");
            items.Nodes.Add("Diamond Chestplate");
            items.Nodes.Add("Diamond Leggings");
            items.Nodes.Add("Diamond Boots");
            items.Nodes.Add("Golden Helmet");
            items.Nodes.Add("Golden Chestplate");
            items.Nodes.Add("Golden Leggings");
            items.Nodes.Add("Golden Boots");
            items.Nodes.Add("Flint");
            items.Nodes.Add("Raw Porkchop");
            items.Nodes.Add("Cooked Porkchop");
            items.Nodes.Add("Painting");
            items.Nodes.Add("Golden Apple");
            items.Nodes.Add("Sign");
            items.Nodes.Add("Wooden Door");
            items.Nodes.Add("Bucket");
            items.Nodes.Add("Water Bucket");
            items.Nodes.Add("Lava Bucket");
            items.Nodes.Add("Minecart");
            items.Nodes.Add("Saddle");
            items.Nodes.Add("Iron Door");
            items.Nodes.Add("Redstone");
            items.Nodes.Add("Snowball");
            items.Nodes.Add("Boat");
            items.Nodes.Add("Leather");
            items.Nodes.Add("Milk");
            items.Nodes.Add("Brick");
            items.Nodes.Add("Clay");
            items.Nodes.Add("Sugar Cane");
            items.Nodes.Add("Paper");
            items.Nodes.Add("Book");
            items.Nodes.Add("Slimeball");
            items.Nodes.Add("Minecart with Chest");
            items.Nodes.Add("Minecart with Furnace");
            items.Nodes.Add("Egg");
            items.Nodes.Add("Compass");
            items.Nodes.Add("Fishing Rod");
            items.Nodes.Add("Clock");
            items.Nodes.Add("Glowstone Dust");
            items.Nodes.Add("Raw Clownfish");
            items.Nodes.Add("Raw Cod");
            items.Nodes.Add("Raw Pufferfish");
            items.Nodes.Add("Raw Salmon");
            items.Nodes.Add("Cooked Cod");
            items.Nodes.Add("Cooked Salmon");
            items.Nodes.Add("Dye");
            items.Nodes.Add("Bone");
            items.Nodes.Add("Sugar");
            items.Nodes.Add("Cake");
            items.Nodes.Add("Bed");
            items.Nodes.Add("Redstone Repeater");
            items.Nodes.Add("Cookie");
            items.Nodes.Add("Map Empty");
            items.Nodes.Add("Map Filled");
            items.Nodes.Add("Shears");
            items.Nodes.Add("Melon");
            items.Nodes.Add("Pumpkin Seeds");
            items.Nodes.Add("Melon Seeds");
            items.Nodes.Add("Raw Beef");
            items.Nodes.Add("Steak");
            items.Nodes.Add("Raw Chicken");
            items.Nodes.Add("Cooked Chicken");
            items.Nodes.Add("Rotten Flesh");
            items.Nodes.Add("Ender Pearl");
            items.Nodes.Add("Blaze Rod");
            items.Nodes.Add("Ghast Tear");
            items.Nodes.Add("Gold Nugget");
            items.Nodes.Add("Nether Wart");
            items.Nodes.Add("Potions");
            items.Nodes.Add("Glass Bottle");
            items.Nodes.Add("Spider Eye");
            items.Nodes.Add("Fermented Spider Eye");
            items.Nodes.Add("Blaze Powder");
            items.Nodes.Add("Magma Cream");
            items.Nodes.Add("Brewing Stand");
            items.Nodes.Add("Cauldron");
            items.Nodes.Add("Eye of Ender");
            items.Nodes.Add("Glistering Melon");
            items.Nodes.Add("Spawn Egg");
            items.Nodes.Add("Bottle o' Enchanting");
            items.Nodes.Add("Fire Charge");
            items.Nodes.Add("Book and Quill");
            items.Nodes.Add("Written Book");
            items.Nodes.Add("Emerald");
            items.Nodes.Add("Item Frame");
            items.Nodes.Add("Flower Pot");
            items.Nodes.Add("Carrot");
            items.Nodes.Add("Potato");
            items.Nodes.Add("Baked Potato");
            items.Nodes.Add("Poisonous Potato");
            items.Nodes.Add("Empty Map");
            items.Nodes.Add("Golden Carrot");
            items.Nodes.Add("Mob head");
            items.Nodes.Add("Creeper Skull");
            items.Nodes.Add("Skeleton Skull");
            items.Nodes.Add("Steve Skull");
            items.Nodes.Add("Wither Skull");
            items.Nodes.Add("Zombie Skull");
            items.Nodes.Add("Carrot on a Stick");
            items.Nodes.Add("Nether Star");
            items.Nodes.Add("Pumpkin Pie");
            items.Nodes.Add("Firework Rocket");
            items.Nodes.Add("Firework Star");
            items.Nodes.Add("Enchanted Book");
            items.Nodes.Add("Nether Brick");
            items.Nodes.Add("Nether Quartz");
            items.Nodes.Add("Minecart with TNT");
            items.Nodes.Add("Minecart with Hopper");
            items.Nodes.Add("Iron Horse Armor");
            items.Nodes.Add("Gold Horse Armor");
            items.Nodes.Add("Diamond Horse Armor");
            items.Nodes.Add("Lead");
            items.Nodes.Add("Name Tag");
            items.Nodes.Add("Minecart with Command Block");
            items.Nodes.Add("13 Disc");
            items.Nodes.Add("Cat Disc");
            items.Nodes.Add("Blocks Disc");
            items.Nodes.Add("Chirp Disc");
            items.Nodes.Add("Far Disc");
            items.Nodes.Add("Mall Disc");
            items.Nodes.Add("Mellohi Disc");
            items.Nodes.Add("Stal Disc");
            items.Nodes.Add("Strad Disc");
            items.Nodes.Add("Ward Disc");
            items.Nodes.Add("11 Disc");
            items.Nodes.Add("Wait Disc");

            //sounds
            TreeNode sounds = new TreeNode("Sounds");
            FrmMain.treeView.Nodes.Add(sounds);

            //ambient
            TreeNode ambient = new TreeNode("Ambient");
            sounds.Nodes.Add(ambient);

            TreeNode cave = new TreeNode("Cave");
            ambient.Nodes.Add(cave);

            for (int a = 1; a <= 13; a++)
            {
                cave.Nodes.Add("Cave " + a.ToString());
            }

            TreeNode weather = new TreeNode("Weather");
            ambient.Nodes.Add(weather);

            weather.Nodes.Add("Weather Rain 1");
            weather.Nodes.Add("Weather Rain 2");
            weather.Nodes.Add("Weather Rain 3");
            weather.Nodes.Add("Weather Rain 4");
            weather.Nodes.Add("Weather Thunder 1");
            weather.Nodes.Add("Weather Thunder 2");
            weather.Nodes.Add("Weather Thunder 3");

            //damage
            TreeNode damage = new TreeNode("Damage");
            sounds.Nodes.Add(damage);

            damage.Nodes.Add("Damage Fall Big");
            damage.Nodes.Add("Damage Fall Small");
            damage.Nodes.Add("Damage Hit 1");
            damage.Nodes.Add("Damage Hit 2");
            damage.Nodes.Add("Damage Hit 3");

            //dig
            TreeNode dig = new TreeNode("Dig");
            sounds.Nodes.Add(dig);

            for (int a = 1; a <= 4; a++)
            {
                dig.Nodes.Add("Dig Cloth " + a.ToString());
            }

            for (int a = 1; a <= 4; a++)
            {
                dig.Nodes.Add("Dig Grass " + a.ToString());
            }

            for (int a = 1; a <= 4; a++)
            {
                dig.Nodes.Add("Dig Gravel " + a.ToString());
            }

            for (int a = 1; a <= 4; a++)
            {
                dig.Nodes.Add("Dig Sand " + a.ToString());
            }

            for (int a = 1; a <= 4; a++)
            {
                dig.Nodes.Add("Dig Snow " + a.ToString());
            }

            for (int a = 1; a <= 4; a++)
            {
                dig.Nodes.Add("Dig Stone " + a.ToString());
            }

            for (int a = 1; a <= 4; a++)
            {
                dig.Nodes.Add("Dig Wood " + a.ToString());
            }

            //fire
            TreeNode fire = new TreeNode("Fire");
            sounds.Nodes.Add(fire);

            fire.Nodes.Add("Fire Burning");
            fire.Nodes.Add("Fire Ignite");

            //fireworks
            TreeNode fireworks = new TreeNode("Fireworks");
            sounds.Nodes.Add(fireworks);

            fireworks.Nodes.Add("Fireworks Blast");
            fireworks.Nodes.Add("Fireworks Blast Far");
            fireworks.Nodes.Add("Fireworks Large Blast");
            fireworks.Nodes.Add("Fireworks Large Blast Far");
            fireworks.Nodes.Add("Fireworks Launch");
            fireworks.Nodes.Add("Fireworks Twinkle");
            fireworks.Nodes.Add("Fireworks Twinkle Far");

            //liquids
            TreeNode liquid = new TreeNode("Liquid");
            sounds.Nodes.Add(liquid);

            liquid.Nodes.Add("Liquid Lava");
            liquid.Nodes.Add("Liquid Lava Pop");
            liquid.Nodes.Add("Liquid Splash 1");
            liquid.Nodes.Add("Liquid Splash 2");

            for (int a = 1; a <= 4; a++)
            {
                liquid.Nodes.Add("Swim " + a.ToString());
            }

            liquid.Nodes.Add("Swim Water");

            //minecart
            TreeNode minecart = new TreeNode("Minecart");
            sounds.Nodes.Add(minecart);

            minecart.Nodes.Add("Minecart Base");
            minecart.Nodes.Add("Minecart Inside");

            //mob
            TreeNode mob = new TreeNode("Mob");
            sounds.Nodes.Add(mob);

            TreeNode bat = new TreeNode("Bat");
            mob.Nodes.Add(bat);

            bat.Nodes.Add("Bat Death");
            bat.Nodes.Add("Bat Hurt 1");
            bat.Nodes.Add("Bat Hurt 2");
            bat.Nodes.Add("Bat Hurt 3");
            bat.Nodes.Add("Bat Hurt 4");
            bat.Nodes.Add("Bat Idle 1");
            bat.Nodes.Add("Bat Idle 2");
            bat.Nodes.Add("Bat Idle 3");
            bat.Nodes.Add("Bat Idle 4");
            bat.Nodes.Add("Bat Loop");
            bat.Nodes.Add("Bat Takeoff");

            TreeNode blaze = new TreeNode("Blaze");
            mob.Nodes.Add(blaze);

            blaze.Nodes.Add("Blaze Breathe 1");
            blaze.Nodes.Add("Blaze Breathe 2");
            blaze.Nodes.Add("Blaze Breathe 3");
            blaze.Nodes.Add("Blaze Breathe 4");
            blaze.Nodes.Add("Blaze Death");
            blaze.Nodes.Add("Blaze Hit 1");
            blaze.Nodes.Add("Blaze Hit 2");
            blaze.Nodes.Add("Blaze Hit 3");
            blaze.Nodes.Add("Blaze Hit 4");

            TreeNode cat = new TreeNode("Cat");
            mob.Nodes.Add(cat);

            cat.Nodes.Add("Cat Hiss 1");
            cat.Nodes.Add("Cat Hiss 2");
            cat.Nodes.Add("Cat Hiss 3");
            cat.Nodes.Add("Cat Hit 1");
            cat.Nodes.Add("Cat Hit 2");
            cat.Nodes.Add("Cat Hit 3");
            cat.Nodes.Add("Cat Meow 1");
            cat.Nodes.Add("Cat Meow 2");
            cat.Nodes.Add("Cat Meow 3");
            cat.Nodes.Add("Cat Meow 4");
            cat.Nodes.Add("Cat Purr 1");
            cat.Nodes.Add("Cat Purr 2");
            cat.Nodes.Add("Cat Purr 3");
            cat.Nodes.Add("Cat Purreow 1");
            cat.Nodes.Add("Cat Purreow 2");

            TreeNode chicken = new TreeNode("Chicken");
            mob.Nodes.Add(chicken);

            chicken.Nodes.Add("Chicken Hurt 1");
            chicken.Nodes.Add("Chicken Hurt 2");
            chicken.Nodes.Add("Chicken Plop");
            chicken.Nodes.Add("Chicken Say 1");
            chicken.Nodes.Add("Chicken Say 2");
            chicken.Nodes.Add("Chicken Say 3");
            chicken.Nodes.Add("Chicken Step 1");
            chicken.Nodes.Add("Chicken Step 2");

            TreeNode cow = new TreeNode("Cow");
            mob.Nodes.Add(cow);

            cow.Nodes.Add("Cow Hurt 1");
            cow.Nodes.Add("Cow Hurt 2");
            cow.Nodes.Add("Cow Hurt 3");
            cow.Nodes.Add("Cow Say 1");
            cow.Nodes.Add("Cow Say 2");
            cow.Nodes.Add("Cow Say 3");
            cow.Nodes.Add("Cow Say 4");
            cow.Nodes.Add("Cow Step 1");
            cow.Nodes.Add("Cow Step 2");
            cow.Nodes.Add("Cow Step 3");
            cow.Nodes.Add("Cow Step 4");

            TreeNode creeper = new TreeNode("Creeper");
            mob.Nodes.Add(creeper);

            creeper.Nodes.Add("Creeper Death");
            creeper.Nodes.Add("Creeper Say 1");
            creeper.Nodes.Add("Creeper Say 2");
            creeper.Nodes.Add("Creeper Say 3");
            creeper.Nodes.Add("Creeper Say 4");

            TreeNode enderDragon = new TreeNode("Ender Dragon");
            mob.Nodes.Add(enderDragon);

            enderDragon.Nodes.Add("Ender Dragon End");
            enderDragon.Nodes.Add("Ender Dragon Growl 1");
            enderDragon.Nodes.Add("Ender Dragon Growl 2");
            enderDragon.Nodes.Add("Ender Dragon Growl 3");
            enderDragon.Nodes.Add("Ender Dragon Growl 4");
            enderDragon.Nodes.Add("Ender Dragon Hit 1");
            enderDragon.Nodes.Add("Ender Dragon Hit 2");
            enderDragon.Nodes.Add("Ender Dragon Hit 3");
            enderDragon.Nodes.Add("Ender Dragon Hit 4");
            enderDragon.Nodes.Add("Ender Dragon Wings 1");
            enderDragon.Nodes.Add("Ender Dragon Wings 2");
            enderDragon.Nodes.Add("Ender Dragon Wings 3");
            enderDragon.Nodes.Add("Ender Dragon Wings 4");
            enderDragon.Nodes.Add("Ender Dragon Wings 5");
            enderDragon.Nodes.Add("Ender Dragon Wings 6");

            TreeNode enderMen = new TreeNode("Ender Men");
            mob.Nodes.Add(enderMen);

            enderMen.Nodes.Add("Ender Men Death");
            enderMen.Nodes.Add("Ender Men Hit 1");
            enderMen.Nodes.Add("Ender Men Hit 2");
            enderMen.Nodes.Add("Ender Men Hit 3");
            enderMen.Nodes.Add("Ender Men Hit 4");
            enderMen.Nodes.Add("Ender Men Idle 1");
            enderMen.Nodes.Add("Ender Men Idle 2");
            enderMen.Nodes.Add("Ender Men Idle 3");
            enderMen.Nodes.Add("Ender Men Idle 4");
            enderMen.Nodes.Add("Ender Men Idle 5");
            enderMen.Nodes.Add("Ender Men Portal");
            enderMen.Nodes.Add("Ender Men Portal 2");
            enderMen.Nodes.Add("Ender Men Scream 1");
            enderMen.Nodes.Add("Ender Men Scream 2");
            enderMen.Nodes.Add("Ender Men Scream 3");
            enderMen.Nodes.Add("Ender Men Scream 4");
            enderMen.Nodes.Add("Ender Men Stare");

            TreeNode ghast = new TreeNode("Ghast");
            mob.Nodes.Add(ghast);

            ghast.Nodes.Add("Ghast Affectionate Scream");
            ghast.Nodes.Add("Ghast Charge");
            ghast.Nodes.Add("Ghast Death");
            ghast.Nodes.Add("Ghast Fireball");
            ghast.Nodes.Add("Ghast Moan 1");
            ghast.Nodes.Add("Ghast Moan 2");
            ghast.Nodes.Add("Ghast Moan 3");
            ghast.Nodes.Add("Ghast Moan 4");
            ghast.Nodes.Add("Ghast Moan 5");
            ghast.Nodes.Add("Ghast Moan 6");
            ghast.Nodes.Add("Ghast Moan 7");
            ghast.Nodes.Add("Ghast Scream 1");
            ghast.Nodes.Add("Ghast Scream 2");
            ghast.Nodes.Add("Ghast Scream 3");
            ghast.Nodes.Add("Ghast Scream 4");
            ghast.Nodes.Add("Ghast Scream 5");

            TreeNode horse = new TreeNode("Horse");
            mob.Nodes.Add(horse);

            horse.Nodes.Add("Horse Angry");
            horse.Nodes.Add("Horse Armor");
            horse.Nodes.Add("Horse Breathe 1");
            horse.Nodes.Add("Horse Breathe 2");
            horse.Nodes.Add("Horse Breathe 3");
            horse.Nodes.Add("Horse Death");
            horse.Nodes.Add("Horse Gallop 1");
            horse.Nodes.Add("Horse Gallop 2");
            horse.Nodes.Add("Horse Gallop 3");
            horse.Nodes.Add("Horse Gallop 4");
            horse.Nodes.Add("Horse Hit 1");
            horse.Nodes.Add("Horse Hit 2");
            horse.Nodes.Add("Horse Hit 3");
            horse.Nodes.Add("Horse Hit 4");
            horse.Nodes.Add("Horse Idle 1");
            horse.Nodes.Add("Horse Idle 2");
            horse.Nodes.Add("Horse Idle 3");
            horse.Nodes.Add("Horse Jump");
            horse.Nodes.Add("Horse Land");
            horse.Nodes.Add("Horse Leather");
            horse.Nodes.Add("Horse Soft 1");
            horse.Nodes.Add("Horse Soft 2");
            horse.Nodes.Add("Horse Soft 3");
            horse.Nodes.Add("Horse Soft 4");
            horse.Nodes.Add("Horse Soft 5");
            horse.Nodes.Add("Horse Soft 6");
            horse.Nodes.Add("Horse Wood 1");
            horse.Nodes.Add("Horse Wood 2");
            horse.Nodes.Add("Horse Wood 3");
            horse.Nodes.Add("Horse Wood 4");
            horse.Nodes.Add("Horse Wood 5");
            horse.Nodes.Add("Horse Wood 6");

            TreeNode donkey = new TreeNode("Donkey");
            horse.Nodes.Add(donkey);

            donkey.Nodes.Add("Donkey Angry 1");
            donkey.Nodes.Add("Donkey Angry 2");
            donkey.Nodes.Add("Donkey Death");
            donkey.Nodes.Add("Donkey Hit 1");
            donkey.Nodes.Add("Donkey Hit 2");
            donkey.Nodes.Add("Donkey Hit 3");
            donkey.Nodes.Add("Donkey Idle 1");
            donkey.Nodes.Add("Donkey Idle 2");
            donkey.Nodes.Add("Donkey Idle 3");

            TreeNode skeletonHorse = new TreeNode("Skeleton Horse");
            horse.Nodes.Add(skeletonHorse);

            skeletonHorse.Nodes.Add("Skeleton Horse Death");
            skeletonHorse.Nodes.Add("Skeleton Horse Hit 1");
            skeletonHorse.Nodes.Add("Skeleton Horse Hit 2");
            skeletonHorse.Nodes.Add("Skeleton Horse Hit 3");
            skeletonHorse.Nodes.Add("Skeleton Horse Hit 4");
            skeletonHorse.Nodes.Add("Skeleton Horse Idle 1");
            skeletonHorse.Nodes.Add("Skeleton Horse Idle 2");
            skeletonHorse.Nodes.Add("Skeleton Horse Idle 3");

            TreeNode zombieHorse = new TreeNode("Zombie Horse");
            horse.Nodes.Add(zombieHorse);

            zombieHorse.Nodes.Add("Zombie Horse Death");
            zombieHorse.Nodes.Add("Zombie Horse Hit 1");
            zombieHorse.Nodes.Add("Zombie Horse Hit 2");
            zombieHorse.Nodes.Add("Zombie Horse Hit 3");
            zombieHorse.Nodes.Add("Zombie Horse Hit 4");
            zombieHorse.Nodes.Add("Zombie Horse Idle 1");
            zombieHorse.Nodes.Add("Zombie Horse Idle 2");
            zombieHorse.Nodes.Add("Zombie Horse Idle 3");

            TreeNode ironGolem = new TreeNode("Iron Golem");
            mob.Nodes.Add(ironGolem);

            ironGolem.Nodes.Add("Iron Golem Death");
            ironGolem.Nodes.Add("Iron Golem Hit 1");
            ironGolem.Nodes.Add("Iron Golem Hit 2");
            ironGolem.Nodes.Add("Iron Golem Hit 3");
            ironGolem.Nodes.Add("Iron Golem Hit 4");
            ironGolem.Nodes.Add("Iron Golem Throw");
            ironGolem.Nodes.Add("Iron Golem Walk 1");
            ironGolem.Nodes.Add("Iron Golem Walk 2");
            ironGolem.Nodes.Add("Iron Golem Walk 3");
            ironGolem.Nodes.Add("Iron Golem Walk 4");

            TreeNode magmaCube = new TreeNode("Magma Cube");
            mob.Nodes.Add(magmaCube);

            magmaCube.Nodes.Add("Magma Cube Big 1");
            magmaCube.Nodes.Add("Magma Cube Big 2");
            magmaCube.Nodes.Add("Magma Cube Big 3");
            magmaCube.Nodes.Add("Magma Cube Big 4");
            magmaCube.Nodes.Add("Magma Cube Jump 1");
            magmaCube.Nodes.Add("Magma Cube Jump 2");
            magmaCube.Nodes.Add("Magma Cube Jump 3");
            magmaCube.Nodes.Add("Magma Cube Jump 4");
            magmaCube.Nodes.Add("Magma Cube Small 1");
            magmaCube.Nodes.Add("Magma Cube Small 2");
            magmaCube.Nodes.Add("Magma Cube Small 3");
            magmaCube.Nodes.Add("Magma Cube Small 4");
            magmaCube.Nodes.Add("Magma Cube Small 5");

            TreeNode pig = new TreeNode("Pig");
            mob.Nodes.Add(pig);

            pig.Nodes.Add("Pig Death");
            pig.Nodes.Add("Pig Say 1");
            pig.Nodes.Add("Pig Say 2");
            pig.Nodes.Add("Pig Say 3");
            pig.Nodes.Add("Pig Step 1");
            pig.Nodes.Add("Pig Step 2");
            pig.Nodes.Add("Pig Step 3");
            pig.Nodes.Add("Pig Step 4");
            pig.Nodes.Add("Pig Step 5");

            TreeNode sheep = new TreeNode("Sheep");
            mob.Nodes.Add(sheep);

            sheep.Nodes.Add("Sheep Say 1");
            sheep.Nodes.Add("Sheep Say 2");
            sheep.Nodes.Add("Sheep Say 3");
            sheep.Nodes.Add("Sheep Shear");
            sheep.Nodes.Add("Sheep Step 1");
            sheep.Nodes.Add("Sheep Step 2");
            sheep.Nodes.Add("Sheep Step 3");
            sheep.Nodes.Add("Sheep Step 4");
            sheep.Nodes.Add("Sheep Step 5");

            TreeNode silverFish = new TreeNode("Silver Fish");
            mob.Nodes.Add(silverFish);

            silverFish.Nodes.Add("Silver Fish Hit 1");
            silverFish.Nodes.Add("Silver Fish Hit 2");
            silverFish.Nodes.Add("Silver Fish Hit 3");
            silverFish.Nodes.Add("Silver Fish Kill");
            silverFish.Nodes.Add("Silver Fish Say 1");
            silverFish.Nodes.Add("Silver Fish Say 2");
            silverFish.Nodes.Add("Silver Fish Say 3");
            silverFish.Nodes.Add("Silver Fish Say 4");
            silverFish.Nodes.Add("Silver Fish Step 1");
            silverFish.Nodes.Add("Silver Fish Step 2");
            silverFish.Nodes.Add("Silver Fish Step 3");
            silverFish.Nodes.Add("Silver Fish Step 4");

            TreeNode skeleton = new TreeNode("Skeleton");
            mob.Nodes.Add(skeleton);

            skeleton.Nodes.Add("Skeleton Death");
            skeleton.Nodes.Add("Skeleton Hurt 1");
            skeleton.Nodes.Add("Skeleton Hurt 2");
            skeleton.Nodes.Add("Skeleton Hurt 3");
            skeleton.Nodes.Add("Skeleton Hurt 4");
            skeleton.Nodes.Add("Skeleton Say 1");
            skeleton.Nodes.Add("Skeleton Say 2");
            skeleton.Nodes.Add("Skeleton Say 3");
            skeleton.Nodes.Add("Skeleton Step 1");
            skeleton.Nodes.Add("Skeleton Step 2");
            skeleton.Nodes.Add("Skeleton Step 3");
            skeleton.Nodes.Add("Skeleton Step 4");

            TreeNode slime = new TreeNode("Slime");
            mob.Nodes.Add(slime);

            slime.Nodes.Add("Slime Attack 1");
            slime.Nodes.Add("Slime Attack 2");
            slime.Nodes.Add("Slime Big 1");
            slime.Nodes.Add("Slime Big 2");
            slime.Nodes.Add("Slime Big 3");
            slime.Nodes.Add("Slime Big 4");
            slime.Nodes.Add("Slime Small 1");
            slime.Nodes.Add("Slime Small 2");
            slime.Nodes.Add("Slime Small 3");
            slime.Nodes.Add("Slime Small 4");
            slime.Nodes.Add("Slime Small 5");

            TreeNode spider = new TreeNode("Spider");
            mob.Nodes.Add(spider);

            spider.Nodes.Add("Spider Death");
            spider.Nodes.Add("Spider Say 1");
            spider.Nodes.Add("Spider Say 2");
            spider.Nodes.Add("Spider Say 3");
            spider.Nodes.Add("Spider Say 4");
            spider.Nodes.Add("Spider Step 1");
            spider.Nodes.Add("Spider Step 2");
            spider.Nodes.Add("Spider Step 3");
            spider.Nodes.Add("Spider Step 4");

            TreeNode villager = new TreeNode("Villager");
            mob.Nodes.Add(villager);

            villager.Nodes.Add("Villager Death");
            villager.Nodes.Add("Villager Haggle 1");
            villager.Nodes.Add("Villager Haggle 2");
            villager.Nodes.Add("Villager Haggle 3");
            villager.Nodes.Add("Villager Hit 1");
            villager.Nodes.Add("Villager Hit 2");
            villager.Nodes.Add("Villager Hit 3");
            villager.Nodes.Add("Villager Hit 4");
            villager.Nodes.Add("Villager Idle 1");
            villager.Nodes.Add("Villager Idle 2");
            villager.Nodes.Add("Villager Idle 3");
            villager.Nodes.Add("Villager No 1");
            villager.Nodes.Add("Villager No 2");
            villager.Nodes.Add("Villager No 3");
            villager.Nodes.Add("Villager Yes 1");
            villager.Nodes.Add("Villager Yes 2");
            villager.Nodes.Add("Villager Yes 3");

            TreeNode wither = new TreeNode("Wither");
            mob.Nodes.Add(wither);

            wither.Nodes.Add("Wither Death");
            wither.Nodes.Add("Wither Hurt 1");
            wither.Nodes.Add("Wither Hurt 2");
            wither.Nodes.Add("Wither Hurt 3");
            wither.Nodes.Add("Wither Hurt 4");
            wither.Nodes.Add("Wither Idle 1");
            wither.Nodes.Add("Wither Idle 2");
            wither.Nodes.Add("Wither Idle 3");
            wither.Nodes.Add("Wither Idle 4");
            wither.Nodes.Add("Wither Shoot");
            wither.Nodes.Add("Wither Spawn");

            TreeNode wolf = new TreeNode("Wolf");
            mob.Nodes.Add(wolf);

            wolf.Nodes.Add("Wolf Bark 1");
            wolf.Nodes.Add("Wolf Bark 2");
            wolf.Nodes.Add("Wolf Bark 3");
            wolf.Nodes.Add("Wolf Death");
            wolf.Nodes.Add("Wolf Growl 1");
            wolf.Nodes.Add("Wolf Growl 2");
            wolf.Nodes.Add("Wolf Growl 3");
            wolf.Nodes.Add("Wolf Howl 1");
            wolf.Nodes.Add("Wolf Howl 2");
            wolf.Nodes.Add("Wolf Hurt 1");
            wolf.Nodes.Add("Wolf Hurt 2");
            wolf.Nodes.Add("Wolf Hurt 3");
            wolf.Nodes.Add("Wolf Panting");
            wolf.Nodes.Add("Wolf Shake");
            wolf.Nodes.Add("Wolf Step 1");
            wolf.Nodes.Add("Wolf Step 2");
            wolf.Nodes.Add("Wolf Step 3");
            wolf.Nodes.Add("Wolf Step 4");
            wolf.Nodes.Add("Wolf Step 5");
            wolf.Nodes.Add("Wolf Whine");

            TreeNode zombie = new TreeNode("Zombie");
            mob.Nodes.Add(zombie);

            zombie.Nodes.Add("Zombie Death");
            zombie.Nodes.Add("Zombie Hurt 1");
            zombie.Nodes.Add("Zombie Hurt 2");
            zombie.Nodes.Add("Zombie Infect");
            zombie.Nodes.Add("Zombie Metal 1");
            zombie.Nodes.Add("Zombie Metal 2");
            zombie.Nodes.Add("Zombie Metal 3");
            zombie.Nodes.Add("Zombie Remedy");
            zombie.Nodes.Add("Zombie Say 1");
            zombie.Nodes.Add("Zombie Say 2");
            zombie.Nodes.Add("Zombie Say 3");
            zombie.Nodes.Add("Zombie Step 1");
            zombie.Nodes.Add("Zombie Step 2");
            zombie.Nodes.Add("Zombie Step 3");
            zombie.Nodes.Add("Zombie Step 4");
            zombie.Nodes.Add("Zombie Step 5");
            zombie.Nodes.Add("Zombie Unfect");
            zombie.Nodes.Add("Zombie Wood 1");
            zombie.Nodes.Add("Zombie Wood 2");
            zombie.Nodes.Add("Zombie Wood 3");
            zombie.Nodes.Add("Zombie Wood 4");
            zombie.Nodes.Add("Zombie Wood Break");

            TreeNode zombiePigmen = new TreeNode("Zombie Pigmen");
            mob.Nodes.Add(zombiePigmen);

            zombiePigmen.Nodes.Add("Zombie Pigmen 1");
            zombiePigmen.Nodes.Add("Zombie Pigmen 2");
            zombiePigmen.Nodes.Add("Zombie Pigmen 3");
            zombiePigmen.Nodes.Add("Zombie Pigmen 4");
            zombiePigmen.Nodes.Add("Zombie Pigmen Angry 1");
            zombiePigmen.Nodes.Add("Zombie Pigmen Angry 2");
            zombiePigmen.Nodes.Add("Zombie Pigmen Angry 3");
            zombiePigmen.Nodes.Add("Zombie Pigmen Angry 4");
            zombiePigmen.Nodes.Add("Zombie Pigmen Death");
            zombiePigmen.Nodes.Add("Zombie Pigmen Hurt 1");
            zombiePigmen.Nodes.Add("Zombie Pigmen Hurt 2");

            //music
            TreeNode soundsMusic = new TreeNode("Music");
            sounds.Nodes.Add(soundsMusic);

            TreeNode game = new TreeNode("Game");
            soundsMusic.Nodes.Add(game);

            for (int a = 1; a <= 3; a++)
            {
                game.Nodes.Add("Game Music Calm " + a.ToString());
            }

            for (int a = 1; a <= 4; a++)
            {
                game.Nodes.Add("Game Music Hal " + a.ToString());
            }

            game.Nodes.Add("Game Music Nuance 1");
            game.Nodes.Add("Game Music Nuance 2");

            for (int a = 1; a <= 3; a++)
            {
                game.Nodes.Add("Game Music Piano " + a.ToString());
            }

            TreeNode creative = new TreeNode("Creative");
            game.Nodes.Add(creative);

            for (int a = 1; a <= 6; a++)
            {
                creative.Nodes.Add("Creative " + a.ToString());
            }

            TreeNode end = new TreeNode("End");
            game.Nodes.Add(end);

            end.Nodes.Add("End Music Boss");
            end.Nodes.Add("End Music Credits");
            end.Nodes.Add("End Music The End");

            TreeNode nether = new TreeNode("Nether");
            game.Nodes.Add(nether);

            for (int a = 1; a <= 4; a++)
            {
                nether.Nodes.Add("Nether " + a.ToString());
            }

            TreeNode menu = new TreeNode("Menu");
            soundsMusic.Nodes.Add(menu);

            for (int a = 1; a <= 4; a++)
            {
                menu.Nodes.Add("Menu " + a.ToString());
            }

            //note
            TreeNode note = new TreeNode("Note");
            sounds.Nodes.Add(note);

            note.Nodes.Add("Note Bass");
            note.Nodes.Add("Note Bass Attack");
            note.Nodes.Add("Note BD");
            note.Nodes.Add("Note Harp");
            note.Nodes.Add("Note Hat");
            note.Nodes.Add("Note Pling");
            note.Nodes.Add("Note Snare");

            //portal
            TreeNode portal = new TreeNode("Portal");
            sounds.Nodes.Add(portal);

            portal.Nodes.Add("Portal Ambient");
            portal.Nodes.Add("Portal Travel");
            portal.Nodes.Add("Portal Trigger");

            //random
            TreeNode random = new TreeNode("Random");
            sounds.Nodes.Add(random);

            random.Nodes.Add("Anvil Break");
            random.Nodes.Add("Anvil Land");
            random.Nodes.Add("Anvil Use");
            random.Nodes.Add("Bow");
            random.Nodes.Add("Bow Hit 1");
            random.Nodes.Add("Bow Hit 2");
            random.Nodes.Add("Bow Hit 3");
            random.Nodes.Add("Bow Hit 4");
            random.Nodes.Add("Break");
            random.Nodes.Add("Breath");
            random.Nodes.Add("Burp");
            random.Nodes.Add("Chest Closed");
            random.Nodes.Add("Chest Open");
            random.Nodes.Add("Classic Hurt");
            random.Nodes.Add("Click");
            random.Nodes.Add("Door Close");
            random.Nodes.Add("Door Open");
            random.Nodes.Add("Drink");
            random.Nodes.Add("Eat 1");
            random.Nodes.Add("Eat 2");
            random.Nodes.Add("Eat 3");
            random.Nodes.Add("Explode 1");
            random.Nodes.Add("Explode 2");
            random.Nodes.Add("Explode 3");
            random.Nodes.Add("Explode 4");
            random.Nodes.Add("Fizz");
            random.Nodes.Add("Fuse");
            random.Nodes.Add("Glass 1");
            random.Nodes.Add("Glass 2");
            random.Nodes.Add("Glass 3");
            random.Nodes.Add("Level Up");
            random.Nodes.Add("Orb");
            random.Nodes.Add("Pop");
            random.Nodes.Add("Splash");
            random.Nodes.Add("Successful Hit");
            random.Nodes.Add("Wood Click");

            //records
            TreeNode records = new TreeNode("Records");
            sounds.Nodes.Add(records);

            records.Nodes.Add("Records 11");
            records.Nodes.Add("Records 13");
            records.Nodes.Add("Records Blocks");
            records.Nodes.Add("Records Cat");
            records.Nodes.Add("Records Chirp");
            records.Nodes.Add("Records Far");
            records.Nodes.Add("Records Mall");
            records.Nodes.Add("Records Mellohi");
            records.Nodes.Add("Records Stal");
            records.Nodes.Add("Records Strad");
            records.Nodes.Add("Records Wait");
            records.Nodes.Add("Records Ward");

            //step
            TreeNode step = new TreeNode("Step");
            sounds.Nodes.Add(step);

            for (int a = 1; a <= 4; a++)
            {
                step.Nodes.Add("Cloth Step " + a.ToString());
            }

            for (int a = 1; a <= 6; a++)
            {
                step.Nodes.Add("Grass Step " + a.ToString());
            }

            for (int a = 1; a <= 4; a++)
            {
                step.Nodes.Add("Gravel Step " + a.ToString());
            }

            for (int a = 1; a <= 5; a++)
            {
                step.Nodes.Add("Ladder Step " + a.ToString());
            }

            for (int a = 1; a <= 5; a++)
            {
                step.Nodes.Add("Sand Step " + a.ToString());
            }

            for (int a = 1; a <= 4; a++)
            {
                step.Nodes.Add("Snow Step " + a.ToString());
            }

            for (int a = 1; a <= 6; a++)
            {
                step.Nodes.Add("Stone Step " + a.ToString());
            }

            for (int a = 1; a <= 6; a++)
            {
                step.Nodes.Add("Wood Step " + a.ToString());
            }

            //tile
            TreeNode tile = new TreeNode("Tile");
            sounds.Nodes.Add(tile);

            TreeNode piston = new TreeNode("Piston");
            tile.Nodes.Add(piston);

            piston.Nodes.Add("Piston In");
            piston.Nodes.Add("Piston Out");
            
            FrmMain.treeView.ExpandAll();

            foreach (TreeNode node in FrmMain.treeView.Nodes)
            {
                if (node.Text == "Blocks")
                {
                    checkAll(node);
                }
            }
        }

        public static void checkAll(TreeNode node)
        {
            node.Checked = true;

            foreach (TreeNode currentNode in node.Nodes)
            {
                checkAll(currentNode);
            }
        }

        public static void saveChanges(FrmMain frmMain)
        {
            if (FrmMain.extractJarOption == "0")
            {
                FrmJarExtractOrganise frmJarExtractOrganise = new FrmJarExtractOrganise();
                frmJarExtractOrganise.ShowDialog();
            }
            else if (FrmMain.extractJarOption == "1")
            {
                FrmMain.copyFileRecursively(FrmMain.extractedJarPath + "\\assets\\minecraft\\textures",
                    FrmMain.directory + "\\assets\\minecraft\\textures");
            }

            if (String.IsNullOrEmpty(FrmMain.minecraftPath) ||
                !Directory.Exists(FrmMain.minecraftPath))
            {
                MessageBox.Show("Minecraft folder not found. Go to the settings tab, locate your minecraft folder and " +
                    "set it there", "Minecraft Texture Studio");
                return;
            }

            FrmProcessChanges frmProcessChanges = new FrmProcessChanges(frmMain);
            frmProcessChanges.ShowDialog();
        }

        private delegate void LoadResourcePackDelegate();

        public static void loadResourcePack()
        {
            try
            {
                if (FrmMain.treeView.InvokeRequired)
                {
                    FrmMain.treeView.Invoke(new LoadResourcePackDelegate(loadResourcePack));
                }
                else
                {
                    foreach (TreeNode node in FrmMain.treeView.Nodes)
                    {
                        uncheckAll(node);
                    }

                    //check blocks
                    foreach (string blockName in FrmMain.blocks.Keys)
                    {
                        foreach (TreeNode node in FrmMain.treeView.Nodes)
                        {
                            if (node.Text == "Blocks")
                            {
                                checkBlockName(node, blockName);
                            }
                        }
                    }

                    //check sounds
                    foreach (string soundName in FrmMain.soundList)
                    {
                        foreach (TreeNode node in FrmMain.treeView.Nodes)
                        {
                            if (node.Text == "Sounds")
                            {
                                checkSoundName(node, soundName);
                            }
                        }
                    }

                    foreach (TreeNode node in FrmMain.treeView.Nodes)
                    {
                        areChildrenChecked(node);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured loading resource pack: " + exception.Message);
            }
        }

        public static bool areChildrenChecked(TreeNode node)
        {
            bool allChecked = true;

            foreach (TreeNode currentNode in node.Nodes)
            {
                bool result = areChildrenChecked(currentNode);
                if (!result)
                {
                    allChecked = false;
                }
            }

            if (node.Nodes.Count == 0)
            {
                allChecked = node.Checked;
            }

            if (allChecked)
            {
                node.Checked = true;
            }

            return allChecked;
        }

        public static void checkBlockName(TreeNode node, string blockName)
        {
            if (node.Text == blockName)
            {
                node.Checked = true;
            }

            foreach (TreeNode currentNode in node.Nodes)
            {
                checkBlockName(currentNode, blockName);
            }
        }

        public static void checkSoundName(TreeNode node, string soundName)
        {
            if (node.Text == soundName)
            {
                node.Checked = true;
            }

            foreach (TreeNode currentNode in node.Nodes)
            {
                checkSoundName(currentNode, soundName);
            }
        }

        public static void checkItemName(TreeNode node, string itemName)
        {
            if (node.Text == itemName)
            {
                node.Checked = true;
            }

            foreach (TreeNode currentNode in node.Nodes)
            {
                checkItemName(currentNode, itemName);
            }
        }

        public static void uncheckAll(TreeNode node)
        {
            node.Checked = false;

            foreach (TreeNode currentNode in node.Nodes)
            {
                uncheckAll(currentNode);
            }
        }

        public static void checkBlockNode(TreeNode node)
        {
            if (node.Nodes.Count == 0 && node.Checked)
            {
                selectedTextures.Add(node.Text);
            }
            else
            {
                foreach (TreeNode currentNode in node.Nodes)
                {
                    checkBlockNode(currentNode);
                }
            }
        }

        public static void checkSoundNode(TreeNode node)
        {
            if (node.Nodes.Count == 0)
            {
                if (node.Checked)
                {
                    selectedSounds.Add(node.Text);
                }
                else
                {
                    unselectedSounds.Add(node.Text);
                }
            }
            else
            {
                foreach (TreeNode currentNode in node.Nodes)
                {
                    checkSoundNode(currentNode);
                }
            }
        }

        public static void checkItemNode(TreeNode node)
        {
            if (node.Nodes.Count == 0)
            {
                if (node.Checked)
                {
                    selectedItems.Add(node.Text);
                }
                else
                {
                    unselectedItems.Add(node.Text);
                }
            }
            else
            {
                foreach (TreeNode currentNode in node.Nodes)
                {
                    checkItemNode(currentNode);
                }
            }
        }
    }
}
