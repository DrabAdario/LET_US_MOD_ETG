using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alexandria.ItemAPI;
using UnityEngine;

namespace Mod
{
    class SpicyPepper : PlayerItem
    {
        public static void Register()
        {
            //The name of the item
            string itemName = "Spicy Pepper";

            //Refers to an embedded png in the project. Make sure to embed your resources! Google it
            string resourceName = "LetUsMod/Resources/spicy_pepper";

            //Create new GameObject
            GameObject obj = new GameObject(itemName);

            //Add a PassiveItem component to the object
            var item = obj.AddComponent<SpicyPepper>();

            //Adds a sprite component to the object and adds your texture to the item sprite collection
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);

            //Ammonomicon entry variables
            string shortDesc = "OOW HOT HOT HOT!";
            string longDesc = "This pepper may burn your tounge,\n\n" +
                "but you will permently deal more damage for your pain!";
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
            user.healthHaver.ApplyHealing(-0.5f);

        }
    }
    



}
