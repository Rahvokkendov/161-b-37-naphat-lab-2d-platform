using UnityEngine;

public abstract class Character : MonoBehaviour
{

    private int health;
    public int Health 
    { 
      get { return health; } 
      set { health = (value < 0 ? 0 : value); }
    }

    protected Animator anim;
    protected Rigidbody2D rb;




    public void Initialized(int defaultHp)
    {
        Health = defaultHp;
        Debug.Log($"Hp initialized.... in {this.name} || HP : {defaultHp} ||");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} taken {damage} amounts of damage || Current Health is {Health}");

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
