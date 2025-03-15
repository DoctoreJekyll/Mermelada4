using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Dialogue
{
    public class RandomTikTokText : MonoBehaviour
    {
  
        private readonly List<string> names = new List<string>
        {
            "Serengamer",
            "XxShadowWolfxX",
            "LunaPixel",
            "NeonDragon",
            "EpicGamer99",
            "DarkSorcerer",
            "FireFox_27",
            "CyberNinja",
            "GalaxyQueen",
            "MysticWarrior"
        };

        private readonly List<string> descriptions = new List<string>
        {
            "Parte 4 | Gameplay nuevo juego filtrado  #anime #juegos #filtraciones",
            "¿Sabías esto?  #datoscuriosos #sorprendente #viral",
            "Así se ve el nuevo parche en acción  #gaming #update #novedades",
            "No esperaba este final...  #terror #historias #wtf",
            "El combo definitivo ⚡️ #combos #fyp #gaming",
            "¿Quién más recuerda este clásico?  #retro #nostalgia #oldschool",
            "Parte 2 | ¿Qué harías en esta situación?  #decisiones #historia",
            "El bug más roto que he visto 😵‍ #gaming #glitch #diversión",
            "Este truco cambió mi juego  #lifehack #protips #gameplay",
            "Este momento me dejó sin palabras...  #sorpresa #gamingclips #wow"
        };

        [SerializeField] private TMP_Text nameTxt;
        [SerializeField] private TMP_Text descriptionTxt;

        private void Start()
        {
            int randomNumber = Random.Range(0, names.Count);
            
            nameTxt.text = names[randomNumber];
            descriptionTxt.text = descriptions[randomNumber];
        }
    }
}
