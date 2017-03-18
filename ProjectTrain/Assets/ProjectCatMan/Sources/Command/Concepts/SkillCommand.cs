namespace ProjectCatMan
{
    public class SkillCommand : ICommand
    {
        public SkillCommand(ISkill skill)
        {
            this.skill = skill;
        }

        ISkill skill;
        public void Execute()
        {
            skill.Execute();
        }
        public void Undo() { }
    }
}