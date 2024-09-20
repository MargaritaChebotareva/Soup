using Assets.Scripts.Core.Entities;
using System.Collections.Generic;

namespace Assets.Scripts.Core.UseCases
{
    public class PrepareMealResult
    {
        public bool IsSucces { get; }
        public List<Recipe> Meals { get; }
        public PrepareMealResult(bool isSucces, List<Recipe> meals)
        {
            IsSucces = isSucces;
            Meals = meals;
        }
    }

}
