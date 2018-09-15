using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftTextureStudio
{
    public class Items
    {
        public static void loadItems()
        {
            FrmMain.items = new Hashtable();
            FrmMain.itemList = new List<string>();
        
            addItem("Iron Shovel", 256);
            addItem("Iron Pickaxe", 257);
            addItem("Iron Axe", 258);
            addItem("Flint and Steel", 259);
            addItem("Apple", 260);
            addItem("Bow Standby", 261);
            addItem("Bow Pulling 0", 261);
            addItem("Bow Pulling 1", 261);
            addItem("Bow Pulling 2", 261);
            addItem("Arrow", 262);
            addItem("Coal", 263);
            addItem("Diamond", 264);
            addItem("Iron Ingot", 265);
            addItem("Gold Ingot", 266);
            addItem("Iron Sword", 267);
            addItem("Wooden Sword", 268);
            addItem("Wooden Shovel", 269);
            addItem("Wooden Pickaxe", 270);
            addItem("Wooden Axe", 271);
            addItem("Stone Sword", 272);
            addItem("Stone Shovel", 273);
            addItem("Stone Pickaxe", 274);
            addItem("Stone Axe", 275);
            addItem("Diamond Sword", 276);
            addItem("Diamond Shovel", 277);
            addItem("Diamond Pickaxe", 278);
            addItem("Diamond Axe", 279);
            addItem("Stick", 280);
            addItem("Bowl", 281);
            addItem("Mushroom Stew", 282);
            addItem("Golden Sword", 283);
            addItem("Golden Shovel", 284);
            addItem("Golden Pickaxe", 285);
            addItem("Golden Axe", 286);
            addItem("String", 287);
            addItem("Feather", 288);
            addItem("Gunpowder", 289);
            addItem("Wooden Hoe", 290);
            addItem("Stone Hoe", 291);
            addItem("Iron Hoe", 292);
            addItem("Diamond Hoe", 293);
            addItem("Gold Hoe", 294);
            addItem("Wheat Seeds", 295);
            addItem("Wheat", 296);
            addItem("Bread", 297);
            addItem("Leather Cap", 298);
            addItem("Leather Tunic", 299);
            addItem("Leather Pants", 300);
            addItem("Leather Boots", 301);
            addItem("Chain Helmet", 302);
            addItem("Chain Chestplate", 303);
            addItem("Chain Leggings", 304);
            addItem("Chain Boots", 305);
            addItem("Iron Helmet", 306);
            addItem("Iron Chestplate", 307);
            addItem("Iron Leggings", 308);
            addItem("Iron Boots", 309);
            addItem("Diamond Helmet", 310);
            addItem("Diamond Chestplate", 311);
            addItem("Diamond Leggings", 312);
            addItem("Diamond Boots", 313);
            addItem("Golden Helmet", 314);
            addItem("Golden Chestplate", 315);
            addItem("Golden Leggings", 316);
            addItem("Golden Boots", 317);
            addItem("Flint", 318);
            addItem("Raw Porkchop", 319);
            addItem("Cooked Porkchop", 320);
            addItem("Painting", 321);
            addItem("Golden Apple", 322);
            addItem("Sign", 323);
            addItem("Wooden Door", 324);
            addItem("Bucket", 325);
            addItem("Water Bucket", 326);
            addItem("Lava Bucket", 327);
            addItem("Minecart", 328);
            addItem("Saddle", 329);
            addItem("Iron Door", 330);
            addItem("Redstone", 331);
            addItem("Snowball", 332);
            addItem("Boat", 333);
            addItem("Leather", 334);
            addItem("Milk", 335);
            addItem("Brick", 336);
            addItem("Clay", 337);
            addItem("Sugar Cane", 338);
            addItem("Paper", 339);
            addItem("Book", 340);
            addItem("Slimeball", 341);
            addItem("Minecart with Chest", 342);
            addItem("Minecart with Furnace", 343);
            addItem("Egg", 344);
            addItem("Compass", 345);
            addItem("Fishing Rod", 346);
            addItem("Clock", 347);
            addItem("Glowstone Dust", 348);
            addItem("Raw Clownfish", 349);
            addItem("Raw Cod", 349);
            addItem("Raw Pufferfish", 349);
            addItem("Raw Salmon", 349);
            addItem("Cooked Cod", 350);
            addItem("Cooked Salmon", 350);
            addItem("Black Dye", 351);
            addItem("Blue Dye", 351);
            addItem("Brown Dye", 351);
            addItem("Cyan Dye", 351);
            addItem("Gray Dye", 351);
            addItem("Green Dye", 351);
            addItem("Light Blue Dye", 351);
            addItem("Lime Dye", 351);
            addItem("Magenta Dye", 351);
            addItem("Orange Dye", 351);
            addItem("Pink Dye", 351);
            addItem("Purple Dye", 351);
            addItem("Red Dye", 351);
            addItem("Silver Dye", 351);
            addItem("White Dye", 351);
            addItem("Yellow Dye", 351);
            addItem("Bone", 352);
            addItem("Sugar", 353);
            addItem("Cake", 354);
            addItem("Bed", 355);
            addItem("Redstone Repeater", 356);
            addItem("Cookie", 357);
            addItem("Map Empty", 358);
            addItem("Map Filled", 358);
            addItem("Shears", 359);
            addItem("Melon", 360);
            addItem("Pumpkin Seeds", 361);
            addItem("Melon Seeds", 362);
            addItem("Raw Beef", 363);
            addItem("Steak", 364);
            addItem("Raw Chicken", 365);
            addItem("Cooked Chicken", 366);
            addItem("Rotten Flesh", 367);
            addItem("Ender Pearl", 368);
            addItem("Blaze Rod", 369);
            addItem("Ghast Tear", 370);
            addItem("Gold Nugget", 371);
            addItem("Nether Wart", 372);
            addItem("Potions", 373);
            addItem("Glass Bottle", 374);
            addItem("Spider Eye", 375);
            addItem("Fermented Spider Eye", 376);
            addItem("Blaze Powder", 377);
            addItem("Magma Cream", 378);
            addItem("Brewing Stand", 379);
            addItem("Cauldron", 380);
            addItem("Eye of Ender", 381);
            addItem("Glistering Melon", 382);
            addItem("Spawn Egg", 383);
            addItem("Bottle o' Enchanting", 384);
            addItem("Fire Charge", 385);
            addItem("Book and Quill", 386);
            addItem("Written Book", 387);
            addItem("Emerald", 388);
            addItem("Item Frame", 389);
            addItem("Flower Pot", 390);
            addItem("Carrot", 391);
            addItem("Potato", 392);
            addItem("Baked Potato", 393);
            addItem("Poisonous Potato", 394);
            addItem("Empty Map", 395);
            addItem("Golden Carrot", 396);
            addItem("Creeper Skull", 397);
            addItem("Skeleton Skull", 397);
            addItem("Steve Skull", 397);
            addItem("Wither Skull", 397);
            addItem("Zombie Skull", 397);
            addItem("Carrot on a Stick", 398);
            addItem("Nether Star", 399);
            addItem("Pumpkin Pie", 400);
            addItem("Firework Rocket", 401);
            addItem("Firework Star", 402);
            addItem("Enchanted Book", 403);
            addItem("Redstone Comparator", 404);
            addItem("Nether Brick", 405);
            addItem("Nether Quartz", 406);
            addItem("Minecart with TNT", 407);
            addItem("Minecart with Hopper", 408);
            addItem("Iron Horse Armor", 417);
            addItem("Gold Horse Armor", 418);
            addItem("Diamond Horse Armor", 419);
            addItem("Lead", 420);
            addItem("Name Tag", 421);
            addItem("Minecart with Command Block", 422);
            addItem("13 Disc", 2256);
            addItem("Cat Disc", 2257);
            addItem("Blocks Disc", 2258);
            addItem("Chirp Disc", 2259);
            addItem("Far Disc", 2260);
            addItem("Mall Disc", 2261);
            addItem("Mellohi Disc", 2262);
            addItem("Stal Disc", 2263);
            addItem("Strad Disc", 2264);
            addItem("Ward Disc", 2265);
            addItem("11 Disc", 2266);
            addItem("Wait Disc", 2267);
        }

        public static void addItem(string itemName, int id)
        {
            List<string> textures = Items.getTextures(itemName);

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
                FrmMain.items.Add(itemName, id);
                FrmMain.itemList.Add(itemName);
            }
        }

        public static List<string> getTextures(string itemName)
        {
            List<string> textures = new List<string>();

            if (itemName == "Iron Shovel")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\iron_shovel.png");
            }
            else if (itemName == "Iron Pickaxe")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\iron_pickaxe.png");
            }
            else if (itemName == "Iron Axe")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\iron_axe.png");
            }
            else if (itemName == "Flint and Steel")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\flint_and_steel.png");
            }
            else if (itemName == "Apple")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\apple.png");
            }
            else if (itemName == "Bow Standby")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\bow_standby.png");
            }
            else if (itemName == "Bow Pulling 0")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\bow_pulling_0.png");
            }
            else if (itemName == "Bow Pulling 1")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\bow_pulling_1.png");
            }
            else if (itemName == "Bow Pulling 2")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\bow_pulling_2.png");
            }
            else if (itemName == "Arrow")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\arrow.png");
            }
            else if (itemName == "Coal")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\coal.png");
            }
            else if (itemName == "Diamond")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\diamond.png");
            }
            else if (itemName == "Iron Ingot")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\iron_ingot.png");
            }
            else if (itemName == "Gold Ingot")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\gold_ingot.png");
            }
            else if (itemName == "Iron Sword")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\iron_sword.png");
            }
            else if (itemName == "Wooden Sword")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\wood_sword.png");
            }
            else if (itemName == "Wooden Shovel")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\wood_shovel.png");
            }
            else if (itemName == "Wooden Pickaxe")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\wood_pickaxe.png");
            }
            else if (itemName == "Wooden Axe")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\wood_axe.png");
            }
            else if (itemName == "Stone Sword")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\stone_sword.png");
            }
            else if (itemName == "Stone Shovel")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\stone_shovel.png");
            }
            else if (itemName == "Stone Pickaxe")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\stone_pickaxe.png");
            }
            else if (itemName == "Stone Axe")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\stone_axe.png");
            }
            else if (itemName == "Diamond Sword")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\diamond_sword.png");
            }
            else if (itemName == "Diamond Shovel")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\diamond_shovel.png");
            }
            else if (itemName == "Diamond Pickaxe")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\diamond_pickaxe.png");
            }
            else if (itemName == "Diamond Axe")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\diamond_axe.png");
            }
            else if (itemName == "Stick")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\stick.png");
            }
            else if (itemName == "Bowl")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\bowl.png");
            }
            else if (itemName == "Mushroom Stew")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\mushroom_stew.png");
            }
            else if (itemName == "Golden Sword")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\gold_sword.png");
            }
            else if (itemName == "Golden Shovel")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\gold_shovel.png");
            }
            else if (itemName == "Golden Pickaxe")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\gold_pickaxe.png");
            }
            else if (itemName == "Golden Axe")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\gold_axe.png");
            }
            else if (itemName == "String")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\string.png");
            }
            else if (itemName == "Feather")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\feather.png");
            }
            else if (itemName == "Gunpowder")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\gunpowder.png");
            }
            else if (itemName == "Wooden Hoe")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\wood_hoe.png");
            }
            else if (itemName == "Stone Hoe")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\stone_hoe.png");
            }
            else if (itemName == "Iron Hoe")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\iron_hoe.png");
            }
            else if (itemName == "Diamond Hoe")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\diamond_hoe.png");
            }
            else if (itemName == "Gold Hoe")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\gold_hoe.png");
            }
            else if (itemName == "Wheat Seeds")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\seeds_wheat.png");
            }
            else if (itemName == "Wheat")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\wheat.png");
            }
            else if (itemName == "Bread")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\bread.png");
            }
            else if (itemName == "Leather Cap")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\leather_helmet.png");
            }
            else if (itemName == "Leather Tunic")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\leather_chestplate.png");
            }
            else if (itemName == "Leather Pants")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\leather_leggings.png");
            }
            else if (itemName == "Leather Boots")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\leather_boots.png");
            }
            else if (itemName == "Chain Helmet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\chainmail_helmet.png");
            }
            else if (itemName == "Chain Chestplate")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\chainmail_chestplate.png");
            }
            else if (itemName == "Chain Leggings")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\chainmail_leggings.png");
            }
            else if (itemName == "Chain Boots")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\chainmail_boots.png");
            }
            else if (itemName == "Iron Helmet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\iron_helmet.png");
            }
            else if (itemName == "Iron Chestplate")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\iron_chestplate.png");
            }
            else if (itemName == "Iron Leggings")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\iron_leggings.png");
            }
            else if (itemName == "Iron Boots")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\iron_boots.png");
            }
            else if (itemName == "Diamond Helmet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\diamond_helmet.png");
            }
            else if (itemName == "Diamond Chestplate")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\diamond_chestplate.png");
            }
            else if (itemName == "Diamond Leggings")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\diamond_leggings.png");
            }
            else if (itemName == "Diamond Boots")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\diamond_boots.png");
            }
            else if (itemName == "Golden Helmet")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\gold_helmet.png");
            }
            else if (itemName == "Golden Chestplate")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\gold_chestplate.png");
            }
            else if (itemName == "Golden Leggings")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\gold_leggings.png");
            }
            else if (itemName == "Golden Boots")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\gold_boots.png");
            }
            else if (itemName == "Flint")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\flint.png");
            }
            else if (itemName == "Raw Porkchop")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\porkchop_raw.png");
            }
            else if (itemName == "Cooked Porkchop")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\porkchop_cooked.png");
            }
            else if (itemName == "Painting")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\painting.png");
            }
            else if (itemName == "Golden Apple")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\apple_golden.png");
            }
            else if (itemName == "Sign")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\sign.png");
            }
            else if (itemName == "Wooden Door")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\door_wood.png");
            }
            else if (itemName == "Bucket")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\bucket_empty.png");
            }
            else if (itemName == "Water Bucket")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\bucket_water.png");
            }
            else if (itemName == "Lava Bucket")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\bucket_lava.png");
            }
            else if (itemName == "Minecart")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\minecart_normal.png");
            }
            else if (itemName == "Saddle")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\saddle.png");
            }
            else if (itemName == "Iron Door")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\door_iron.png");
            }
            else if (itemName == "Redstone")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\redstone_dust.png");
            }
            else if (itemName == "Snowball")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\snowball.png");
            }
            else if (itemName == "Boat")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\boat.png");
            }
            else if (itemName == "Leather")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\leather.png");
            }
            else if (itemName == "Milk")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\bucket_milk.png");
            }
            else if (itemName == "Brick")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\brick.png");
            }
            else if (itemName == "Clay")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\clay_ball.png");
            }
            else if (itemName == "Sugar Cane")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\reeds.png");
            }
            else if (itemName == "Paper")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\paper.png");
            }
            else if (itemName == "Book")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\book_normal.png");
            }
            else if (itemName == "Slimeball")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\slimeball.png");
            }
            else if (itemName == "Minecart with Chest")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\minecart_chest.png");
            }
            else if (itemName == "Minecart with Furnace")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\minecart_furnace.png");
            }
            else if (itemName == "Egg")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\egg.png");
            }
            else if (itemName == "Compass")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\compass.png");
            }
            else if (itemName == "Fishing Rod")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\fishing_rod_uncast.png");
            }
            else if (itemName == "Clock")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\clock.png");
            }
            else if (itemName == "Glowstone Dust")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\glowstone_dust.png");
            }
            else if (itemName == "Raw Clownfish")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\fish_clownfish_raw.png");
            }
            else if (itemName == "Raw Cod")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\fish_cod_raw.png");
            }
            else if (itemName == "Raw Pufferfish")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\fish_pufferfish_raw.png");
            }
            else if (itemName == "Raw Salmon")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\fish_salmon_raw.png");
            }
            else if (itemName == "Cooked Cod")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\fish_cod_cooked.png");
            }
            else if (itemName == "Cooked Salmon")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\fish_salmon_cooked.png");
            }
            else if (itemName == "Black Dye")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\dye_powder_black.png");
            }
            else if (itemName == "Blue Dye")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\dye_powder_blue.png");
            }
            else if (itemName == "Brown Dye")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\dye_powder_brown.png");
            }
            else if (itemName == "Cyan Dye")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\dye_powder_cyan.png");
            }
            else if (itemName == "Gray Dye")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\dye_powder_gray.png");
            }
            else if (itemName == "Green Dye")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\dye_powder_green.png");
            }
            else if (itemName == "Light Blue Dye")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\dye_powder_light_blue.png");
            }
            else if (itemName == "Lime Dye")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\dye_powder_lime.png");
            }
            else if (itemName == "Magenta Dye")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\dye_powder_magenta.png");
            }
            else if (itemName == "Orange Dye")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\dye_powder_orange.png");
            }
            else if (itemName == "Pink Dye")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\dye_powder_pink.png");
            }
            else if (itemName == "Purple Dye")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\dye_powder_purple.png");
            }
            else if (itemName == "Red Dye")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\dye_powder_red.png");
            }
            else if (itemName == "Silver Dye")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\dye_powder_silver.png");
            }
            else if (itemName == "White Dye")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\dye_powder_white.png");
            }
            else if (itemName == "Yellow Dye")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\dye_powder_yellow.png");
            }
            else if (itemName == "Bone")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\bone.png");
            }
            else if (itemName == "Sugar")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\sugar.png");
            }
            else if (itemName == "Cake")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\cake.png");
            }
            else if (itemName == "Bed")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\bed.png");
            }
            else if (itemName == "Redstone Repeater")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\repeater.png");
            }
            else if (itemName == "Cookie")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\cookie.png");
            }
            else if (itemName == "Map Empty")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\map_empty.png");
            }
            else if (itemName == "Map Filled")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\map_filled.png");
            }
            else if (itemName == "Shears")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\shears.png");
            }
            else if (itemName == "Melon")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\melon.png");
            }
            else if (itemName == "Pumpkin Seeds")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\seeds_pumpkin.png");
            }
            else if (itemName == "Melon Seeds")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\seeds_melon.png");
            }
            else if (itemName == "Raw Beef")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\beef_raw.png");
            }
            else if (itemName == "Steak")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\beef_cooked.png");
            }
            else if (itemName == "Raw Chicken")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\chicken_raw.png");
            }
            else if (itemName == "Cooked Chicken")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\chicken_cooked.png");
            }
            else if (itemName == "Rotten Flesh")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\rotten_flesh.png");
            }
            else if (itemName == "Ender Pearl")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\ender_pearl.png");
            }
            else if (itemName == "Blaze Rod")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\blaze_rod.png");
            }
            else if (itemName == "Ghast Tear")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\ghast_tear.png");
            }
            else if (itemName == "Gold Nugget")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\gold_nugget.png");
            }
            else if (itemName == "Nether Wart")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\nether_wart.png");
            }
            else if (itemName == "Potions")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\potion_bottle_empty.png");
            }
            else if (itemName == "Glass Bottle")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\potion_bottle_drinkable.png");
            }
            else if (itemName == "Spider Eye")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\spider_eye.png");
            }
            else if (itemName == "Fermented Spider Eye")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\spider_eye_fermented.png");
            }
            else if (itemName == "Blaze Powder")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\blaze_powder.png");
            }
            else if (itemName == "Magma Cream")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\magma_cream.png");
            }
            else if (itemName == "Brewing Stand")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\brewing_stand.png");
            }
            else if (itemName == "Cauldron")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\cauldron.png");
            }
            else if (itemName == "Eye of Ender")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\ender_eye.png");
            }
            else if (itemName == "Glistering Melon")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\melon_speckled.png");
            }
            else if (itemName == "Spawn Egg")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\spawn_egg.png");
            }
            else if (itemName == "Bottle o' Enchanting")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\experience_bottle.png");
            }
            else if (itemName == "Fire Charge")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\fireball.png");
            }
            else if (itemName == "Book and Quill")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\book_writable.png");
            }
            else if (itemName == "Written Book")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\book_written.png");
            }
            else if (itemName == "Emerald")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\emerald.png");
            }
            else if (itemName == "Item Frame")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\item_frame.png");
            }
            else if (itemName == "Flower Pot")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\flower_pot.png");
            }
            else if (itemName == "Carrot")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\carrot.png");
            }
            else if (itemName == "Potato")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\potato.png");
            }
            else if (itemName == "Baked Potato")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\potato_baked.png");
            }
            else if (itemName == "Poisonous Potato")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\potato_poisonous.png");
            }
            else if (itemName == "Empty Map")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\map_empty.png");
            }
            else if (itemName == "Golden Carrot")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\carrot_golden.png");
            }
            else if (itemName == "Creeper Skull")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\skull_creeper.png");
            }
                else if (itemName == "Skeleton Skull")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\skull_skeleton.png");
            }
                else if (itemName == "Steve Skull")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\skull_steve.png");
            }
                else if (itemName == "Wither Skull")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\skull_wither.png");
            }
                else if (itemName == "Zombie Skull")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\skull_zombie.png");
            }
            else if (itemName == "Carrot on a Stick")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\carrot_on_a_stick.png");
            }
            else if (itemName == "Nether Star")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\nether_star.png");
            }
            else if (itemName == "Pumpkin Pie")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\pumpkin_pie.png");
            }
            else if (itemName == "Firework Rocket")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\fireworks.png");
            }
            else if (itemName == "Firework Star")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\fireworks_charge.png");
            }
            else if (itemName == "Enchanted Book")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\book_enchanted.png");
            }
            else if (itemName == "Redstone Comparator")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\comparator.png");
            }
            else if (itemName == "Nether Brick")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\netherbrick.png");
            }
            else if (itemName == "Nether Quartz")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\quartz.png");
            }
            else if (itemName == "Minecart with TNT")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\minecart_tnt.png");
            }
            else if (itemName == "Minecart with Hopper")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\minecart_hopper.png");
            }
            else if (itemName == "Iron Horse Armor")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\iron_horse_armor.png");
            }
            else if (itemName == "Gold Horse Armor")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\gold_horse_armor.png");
            }
            else if (itemName == "Diamond Horse Armor")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\diamond_horse_armor.png");
            }
            else if (itemName == "Lead")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\lead.png");
            }
            else if (itemName == "Name Tag")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\name_tag.png");
            }
            else if (itemName == "Minecart with Command Block")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\minecart_command_block.png");
            }
            else if (itemName == "13 Disc")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\record_13.png");
            }
            else if (itemName == "Cat Disc")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\record_cat.png");
            }
            else if (itemName == "Blocks Disc")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\record_blocks.png");
            }
            else if (itemName == "Chirp Disc")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\record_chirp.png");
            }
            else if (itemName == "Far Disc")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\record_far.png");
            }
            else if (itemName == "Mall Disc")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\record_mall.png");
            }
            else if (itemName == "Mellohi Disc")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\record_mellohi.png");
            }
            else if (itemName == "Stal Disc")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\record_stal.png");
            }
            else if (itemName == "Strad Disc")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\record_strad.png");
            }
            else if (itemName == "Ward Disc")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\record_ward.png");
            }
            else if (itemName == "11 Disc")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\record_11.png");
            }
            else if (itemName == "Wait Disc")
            {
                textures.Add(FrmMain.directory + "\\assets\\minecraft\\textures\\items\\record_wait.png");
            }

            return textures;
        }
    }
}
