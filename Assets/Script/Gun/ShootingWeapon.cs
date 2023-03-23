namespace Assets.Script.Gun
{
    public abstract class ShootingWeapon : BaseWeapon
    {
        public override void Attack() { }
        public virtual void Recharge() { }
    }
}