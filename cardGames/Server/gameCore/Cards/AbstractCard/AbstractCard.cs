namespace Server.gameCore.Cards.AbstractCard
{
    public abstract class AbstractCard
    {
        protected int _value = 0;

        public int GetValue()
        {
            return _value;
        }
    }
}