using Assets.Scripts.Core.Output;
using Assets.Scripts.Core.UseCases;
using Assets.Scripts.Core.UseCases.Requests;
using Assets.Scripts.Core.UseCases.Responses;
using System;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class IngredientController
    {
        private BuyIngredient buyIngredient;
        private IPresenter presenter;
        public event Action<BuyIngredientResponse> OnBoughtIngredient;
        public IngredientController(BuyIngredient buyIngredient, IPresenter presenter)
        {
            this.buyIngredient = buyIngredient;
            this.presenter = presenter;
            presenter.OnBuyIngredientResponse += OnBuyIngredientResponse;
            Debug.Log($"{nameof(IngredientController)} was created");
        }

        private void OnBuyIngredientResponse(BuyIngredientResponse response)
        {
            OnBoughtIngredient?.Invoke(response);
        }

        public void ClickOnIngredient(int id)
        {
            buyIngredient.Execute(new BuyIngredientRequest(id));
        }

    }
}