using UnityEngine;

public class Crocodile : Enemy, IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaiTime { get; set; }

    [SerializeField] float atkRange;
    public Player Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Initialized(80);
        DamageHit = 20;

        atkRange = 6.0f;
        Player = GameObject.FindFirstObjectByType<Player>();
        ReloadTime = 2.0f;
        WaiTime = 0.0f;
    }

   
  

    public override void Behavior()
    {
        Vector2 distance = transform.position - Player.transform.position;

        if (distance.magnitude <= atkRange && WaiTime >= ReloadTime)
        {
            Debug.Log($"{Player.name} is in {this.name} range");
            Shoot();
        }
        
    }

    public void Shoot()
    {
        var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
        Rock rock = bullet.GetComponent<Rock>();
        Debug.Log($"{this.name} is trowing rocks at {Player.name}");
        rock.InitWeapon(20, this);
        WaiTime = 0.0f;
    }


    private void FixedUpdate()
    {
        Behavior();
        WaiTime += Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
