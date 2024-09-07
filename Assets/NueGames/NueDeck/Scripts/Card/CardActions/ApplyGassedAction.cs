using NueGames.NueDeck.Scripts.Enums;
using UnityEngine;

namespace NueGames.NueDeck.Scripts.Card.CardActions
{
    /// <summary>
    /// Action that applies the Gassed Status effect
    /// </summary>
    public class ApplyGassedAction : CardActionBase
    {
        public override CardActionType ActionType => CardActionType.ApplyGassed;

        public override void DoAction(CardActionParameters actionParameters)
        {
            if (!actionParameters.TargetCharacter) return;

            //Add Amplification of Poisonous Gas to the base gassed value of the card
            int amplifiedValue = Mathf.RoundToInt(actionParameters.Value) + actionParameters.SelfCharacter.CharacterStats.StatusDict[StatusType.AmplificationOfPoisonousGas].StatusValue;

            actionParameters.TargetCharacter.CharacterStats.ApplyStatus(StatusType.Gassed, amplifiedValue);

            if (FxManager != null)
                FxManager.PlayFx(actionParameters.TargetCharacter.transform, FxType.Poison);

            if (AudioManager != null)
                AudioManager.PlayOneShot(actionParameters.CardData.AudioType);
        }


    }

}