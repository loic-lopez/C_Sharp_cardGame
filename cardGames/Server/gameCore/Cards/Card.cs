using System;
using Server.gameCore.Library;

namespace Server.gameCore.Cards
{
    public class Card
    {
        private object _instance;
        private string _cardName;
        private Color _color;


        public Card(string cardName, Color color)
        {
            _cardName = cardName;
            _color = color;
            instanciate();
        }

        public static Type[] getCardsName()
        {
            return Utils.GetTypesInNamespace("Server.gameCore.Cards.CardsPack");
        }

        private void instanciate()
        {
            _instance = Utils.MagicallyCreateInstance(_cardName);
        }


        public int GetCardValue()
        {
            var type = _instance.GetType();
            var methodInfo = type.GetMethod("GetValue");
            return (int) methodInfo.Invoke(_instance, null);
        }

        public string GetCardName() => _cardName;

        public Color GetColor() => _color;
    }
}