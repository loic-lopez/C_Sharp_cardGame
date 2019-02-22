using System;
using System.Collections.Generic;
using System.Linq;
using Google.Protobuf.Protocol;
using Server.gameCore.Cards;
using Server.gameCore.Library;
using Card = Server.gameCore.Cards.Card;

namespace Server.gameCore
{
    public class Board
    {
        public const int MaxPlayers = 2;
        private Dictionary<string, Player> _players;
        private List<Card> _playedCards;
        private List<string> _playerNames;
        private string _designedPlayer;
        private List<string> _waitingPlayerList;
        private bool _inBattle;

        public Board()
        {
            _playedCards = new List<Card>();
            _players = new Dictionary<string, Player>();
            _playerNames = new List<string>();
            _designedPlayer = null;
            _waitingPlayerList = new List<string>();
            _inBattle = false;
        }

        public bool NewPlayer(string userName)
        {
            if (_waitingPlayerList.Any(waitingPlayer =>
                String.Compare(waitingPlayer, userName, StringComparison.Ordinal) == 0))
                return false;

            _waitingPlayerList.Add(userName);
            _playerNames.Add(userName);
            return true;
        }

        public void RemovePlayer(string userName)
        {
            _waitingPlayerList.Remove(userName);
            _playerNames.Remove(userName);
            _players.Remove(userName);
        }

        public int GetNbrOfPlayers()
        {
            return _playerNames.Count;
        }

        public void CreateGameInstance()
        {
            Type[] cardsNameList = Card.getCardsName();
            List<Color> colorsList = Utils.ShuffleList(Utils.GetColorsNames());
            List<Card> cards = (from color in colorsList from card in cardsNameList select new Card(card.Name, color))
                .ToList();

            var firstPlayer = true;

            foreach (var playerName in _playerNames)
            {
                _players.Add(playerName, new Player());
                cards = Utils.ShuffleList(cards);
            }

            _waitingPlayerList.Clear();
            _players.First().Value.SetHisTurn();

            foreach (var card in cards)
            {
                if (firstPlayer)
                {
                    _players.ElementAt(0).Value.addCard(card);
                    firstPlayer = false;
                }
                else
                {
                    _players.ElementAt(1).Value.addCard(card);
                    firstPlayer = true;
                }
            }
        }

        public List<string> GetLastPlayedCard()
        {
            Card lastCard = _playedCards.Last();
            List<string> card = new List<string> {lastCard.GetCardName(), lastCard.GetColor().ToString()};
            return card;
        }

        public bool CanPlay(string playerName)
        {
            return _players[playerName].isHisTurn();
        }

        public Response PlayCard(string username)
        {
            Response response;

            response = new Response
            {
                Type = Response.Types.Type.GameAction
            };

            if (_playedCards.Count == 0)
            {
                return PlayACardAndDoNothing(response, username);
            }
            if (_inBattle && _playedCards.Count >= 2)
            {
                response = PlayACardAndDoNothing(response, username);
                _players[username].SetInBattle(false);
                if (!_players.First().Value.IsInBattle() && !_players.Last().Value.IsInBattle())
                {
                    _inBattle = false;
                }
                return response;
            }
            else
            {
                Card playedCard = _players[username].PlayACard();
                if (_playedCards.Last().GetCardValue() == playedCard.GetCardValue())
                {
                    _playedCards.Add(playedCard);
                    _inBattle = true;
                    foreach (var player in _players)
                        player.Value.SetHisTurn();
                    response.ResponseMsg = "You are in battle: " + playedCard.GetCardName() + "!";
                }
                else if (_playedCards.Last().GetCardValue() > playedCard.GetCardValue())
                {
                    int playerIndex = _players.Keys.ToList().IndexOf(username);
                    string winnerName = "";
                    switch (playerIndex)
                    {
                        case 0:
                            winnerName = _players.Keys.ToList().ElementAt(1);
                            break;
                        case 1:
                            winnerName = _players.Keys.ToList().ElementAt(0);
                            break;
                    }
                    response.ResponseMsg = winnerName + " won the turn: " + _playedCards.Last().GetCardName() + "!";
                    _playedCards.Add(playedCard);
                    foreach (var PlayedCard in _playedCards)
                        _players[winnerName].addCard(PlayedCard);
                    _playedCards.Clear();
                }
                else if (_playedCards.Last().GetCardValue() < playedCard.GetCardValue())
                {
                    _playedCards.Add(playedCard);
                    string winnerName = username;
                    foreach (var PlayedCard in _playedCards)
                        _players[winnerName].addCard(PlayedCard);
                    response.ResponseMsg = winnerName + " won the turn: " + playedCard.GetCardName() + "!";
                    _playedCards.Clear();
                }
            }
            return response;
        }

        public Response PassTurn(string username)
        {
            Response response = new Response();

            _players[username].SetHisTurn(false);
            int nextPlayerIndex = _players.Keys.ToList().IndexOf(username);
            if (nextPlayerIndex == 1)
                nextPlayerIndex = 0;
            else
                nextPlayerIndex = 1;

            _players.ElementAt(nextPlayerIndex).Value.SetHisTurn();
            response.ResponseMsg = "The game continue, we're waiting " + _players.ElementAt(nextPlayerIndex).Key + " !";
            response.Type = Response.Types.Type.GameAction;
            return response;
        }

        private static Response FirstPlayCheck(string color, string cardName)
        {
            List<Color> colors = Utils.GetColorsNames();
            bool found = colors.Any(colorname => colorname.ToString() == color.ToUpper());

            if (!found)
            {
                return new Response
                {
                    ResponseMsg = "Color: " + color + " doesn't exist.",
                    Type = Response.Types.Type.Failed
                };
            }

            Type[] cardsNameList = Card.getCardsName();
            found = cardsNameList.Any(card =>
                String.Equals(card.Name, cardName, StringComparison.CurrentCultureIgnoreCase));

            if (!found)
            {
                return new Response
                {
                    ResponseMsg = "Card: " + cardName + " doesn't exist.",
                    Type = Response.Types.Type.Failed
                };
            }
            return new Response
            {
                Type = Response.Types.Type.Success
            };
        }

        private Response PlayACardAndDoNothing(Response response, string username)
        {
            Card playedCard = _players[username].PlayACard();
            _playedCards.Add(playedCard);
            response.Type = Response.Types.Type.GameAction;
            response.ResponseMsg = username + " played " + playedCard.GetColor() + " " + playedCard.GetCardName() + ".";
            return response;
        }
    }
}