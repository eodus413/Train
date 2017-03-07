using System.Collections.Generic;

namespace ProjectTrain
{
    public class Systems
    {
        public Systems()
        {
            initSystem = new List<IInitializeSystem>();
            executeSystem = new List<IExecuteSystem>();
        }
        List<IInitializeSystem> initSystem;
        List<IExecuteSystem> executeSystem;

        public Systems Add(ISystem newSystem)
        {
            IInitializeSystem init = newSystem as IInitializeSystem;
            if (init != null)
            {
                initSystem.Add(init);
            }
            IExecuteSystem exec = newSystem as IExecuteSystem;
            if (exec != null)
            {
                executeSystem.Add(exec);
            }

            return this;
        }
        public void Initialize()
        {
            int initSystemSize = initSystem.Count;
            for (int i = 0; i < initSystemSize; ++i)
            {
                initSystem[i].Initialize();
            }
        }
        public void Execute()
        {
            int executeSystemSize = executeSystem.Count;

            for (int i = 0; i < executeSystemSize; ++i)
            {
                executeSystem[i].Execute();
            }
        }
    }
}