using System.Threading.Tasks;

namespace Assets.Scripts.Initialization
{
    internal interface IInitializeAsync
    {
        Task<InitializeResult> Initialize();
    }
}
