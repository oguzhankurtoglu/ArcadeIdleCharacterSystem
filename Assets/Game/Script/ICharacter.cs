namespace Game.Script
{
    public interface ICharacter
    {
        public CharacterAnimator Animator { get; set; }
        public void Logic();


    }
}