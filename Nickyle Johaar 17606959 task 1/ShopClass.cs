using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nickyle_Johaar_17606959_task_1
{
    class ShopClass
    {
        private character purchaser;
        private weaponClass[] weaponSelected;
        private Random select;

        
        public ShopClass(character playerpurchaser)
        {
            
            purchaser = playerpurchaser;
            weaponSelected = new weaponClass[3];
            select = new Random();
            

        }
        //this is the purchase method and checks if the weapon is in store
        public void Buy(int num)
        {
            
            purchaser.GoldPickUp -= weaponSelected[num].CostOfWeapon;
            purchaser.PickUp(weaponSelected[num]);
        }

        //this makes sure that weapon can be bought
        public bool CanBuyWeapon(int num)
        {
            if (purchaser.GoldPickUp >= num)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        



    }
}
