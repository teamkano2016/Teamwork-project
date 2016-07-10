namespace OOPGame.Exceptions
{
    using System;

    public class HeroLivesOutOfRangeException: Exception
    {
        public HeroLivesOutOfRangeException() : base()
        {
        }
        public HeroLivesOutOfRangeException(string message) : base(message)
        {
        }

        public HeroLivesOutOfRangeException(string message, Exception innerexception):base(message, innerexception)
        {
        }
    }
}
