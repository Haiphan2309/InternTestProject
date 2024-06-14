using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PokemonDesignWindow : EditorWindow
{
    Texture2D headerTexture;
    //Color headerTextureColor = new Color(0.3f, 0.3f, 0.3f, 1);
    Rect headerRect;

    Rect pokemonRect;
    Rect typeIconRect;

    static PokemonData pokemonData;

    public static PokemonData PokemonData { get { return pokemonData; } }

    [MenuItem("Window/Pokemon Designer")]
    static void OpenWindow()
    {
        PokemonDesignWindow window = (PokemonDesignWindow)GetWindow(typeof(PokemonDesignWindow));
        window.minSize = new Vector2(600, 300);
        window.Show();
    }

    private void OnEnable()
    {
        InitTextures();
        InitData();
    }
    public static void InitData()
    {
        pokemonData = (PokemonData)ScriptableObject.CreateInstance(typeof(PokemonData));
    }    
    void InitTextures()
    {
        //headerTexture = new Texture2D(1, 1);
        //headerTexture.SetPixel(0, 0, headerTextureColor);
        headerTexture = Resources.Load<Texture2D>("Textures/HeaderTexture");
        //headerTexture.Apply();

        
    }

    private void OnGUI()
    {
        DrawLayout();
        DrawHeader();
        DrawPokemonInfo();
        DrawTypeIcon();
    }

    void DrawLayout()
    {
        headerRect.x = 0;
        headerRect.y = 0;
        headerRect.width = Screen.width;
        headerRect.height = 50;

        pokemonRect.x = 0;
        pokemonRect.y = headerRect.height;
        pokemonRect.width = Screen.width/2;
        pokemonRect.height = Screen.height - headerRect.height;

        typeIconRect.width = 100;
        typeIconRect.height = 100;
        typeIconRect.x = Screen.width/2 + (Screen.width/4 - typeIconRect.width/2);
        typeIconRect.y = headerRect.height + ((Screen.height-headerRect.height)/2 - typeIconRect.height/2);

        GUI.DrawTexture(headerRect, headerTexture);
        GUI.DrawTexture(pokemonRect, new Texture2D(1, 1));  
    }

    void DrawTypeIcon()
    {
        switch (pokemonData.type)
        {
            case Enums.PokemonType.FIRE:
                GUI.DrawTexture(typeIconRect, Resources.Load<Texture2D>("Textures/FireType"));
                break;

            case Enums.PokemonType.WATER:
                GUI.DrawTexture(typeIconRect, Resources.Load<Texture2D>("Textures/WaterType"));
                break;

            case Enums.PokemonType.GRASS:
                GUI.DrawTexture(typeIconRect, Resources.Load<Texture2D>("Textures/GrassType"));
                break;
        }
    }

    void DrawHeader()
    {
        GUILayout.BeginArea(headerRect);
        GUILayout.FlexibleSpace();
        GUILayout.Label("POKEMON INFO");
        GUILayout.FlexibleSpace();
        GUILayout.EndArea();
    }

    void DrawPokemonInfo()
    {
        GUILayout.BeginArea(pokemonRect);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Type");
        pokemonData.type = (Enums.PokemonType)EditorGUILayout.EnumPopup(pokemonData.type);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Name");
        pokemonData.pokemonName = EditorGUILayout.TextArea(pokemonData.pokemonName);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Hp");
        pokemonData.hp = EditorGUILayout.IntSlider(pokemonData.hp, 0, 100);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Atk");
        pokemonData.atk = EditorGUILayout.IntSlider(pokemonData.atk, 0, 100);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Def");
        pokemonData.def = EditorGUILayout.IntSlider(pokemonData.def, 0, 100);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Sp.Atk");
        pokemonData.spatk = EditorGUILayout.IntSlider(pokemonData.spatk, 0, 100);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Sp.Def");
        pokemonData.spdef = EditorGUILayout.IntSlider(pokemonData.spdef, 0, 100);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Speed");
        pokemonData.spe = EditorGUILayout.IntSlider(pokemonData.spe, 0, 100);
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Generate", GUILayout.Height(30), GUILayout.Width(80)))
        {
            PokemonManager.Instance.GeneratePokemon(pokemonData.type);
        }
        GUILayout.EndArea();
        
    }
}
