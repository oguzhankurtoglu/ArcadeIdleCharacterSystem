namespace Game.Script.CharacterBase
{
    public interface ICharacter
    {
        public CharacterAnimator Animator { get; set; }
        public void Logic();


    }
}