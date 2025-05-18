using System.Collections.Generic;
using UnityEngine;

namespace Excercise1
{
    public class CharacterService : MonoBehaviour//SOLID principle: Single Responsibility
    {
        public static CharacterService Instance { get; private set; }

        private readonly Dictionary<string, ICharacter> _charactersById = new();
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject); //Singleton pattern and we dont find reference manually
                return;
            }
            Instance = this;
        }

        public bool TryAddCharacter(string id, ICharacter character)
            => _charactersById.TryAdd(id, character);
        public bool TryRemoveCharacter(string id)
            => _charactersById.Remove(id);
        public ICharacter GetCharacter(string id)
            => _charactersById.TryGetValue(id, out var character) ? character : null;
    }
}
