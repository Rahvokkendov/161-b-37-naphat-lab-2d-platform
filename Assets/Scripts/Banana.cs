using UnityEngine;
using UnityEngine.TextCore.Text;

public class Banana : Weapons
{
    [SerializeField] private float speed;
    public override void Move()
    {
        float newX = transform.position.x + speed * Time.fixedDeltaTime;
        float newY = transform.position.y;
        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;
    }
    public override void OnHitWith(Character target)
    {
        if (target is Enemy)
            target.TakeDamage(this.Damage);
    }

    void Start()
    {
        speed = 4.0f * GetShootDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }

}
