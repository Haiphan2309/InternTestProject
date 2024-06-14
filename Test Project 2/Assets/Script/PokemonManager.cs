using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonManager : MonoBehaviour
{
    public static PokemonManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void GeneratePokemon(Enums.PokemonType pokemonType)
    {
        Debug.Log("Generate pokemon type: " + pokemonType.ToString());
    }
}
