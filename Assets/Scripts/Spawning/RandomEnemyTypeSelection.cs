using System;

namespace Spawning
{
    /// <summary>
    /// Выбор типа врага случайным образом
    /// </summary>
    public class RandomEnemyTypeSelection : ITypeSelection
    {
        Random _randomizer;

        public RandomEnemyTypeSelection()
        {
            _randomizer = new Random();
        }

        public string SelectType()
        {
            return ChooseEnemyType();
        }

        private string ChooseEnemyType()
        {
            int generationValue = _randomizer.Next(1, 101);

            if (generationValue >= 90) return "UFO";
            else return "Asteroid";
        }
    }
}