namespace OOPGame.Items
{
	using GameAbstracts;
	using OOPGame.GameStructure;

	public class Potion : Item
	{
		public Potion() : base()
		{
			this.Figure = Constants.Potion;
		}
	}
}