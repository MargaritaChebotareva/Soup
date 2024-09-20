using Assets.Scripts.Core.Entities;
using System.Collections.Generic;

namespace Assets.Scripts.Core.UseCases
{
    public class PrepareDishResult
    {
        public bool IsSucces { get; }
        public List<Recipe> Dishes { get; }
        public PrepareDishResult(bool isSucces, List<Recipe> dishes)
        {
            IsSucces = isSucces;
            Dishes = dishes;
        }
    }

}
