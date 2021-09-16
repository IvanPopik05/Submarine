using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MainSubmarineScript : MonoBehaviour
{
    public TypeBoat TypeBoat { get; set; } = TypeBoat.MovementBoat;
    [SerializeField] private Image[] wherePanels;
    [Header("Colors")]
    [SerializeField] private Color yellowBoat, greenBoat;
    public Image Boat;
    [SerializeField] private float speed;
    [HideInInspector]public Vector2 Dir = Vector2.right;
    private void SelectBoat() 
    {
        switch (TypeBoat)
        {
            case TypeBoat.MovementBoat:
                Boat.color = greenBoat;
                WherePanelsActive(true);
                break;
            case TypeBoat.TurnedBoat:
                Boat.color = yellowBoat;
                WherePanelsActive(false);
                break;
            default:
                break;
        }
    }
    private void WherePanelsActive(bool active) 
    {
        if (active)
        {
            wherePanels[0].color = greenBoat;
            wherePanels[1].color = Color.white;
        }
        else 
        {
            wherePanels[0].color = Color.white;
            wherePanels[1].color = yellowBoat;
        }
    }

    private TypeBoat RandomizeType() 
    {
        int randNumber = Random.Range(0,(int)TypeBoat.TurnedBoat + 1);
        return randNumber == 0 ? TypeBoat.MovementBoat : TypeBoat.TurnedBoat;
    }
    private Vector2 RandomDirection() 
    {
        Vector2[] directions = { Vector2.up, Vector2.right, Vector2.down, Vector2.left };
        int randDir = Random.Range(0,directions.Length);
        return directions[randDir];
    }
    public void NewBoat() 
    {
        TypeBoat = RandomizeType();
        Dir = RandomDirection();
        if (Boat.transform.rotation.z > 360)
        {
            Boat.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        Boat.transform.Rotate(0, 0, 90);
        SelectBoat();
    }
}
