using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nickyle_Johaar_17606959_task_1
{
    class meleeweaponClass: weaponClass
    {
        //this the melee weapon class
        public enum MeleeWeapons
        {
            LongSword,
            Dagger
        }

        // this implements the change of weapons on the mao when the player moves over them
        public override string ToString()
        {
            return "MeleeWeapon located at position [" + PositionX + "," + PositionY + "] Dealt Damage:(" + WeaponDamageAmount + ")";
        }
        public meleeweaponClass(TypeOfWeaponUsed weaponSelectionType, string characterS, int positionx = 1, int positiony = 1) : base(characterS, positionx, positiony)
        {

           
            if (weaponSelectionType == TypeOfWeaponUsed.LongSword)
            {
                base.weaponSelectionType = TypeOfWeaponUsed.LongSword;
                weaponDurability = 6;
                weaponDamageAmount = 4;
                costOfWeapon = 5;
                base.weaponRange = 1;
                weaponSelected = "Longsword";
            }
            if (weaponSelectionType == TypeOfWeaponUsed.Dagger)
            {
                base.weaponSelectionType = TypeOfWeaponUsed.Dagger;
                weaponDurability = 10;
                weaponDamageAmount = 3;
                costOfWeapon = 3;
                base.weaponRange = 1;
                weaponSelected = "Dagger";

            }

            TypeOfWeaponSelected = weaponSelectionType;

        }

        public TypeOfWeaponUsed TypeOfWeaponSelected;

       
    }
}
