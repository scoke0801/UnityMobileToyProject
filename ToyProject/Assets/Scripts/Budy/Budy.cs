using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Budy : MonoBehaviour
{
    [SerializeField]
    protected Status status;

    [SerializeField] 
    private BudyAct budyAct;

    // Start is called before the first frame update
    void Start()
    {
        budyAct = new BudyAct(this);
    } 

    // Update is called once per frame
    void Update()
    {
        budyAct.Update();
    } 

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject.name == "Chicken(Clone)")
        {
            budyAct.DoAttack(other);
        }
        else if (other.gameObject.name == "Condor(Clone)")
        {
            budyAct.DoAttack(other);
        }
    }

    public void ChangeBudyAct()
    {
        this.budyAct = new BudyAct(this);
    }
    public void ChangeBudyForwardAttack()
    { 
        this.budyAct = new BudyForwardAttack( this );
    }
}
