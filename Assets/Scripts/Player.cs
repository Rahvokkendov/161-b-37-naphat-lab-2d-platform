using UnityEngine;

public class Player : Character, IShootable
{
    [field: SerializeField] public GameObject Bullet { get ; set ; }
    [field: SerializeField] public Transform ShootPoint { get ; set ; }
    public float ReloadTime { get ; set ; }
    public float WaiTime { get ; set ; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Initialized(50);
        ReloadTime = 1.0f;
        WaiTime = 0.0f;
    }

    private void FixedUpdate()
    {
        WaiTime += Time.fixedDeltaTime;
    }


    public void OnHitWith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
      Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            OnHitWith(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if(Input.GetButtonDown("Fire1") && WaiTime >= ReloadTime)
        {
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Banana banana = bullet.GetComponent<Banana>();
            if (banana != null)
            {
                banana.InitWeapon(20, this);
            }
            WaiTime = 0.0f;
        }
    }
}
