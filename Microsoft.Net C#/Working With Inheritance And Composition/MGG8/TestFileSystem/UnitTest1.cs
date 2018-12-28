using System;
using MGG8.FileSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFileSystem
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
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

            levelSprites.AddFile(spriteOne);
            levelSprites.AddFile(spriteTwo);
            levelSprites.AddFile(spriteThree);
            levelSprites.AddFile(spriteFour);

            //Act
            gameVideos.AddFile(new File("proverka testa.txt", 100));
            gameVideos.AddFile(new File("proverka testa 222.txt", 100));
            gameVideos.AddFolder(new Folder("popsa"));
            gameVideos.RemoveFile("proverka testa.txt");
            //Assert
        }
    }
}
