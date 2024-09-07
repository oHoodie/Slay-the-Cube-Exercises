using NueGames.NueDeck.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NueGames.NueDeck.Scripts.Card.CardActions
{
    public class ApplyGassedAction : CardActionBase
    {
        public override CardActionType ActionType => CardActionType.ApplyGassed;

        public override void DoAction(CardActionParameters actionParameters)
        {
            if (!actionParameters.TargetCharacter) return;

            actionParameters.TargetCharacter.CharacterStats.ApplyStatus(StatusType.Gassed, Mathf.RoundToInt(actionParameters.Value));

            if (FxManager != null)
                FxManager.PlayFx(actionParameters.TargetCharacter.transform, FxType.Stun);

            if (AudioManager != null)
                AudioManager.PlayOneShot(actionParameters.CardData.AudioType);
        }


    }

}