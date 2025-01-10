namespace Assets.Scripts.Initialization
{
    internal interface IInitializeStepModifier
    {
        void AddSceneContextStep(IInitializeAsync step);
    }
}
