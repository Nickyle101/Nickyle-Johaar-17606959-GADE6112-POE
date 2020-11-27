using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nickyle_Johaar_17606959_task_1
{
    class LeaderClass: enemiesClass
    {
        //public override MovementOfCharacter ReturnMove(MovementOfCharacter newMovementLocation = 0)
        //{
        //    MovementOfCharacter movementLocationOnMap = FollowPlayer(newMovementLocation);
        //    if (movementLocationOnMap == MovementOfCharacter.NoMovement)
        //    {
        //        RandomMovement(newMovementLocation);
        //    }

        //    return newMovementLocation;
        //}
        public override string ToString()
        {
            
            string displayoutput;
            if (weaponItem == null)
            {
                displayoutput = "Bare handed leader position at [" + PositionX + "," + PositionY + "] Deals:(" + PlayerDamage + ") HealthPoints:" + PlayerHP + " possess " + GoldPickUp + "gold";
            }
            else
            {
                displayoutput = "Leader current position at [" + PositionX + "," + PositionY + "] Deals:(" + PlayerDamage + ") HealthPoints:" + PlayerHP + "Equiped with " + weaponItem.WeaponSelectionType.ToString() + " possess " + GoldPickUp + "gold";
            }

            return displayoutput;
        }
        public MovementOfCharacter FollowPlayer(MovementOfCharacter leaderMovement = 0)
        {
            int positionxLeader;
            int positionyLeader;
            positionxLeader = base.x - leaderLocation.PositionX;
            positionyLeader = base.y - leaderLocation.PositionY;
            leaderMovement = MovementOfCharacter.NoMovement;

            if (Math.Abs(positionxLeader) >= Math.Abs(positionyLeader))
            {
                if (positionxLeader < 0 && PlayerObserver[2] is emptyTile || PlayerObserver[2] is ItemClass && !(PlayerObserver[2] is HeroClass))
                {
                    if (PlayerObserver[2] is ItemClass)
                    {
                        PickUp(PlayerObserver[2] as ItemClass);
                    }
                    leaderMovement = MovementOfCharacter.Right;
                    base.x++;
                }

                if (positionxLeader > 0 && PlayerObserver[0] is emptyTile || PlayerObserver[0] is ItemClass && !(PlayerObserver[0] is HeroClass))
                {
                    if (PlayerObserver[0] is ItemClass)
                    {
                        PickUp(PlayerObserver[0] as ItemClass);
                    }
                    leaderMovement = MovementOfCharacter.Left;
                    base.x--;
                }

            }
            if (Math.Abs(positionyLeader) > Math.Abs(positionxLeader))
            {
                if (positionyLeader < 0 && PlayerObserver[1] is emptyTile || PlayerObserver[1] is ItemClass && !(PlayerObserver[1] is HeroClass))
                {
                    if (PlayerObserver[1] is ItemClass)
                    {
                        PickUp(PlayerObserver[1] as ItemClass);
                    }
                    leaderMovement = MovementOfCharacter.Up;
                    base.y++;
                }
                if (positionyLeader > 0 && PlayerObserver[3] is emptyTile || PlayerObserver[3] is ItemClass && !(PlayerObserver[3] is HeroClass))
                {
                    if (PlayerObserver[3] is ItemClass)
                    {
                        PickUp(PlayerObserver[3] as ItemClass);
                    }
                    leaderMovement = MovementOfCharacter.Down;
                    base.y--;
                }
            }
            return leaderMovement;
        }

        public LeaderClass(int positionx, int positiony, HeroClass target, int playerdamage = 2, string characterS = "L", int playerhp = 20) : base(positionx, positiony, characterS, playerdamage, playerhp)
        {

            leaderLocation = target;
            base.weaponItem = new meleeweaponClass(TypeOfWeaponUsed.LongSword, "LS");
            base.playerDamage = playerdamage;
            base.playerHP = playerhp;
            base.goldPickUp = 2;
            base.x = positionx;
            base.y = positiony;
            base.s = characterS;

        }
        //this methods makes the leader follow after the player

        public MovementOfCharacter RandomMovement(MovementOfCharacter newMovementLocation = 0)
        {
            int directionRandom = select.Next(0, 4);
            newMovementLocation = MovementOfCharacter.NoMovement;

            while (newMovementLocation == MovementOfCharacter.NoMovement)
            {
                if (directionRandom == 0)
                {
                    if (PlayerObserver[0] is emptyTile || PlayerObserver[0] is ItemClass && !(PlayerObserver[0] is HeroClass))
                    {
                        if (PlayerObserver[0] is ItemClass)
                        {
                            PickUp(PlayerObserver[0] as ItemClass);
                        }
                        newMovementLocation = MovementOfCharacter.Left;
                        PositionX--;
                    }
                    else
                    {
                        directionRandom = select.Next(0, 4);
                    }
                }
                else if (directionRandom == 1)
                {
                    if (PlayerObserver[1] is emptyTile || PlayerObserver[1] is ItemClass && !(PlayerObserver[1] is HeroClass))
                    {
                        if (PlayerObserver[1] is ItemClass)
                        {
                            PickUp(PlayerObserver[1] as ItemClass);
                        }
                        newMovementLocation = MovementOfCharacter.Up;
                        PositionY--;
                    }
                    else
                    {
                        directionRandom = select.Next(0, 4);
                    }
                }
                else if (directionRandom == 2)
                {
                    if (PlayerObserver[2] is emptyTile || PlayerObserver[2] is ItemClass && !(PlayerObserver[2] is HeroClass))
                    {
                        if (PlayerObserver[2] is ItemClass)
                        {
                            PickUp(PlayerObserver[2] as ItemClass);
                        }
                        newMovementLocation = MovementOfCharacter.Right;
                        PositionX++;
                    }
                    else
                    {
                        directionRandom = select.Next(0, 4);
                    }
                }
                else if (directionRandom == 3)
                {
                    if (PlayerObserver[3] is emptyTile || PlayerObserver[3] is ItemClass && !(PlayerObserver[3] is HeroClass))
                    {
                        if (PlayerObserver[3] is ItemClass)
                        {
                            PickUp(PlayerObserver[3] as ItemClass);
                        }
                        newMovementLocation = MovementOfCharacter.Down;
                        PositionY++;
                    }
                    else
                    {
                        directionRandom = select.Next(0, 4);
                    }
                }
                else
                {
                    newMovementLocation = MovementOfCharacter.NoMovement;
                }
            }
            return newMovementLocation;
        }

        private Tile leaderLocation;
        public Tile LeaderLocation
        {
            get { return leaderLocation; }
            set { leaderLocation = value; }
        }


    }
}
