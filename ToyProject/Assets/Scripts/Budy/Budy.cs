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
        budyAct = new BudyAttack(this);
    } 

    // Update is called once per frame
    void Update()
    {
        budyAct.Update();
    } 

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject.tag == "Monster")
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
}
