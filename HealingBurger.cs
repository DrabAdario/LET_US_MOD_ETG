using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alexandria.ItemAPI;
using UnityEngine;

namespace Mod
{
    class HealingBurger : PlayerItem
    {
        public static void Register()
        {
            //The name of the item
            string itemName = "Healing Burger";

            //Refers to an embedded png in the project. Make sure to embed your resources! Google it
            string resourceName = "LetUsMod/Resources/hamBurg";

            //Create new GameObject
            GameObject obj = new GameObject(itemName);

            //Add a PassiveItem component to the object
            var item = obj.AddComponent<HealingBurger>();

            //Adds a sprite component to the object and adds your texture to the item sprite collection
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);

            //Ammonomicon entry variables
            string shortDesc = "yummy burger!";
            string longDesc = "This burger will heal you,\n\n" +
                "you WILL HAVE A EXTRA HEART!";
            ItemBuilder.SetupItem(item, shortDesc, longDesc, "Item");

            //Adds the item to the gungeon item list, the ammonomicon, the loot table, etc.
            //Do this after ItemBuilder.AddSpriteToObject!
            ItemBuilder.SetCooldownType(item, ItemBuilder.CooldownType.None, 0f);

            item.consumable = true;
        }
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
        }
        public override void DoEffect(PlayerController user)
        {
            user.healthHaver.ApplyHealing(1f);


        }
    }
    



}
