using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxhealth = 100;
    public int currentHealth { get; private set; } //any class can get the value only change it in this class

    public event System.Action<int, int> OnHealthChanged;

    private void Awake()
    {
        currentHealth = maxhealth; //initial value

    }

    public void Heal(int healing)
    { 
        currentHealth += Mathf.Clamp(healing, 1, maxhealth); //prevents excessive Health

        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxhealth, currentHealth);
        }
    }

    public virtual void Die()
    {
        //Die in some way, should be overriden
       // Debug.Log(transform.name + " died.");

    }
}
