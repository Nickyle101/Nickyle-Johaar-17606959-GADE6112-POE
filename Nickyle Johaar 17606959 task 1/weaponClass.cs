using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nickyle_Johaar_17606959_task_1
{
    class weaponClass:ItemClass
    {
       // this is the weapon class that holds all the protected values
        protected TypeOfWeaponUsed weaponSelectionType;//weapon type
        protected int costOfWeapon;//cost
        protected int weaponDamageAmount;//Damage
        protected string weaponSelected;
        protected int weaponRange;//Range
        protected int weaponDurability;//Durability
        protected string weaponCharacter;

        public weaponClass(string weaponChar, int positionx = 1, int positiony = 1) : base(positionx, positiony, weaponChar)// recieves a symbol and optional x and y position
        {

        }
        public TypeOfWeaponUsed WeaponSelectionType
        {
            get { return weaponSelectionType; }
            set { weaponSelectionType = value; }
        }
        public int WeaponDurability//weapon durability
        {
            get { return weaponDurability; }
            set { weaponDurability = value; }
        }
        public int WeaponImpactRange//weapon range
        {
            get { return weaponRange; }
            set { weaponRange = value; }
        }
        
        public int CostOfWeapon//weapon cost
        {
            get { return costOfWeapon; }
            set { costOfWeapon = value; }
        }
        public string WeaponCharacter
        {
            get { return weaponCharacter; }
            set { weaponCharacter = value; }
        }
        public int WeaponDamageAmount//weapon damage
        {
            get { return weaponDamageAmount; }
            set { weaponDamageAmount = value; }
        }
        
        

        
    }
}
