using UnityEngine;

namespace Game.Script
{
    public class CharacterSpawner : MonoSingleton<CharacterSpawner>
    {
        public GameObject CreateCharacter(CharacterItem characterItem, Transform spawnPoint)
        {
            var character = Instantiate(characterItem.prefab, spawnPoint);
            character.transform.position = spawnPoint.position;
            character.transform.localEulerAngles = spawnPoint.localEulerAngles;
            return character;
        }
    }
}