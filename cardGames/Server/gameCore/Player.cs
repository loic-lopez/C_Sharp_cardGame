using System.Collections.Generic;
using System.Linq;
using Server.gameCore.Cards;

namespace Server.gameCore
{
    public class Player
    {
        private List<Card> _cards;
        bool _histurn;
        private bool _inBattle;

        public Player()
        {
            _cards = new List<Card>();
            _histurn = false;
            _inBattle = false;
        }

        public void addCard(Card card)
        {
            _cards.Add(card);
        }

        public void SetInBattle(bool inBattle = true)
        {
            _inBattle = inBattle;
        }

        public bool IsInBattle()
        {
            return _inBattle;
        }

        public bool isHisTurn()
        {
            return _histurn;
        }

        public void SetHisTurn(bool hisTurn = true)
        {
            _histurn = hisTurn;
        }

        public List<Card> GetCards()
        {
            return _cards;
        }

        public Card PlayACard()
        {
            Card cardFound = _cards.First();
            _cards.Remove(cardFound);
            return cardFound;
        }
    }
}