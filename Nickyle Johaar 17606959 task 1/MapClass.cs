﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nickyle_Johaar_17606959_task_1
{
    [Serializable]
    class MapClass
    {
        public Tile[,] gameMap;
        public enemiesClass[] playerEnemies;
        public Random roll = new Random();
        private int heightOfGameMap;
        private int widthOfGameMap;
        private int numberOfenemies;
        private HeroClass playerCharacter;
        public ItemClass[] item;

        public int HeightOfGameMap
        {
            get { return heightOfGameMap; }
            set { heightOfGameMap = value; }
        }
        public int WidthOfGameMap
        {
            get { return widthOfGameMap; }
            set { widthOfGameMap = value; }
        }
        public int NumberOfEnemies
        {
            get { return numberOfenemies; }
            set { numberOfenemies = value; }
        }
        public HeroClass PlayerCharacter
        {
            get { return playerCharacter; }
            set { playerCharacter = value; }
        }
        //this is the create method, the reason i call it create tile instead of create() is because it was easier for me to understand when using it
        private Tile CreateTile(TileType tiletype)
        {
            int randomizedPositionx = roll.Next(0, WidthOfGameMap);
            int randomizedpositiony = roll.Next(0, HeightOfGameMap);

            while (gameMap[randomizedPositionx, randomizedpositiony] is Obstacle || gameMap[randomizedPositionx, randomizedpositiony] is character || gameMap[randomizedPositionx, randomizedpositiony] is ItemClass)
            {
                randomizedPositionx = roll.Next(0, WidthOfGameMap);
                randomizedpositiony = roll.Next(0, HeightOfGameMap);
            }
            if (tiletype == TileType.Hero)
            {
                playerCharacter = new HeroClass(randomizedPositionx, randomizedpositiony, 100);
                return playerCharacter;
            }
            //places weapons on map i used the same approach i took with placement of enemies as seen below
            // This also allows weapons to switch when the player comes into cotact with a new weapon
            else if (tiletype == TileType.Weapon)
            {
                int locationOfWeaponsOnMap = roll.Next(1, 5);

                if (locationOfWeaponsOnMap == 1)
                {
                    return new RangedWeaponClass(TypeOfWeaponUsed.LongBow, "LB", randomizedPositionx, randomizedpositiony);
                }
                else if (locationOfWeaponsOnMap == 2)
                {
                    return new RangedWeaponClass(TypeOfWeaponUsed.Rifle, "R", randomizedPositionx, randomizedpositiony);
                }
                else if (locationOfWeaponsOnMap == 3)
                {
                    return new meleeweaponClass(TypeOfWeaponUsed.Dagger, "DG", randomizedPositionx, randomizedpositiony);
                }
                else
                {
                    return new meleeweaponClass(TypeOfWeaponUsed.LongSword, "LS", randomizedPositionx, randomizedpositiony);
                }
            }
            else if (tiletype == TileType.Enemy)
            {
                int locationOfenemiesOnMap = roll.Next(1, 4);
                if (locationOfenemiesOnMap == 1)
                {
                    return new GoblinClass(randomizedPositionx, randomizedpositiony);
                }
                else if(locationOfenemiesOnMap==2)
                {
                    return new MageClass(randomizedPositionx, randomizedpositiony);
                }
                // this allows the leader to spawn on the map
                else
                {
                    return new LeaderClass(randomizedPositionx, randomizedpositiony, playerCharacter);
                }
            }
            
            //this spawns the gold with the game
            else
            {
                return new GoldClass(randomizedPositionx, randomizedpositiony);
            }

        }
        public void MapFullUpdate()
        {
            for (int x = 0; x < WidthOfGameMap; x++)
            {
                for (int y = 0; y < HeightOfGameMap; y++)
                {
                    gameMap[x, y] = new emptyTile(x, y);
                }
            }
        }
        //this is the map update method
        public void MapUpdater()
        {
            MapInitialization();
            gameMap[playerCharacter.PositionX, playerCharacter.PositionY] = playerCharacter;

            foreach (enemiesClass enemySelect in playerEnemies)
            {
                if (enemySelect.IsDead() == false)
                {
                    gameMap[enemySelect.PositionX, enemySelect.PositionY] = enemySelect;
                }
            }
            foreach (ItemClass gold in item)
            {
                if (gold != null)
                {
                    gameMap[gold.PositionX, gold.PositionY] = gold;
                }
            }
        }
        //this is the map initialize method
        public void MapInitialization()
        {
            for (int x = 0; x < WidthOfGameMap; x++)
            {
                for (int y = 0; y < HeightOfGameMap; y++)
                {
                    gameMap[x, y] = new emptyTile(x, y);
                }
            }
            GenerateOB();
        }
        //This the constructer within the game
        public MapClass(int minWidth, int maxWidth, int minHeight, int maxHeight, int numberOfenemies, int amountOfItems)
        {
            this.WidthOfGameMap = roll.Next(minWidth, maxWidth);
            this.HeightOfGameMap = roll.Next(minHeight, maxHeight);
            this.NumberOfEnemies = numberOfenemies;

            item = new ItemClass[amountOfItems];
            gameMap = new Tile[WidthOfGameMap, HeightOfGameMap];
            playerEnemies = new enemiesClass[NumberOfEnemies];

            MapFullUpdate();
            MapInitialization();

            Tile characterHero = CreateTile(TileType.Hero);
            gameMap[playerCharacter.PositionX, playerCharacter.PositionY] = characterHero;


            for (int i = 0; i < playerEnemies.Length; i++)
            {
                playerEnemies[i] = (enemiesClass)CreateTile(TileType.Enemy);
                gameMap[playerEnemies[i].PositionX, playerEnemies[i].PositionY] = playerEnemies[i];
            }
            for (int i = 0; i < item.Length; i++)
            {
                int locationsOfItems = roll.Next(1, 3);
                if (locationsOfItems == 1)
                {
                    item[i] = (ItemClass)CreateTile(TileType.Gold);
                }
                if (locationsOfItems == 2)
                {
                    item[i] = (ItemClass)CreateTile(TileType.Weapon);
                }
                
                gameMap[item[i].PositionX, item[i].PositionY] = item[i];
            }
            VisionUpdater();
        }
        //this controls the item position on the map and the item pick up
        public ItemClass GetItemAtPosition(int x, int y)
        {
            ItemClass itemcollected = null;
            for (int j = 0; j < item.Length; j++)
            {
                if (item[j] != null)
                {
                    if (item[j].PositionX == x && item[j].PositionY == y)
                    {
                        itemcollected = item[j];
                        item[j] = null;
                    }
                }
            }
            return itemcollected;
        }
        //this the spawning method
        public void GenerateOB()
        {
            for (int x = 0; x < WidthOfGameMap; x++)
            {
                for (int y = 0; y < HeightOfGameMap; y++)
                {
                    if (x == 0 || y == 0 || x == WidthOfGameMap - 1 || y == HeightOfGameMap - 1)
                    {
                        gameMap[x, y] = new Obstacle(x, y, "X");
                    }
                }
            }
        }


        //this is the vision update method
        public void VisionUpdater()
        {
            playerCharacter.PlayerObserver[0] = gameMap[playerCharacter.PositionX - 1, playerCharacter.PositionY];
            playerCharacter.PlayerObserver[1] = gameMap[playerCharacter.PositionX, playerCharacter.PositionY - 1];
            playerCharacter.PlayerObserver[2] = gameMap[playerCharacter.PositionX + 1, playerCharacter.PositionY];
            playerCharacter.PlayerObserver[3] = gameMap[playerCharacter.PositionX, playerCharacter.PositionY + 1];

            foreach (enemiesClass enemySelect in playerEnemies)
            {
                enemySelect.PlayerObserver[0] = gameMap[enemySelect.PositionX - 1, enemySelect.PositionY];
                enemySelect.PlayerObserver[1] = gameMap[enemySelect.PositionX, enemySelect.PositionY - 1];
                enemySelect.PlayerObserver[2] = gameMap[enemySelect.PositionX + 1, enemySelect.PositionY];
                enemySelect.PlayerObserver[3] = gameMap[enemySelect.PositionX, enemySelect.PositionY + 1];
            }
        }

    }
}
