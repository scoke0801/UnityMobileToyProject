using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Budy : MonoBehaviour
{
    [SerializeField]
    protected Status status;

    [SerializeField] 
    private BudyAttack budyAct; 

    // Start is called before the first frame update
    void Start()
    { 
        budyAct = new BudyCarrierAttack(this, 7);
        //budyAct = new BudyAtomAttack(this, 5);  
    } 
 
    void Update()
    {
       budyAct.Update();
    } 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            budyAct.DoAttack(other);
        } 
    }

    public void ChangeBudyAct()
    {
        this.budyAct = new BudyAttack(this);
    }
    public void ChangeBudyForwardAttack()
    { 
        this.budyAct = new BudyForwardAttack( this );
    }

    public void ChangeBudyCarrierAttack()
    {
        this.budyAct = new BudyCarrierAttack(this, 7);
    }
}
