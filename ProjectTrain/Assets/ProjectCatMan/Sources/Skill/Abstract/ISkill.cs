namespace ProjectCatMan
{
    public interface ISkill
    {
        SkillData data { get; }
        void Execute();
    }
}