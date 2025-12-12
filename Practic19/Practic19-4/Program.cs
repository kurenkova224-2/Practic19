using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic19_4
{
    internal class Program
    {
        public class HeroIsDeadException : Exception
        {
            public HeroIsDeadException(int health)
            : base($"Герой погиб! Здоровье стало {health}")
            {
            }
        }

        public class Game
        {
            public int Health { get; private set; }

            public Game(int initialHealth)
            {
                Health = initialHealth;
            }

            public void TakeDamage(int damage)
            {
                Console.WriteLine($"Здоровье: {Health}");
                Console.WriteLine($"Получаем урон: {damage}");

                Health -= damage;

                if (Health <= 0)
                {
                    throw new HeroIsDeadException(Health);
                }

                Console.WriteLine($"Здоровье после получения урона: {Health}");
            }
        }
        static void Main(string[] args)
        {
            Game game = new Game(100);

            try
            {
                game.TakeDamage(150); // Урон больше текущего здоровья
            }
            catch (HeroIsDeadException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            // Дополнительная проверка с меньшим уроном
            try
            {
                game.TakeDamage(30); // Урон меньше текущего здоровья
                game.TakeDamage(50); // Урон, который не убивает героя
                game.TakeDamage(20); // Урон, который убивает героя
            }
            catch (HeroIsDeadException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
