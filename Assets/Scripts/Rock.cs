using UnityEngine;

public class Rock : Weapons
{
    public Rigidbody2D Rb;
    public Vector2 Force;
    public override void Move()
    {
        Rb.AddForce(Force);
    }
    public override void OnHitWith(Character target)
    {
        if (target is Player)
            target.TakeDamage(this.Damage);
    }

    void Start()
    {
        Force = new Vector2(GetShootDirection() * 90, 350);
        Move();
    }

 

}
