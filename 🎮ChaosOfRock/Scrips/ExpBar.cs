using UnityEngine.UI;
using UnityEngine;

public class ExpBar : MonoBehaviour
{
    public float Exp, Explvl;
    public float ExplvlMax;
    public bool isExp;

    void Start()
    {
        isExp = false;
    }

    void Update()
    {
        ExpCount();
    }

    void ExpCount()
    {
            Explvl += Exp;
    }
}

