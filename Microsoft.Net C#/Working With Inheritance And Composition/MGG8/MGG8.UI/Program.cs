using MGG8.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGG8.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            File file = new File();
            file.Extension = file.FileName;
            Folder root = new Folder("Games");

            Folder skyrim = new Folder("Skyrim");

            Folder gameVideos = new Folder("videos");
            Folder gameLevels = new Folder("game_levels");

            root.AddFolder(skyrim);
            skyrim.AddFolder(gameVideos);
            skyrim.AddFolder(gameLevels);
   
            Folder levelSprites = new Folder("level_sprites");

            gameLevels.AddFolder(levelSprites);

            File spriteOne = new File("levelOneSprite.spr", 10000);
            File spriteTwo = new File("levelTwoSprite.spr", 20000);
            File spriteThree = new File("levelThreeSprite.spr", 20000);
            File spriteFour = new File("levelFourSprite.spr", 30000);

            File introVideo = new File("intro.mp4", 300000);
            File endingVideo = new File("ending.mp4", 200000);

            File gameConfigurationFile = new File("game_settings.config", 1000);
            File saveRecordsFile = new File("saves.config", 2000);

            levelSprites.AddFile(spriteOne);
            levelSprites.AddFile(spriteTwo);
            levelSprites.AddFile(spriteThree);
            levelSprites.AddFile(spriteFour);

            gameVideos.AddFile(introVideo);
            gameVideos.AddFile(endingVideo);

            skyrim.AddFile(gameConfigurationFile);
            skyrim.AddFile(saveRecordsFile);



            Console.WriteLine(skyrim.FolderSize);

            Console.ReadLine();
        }
    }
}
