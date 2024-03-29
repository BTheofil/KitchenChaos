using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject {

    public event EventHandler<OnIngrediendAddedEventArgs> OnIngrediendAdded;
    public class OnIngrediendAddedEventArgs : EventArgs {
        public KitchenObjectSO kitchenObjectSO;
    }

    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;

    private List<KitchenObjectSO> kitchenObjectSOList;

    private void Awake() {
        kitchenObjectSOList = new List<KitchenObjectSO>();  
    }

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO) {
        if (!validKitchenObjectSOList.Contains(kitchenObjectSO)) {
            //not valid
            return false;
        }

        if (kitchenObjectSOList.Contains(kitchenObjectSO)) {
            //already has this type
            return false;
        } else {
            kitchenObjectSOList.Add(kitchenObjectSO);

            OnIngrediendAdded?.Invoke(this, new OnIngrediendAddedEventArgs {
                kitchenObjectSO = kitchenObjectSO
            });

            return true;
        }
    }

    public List<KitchenObjectSO> GetKitchenObjectSOList() {
        return kitchenObjectSOList;
    }
}
