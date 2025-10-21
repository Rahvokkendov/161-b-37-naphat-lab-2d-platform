using UnityEngine;

public class Crocodile : Enemy
{
    [SerializeField] float atkRange;
    public Player Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Initialized(80);
        DamageHit = 20;

        atkRange = 6.0f;
        Player = GameObject.FindFirstObjectByType<Player>();
    }

    public override void Behavior()
    {
        Vector2 distance = transform.position - Player.transform.position;

        if (distance.magnitude <= atkRange)
        {
            Debug.Log($"{Player.name} is in {this.name} range");
        }
        Shoot();
    }

    public void Shoot()
    {
        Debug.Log($"{this.name} is trowing rocks at {Player.name}");
    }


    private void FixedUpdate()
    {
        Behavior();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
