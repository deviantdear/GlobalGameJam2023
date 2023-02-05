using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPickUp : Interactable
{
    [SerializeField] SpriteRenderer m_sprite;
    [SerializeField] Sprite m_Eaten;

    [SerializeField] GameObject gameController;
    [SerializeField] GameObject playerCharacter;

    [SerializeField] float despawnDistance;
    [SerializeField] float distanceFromPlayer;

    public override bool Interact()
    {
        Debug.Log("Interacting");
        if (hasInteracted)
            return false;
        
        PickUp();
        return true;
    }

    void PickUp()
    {
        Debug.Log("Food Picked Up");
        m_sprite.sprite = m_Eaten;
        hasInteracted = true;

        gameController.GetComponent<GameStateManager>().IncreaseByRootValue();
        gameController.GetComponent<SpawnGrass>().DecrementCount();
        Destroy(this.gameObject);
    }

    void Start()
    {
        playerCharacter = GameObject.FindWithTag("Player");
        gameController = GameObject.FindWithTag("GameController");
    }

    void Update()
    {
        // if the object is too far away from the player, spawn a new one and destroy this one
        distanceFromPlayer = Vector3.Distance(playerCharacter.transform.position, this.transform.position);

        if (distanceFromPlayer > despawnDistance)
        {
            gameController.GetComponent<SpawnGrass>().SpawnRootsCheck();
            gameController.GetComponent<SpawnGrass>().DecrementCount();
            Destroy(this.gameObject);
        }
    }


}
