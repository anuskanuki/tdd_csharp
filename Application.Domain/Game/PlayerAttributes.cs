using System;
using System.Collections.Generic;


namespace Application.Domain
{
    public class PlayerAttributes
    {

        /* Player Attributes */
        public int Life { get; set; }

        public string Name { get; set; }

        public string NickName { get; set; }

        public bool IsNewPlayer { get; set; }

        public List<string> Weapons { get; set; }


        /* Constructor class */
        public PlayerAttributes()
        {
            Name = CreateNames();

            IsNewPlayer = true;

            CreateWeapons();
        }

        /* This method increases the player life */
        public void Sleep()
        {
            var random = new Random();

            // increase player life: 20/45/100
            var increaseLife = random.Next(1, 101);

            Life += increaseLife;
        }

        /* This method subtract the player life*/
        public void LostLife(int lostLife)
        {
            Life = Math.Max(1, Life -= lostLife);
        }

        /* This method creates the player name randomly*/
        private string CreateNames()
        {
            var names = new[]
            {
                "Spider Man",
                "Iron Man",
                "Captain America",
                "Ant Man",
                "Hulk",
                "The Flash"
            };

            return names[new Random().Next(0, names.Length)];
        }

        /* This Method lists all the weapons availables to the players*/
        private void CreateWeapons()
        {
            Weapons = new List<string>()
            {
                "Agility",
                "Agility Strength",
                "AK-47",
                "Artificial Intelligence",
                // "Fly"
                // "Strength",
                "Strength"
            };
        }
    }
}
