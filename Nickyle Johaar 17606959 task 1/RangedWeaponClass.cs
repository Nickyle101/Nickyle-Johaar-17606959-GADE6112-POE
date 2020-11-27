using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nickyle_Johaar_17606959_task_1
{
    class RangedWeaponClass: weaponClass
    {
        public enum RangedWeapons
        {
            LongBow,
            Rifle
        }

        public override string ToString()
        {
            return "Ranged Weapon located at position [" + PositionX + "," + PositionY + "] Dealt Damage:(" + WeaponDamageAmount + ")";
        }
      

        public RangedWeaponClass(TypeOfWeaponUsed weaponSelectionType, string characterS = "I", int posistionx = 1, int posistiony = 1) : base(characterS, posistionx, posistiony)
        {
            if (weaponSelectionType == TypeOfWeaponUsed.Rifle)
            {
                weaponSelectionType = TypeOfWeaponUsed.Rifle;
                weaponDurability = 3;
                base.weaponRange = 3;
                weaponDamageAmount = 5;
                costOfWeapon = 7;
                weaponSelected = "Rifle";
            }
            if (weaponSelectionType == TypeOfWeaponUsed.LongBow)
            {
                weaponSelectionType = TypeOfWeaponUsed.LongBow;
                base.weaponRange = 2;
                weaponDamageAmount = 4;
                costOfWeapon = 6;
                weaponDurability = 4;
                weaponSelected = "LongBow";

            }
            

            typeOfWeaponSelected = weaponSelectionType;

        }

        public TypeOfWeaponUsed typeOfWeaponSelected;

        
    }
}
