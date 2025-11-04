using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public HealthBarUi HealthBar;


    private int maxHealth;

    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = (value > 200 ? 200: value); }
    }

    private int health;
    public int Health 
    { 
      get { return health; } 
      set { health = (value < 0 ? 0 : value); }
    }

    protected Animator anim;
    protected Rigidbody2D rb;




    public void Initialized(int maxHp)
    {
        MaxHealth = maxHp;
        Health = maxHp;
        Debug.Log($"Hp initialized.... in {this.name} || HP : {Health} ||");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        HealthBar.SetMaxHealt(MaxHealth);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} taken {damage} amounts of damage || Current Health is {Health}");
        HealthBar.SetHealth(Health);
        IsDead();
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
