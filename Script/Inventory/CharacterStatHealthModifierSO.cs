using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterStatHealthModifierSO : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        Player health = character.GetComponent<Player>();

        if (health != null)
        {
            health.AddHealth((float)val);
        }
    }
}
