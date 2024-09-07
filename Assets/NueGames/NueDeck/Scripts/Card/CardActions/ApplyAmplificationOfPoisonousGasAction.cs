using NueGames.NueDeck.Scripts.Enums;
using UnityEngine;

namespace NueGames.NueDeck.Scripts.Card.CardActions
{
    /// <summary>
    /// Action that applies the "Amplification of Poisonous Gas" Power / Status effect
    /// </summary>
    public class ApplyAmplificationOfPoisonousGasAction : CardActionBase
    {
        public override CardActionType ActionType => CardActionType.ApplyAmplificationOfPoisonousGas;

        public override void DoAction(CardActionParameters actionParameters)
        {
            // Get self as target if card wasn't played on a specific ally
            var target = actionParameters.TargetCharacter
                ? actionParameters.TargetCharacter
                : actionParameters.SelfCharacter;

            if (!target) return;

            target.CharacterStats.ApplyStatus(StatusType.AmplificationOfPoisonousGas, Mathf.RoundToInt(actionParameters.Value));

            if (FxManager != null)
                FxManager.PlayFx(target.transform, FxType.Poison);

            if (AudioManager != null)
                AudioManager.PlayOneShot(actionParameters.CardData.AudioType);
        }


    }

}