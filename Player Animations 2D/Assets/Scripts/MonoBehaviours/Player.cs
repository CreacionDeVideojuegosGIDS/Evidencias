using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
	public HealthBar healthBarPrefab;
	private HealthBar healthBar;

	void Start()
	{
		healthBar = Instantiate(healthBarPrefab);
		healthBar.character = this; 
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("CanBePickedUp"))
		{
			Item hitObject = collision.gameObject.GetComponent<Consumable>().item;
			if (hitObject != null)
			{
				print("Nombre:" + hitObject.objectName);

				switch (hitObject.itemType)
				{
					case Item.ItemType.COIN:
						break;
					case Item.ItemType.HEALTH:
						AdjustHitPoints(hitObject.quantity);
						break;
					default:
						break;
				}

				collision.gameObject.SetActive(false);
			}
		}
	}

	public bool AdjustHitPoints(int amount)
	{
		 if (hitPoints.value < maxHitPoints) // no se puede exceder el máximo de puntos 
		{ 
			hitPoints.value = hitPoints.value + amount; 
			print("Ajustando Puntos: " + amount + ". Nuevo Valor: " + hitPoints.value); 
			return true;
		} 
		return false;
	}
}
