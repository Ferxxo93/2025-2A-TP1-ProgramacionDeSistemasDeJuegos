using System;
using UnityEngine;

namespace Excercise1
{
    public class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] protected string id;

        protected virtual void OnEnable()
        {
            CharacterService service =FindAnyObjectByType<CharacterService>();
            if (service != null)
            {
                service.TryAddCharacter(id, this);
            }
            //TODO: Add to CharacterService. The id should be the given serialized field. 
        }

        protected virtual void OnDisable()
        {
            CharacterService service = FindAnyObjectByType<CharacterService>();
            if (service != null)
            {
                service.TryRemoveCharacter(id);
            }
            //TODO: Remove from CharacterService.
        }
    }
}