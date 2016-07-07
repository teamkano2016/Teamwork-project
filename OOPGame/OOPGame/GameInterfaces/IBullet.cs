using OOPGame.GameObject;

namespace OOPGame
{
    public interface IBullet : IGameObject
    {
        void Move(int leftRight);
    }
}
