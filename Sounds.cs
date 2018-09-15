using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace MinecraftTextureStudio
{
    public class Sounds
    {
        public static Hashtable sounds;

        public static void loadSounds()
        {
            FrmMain.soundList = new List<string>();
            sounds = new Hashtable();

            for (int a = 1; a <= 13; a++)
            {
                addSound("Cave " + a.ToString());
            }

            addSound("Weather Rain 1");
            addSound("Weather Rain 2");
            addSound("Weather Rain 3");
            addSound("Weather Rain 4");
            addSound("Weather Thunder 1");
            addSound("Weather Thunder 2");
            addSound("Weather Thunder 3");
            addSound("Damage Fall Big");
            addSound("Damage Fall Small");
            addSound("Damage Hit 1");
            addSound("Damage Hit 2");
            addSound("Damage Hit 3");
            
            for (int a = 1; a <= 4; a++)
            {
                addSound("Dig Cloth " + a.ToString());
            }

            for (int a = 1; a <= 4; a++)
            {
                addSound("Dig Grass " + a.ToString());
            }

            for (int a = 1; a <= 4; a++)
            {
                addSound("Dig Gravel " + a.ToString());
            }

            for (int a = 1; a <= 4; a++)
            {
                addSound("Dig Sand " + a.ToString());
            }

            for (int a = 1; a <= 4; a++)
            {
                addSound("Dig Snow " + a.ToString());
            }

            for (int a = 1; a <= 4; a++)
            {
                addSound("Dig Stone " + a.ToString());
            }

            for (int a = 1; a <= 4; a++)
            {
                addSound("Dig Wood " + a.ToString());
            }
            
            addSound("Fire Burning");
            addSound("Fire Ignite");
            addSound("Fireworks Blast");
            addSound("Fireworks Blast Far");
            addSound("Fireworks Large Blast");
            addSound("Fireworks Large Blast Far");
            addSound("Fireworks Launch");
            addSound("Fireworks Twinkle");
            addSound("Fireworks Twinkle Far");
            addSound("Liquid Lava");
            addSound("Liquid Lava Pop");
            addSound("Liquid Splash 1");
            addSound("Liquid Splash 2");

            for (int a = 1; a <= 4; a++)
            {
                addSound("Swim " + a.ToString());
            }

            addSound("Swim Water");
            addSound("Minecart Base");
            addSound("Minecart Inside");
            addSound("Bat Death");
            addSound("Bat Hurt 1");
            addSound("Bat Hurt 2");
            addSound("Bat Hurt 3");
            addSound("Bat Hurt 4");
            addSound("Bat Idle 1");
            addSound("Bat Idle 2");
            addSound("Bat Idle 3");
            addSound("Bat Idle 4");
            addSound("Bat Loop");
            addSound("Bat Takeoff");
            addSound("Blaze Breathe 1");
            addSound("Blaze Breathe 2");
            addSound("Blaze Breathe 3");
            addSound("Blaze Breathe 4");
            addSound("Blaze Death");
            addSound("Blaze Hit 1");
            addSound("Blaze Hit 2");
            addSound("Blaze Hit 3");
            addSound("Blaze Hit 4");
            addSound("Cat Hiss 1");
            addSound("Cat Hiss 2");
            addSound("Cat Hiss 3");
            addSound("Cat Hit 1");
            addSound("Cat Hit 2");
            addSound("Cat Hit 3");
            addSound("Cat Meow 1");
            addSound("Cat Meow 2");
            addSound("Cat Meow 3");
            addSound("Cat Meow 4");
            addSound("Cat Purr 1");
            addSound("Cat Purr 2");
            addSound("Cat Purr 3");
            addSound("Cat Purreow 1");
            addSound("Cat Purreow 2");
            addSound("Chicken Hurt 1");
            addSound("Chicken Hurt 2");
            addSound("Chicken Plop");
            addSound("Chicken Say 1");
            addSound("Chicken Say 2");
            addSound("Chicken Say 3");
            addSound("Chicken Step 1");
            addSound("Chicken Step 2");
            addSound("Cow Hurt 1");
            addSound("Cow Hurt 2");
            addSound("Cow Hurt 3");
            addSound("Cow Say 1");
            addSound("Cow Say 2");
            addSound("Cow Say 3");
            addSound("Cow Say 4");
            addSound("Cow Step 1");
            addSound("Cow Step 2");
            addSound("Cow Step 3");
            addSound("Cow Step 4");
            addSound("Creeper Death");
            addSound("Creeper Say 1");
            addSound("Creeper Say 2");
            addSound("Creeper Say 3");
            addSound("Creeper Say 4");
            addSound("Ender Dragon End");
            addSound("Ender Dragon Growl 1");
            addSound("Ender Dragon Growl 2");
            addSound("Ender Dragon Growl 3");
            addSound("Ender Dragon Growl 4");
            addSound("Ender Dragon Hit 1");
            addSound("Ender Dragon Hit 2");
            addSound("Ender Dragon Hit 3");
            addSound("Ender Dragon Hit 4");
            addSound("Ender Dragon Wings 1");
            addSound("Ender Dragon Wings 2");
            addSound("Ender Dragon Wings 3");
            addSound("Ender Dragon Wings 4");
            addSound("Ender Dragon Wings 5");
            addSound("Ender Dragon Wings 6");
            addSound("Ender Men Death");
            addSound("Ender Men Hit 1");
            addSound("Ender Men Hit 2");
            addSound("Ender Men Hit 3");
            addSound("Ender Men Hit 4");
            addSound("Ender Men Idle 1");
            addSound("Ender Men Idle 2");
            addSound("Ender Men Idle 3");
            addSound("Ender Men Idle 4");
            addSound("Ender Men Idle 5");
            addSound("Ender Men Portal");
            addSound("Ender Men Portal 2");
            addSound("Ender Men Scream 1");
            addSound("Ender Men Scream 2");
            addSound("Ender Men Scream 3");
            addSound("Ender Men Scream 4");
            addSound("Ender Men Stare");
            addSound("Ghast Affectionate Scream");
            addSound("Ghast Charge");
            addSound("Ghast Death");
            addSound("Ghast Fireball");
            addSound("Ghast Moan 1");
            addSound("Ghast Moan 2");
            addSound("Ghast Moan 3");
            addSound("Ghast Moan 4");
            addSound("Ghast Moan 5");
            addSound("Ghast Moan 6");
            addSound("Ghast Moan 7");
            addSound("Ghast Scream 1");
            addSound("Ghast Scream 2");
            addSound("Ghast Scream 3");
            addSound("Ghast Scream 4");
            addSound("Ghast Scream 5");
            addSound("Horse Angry");
            addSound("Horse Armor");
            addSound("Horse Breathe 1");
            addSound("Horse Breathe 2");
            addSound("Horse Breathe 3");
            addSound("Horse Death");
            addSound("Horse Gallop 1");
            addSound("Horse Gallop 2");
            addSound("Horse Gallop 3");
            addSound("Horse Gallop 4");
            addSound("Horse Hit 1");
            addSound("Horse Hit 2");
            addSound("Horse Hit 3");
            addSound("Horse Hit 4");
            addSound("Horse Idle 1");
            addSound("Horse Idle 2");
            addSound("Horse Idle 3");
            addSound("Horse Jump");
            addSound("Horse Land");
            addSound("Horse Leather");
            addSound("Horse Soft 1");
            addSound("Horse Soft 2");
            addSound("Horse Soft 3");
            addSound("Horse Soft 4");
            addSound("Horse Soft 5");
            addSound("Horse Soft 6");
            addSound("Horse Wood 1");
            addSound("Horse Wood 2");
            addSound("Horse Wood 3");
            addSound("Horse Wood 4");
            addSound("Horse Wood 5");
            addSound("Horse Wood 6");
            addSound("Donkey Angry 1");
            addSound("Donkey Angry 2");
            addSound("Donkey Death");
            addSound("Donkey Hit 1");
            addSound("Donkey Hit 2");
            addSound("Donkey Hit 3");
            addSound("Donkey Idle 1");
            addSound("Donkey Idle 2");
            addSound("Donkey Idle 3");
            addSound("Skeleton Horse Death");
            addSound("Skeleton Horse Hit 1");
            addSound("Skeleton Horse Hit 2");
            addSound("Skeleton Horse Hit 3");
            addSound("Skeleton Horse Hit 4");
            addSound("Skeleton Horse Idle 1");
            addSound("Skeleton Horse Idle 2");
            addSound("Skeleton Horse Idle 3");
            addSound("Zombie Horse Death");
            addSound("Zombie Horse Hit 1");
            addSound("Zombie Horse Hit 2");
            addSound("Zombie Horse Hit 3");
            addSound("Zombie Horse Hit 4");
            addSound("Zombie Horse Idle 1");
            addSound("Zombie Horse Idle 2");
            addSound("Zombie Horse Idle 3");
            addSound("Iron Golem Death");
            addSound("Iron Golem Hit 1");
            addSound("Iron Golem Hit 2");
            addSound("Iron Golem Hit 3");
            addSound("Iron Golem Hit 4");
            addSound("Iron Golem Throw");
            addSound("Iron Golem Walk 1");
            addSound("Iron Golem Walk 2");
            addSound("Iron Golem Walk 3");
            addSound("Iron Golem Walk 4");
            addSound("Magma Cube Big 1");
            addSound("Magma Cube Big 2");
            addSound("Magma Cube Big 3");
            addSound("Magma Cube Big 4");
            addSound("Magma Cube Jump 1");
            addSound("Magma Cube Jump 2");
            addSound("Magma Cube Jump 3");
            addSound("Magma Cube Jump 4");
            addSound("Magma Cube Small 1");
            addSound("Magma Cube Small 2");
            addSound("Magma Cube Small 3");
            addSound("Magma Cube Small 4");
            addSound("Magma Cube Small 5");
            addSound("Pig Death");
            addSound("Pig Say 1");
            addSound("Pig Say 2");
            addSound("Pig Say 3");
            addSound("Pig Step 1");
            addSound("Pig Step 2");
            addSound("Pig Step 3");
            addSound("Pig Step 4");
            addSound("Pig Step 5");
            addSound("Sheep Say 1");
            addSound("Sheep Say 2");
            addSound("Sheep Say 3");
            addSound("Sheep Shear");
            addSound("Sheep Step 1");
            addSound("Sheep Step 2");
            addSound("Sheep Step 3");
            addSound("Sheep Step 4");
            addSound("Sheep Step 5");
            addSound("Silver Fish Hit 1");
            addSound("Silver Fish Hit 2");
            addSound("Silver Fish Hit 3");
            addSound("Silver Fish Kill");
            addSound("Silver Fish Say 1");
            addSound("Silver Fish Say 2");
            addSound("Silver Fish Say 3");
            addSound("Silver Fish Say 4");
            addSound("Silver Fish Step 1");
            addSound("Silver Fish Step 2");
            addSound("Silver Fish Step 3");
            addSound("Silver Fish Step 4");
            addSound("Skeleton Death");
            addSound("Skeleton Hurt 1");
            addSound("Skeleton Hurt 2");
            addSound("Skeleton Hurt 3");
            addSound("Skeleton Hurt 4");
            addSound("Skeleton Say 1");
            addSound("Skeleton Say 2");
            addSound("Skeleton Say 3");
            addSound("Skeleton Step 1");
            addSound("Skeleton Step 2");
            addSound("Skeleton Step 3");
            addSound("Skeleton Step 4");
            addSound("Slime Attack 1");
            addSound("Slime Attack 2");
            addSound("Slime Big 1");
            addSound("Slime Big 2");
            addSound("Slime Big 3");
            addSound("Slime Big 4");
            addSound("Slime Small 1");
            addSound("Slime Small 2");
            addSound("Slime Small 3");
            addSound("Slime Small 4");
            addSound("Slime Small 5");
            addSound("Spider Death");
            addSound("Spider Say 1");
            addSound("Spider Say 2");
            addSound("Spider Say 3");
            addSound("Spider Say 4");
            addSound("Spider Step 1");
            addSound("Spider Step 2");
            addSound("Spider Step 3");
            addSound("Spider Step 4");
            addSound("Villager Death");
            addSound("Villager Haggle 1");
            addSound("Villager Haggle 2");
            addSound("Villager Haggle 3");
            addSound("Villager Hit 1");
            addSound("Villager Hit 2");
            addSound("Villager Hit 3");
            addSound("Villager Hit 4");
            addSound("Villager Idle 1");
            addSound("Villager Idle 2");
            addSound("Villager Idle 3");
            addSound("Villager No 1");
            addSound("Villager No 2");
            addSound("Villager No 3");
            addSound("Villager Yes 1");
            addSound("Villager Yes 2");
            addSound("Villager Yes 3");
            addSound("Wither Death");
            addSound("Wither Hurt 1");
            addSound("Wither Hurt 2");
            addSound("Wither Hurt 3");
            addSound("Wither Hurt 4");
            addSound("Wither Idle 1");
            addSound("Wither Idle 2");
            addSound("Wither Idle 3");
            addSound("Wither Idle 4");
            addSound("Wither Shoot");
            addSound("Wither Spawn");
            addSound("Wolf Bark 1");
            addSound("Wolf Bark 2");
            addSound("Wolf Bark 3");
            addSound("Wolf Death");
            addSound("Wolf Growl 1");
            addSound("Wolf Growl 2");
            addSound("Wolf Growl 3");
            addSound("Wolf Howl 1");
            addSound("Wolf Howl 2");
            addSound("Wolf Hurt 1");
            addSound("Wolf Hurt 2");
            addSound("Wolf Hurt 3");
            addSound("Wolf Panting");
            addSound("Wolf Shake");
            addSound("Wolf Step 1");
            addSound("Wolf Step 2");
            addSound("Wolf Step 3");
            addSound("Wolf Step 4");
            addSound("Wolf Step 5");
            addSound("Wolf Whine");
            addSound("Zombie Death");
            addSound("Zombie Hurt 1");
            addSound("Zombie Hurt 2");
            addSound("Zombie Infect");
            addSound("Zombie Metal 1");
            addSound("Zombie Metal 2");
            addSound("Zombie Metal 3");
            addSound("Zombie Remedy");
            addSound("Zombie Say 1");
            addSound("Zombie Say 2");
            addSound("Zombie Say 3");
            addSound("Zombie Step 1");
            addSound("Zombie Step 2");
            addSound("Zombie Step 3");
            addSound("Zombie Step 4");
            addSound("Zombie Step 5");
            addSound("Zombie Unfect");
            addSound("Zombie Wood 1");
            addSound("Zombie Wood 2");
            addSound("Zombie Wood 3");
            addSound("Zombie Wood 4");
            addSound("Zombie Wood Break");
            addSound("Zombie Pigmen 1");
            addSound("Zombie Pigmen 2");
            addSound("Zombie Pigmen 3");
            addSound("Zombie Pigmen 4");
            addSound("Zombie Pigmen Angry 1");
            addSound("Zombie Pigmen Angry 2");
            addSound("Zombie Pigmen Angry 3");
            addSound("Zombie Pigmen Angry 4");
            addSound("Zombie Pigmen Death");
            addSound("Zombie Pigmen Hurt 1");
            addSound("Zombie Pigmen Hurt 2");

            for (int a = 1; a <= 3; a++)
            {
                addSound("Game Music Calm " + a.ToString());
            }

            for (int a = 1; a <= 4; a++)
            {
                addSound("Game Music Hal " + a.ToString());
            }

            addSound("Game Music Nuance 1");
            addSound("Game Music Nuance 2");

            for (int a = 1; a <= 3; a++)
            {
                addSound("Game Music Piano " + a.ToString());
            }

            for (int a = 1; a <= 6; a++)
            {
                addSound("Creative " + a.ToString());
            }

            addSound("End Music Boss");
            addSound("End Music Credits");
            addSound("End Music The End");

            for (int a = 1; a <= 4; a++)
            {
                addSound("Nether " + a.ToString());
            }

            for (int a = 1; a <= 4; a++)
            {
                addSound("Menu " + a.ToString());
            }

            addSound("Note Bass");
            addSound("Note Bass Attack");
            addSound("Note BD");
            addSound("Note Harp");
            addSound("Note Hat");
            addSound("Note Pling");
            addSound("Note Snare");
            addSound("Portal Ambient");
            addSound("Portal Travel");
            addSound("Portal Trigger");
            addSound("Anvil Break");
            addSound("Anvil Land");
            addSound("Anvil Use");
            addSound("Bow");
            addSound("Bow Hit 1");
            addSound("Bow Hit 2");
            addSound("Bow Hit 3");
            addSound("Bow Hit 4");
            addSound("Break");
            addSound("Breath");
            addSound("Burp");
            addSound("Chest Closed");
            addSound("Chest Open");
            addSound("Classic Hurt");
            addSound("Click");
            addSound("Door Close");
            addSound("Door Open");
            addSound("Drink");
            addSound("Eat 1");
            addSound("Eat 2");
            addSound("Eat 3");
            addSound("Explode 1");
            addSound("Explode 2");
            addSound("Explode 3");
            addSound("Explode 4");
            addSound("Fizz");
            addSound("Fuse");
            addSound("Glass 1");
            addSound("Glass 2");
            addSound("Glass 3");
            addSound("Level Up");
            addSound("Orb");
            addSound("Pop");
            addSound("Splash");
            addSound("Successful Hit");
            addSound("Wood Click");
            addSound("Records 11");
            addSound("Records 13");
            addSound("Records Blocks");
            addSound("Records Cat");
            addSound("Records Chirp");
            addSound("Records Far");
            addSound("Records Mall");
            addSound("Records Mellohi");
            addSound("Records Stal");
            addSound("Records Strad");
            addSound("Records Wait");
            addSound("Records Ward");

            for (int a = 1; a <= 4; a++)
            {
                addSound("Cloth Step " + a.ToString());
            }

            for (int a = 1; a <= 6; a++)
            {
                addSound("Grass Step " + a.ToString());
            }

            for (int a = 1; a <= 4; a++)
            {
                addSound("Gravel Step " + a.ToString());
            }

            for (int a = 1; a <= 5; a++)
            {
                addSound("Ladder Step " + a.ToString());
            }

            for (int a = 1; a <= 5; a++)
            {
                addSound("Sand Step " + a.ToString());
            }

            for (int a = 1; a <= 4; a++)
            {
                addSound("Snow Step " + a.ToString());
            }

            for (int a = 1; a <= 6; a++)
            {
                addSound("Stone Step " + a.ToString());
            }

            for (int a = 1; a <= 6; a++)
            {
                addSound("Wood Step " + a.ToString());
            }

            addSound("Piston In");
            addSound("Piston Out");
        }

        public static void addSound(string soundName)
        {
            string filename = Sounds.getSounds(soundName);

            if (!File.Exists(filename))
            {
                //Console.WriteLine(filename + " not found");
            }
            else
            {
                sounds.Add(filename, 1);
                FrmMain.soundList.Add(soundName);
            }
        }

        public static string getSounds(string soundName)
        {
            string[] spaceDelim = { " " };

            if (soundName.StartsWith("Cave "))
            {
                string[] tokens = soundName.Split(spaceDelim, StringSplitOptions.None);
                if (tokens.Length == 2)
                {
                    string number = tokens[1];
                    return FrmMain.directory + @"\assets\minecraft\sounds\ambient\cave\cave" + number + ".ogg";
                }
            }

            if (soundName == "Weather Rain 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\ambient\weather\rain1.ogg";
            }

            if (soundName == "Weather Rain 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\ambient\weather\rain2.ogg";
            }
            
            if (soundName == "Weather Rain 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\ambient\weather\rain3.ogg";
            }
            
            if (soundName == "Weather Rain 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\ambient\weather\rain4.ogg";
            }
            
            if (soundName == "Weather Thunder 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\ambient\weather\thunder1.ogg";
            }
            
            if (soundName == "Weather Thunder 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\ambient\weather\thunder2.ogg";
            }
            
            if (soundName == "Weather Thunder 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\ambient\weather\thunder3.ogg";
            }
            
            if (soundName == "Damage Fall Big")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\damage\fallbig.ogg";
            }
            
            if (soundName == "Damage Fall Small")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\damage\fallsmall.ogg";
            }
            
            if (soundName == "Damage Hit 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\damage\hit1.ogg";
            }
            
            if (soundName == "Damage Hit 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\damage\hit2.ogg";
            }
            
            if (soundName == "Damage Hit 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\damage\hit3.ogg";
            }

            if (soundName.StartsWith("Dig Cloth "))
            {
                string[] tokens = soundName.Split(spaceDelim, StringSplitOptions.None);
                if (tokens.Length == 3)
                {
                    string number = tokens[2];
                    return FrmMain.directory + @"\assets\minecraft\sounds\dig\cloth" + number + ".ogg";
                }
            }

            if (soundName.StartsWith("Dig Grass "))
            {
                string[] tokens = soundName.Split(spaceDelim, StringSplitOptions.None);
                if (tokens.Length == 3)
                {
                    string number = tokens[2];
                    return FrmMain.directory + @"\assets\minecraft\sounds\dig\grass" + number + ".ogg";
                }
            }

            if (soundName.StartsWith("Dig Gravel "))
            {
                string[] tokens = soundName.Split(spaceDelim, StringSplitOptions.None);
                if (tokens.Length == 3)
                {
                    string number = tokens[2];
                    return FrmMain.directory + @"\assets\minecraft\sounds\dig\gravel" + number + ".ogg";
                }
            }

            if (soundName.StartsWith("Dig Sand "))
            {
                string[] tokens = soundName.Split(spaceDelim, StringSplitOptions.None);
                if (tokens.Length == 3)
                {
                    string number = tokens[2];
                    return FrmMain.directory + @"\assets\minecraft\sounds\dig\sand" + number + ".ogg";
                }
            }

            if (soundName.StartsWith("Dig Snow "))
            {
                string[] tokens = soundName.Split(spaceDelim, StringSplitOptions.None);
                if (tokens.Length == 3)
                {
                    string number = tokens[2];
                    return FrmMain.directory + @"\assets\minecraft\sounds\dig\snow" + number + ".ogg";
                }
            }

            if (soundName.StartsWith("Dig Stone "))
            {
                string[] tokens = soundName.Split(spaceDelim, StringSplitOptions.None);
                if (tokens.Length == 3)
                {
                    string number = tokens[2];
                    return FrmMain.directory + @"\assets\minecraft\sounds\dig\stone" + number + ".ogg";
                }
            }

            if (soundName.StartsWith("Dig Wood "))
            {
                string[] tokens = soundName.Split(spaceDelim, StringSplitOptions.None);
                if (tokens.Length == 3)
                {
                    string number = tokens[2];
                    return FrmMain.directory + @"\assets\minecraft\sounds\dig\wood" + number + ".ogg";
                }
            }

            if (soundName == "Fire Burning")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\fire\fire.ogg";
            }
            
            if (soundName == "Fire Ignite")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\fire\ignite.ogg";
            }
            
            if (soundName == "Fireworks Blast")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\fireworks\blast1.ogg";
            }
            
            if (soundName == "Fireworks Blast Far")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\fireworks\blast_far1.ogg";
            }
            
            if (soundName == "Fireworks Large Blast")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\fireworks\largeBlast1.ogg";
            }
            
            if (soundName == "Fireworks Large Blast Far")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\fireworks\largeBlast_far1.ogg";
            }
            
            if (soundName == "Fireworks Launch")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\fireworks\launch1.ogg";
            }
            
            if (soundName == "Fireworks Twinkle")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\fireworks\twinkle1.ogg";
            }
            
            if (soundName == "Fireworks Twinkle Far")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\fireworks\twinkle_far1.ogg";
            }
            
            if (soundName == "Liquid Lava")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\liquid\lava.ogg";
            }
            
            if (soundName == "Liquid Lava Pop")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\liquid\lavapop.ogg";
            }
            
            if (soundName == "Liquid Splash 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\liquid\splash.ogg";
            }
            
            if (soundName == "Liquid Splash 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\liquid\splash2.ogg";
            }

            if (soundName == "Swim Water")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\liquid\water.ogg";
            }
            else if (soundName.StartsWith("Swim "))
            {
                string[] tokens = soundName.Split(spaceDelim, StringSplitOptions.None);
                if (tokens.Length == 2)
                {
                    string number = tokens[1];
                    return FrmMain.directory + @"\assets\minecraft\sounds\liquid\swim" + number + ".ogg";
                }
            }

            if (soundName == "Minecart Base")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\minecart\base.ogg";
            }
            
            if (soundName == "Minecart Inside")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\minecart\inside.ogg";
            }
            
            if (soundName == "Bat Death")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\bat\death.ogg";
            }
            
            if (soundName == "Bat Hurt 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\bat\hurt1.ogg";
            }
            
            if (soundName == "Bat Hurt 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\bat\hurt2.ogg";
            }
            
            if (soundName == "Bat Hurt 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\bat\hurt3.ogg";
            }
            
            if (soundName == "Bat Hurt 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\bat\hurt4.ogg";
            }
            
            if (soundName == "Bat Idle 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\bat\idle1.ogg";
            }
            
            if (soundName == "Bat Idle 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\bat\idle2.ogg";
            }
            
            if (soundName == "Bat Idle 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\bat\idle3.ogg";
            }
            
            if (soundName == "Bat Idle 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\bat\idle4.ogg";
            }
            
            if (soundName == "Bat Loop")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\bat\loop.ogg";
            }
            
            if (soundName == "Bat Takeoff")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\bat\takeoff.ogg";
            }

            if (soundName == "Blaze Breathe 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\blaze\breathe1.ogg";
            }
            
            if (soundName == "Blaze Breathe 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\blaze\breathe2.ogg";
            }
            
            if (soundName == "Blaze Breathe 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\blaze\breathe3.ogg";
            }
            
            if (soundName == "Blaze Breathe 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\blaze\breathe4.ogg";
            }
            
            if (soundName == "Blaze Death")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\blaze\death.ogg";
            }
            
            if (soundName == "Blaze Hit 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\blaze\hit1.ogg";
            }
            
            if (soundName == "Blaze Hit 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\blaze\hit2.ogg";
            }
            
            if (soundName == "Blaze Hit 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\blaze\hit3.ogg";
            }
            
            if (soundName == "Blaze Hit 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\blaze\hit4.ogg";
            }

            if (soundName == "Cat Hiss 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cat\hiss1.ogg";
            }
            
            if (soundName == "Cat Hiss 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cat\hiss2.ogg";
            }
            
            if (soundName == "Cat Hiss 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cat\hiss3.ogg";
            }
            
            if (soundName == "Cat Hit 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cat\hitt1.ogg";
            }
            
            if (soundName == "Cat Hit 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cat\hitt2.ogg";
            }
            
            if (soundName == "Cat Hit 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cat\hitt3.ogg";
            }
            
            if (soundName == "Cat Meow 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cat\meow1.ogg";
            }
            
            if (soundName == "Cat Meow 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cat\meow2.ogg";
            }
            
            if (soundName == "Cat Meow 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cat\meow3.ogg";
            }
            
            if (soundName == "Cat Meow 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cat\meow4.ogg";
            }
            
            if (soundName == "Cat Purr 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cat\purr1.ogg";
            }
            
            if (soundName == "Cat Purr 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cat\purr2.ogg";
            }
            
            if (soundName == "Cat Purr 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cat\purr3.ogg";
            }
            
            if (soundName == "Cat Purreow 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cat\purreow1.ogg";
            }
            
            if (soundName == "Cat Purreow 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cat\purreow2.ogg";
            }

            if (soundName == "Chicken Hurt 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\chicken\hurt1.ogg";
            }
            
            if (soundName == "Chicken Hurt 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\chicken\hurt2.ogg";
            }
            
            if (soundName == "Chicken Plop")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\chicken\plop.ogg";
            }
            
            if (soundName == "Chicken Say 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\chicken\say1.ogg";
            }
            
            if (soundName == "Chicken Say 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\chicken\say2.ogg";
            }
            
            if (soundName == "Chicken Say 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\chicken\say3.ogg";
            }
            
            if (soundName == "Chicken Step 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\chicken\step1.ogg";
            }
            
            if (soundName == "Chicken Step 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\chicken\step2.ogg";
            }

            if (soundName == "Cow Hurt 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cow\hurt1.ogg";
            }
            
            if (soundName == "Cow Hurt 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cow\hurt2.ogg";
            }
            
            if (soundName == "Cow Hurt 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cow\hurt3.ogg";
            }
            
            if (soundName == "Cow Say 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cow\say1.ogg";
            }
            
            if (soundName == "Cow Say 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cow\say2.ogg";
            }
            
            if (soundName == "Cow Say 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cow\say3.ogg";
            }
            
            if (soundName == "Cow Say 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cow\say4.ogg";
            }
            
            if (soundName == "Cow Step 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cow\step1.ogg";
            }
            
            if (soundName == "Cow Step 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cow\step2.ogg";
            }
            
            if (soundName == "Cow Step 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cow\step3.ogg";
            }
            
            if (soundName == "Cow Step 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\cow\step4.ogg";
            }

            if (soundName == "Creeper Death")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\creeper\death.ogg";
            }
            
            if (soundName == "Creeper Say 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\creeper\say1.ogg";
            }
            
            if (soundName == "Creeper Say 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\creeper\say2.ogg";
            }
            
            if (soundName == "Creeper Say 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\creeper\say3.ogg";
            }
            
            if (soundName == "Creeper Say 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\creeper\say4.ogg";
            }

            if (soundName == "Ender Dragon End")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\enderdragon\end.ogg";
            }
            
            if (soundName == "Ender Dragon Growl 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\enderdragon\growl1.ogg";
            }
            
            if (soundName == "Ender Dragon Growl 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\enderdragon\growl2.ogg";
            }
            
            if (soundName == "Ender Dragon Growl 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\enderdragon\growl3.ogg";
            }
            
            if (soundName == "Ender Dragon Growl 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\enderdragon\growl4.ogg";
            }

            if (soundName == "Ender Dragon Hit 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\enderdragon\hit1.ogg";
            }
            
            if (soundName == "Ender Dragon Hit 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\enderdragon\hit2.ogg";
            }
            
            if (soundName == "Ender Dragon Hit 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\enderdragon\hit3.ogg";
            }
            
            if (soundName == "Ender Dragon Hit 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\enderdragon\hit4.ogg";
            }
            
            if (soundName == "Ender Dragon Wings 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\enderdragon\wings1.ogg";
            }
            
            if (soundName == "Ender Dragon Wings 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\enderdragon\wings2.ogg";
            }
            
            if (soundName == "Ender Dragon Wings 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\enderdragon\wings3.ogg";
            }
            
            if (soundName == "Ender Dragon Wings 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\enderdragon\wings4.ogg";
            }
            
            if (soundName == "Ender Dragon Wings 5")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\enderdragon\wings5.ogg";
            }
            
            if (soundName == "Ender Dragon Wings 6")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\enderdragon\wings6.ogg";
            }

            if (soundName == "Ender Men Death")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\endermen\death.ogg";
            }
            
            if (soundName == "Ender Men Hit 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\endermen\hit1.ogg";
            }
            
            if (soundName == "Ender Men Hit 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\endermen\hit2.ogg";
            }
            
            if (soundName == "Ender Men Hit 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\endermen\hit3.ogg";
            }
            
            if (soundName == "Ender Men Hit 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\endermen\hit4.ogg";
            }
            
            if (soundName == "Ender Men Idle 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\endermen\idle1.ogg";
            }
            
            if (soundName == "Ender Men Idle 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\endermen\idle2.ogg";
            }
            
            if (soundName == "Ender Men Idle 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\endermen\idle3.ogg";
            }
            
            if (soundName == "Ender Men Idle 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\endermen\idle4.ogg";
            }
            
            if (soundName == "Ender Men Idle 5")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\endermen\idle5.ogg";
            }
            
            if (soundName == "Ender Men Portal")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\endermen\portal.ogg";
            }
            
            if (soundName == "Ender Men Portal 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\endermen\portal2.ogg";
            }
            
            if (soundName == "Ender Men Scream 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\endermen\scream1.ogg";
            }
            
            if (soundName == "Ender Men Scream 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\endermen\scream2.ogg";
            }
            
            if (soundName == "Ender Men Scream 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\endermen\scream3.ogg";
            }
            
            if (soundName == "Ender Men Scream 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\endermen\scream4.ogg";
            }
            
            if (soundName == "Ender Men Stare")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\endermen\stare.ogg";
            }
            
            if (soundName == "Ghast Affectionate Scream")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\ghast\affectionate_scream.ogg";
            }
            
            if (soundName == "Ghast Charge")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\ghast\charge.ogg";
            }
            
            if (soundName == "Ghast Death")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\ghast\death.ogg";
            }
            
            if (soundName == "Ghast Fireball")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\ghast\fireball4.ogg";
            }

            if (soundName == "Ghast Moan 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\ghast\moan1.ogg";
            }
            
            if (soundName == "Ghast Moan 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\ghast\moan2.ogg";
            }
            
            if (soundName == "Ghast Moan 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\ghast\moan3.ogg";
            }
            
            if (soundName == "Ghast Moan 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\ghast\moan4.ogg";
            }
            
            if (soundName == "Ghast Moan 5")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\ghast\moan5.ogg";
            }
            
            if (soundName == "Ghast Moan 6")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\ghast\moan6.ogg";
            }
            
            if (soundName == "Ghast Moan 7")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\ghast\moan7.ogg";
            }

            if (soundName == "Ghast Scream 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\ghast\scream1.ogg";
            }
            
            if (soundName == "Ghast Scream 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\ghast\scream2.ogg";
            }
            
            if (soundName == "Ghast Scream 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\ghast\scream3.ogg";
            }
            
            if (soundName == "Ghast Scream 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\ghast\scream4.ogg";
            }
            
            if (soundName == "Ghast Scream 5")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\ghast\scream5.ogg";
            }

            if (soundName == "Horse Angry")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\angry1.ogg";
            }
            
            if (soundName == "Horse Armor")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\armor.ogg";
            }
            
            if (soundName == "Horse Breathe 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\breathe1.ogg";
            }
            
            if (soundName == "Horse Breathe 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\breathe2.ogg";
            }
            
            if (soundName == "Horse Breathe 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\breathe3.ogg";
            }
            
            if (soundName == "Horse Death")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\death.ogg";
            }

            if (soundName == "Horse Gallop 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\gallop1.ogg";
            }
            
            if (soundName == "Horse Gallop 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\gallop2.ogg";
            }
            
            if (soundName == "Horse Gallop 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\gallop3.ogg";
            }
            
            if (soundName == "Horse Gallop 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\gallop4.ogg";
            }
            
            if (soundName == "Horse Hit 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\hit1.ogg";
            }
            
            if (soundName == "Horse Hit 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\hit2.ogg";
            }
            
            if (soundName == "Horse Hit 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\hit3.ogg";
            }
            
            if (soundName == "Horse Hit 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\hit4.ogg";
            }
            
            if (soundName == "Horse Idle 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\idle1.ogg";
            }
            
            if (soundName == "Horse Idle 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\idle2.ogg";
            }
            
            if (soundName == "Horse Idle 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\idle3.ogg";
            }
            
            if (soundName == "Horse Jump")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\jump.ogg";
            }
            
            if (soundName == "Horse Land")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\land.ogg";
            }
            
            if (soundName == "Horse Leather")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\leather.ogg";
            }
            
            if (soundName == "Horse Soft 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\soft1.ogg";
            }
            
            if (soundName == "Horse Soft 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\soft2.ogg";
            }
            
            if (soundName == "Horse Soft 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\soft3.ogg";
            }
            
            if (soundName == "Horse Soft 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\soft4.ogg";
            }
            
            if (soundName == "Horse Soft 5")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\soft5.ogg";
            }
            
            if (soundName == "Horse Soft 6")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\soft6.ogg";
            }
            
            if (soundName == "Horse Wood 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\wood1.ogg";
            }
            
            if (soundName == "Horse Wood 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\wood2.ogg";
            }
            
            if (soundName == "Horse Wood 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\wood3.ogg";
            }
            
            if (soundName == "Horse Wood 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\wood4.ogg";
            }
            
            if (soundName == "Horse Wood 5")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\wood5.ogg";
            }
            
            if (soundName == "Horse Wood 6")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\wood6.ogg";
            }

            if (soundName == "Donkey Angry 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\donkey\angry1.ogg";
            }
            
            if (soundName == "Donkey Angry 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\donkey\angry2.ogg";
            }
            
            if (soundName == "Donkey Death")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\donkey\death.ogg";
            }
            
            if (soundName == "Donkey Hit 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\donkey\hit1.ogg";
            }
            
            if (soundName == "Donkey Hit 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\donkey\hit2.ogg";
            }
            
            if (soundName == "Donkey Hit 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\donkey\hit3.ogg";
            }
            
            if (soundName == "Donkey Idle 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\donkey\idle1.ogg";
            }
            
            if (soundName == "Donkey Idle 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\donkey\idle2.ogg";
            }
            
            if (soundName == "Donkey Idle 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\donkey\idle3.ogg";
            }
            
            if (soundName == "Skeleton Horse Death")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\skeleton\death.ogg";
            }
            
            if (soundName == "Skeleton Horse Hit 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\skeleton\hit1.ogg";
            }
            
            if (soundName == "Skeleton Horse Hit 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\skeleton\hit2.ogg";
            }
            
            if (soundName == "Skeleton Horse Hit 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\skeleton\hit3.ogg";
            }
            
            if (soundName == "Skeleton Horse Hit 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\skeleton\hit4.ogg";
            }
            
            if (soundName == "Skeleton Horse Idle 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\skeleton\idle1.ogg";
            }
            
            if (soundName == "Skeleton Horse Idle 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\skeleton\idle2.ogg";
            }
            
            if (soundName == "Skeleton Horse Idle 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\skeleton\idle3.ogg";
            }
            
            if (soundName == "Zombie Horse Death")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\zombie\death.ogg";
            }
            
            if (soundName == "Zombie Horse Hit 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\zombie\hit1.ogg";
            }
            
            if (soundName == "Zombie Horse Hit 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\zombie\hit2.ogg";
            }
            
            if (soundName == "Zombie Horse Hit 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\zombie\hit3.ogg";
            }
            
            if (soundName == "Zombie Horse Hit 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\zombie\hit4.ogg";
            }
            
            if (soundName == "Zombie Horse Idle 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\zombie\idle1.ogg";
            }
            
            if (soundName == "Zombie Horse Idle 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\zombie\idle2.ogg";
            }
            
            if (soundName == "Zombie Horse Idle 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\horse\zombie\idle3.ogg";
            }
            
            if (soundName == "Iron Golem Death")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\irongolem\death.ogg";
            }
            
            if (soundName == "Iron Golem Hit 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\irongolem\hit1.ogg";
            }
            
            if (soundName == "Iron Golem Hit 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\irongolem\hit2.ogg";
            }
            
            if (soundName == "Iron Golem Hit 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\irongolem\hit3.ogg";
            }
            
            if (soundName == "Iron Golem Hit 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\irongolem\hit4.ogg";
            }
            
            if (soundName == "Iron Golem Throw")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\irongolem\throw.ogg";
            }
            
            if (soundName == "Iron Golem Walk 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\irongolem\walk1.ogg";
            }
            
            if (soundName == "Iron Golem Walk 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\irongolem\walk2.ogg";
            }
            
            if (soundName == "Iron Golem Walk 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\irongolem\walk3.ogg";
            }
            
            if (soundName == "Iron Golem Walk 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\irongolem\walk4.ogg";
            }

            if (soundName == "Magma Cube Big 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\magmacube\big1.ogg";
            }
            
            if (soundName == "Magma Cube Big 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\magmacube\big2.ogg";
            }
            
            if (soundName == "Magma Cube Big 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\magmacube\big3.ogg";
            }
            
            if (soundName == "Magma Cube Big 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\magmacube\big4.ogg";
            }
            
            if (soundName == "Magma Cube Jump 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\magmacube\jump1.ogg";
            }
            
            if (soundName == "Magma Cube Jump 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\magmacube\jump2.ogg";
            }
            
            if (soundName == "Magma Cube Jump 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\magmacube\jump3.ogg";
            }
            
            if (soundName == "Magma Cube Jump 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\magmacube\jump4.ogg";
            }
            
            if (soundName == "Magma Cube Small 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\magmacube\small1.ogg";
            }
            
            if (soundName == "Magma Cube Small 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\magmacube\small2.ogg";
            }
            
            if (soundName == "Magma Cube Small 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\magmacube\small3.ogg";
            }
            
            if (soundName == "Magma Cube Small 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\magmacube\small4.ogg";
            }
            
            if (soundName == "Magma Cube Small 5")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\magmacube\small5.ogg";
            }

            if (soundName == "Pig Death")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\pig\death.ogg";
            }
            
            if (soundName == "Pig Say 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\pig\say1.ogg";
            }
            
            if (soundName == "Pig Say 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\pig\say2.ogg";
            }
            
            if (soundName == "Pig Say 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\pig\say3.ogg";
            }
            
            if (soundName == "Pig Step 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\pig\step1.ogg";
            }
            
            if (soundName == "Pig Step 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\pig\step2.ogg";
            }
            
            if (soundName == "Pig Step 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\pig\step3.ogg";
            }
            
            if (soundName == "Pig Step 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\pig\step4.ogg";
            }
            
            if (soundName == "Pig Step 5")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\pig\step5.ogg";
            }

            if (soundName == "Sheep Say 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\sheep\say1.ogg";
            }
            
            if (soundName == "Sheep Say 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\sheep\say2.ogg";
            }
            
            if (soundName == "Sheep Say 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\sheep\say3.ogg";
            }
            
            if (soundName == "Sheep Shear")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\sheep\shear.ogg";
            }
            
            if (soundName == "Sheep Step 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\sheep\step1.ogg";
            }
            
            if (soundName == "Sheep Step 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\sheep\step2.ogg";
            }
            
            if (soundName == "Sheep Step 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\sheep\step3.ogg";
            }
            
            if (soundName == "Sheep Step 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\sheep\step4.ogg";
            }
            
            if (soundName == "Sheep Step 5")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\sheep\step5.ogg";
            }

            if (soundName == "Silver Fish Hit 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\silverfish\hit1.ogg";
            }
            
            if (soundName == "Silver Fish Hit 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\silverfish\hit2.ogg";
            }
            
            if (soundName == "Silver Fish Hit 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\silverfish\hit3.ogg";
            }
            
            if (soundName == "Silver Fish Kill")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\silverfish\kill.ogg";
            }
            
            if (soundName == "Silver Fish Say 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\silverfish\say1.ogg";
            }
            
            if (soundName == "Silver Fish Say 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\silverfish\say2.ogg";
            }
            
            if (soundName == "Silver Fish Say 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\silverfish\say3.ogg";
            }
            
            if (soundName == "Silver Fish Say 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\silverfish\say4.ogg";
            }
            
            if (soundName == "Silver Fish Step 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\silverfish\step1.ogg";
            }
            
            if (soundName == "Silver Fish Step 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\silverfish\step2.ogg";
            }

            if (soundName == "Silver Fish Step 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\silverfish\step3.ogg";
            }

            if (soundName == "Silver Fish Step 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\silverfish\step4.ogg";
            }

            if (soundName == "Skeleton Death")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\skeleton\death.ogg";
            }

            if (soundName == "Skeleton Hurt 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\skeleton\hurt1.ogg";
            }

            if (soundName == "Skeleton Hurt 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\skeleton\hurt2.ogg";
            }

            if (soundName == "Skeleton Hurt 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\skeleton\hurt3.ogg";
            }

            if (soundName == "Skeleton Hurt 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\skeleton\hurt4.ogg";
            }

            if (soundName == "Skeleton Say 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\skeleton\say1.ogg";
            }

            if (soundName == "Skeleton Say 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\skeleton\say2.ogg";
            }

            if (soundName == "Skeleton Say 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\skeleton\say3.ogg";
            }

            if (soundName == "Skeleton Step 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\skeleton\step1.ogg";
            }

            if (soundName == "Skeleton Step 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\skeleton\step2.ogg";
            }

            if (soundName == "Skeleton Step 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\skeleton\step3.ogg";
            }

            if (soundName == "Skeleton Step 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\skeleton\step4.ogg";
            }

            if (soundName == "Slime Attack 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\slime\attack1.ogg";
            }

            if (soundName == "Slime Attack 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\slime\attack2.ogg";
            }

            if (soundName == "Slime Big 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\slime\big1.ogg";
            }

            if (soundName == "Slime Big 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\slime\big2.ogg";
            }

            if (soundName == "Slime Big 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\slime\big3.ogg";
            }

            if (soundName == "Slime Big 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\slime\big4.ogg";
            }

            if (soundName == "Slime Small 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\slime\small1.ogg";
            }

            if (soundName == "Slime Small 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\slime\small2.ogg";
            }

            if (soundName == "Slime Small 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\slime\small3.ogg";
            }

            if (soundName == "Slime Small 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\slime\small4.ogg";
            }

            if (soundName == "Slime Small 5")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\slime\small5.ogg";
            }

            if (soundName == "Spider Death")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\spider\death.ogg";
            }

            if (soundName == "Spider Say 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\spider\say1.ogg";
            }

            if (soundName == "Spider Say 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\spider\say2.ogg";
            }

            if (soundName == "Spider Say 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\spider\say3.ogg";
            }

            if (soundName == "Spider Say 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\spider\say4.ogg";
            }

            if (soundName == "Spider Step 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\spider\step1.ogg";
            }

            if (soundName == "Spider Step 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\spider\step2.ogg";
            }

            if (soundName == "Spider Step 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\spider\step3.ogg";
            }

            if (soundName == "Spider Step 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\spider\step4.ogg";
            }

            if (soundName == "Villager Death")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\villager\death.ogg";
            }

            if (soundName == "Villager Haggle 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\villager\haggle1.ogg";
            }

            if (soundName == "Villager Haggle 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\villager\haggle2.ogg";
            }

            if (soundName == "Villager Haggle 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\villager\haggle3.ogg";
            }

            if (soundName == "Villager Hit 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\villager\hit1.ogg";
            }

            if (soundName == "Villager Hit 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\villager\hit2.ogg";
            }

            if (soundName == "Villager Hit 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\villager\hit3.ogg";
            }

            if (soundName == "Villager Hit 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\villager\hit4.ogg";
            }

            if (soundName == "Villager Idle 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\villager\idle1.ogg";
            }

            if (soundName == "Villager Idle 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\villager\idle2.ogg";
            }

            if (soundName == "Villager Idle 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\villager\idle3.ogg";
            }

            if (soundName == "Villager No 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\villager\no1.ogg";
            }

            if (soundName == "Villager No 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\villager\no2.ogg";
            }

            if (soundName == "Villager No 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\villager\no3.ogg";
            }

            if (soundName == "Villager Yes 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\villager\yes1.ogg";
            }

            if (soundName == "Villager Yes 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\villager\yes2.ogg";
            }

            if (soundName == "Villager Yes 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\villager\yes3.ogg";
            }

            if (soundName == "Wither Death")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wither\death.ogg";
            }

            if (soundName == "Wither Hurt 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wither\hurt1.ogg";
            }

            if (soundName == "Wither Hurt 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wither\hurt2.ogg";
            }

            if (soundName == "Wither Hurt 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wither\hurt3.ogg";
            }

            if (soundName == "Wither Hurt 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wither\hurt4.ogg";
            }

            if (soundName == "Wither Idle 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wither\idle1.ogg";
            }

            if (soundName == "Wither Idle 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wither\idle2.ogg";
            }

            if (soundName == "Wither Idle 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wither\idle3.ogg";
            }

            if (soundName == "Wither Idle 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wither\idle4.ogg";
            }

            if (soundName == "Wither Shoot")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wither\shoot.ogg";
            }

            if (soundName == "Wither Spawn")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wither\spawn.ogg";
            }

            if (soundName == "Wolf Bark 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wolf\bark1.ogg";
            }

            if (soundName == "Wolf Bark 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wolf\bark2.ogg";
            }

            if (soundName == "Wolf Bark 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wolf\bark3.ogg";
            }

            if (soundName == "Wolf Death")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wolf\death.ogg";
            }

            if (soundName == "Wolf Growl 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wolf\growl1.ogg";
            }

            if (soundName == "Wolf Growl 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wolf\growl2.ogg";
            }

            if (soundName == "Wolf Growl 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wolf\growl3.ogg";
            }

            if (soundName == "Wolf Howl 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wolf\howl1.ogg";
            }

            if (soundName == "Wolf Howl 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wolf\howl2.ogg";
            }

            if (soundName == "Wolf Hurt 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wolf\hurt1.ogg";
            }

            if (soundName == "Wolf Hurt 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wolf\hurt2.ogg";
            }

            if (soundName == "Wolf Hurt 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wolf\hurt3.ogg";
            }

            if (soundName == "Wolf Panting")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wolf\panting.ogg";
            }

            if (soundName == "Wolf Shake")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wolf\shake.ogg";
            }

            if (soundName == "Wolf Step 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wolf\step1.ogg";
            }

            if (soundName == "Wolf Step 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wolf\step2.ogg";
            }

            if (soundName == "Wolf Step 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wolf\step3.ogg";
            }

            if (soundName == "Wolf Step 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wolf\step4.ogg";
            }

            if (soundName == "Wolf Step 5")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wolf\step5.ogg";
            }

            if (soundName == "Wolf Whine")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\wolf\whine.ogg";
            }

            if (soundName == "Zombie Death")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\death.ogg";
            }

            if (soundName == "Zombie Hurt 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\hurt1.ogg";
            }

            if (soundName == "Zombie Hurt 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\hurt2.ogg";
            }

            if (soundName == "Zombie Infect")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\infect.ogg";
            }

            if (soundName == "Zombie Metal 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\metal1.ogg";
            }

            if (soundName == "Zombie Metal 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\metal2.ogg";
            }

            if (soundName == "Zombie Metal 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\metal3.ogg";
            }

            if (soundName == "Zombie Remedy")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\remedy.ogg";
            }

            if (soundName == "Zombie Say 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\say1.ogg";
            }

            if (soundName == "Zombie Say 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\say2.ogg";
            }

            if (soundName == "Zombie Say 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\say3.ogg";
            }

            if (soundName == "Zombie Step 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\step1.ogg";
            }

            if (soundName == "Zombie Step 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\step2.ogg";
            }

            if (soundName == "Zombie Step 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\step3.ogg";
            }

            if (soundName == "Zombie Step 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\step4.ogg";
            }

            if (soundName == "Zombie Step 5")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\step5.ogg";
            }

            if (soundName == "Zombie Unfect")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\unfect.ogg";
            }

            if (soundName == "Zombie Wood 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\wood1.ogg";
            }

            if (soundName == "Zombie Wood 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\wood2.ogg";
            }

            if (soundName == "Zombie Wood 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\wood3.ogg";
            }

            if (soundName == "Zombie Wood 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\wood4.ogg";
            }

            if (soundName == "Zombie Wood Break")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombie\woodbreak.ogg";
            }

            if (soundName == "Zombie Pigmen 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombiepig\zpig1.ogg";
            }

            if (soundName == "Zombie Pigmen 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombiepig\zpig2.ogg";
            }

            if (soundName == "Zombie Pigmen 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombiepig\zpig3.ogg";
            }

            if (soundName == "Zombie Pigmen 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombiepig\zpig4.ogg";
            }

            if (soundName == "Zombie Pigmen Angry 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombiepig\zpigangry1.ogg";
            }

            if (soundName == "Zombie Pigmen Angry 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombiepig\zpigangry2.ogg";
            }

            if (soundName == "Zombie Pigmen Angry 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombiepig\zpigangry3.ogg";
            }

            if (soundName == "Zombie Pigmen Angry 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombiepig\zpigangry4.ogg";
            }

            if (soundName == "Zombie Pigmen Death")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombiepig\zpigdeath.ogg";
            }

            if (soundName == "Zombie Pigmen Hurt 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombiepig\zpighurt1.ogg";
            }

            if (soundName == "Zombie Pigmen Hurt 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\mob\zombiepig\zpighurt2.ogg";
            }

            if (soundName == "Game Music Calm 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\calm1.ogg";
            }

            if (soundName == "Game Music Calm 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\calm2.ogg";
            }

            if (soundName == "Game Music Calm 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\calm3.ogg";
            }

            if (soundName == "Game Music Hal 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\hal1.ogg";
            }

            if (soundName == "Game Music Hal 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\hal2.ogg";
            }

            if (soundName == "Game Music Hal 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\hal3.ogg";
            }

            if (soundName == "Game Music Hal 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\hal4.ogg";
            }

            if (soundName == "Game Music Nuance 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\nuance1.ogg";
            }

            if (soundName == "Game Music Nuance 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\nuance2.ogg";
            }

            if (soundName == "Game Music Piano 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\piano1.ogg";
            }

            if (soundName == "Game Music Piano 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\piano2.ogg";
            }

            if (soundName == "Game Music Piano 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\piano3.ogg";
            }

            if (soundName == "Creative 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\creative\creative1.ogg";
            }

            if (soundName == "Creative 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\creative\creative2.ogg";
            }

            if (soundName == "Creative 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\creative\creative3.ogg";
            }

            if (soundName == "Creative 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\creative\creative4.ogg";
            }

            if (soundName == "Creative 5")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\creative\creative5.ogg";
            }

            if (soundName == "Creative 6")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\creative\creative6.ogg";
            }

            if (soundName == "End Music Boss")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\end\boss.ogg";
            }

            if (soundName == "End Music Credits")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\end\credits.ogg";
            }

            if (soundName == "End Music The End")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\end\end.ogg";
            }

            if (soundName == "Nether 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\nether\nether1.ogg";
            }

            if (soundName == "Nether 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\nether\nether2.ogg";
            }

            if (soundName == "Nether 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\nether\nether3.ogg";
            }

            if (soundName == "Nether 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\game\nether\nether4.ogg";
            }

            if (soundName == "Menu 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\menu\menu1.ogg";
            }

            if (soundName == "Menu 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\menu\menu2.ogg";
            }

            if (soundName == "Menu 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\menu\menu3.ogg";
            }

            if (soundName == "Menu 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\music\menu\menu4.ogg";
            }

            if (soundName == "Note Bass")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\note\bass.ogg";
            }

            if (soundName == "Note Bass Attack")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\note\bassattack.ogg";
            }

            if (soundName == "Note BD")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\note\bd.ogg";
            }

            if (soundName == "Note Harp")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\note\harp.ogg";
            }

            if (soundName == "Note Hat")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\note\hat.ogg";
            }

            if (soundName == "Note Pling")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\note\pling.ogg";
            }

            if (soundName == "Note Snare")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\note\snare.ogg";
            }

            if (soundName == "Portal Ambient")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\portal\portal.ogg";
            }

            if (soundName == "Portal Travel")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\portal\travel.ogg";
            }

            if (soundName == "Portal Trigger")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\portal\trigger.ogg";
            }
            
            //random
            if (soundName == "Anvil Break")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\anvil_break.ogg";
            }
            
            if (soundName == "Anvil Land")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\anvil_land.ogg";
            }
            
            if (soundName == "Anvil Use")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\anvil_use.ogg";
            }
            
            if (soundName == "Bow")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\bow.ogg";
            }
            
            if (soundName == "Bow Hit 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\bowhit1.ogg";
            }
            
            if (soundName == "Bow Hit 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\bowhit2.ogg";
            }
            
            if (soundName == "Bow Hit 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\bowhit3.ogg";
            }
            
            if (soundName == "Bow Hit 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\bowhit4.ogg";
            }
            
            if (soundName == "Break")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\break.ogg";
            }
            
            if (soundName == "Breath")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\breath.ogg";
            }
            
            if (soundName == "Burp")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\burp.ogg";
            }
            
            if (soundName == "Chest Closed")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\chestclosed.ogg";
            }
            
            if (soundName == "Chest Open")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\chestopen.ogg";
            }
            
            if (soundName == "Classic Hurt")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\classic_hurt.ogg";
            }
            
            if (soundName == "Click")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\click.ogg";
            }
            
            if (soundName == "Door Close")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\door_close.ogg";
            }
            
            if (soundName == "Door Open")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\door_open.ogg";
            }
            
            if (soundName == "Drink")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\drink.ogg";
            }

            if (soundName == "Eat 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\eat1.ogg";
            }
            
            if (soundName == "Eat 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\eat2.ogg";
            }
            
            if (soundName == "Eat 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\eat3.ogg";
            }
            
            if (soundName == "Explode 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\explode1.ogg";
            }
            
            if (soundName == "Explode 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\explode2.ogg";
            }
            
            if (soundName == "Explode 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\explode3.ogg";
            }
            
            if (soundName == "Explode 4")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\explode4.ogg";
            }
            
            if (soundName == "Fizz")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\fizz.ogg";
            }
            
            if (soundName == "Fuse")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\fuse.ogg";
            }
            
            if (soundName == "Glass 1")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\glass1.ogg";
            }
            
            if (soundName == "Glass 2")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\glass2.ogg";
            }
            
            if (soundName == "Glass 3")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\glass3.ogg";
            }

            if (soundName == "Level Up")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\levelup.ogg";
            }
            
            if (soundName == "Orb")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\orb.ogg";
            }
            
            if (soundName == "Pop")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\pop.ogg";
            }
            
            if (soundName == "Splash")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\splash.ogg";
            }
            
            if (soundName == "Successful Hit")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\successful_hit.ogg";
            }
            
            if (soundName == "Wood Click")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\random\wood_click.ogg";
            }

            //records
            if (soundName == "Records 11")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\records\11.ogg";
            }

            if (soundName == "Records 13")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\records\13.ogg";
            }

            if (soundName == "Records Blocks")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\records\blocks.ogg";
            }

            if (soundName == "Records Cat")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\records\cat.ogg";
            }

            if (soundName == "Records Chirp")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\records\chirp.ogg";
            }

            if (soundName == "Records Far")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\records\far.ogg";
            }

            if (soundName == "Records Mall")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\records\mall.ogg";
            }

            if (soundName == "Records Mellohi")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\records\mellohi.ogg";
            }

            if (soundName == "Records Stal")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\records\stal.ogg";
            }

            if (soundName == "Records Strad")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\records\strad.ogg";
            }

            if (soundName == "Records Wait")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\records\wait.ogg";
            }

            if (soundName == "Records Ward")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\records\ward.ogg";
            }

            if (soundName.StartsWith("Cloth Step "))
            {
                string[] tokens = soundName.Split(spaceDelim, StringSplitOptions.None);
                if (tokens.Length == 3)
                {
                    string number = tokens[2];
                    return FrmMain.directory + @"\assets\minecraft\sounds\step\cloth" + number + ".ogg";
                }
            }

            if (soundName.StartsWith("Grass Step "))
            {
                string[] tokens = soundName.Split(spaceDelim, StringSplitOptions.None);
                if (tokens.Length == 3)
                {
                    string number = tokens[2];
                    return FrmMain.directory + @"\assets\minecraft\sounds\step\grass" + number + ".ogg";
                }
            }

            if (soundName.StartsWith("Gravel Step "))
            {
                string[] tokens = soundName.Split(spaceDelim, StringSplitOptions.None);
                if (tokens.Length == 3)
                {
                    string number = tokens[2];
                    return FrmMain.directory + @"\assets\minecraft\sounds\step\gravel" + number + ".ogg";
                }
            }

            if (soundName.StartsWith("Ladder Step "))
            {
                string[] tokens = soundName.Split(spaceDelim, StringSplitOptions.None);
                if (tokens.Length == 3)
                {
                    string number = tokens[2];
                    return FrmMain.directory + @"\assets\minecraft\sounds\step\ladder" + number + ".ogg";
                }
            }

            if (soundName.StartsWith("Sand Step "))
            {
                string[] tokens = soundName.Split(spaceDelim, StringSplitOptions.None);
                if (tokens.Length == 3)
                {
                    string number = tokens[2];
                    return FrmMain.directory + @"\assets\minecraft\sounds\step\sand" + number + ".ogg";
                }
            }

            if (soundName.StartsWith("Snow Step "))
            {
                string[] tokens = soundName.Split(spaceDelim, StringSplitOptions.None);
                if (tokens.Length == 3)
                {
                    string number = tokens[2];
                    return FrmMain.directory + @"\assets\minecraft\sounds\step\snow" + number + ".ogg";
                }
            }

            if (soundName.StartsWith("Stone Step "))
            {
                string[] tokens = soundName.Split(spaceDelim, StringSplitOptions.None);
                if (tokens.Length == 3)
                {
                    string number = tokens[2];
                    return FrmMain.directory + @"\assets\minecraft\sounds\step\stone" + number + ".ogg";
                }
            }

            if (soundName.StartsWith("Wood Step "))
            {
                string[] tokens = soundName.Split(spaceDelim, StringSplitOptions.None);
                if (tokens.Length == 3)
                {
                    string number = tokens[2];
                    return FrmMain.directory + @"\assets\minecraft\sounds\step\wood" + number + ".ogg";
                }
            }

            if (soundName == "Piston In")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\tile\piston\in.ogg";
            }

            if (soundName == "Piston Out")
            {
                return FrmMain.directory + @"\assets\minecraft\sounds\tile\piston\out.ogg";
            }

            return "";
        }
    }
}
