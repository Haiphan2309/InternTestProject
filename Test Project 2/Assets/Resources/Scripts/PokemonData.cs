using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Pokemon Data", menuName = "Pokemon Data")]
public class PokemonData : ScriptableObject
{
    public string pokemonName;
    public int hp, atk, def, spatk, spdef, spe;
    public Enums.PokemonType type;
}
