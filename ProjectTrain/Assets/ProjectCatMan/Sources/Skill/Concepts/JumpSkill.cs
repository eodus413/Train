namespace ProjectCatMan
{
    public class JumpSkill : ISkill
    {
        public JumpSkill(SkillData data,UnitBase unit)
        {
            this.data = data;
        }

        public SkillData data { get; private set; }
        public UnitBase unit { get; private set; }
        public void Execute()
        {

        } 
    }
}