using NueGames.NueDeck.Scripts.Collection;
using NueGames.NueDeck.Scripts.Data.Collection;
using NueGames.NueDeck.Scripts.Enums;
using NueGames.NueDeck.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NueGames.NueDeck.Scripts.Card.CardActions
{
    /// <summary>
    /// Action that creates x "Toxic gas container" cards in the player's hand
    /// </summary>
    public class CreateToxicGasContainerAction : CardActionBase
    {
        public override CardActionType ActionType => CardActionType.CreateToxicGasContainer;

        public override void DoAction(CardActionParameters actionParameters)
        {
            // Get cardData for Toxic Gas Container
            CardData cardData = GameManager.Instance.GameplayData.AllCardsList.Find(c => c.Id == "11_skill_toxicGasContainer");
            if(cardData == null)
            {
                Debug.LogError("Card does not exist: 11_skill_toxicGasContainer");
                return;
            }

            // Add the card to hand x times
            HandController handController = CollectionManager.Instance.HandController;
            for (int i = 0; i < actionParameters.Value; i++)
            {
                // Add the cards to the deck permanently (probably makes no sense gameplay-wise, but exercise does not say otherwise)
                GameManager.Instance.PersistentGameplayData.CurrentCardsList.Add(cardData);
                CollectionManager.Instance.HandPile.Add(cardData);

                // Instantiate the card MonoBehaviour and it it to the HandController
                var clone = GameManager.BuildAndGetCard(cardData, handController.drawTransform);
                handController.AddCardToHand(clone);
            }

            if (AudioManager != null)
                AudioManager.PlayOneShot(actionParameters.CardData.AudioType);
        }

    }
}