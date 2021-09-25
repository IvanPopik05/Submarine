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
    [SerializeField] GameObject[] Boats;
    [HideInInspector]public Vector2 Dir = Vector2.right;
    [HideInInspector] public List<Image> BoatChildren = new List<Image>();
    private void Awake()
    {
        for (int i = 0; i < Boats.Length; i++)
        {
            foreach (var boat in getBoats(Boats[i]))
            {
                BoatChildren.Add(boat);
            }
        }
    }
    private Image[] getBoats(GameObject parentBoats) 
    {
        return parentBoats.GetComponentsInChildren<Image>();
    }
    private void SelectBoat() 
    {
        switch (TypeBoat)
        {
            case TypeBoat.MovementBoat:
                GetBoatColor(greenBoat);
                WherePanelsActive(true);
                break;
            case TypeBoat.TurnedBoat:
                GetBoatColor(yellowBoat);
                WherePanelsActive(false);
                break;
            default:
                break;
        }
    }
    private void GetBoatColor(Color color) 
    {
        foreach (var boat in BoatChildren)
        {
            boat.color = color;
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
        if (BoatChildren[0].transform.rotation.z > 360)
        {
            TurnBackBoat();
        }
        RotateBoat();
        SelectBoat();
    }

    private void RotateBoat() 
    {
        foreach (var boat in BoatChildren)
        {
            boat.transform.Rotate(0,0,90);
        }
    }
    private void TurnBackBoat() 
    {
        foreach (var boat in BoatChildren)
        {
            boat.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
