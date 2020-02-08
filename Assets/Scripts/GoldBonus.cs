using UnityEngine;


public class GoldBonus : Bonus
{
    [SerializeField] private int gold = 1;
    
    protected override void PickUpBonus()
    {
        base.PickUpBonus();
        Debug.Log($"Added {gold}  gold");
        GameController.Gold += gold;
    }
}