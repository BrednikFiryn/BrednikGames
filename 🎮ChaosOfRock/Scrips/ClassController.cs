using UnityEngine;

public class ClassController : MonoBehaviour
{

    public Movement Movement_;
    public WeaponShoot _WeaponShoot;
    public Reload _Reload;
    public ExpBar _ExpBar;
    public HealthBar _HealthBar;
    public InterfaceController _Interface;
    public AnimMovement _AnimMovement;
    public Elevator _Elevator;
    public BridgeActive _BridgeActive;
    public Thorns _Thorns;
    public TrapCrystal _TrapCrystal;
    public FireTick _FireTick;

    private void Update()
    {
        ClassContr();
    }

    /// <summary>
    /// ”правление классами
    /// </summary>
    private void ClassContr()
    {
        _Elevator = FindObjectOfType<Elevator>();
        _AnimMovement = FindObjectOfType<AnimMovement>();
        _Interface = FindObjectOfType<InterfaceController>();
        _HealthBar = FindObjectOfType<HealthBar>();
        _ExpBar = FindObjectOfType<ExpBar>();
        _Reload = FindObjectOfType<Reload>();
        _WeaponShoot = FindObjectOfType<WeaponShoot>();
        Movement_ = FindObjectOfType<Movement>();
        _BridgeActive = FindObjectOfType<BridgeActive>();
        _Thorns = FindObjectOfType<Thorns>();
        _TrapCrystal = FindObjectOfType<TrapCrystal>();
    }
}
