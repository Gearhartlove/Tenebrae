using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeInventory : MonoBehaviour
{
    Item item1 = new Item("Ogre Cudgle", 17, 1600);
    Item item2 = new Item("Wooden Dagger", 1, 1);

    private void Start()
    {
        Item[] itemArray2 = { item1, item2 };
    }



    private class Item
    {
        public string Name;
        public int ItemLevel;
        public int Cost;

        //Discovered Item
        public Item(string name, int itemLevel, int cost)
        {
            Name = name;
            ItemLevel = itemLevel;
            Cost = cost;
        }

        public void DisplayInfo()
        {
            Debug.Log("Name: " + Name + " " +
                "Item Level: " + ItemLevel + " " +
                "Cost: " + Cost);
        }
    }
}
