using Game.Script.Data;
using UnityEngine;

namespace Game.Script.CharacterBase
{
    public class CharacterSpawner : MonoSingleton<CharacterSpawner>
    {
        public GameObject CreateCharacter(CharacterItem characterItem, Transform spawnPoint)
        {
            var character = Instantiate(characterItem.prefab, spawnPoint);
            character.transform.position = spawnPoint.position;
            character.transform.localEulerAngles = spawnPoint.localEulerAngles;
            character.name = characterItem.name + Time.realtimeSinceStartup;
            return character;
        }
    }
}