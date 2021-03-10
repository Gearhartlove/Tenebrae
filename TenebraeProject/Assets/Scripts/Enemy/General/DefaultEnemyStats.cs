using System;
using UnityEngine;
namespace Enemy
{
    public class DefaultEnemyStats : MonoBehaviour
    {
        //fields

        //Stats
        public virtual float MaxHP {
            get { return 100; }
            set { MaxHP = value; }
        }
        public float CurrentHPValue;

        private void Awake()
        {
            CurrentHPValue = MaxHP;
        }

        //get stat type on enemy using switch statement
        //add cases for new enemies in the Game
        public static DefaultEnemyStats GetStatType()
        {
            var S = GameObject.GetComponent<Bar>();
            //S ??= this.GetComponent<Raven>(); //if null, assign
            switch (S.type)
            {
                case "Bar":
                    Debug.Log("Rawww, I'm a bear");
                    BarStats BarStats = new BarStats();
                    return BarStats;

                default: return null;
            }
        }
    }

    public class BarStats : DefaultEnemyStats
    {
       public override float MaxHP
       {
            get => 200;
            set => MaxHP = value;
       }
    }

}
